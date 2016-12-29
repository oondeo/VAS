﻿//
//  Copyright (C) 2016 Fluendo S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using System.Diagnostics;
using System.Collections.Generic;
using VAS.Core.Common;
using VAS.Core.Events;
using VAS.Core.Interfaces;
using VAS.Core.Store.Playlists;

namespace VAS.Services
{
	/// <summary>
	/// This service collects the user usage statistics per session.
	/// </summary>
	public abstract class UserStatisticsService : IService
	{
		protected List<string> StatesToTrack;
		protected int TotalUserTeams;
		protected int TotalUserProjects;
		public int TeamsAmount;
		public int PlayListsAmount;
		public int RendersAmount;
		public int ManualTagsAmount;
		public int DrawingsAmount;
		public int CreatedProjects;
		public Dictionary<Guid, Tuple<int, int>> ProjectDictionary;
		public List<Tuple<string, int>> TimerList;
		int TotalUserPlaylists;
		string CurrentState;
		Stopwatch StateTimer;
		Stopwatch GeneralTimer;

		#region IService implementation

		public UserStatisticsService ()
		{
			ProjectDictionary = new Dictionary<Guid, Tuple<int, int>> ();
			StateTimer = new Stopwatch ();
			GeneralTimer = new Stopwatch ();
			TimerList = new List<Tuple<string, int>> ();
		}

		public int Level {
			get {
				return 21; //Always set a higher level than DatabaseManager
			}
		}

		public string Name {
			get {
				return "UserStatistics";
			}
		}

		public virtual bool Start ()
		{
			App.Current.EventsBroker.Subscribe<NewPlaylistEvent> (HandleNewPlaylistEvent);
			App.Current.EventsBroker.Subscribe<CreateEvent<Job>> (HandleCreateJob);
			App.Current.EventsBroker.Subscribe<NewDashboardEvent> (HandleDashboardEvent);
			App.Current.EventsBroker.Subscribe<DrawingSavedToProjectEvent> (HandleDrawingSavedToProject);
			App.Current.EventsBroker.Subscribe<CreateProjectEvent> (HandleNewProject);
			App.Current.EventsBroker.Subscribe<OpenedProjectEvent> (HandleOpenProject);
			App.Current.EventsBroker.Subscribe<NavigationEvent> (HandleNavigationEvent);
			GeneralTimer.Start ();

			return true;
		}

		public virtual bool Stop ()
		{
			SaveTimer ();
			App.Current.EventsBroker.Unsubscribe<NewPlaylistEvent> (HandleNewPlaylistEvent);
			App.Current.EventsBroker.Unsubscribe<CreateEvent<Job>> (HandleCreateJob);
			App.Current.EventsBroker.Unsubscribe<NewDashboardEvent> (HandleDashboardEvent);
			App.Current.EventsBroker.Unsubscribe<DrawingSavedToProjectEvent> (HandleDrawingSavedToProject);
			App.Current.EventsBroker.Unsubscribe<CreateProjectEvent> (HandleNewProject);
			App.Current.EventsBroker.Unsubscribe<OpenedProjectEvent> (HandleOpenProject);
			App.Current.EventsBroker.Unsubscribe<NavigationEvent> (HandleNavigationEvent);
			GeneralTimer.Stop ();
			RetrieveUserData ();
			SendData ();

			return true;
		}

		#endregion

		/// <summary>
		/// Retrieves the total user statistics data.
		/// </summary>
		public virtual void RetrieveUserData ()
		{
			TotalUserPlaylists = App.Current.DatabaseManager.ActiveDB.Count<Playlist> ();
		}

		/// <summary>
		/// Loads the current session project values.
		/// </summary>
		/// <param name="projectId">Project identifier.</param>
		void LoadSessionProjectValues (Guid projectId)
		{
			if (!ProjectDictionary.ContainsKey (projectId)) {
				ProjectDictionary.Add (projectId, new Tuple<int, int> (ManualTagsAmount, DrawingsAmount));
			} else {
				Tuple<int, int> tuple = ProjectDictionary [projectId];
				ManualTagsAmount = tuple.Item1;
				DrawingsAmount = tuple.Item2;
			}
		}

		/// <summary>
		/// Saves the current state time spent on.
		/// </summary>
		void SaveTimer ()
		{
			StateTimer.Stop ();
			TimerList.Add (new Tuple<string, int> (CurrentState, ((int)StateTimer.ElapsedMilliseconds) / 1000));
			StateTimer.Reset ();
		}

		/// <summary>
		/// Tracks the current session project data to HockeyApp.
		/// </summary>
		void TrackProjects ()
		{
			Dictionary<string, string> dict = new Dictionary<string, string> ();
			Dictionary<string, double> dict2 = new Dictionary<string, double> ();

			foreach (var item in ProjectDictionary) {
				dict.Add ("ProjectId", item.Key.ToString ());
				dict2.Add ("Tags", item.Value.Item1);
				dict2.Add ("Drawings", item.Value.Item2);
				App.Current.KPIService.TrackEvent ("Projects", dict, dict2);
				dict.Clear ();
				dict2.Clear ();
			}
		}

		/// <summary>
		/// Tracks the time spent on each state to HockeyApp.
		/// </summary>
		void TrackTimers ()
		{
			Dictionary<string, string> dict = new Dictionary<string, string> ();
			Dictionary<string, double> dict2 = new Dictionary<string, double> ();

			foreach (var item in TimerList) {
				dict.Add ("State", item.Item1);
				dict2.Add ("Time", item.Item2);
				App.Current.KPIService.TrackEvent ("Time spent", dict, dict2);
				dict.Clear ();
				dict2.Clear ();
			}
		}

		/// <summary>
		/// Tracks the service collected data to HockeyApp.
		/// </summary>
		public virtual void SendData ()
		{
			TrackProjects ();
			TrackTimers ();
			TrackEvent ("Teams amount", "Teams", TeamsAmount);
			TrackEvent ("Renders amount", "Renders", RendersAmount);
			TrackEvent ("Playlists amount", "Playlists", PlayListsAmount);
			TrackEvent ("Projects amount", "Projects", CreatedProjects);
			TrackEvent ("Total playlists", "Playlists", TotalUserPlaylists);
			TrackEvent ("Total time spent", "Time", ((int)GeneralTimer.ElapsedMilliseconds) / 1000);
		}

		/// <summary>
		/// Tracks an event to HockeyApp.
		/// </summary>
		/// <param name="eventName">Event name.</param>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public virtual void TrackEvent (string eventName, string key, double value)
		{
			Dictionary<string, double> dict = new Dictionary<string, double> {
				{key, value}
			};
			App.Current.KPIService.TrackEvent (eventName, null, dict);
		}

		/// <summary>
		/// Handles when navigation event has been thrown.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleNavigationEvent (NavigationEvent evt)
		{
			string NextEvent = evt.Name;

			if (!string.IsNullOrEmpty (CurrentState) && (NextEvent != CurrentState)) {
				SaveTimer ();
			}
			if (StatesToTrack.Contains (NextEvent)) {
				StateTimer.Start ();
				CurrentState = NextEvent;
			}
		}

		/// <summary>
		/// Handles when a new project has been created.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleNewProject (CreateProjectEvent evt)
		{
			CreatedProjects++;
			ManualTagsAmount = 0;
			DrawingsAmount = 0;
		}

		/// <summary>
		/// Handles when a project has been opened.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleOpenProject (OpenedProjectEvent evt)
		{
			LoadSessionProjectValues (evt.Project.ID);
		}

		/// <summary>
		/// Handles when a dashboard event has been throwed.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleDashboardEvent (NewDashboardEvent evt)
		{
			ManualTagsAmount++;
			ProjectDictionary [evt.ProjectId] = new Tuple<int, int> (ManualTagsAmount, DrawingsAmount);
		}

		/// <summary>
		/// Handles when a drawing has been saved to a project.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleDrawingSavedToProject (DrawingSavedToProjectEvent evt)
		{
			DrawingsAmount++;
			ProjectDictionary [evt.ProjectId] = new Tuple<int, int> (ManualTagsAmount, DrawingsAmount);
		}

		/// <summary>
		/// Handles when a playlist has been created.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleNewPlaylistEvent (NewPlaylistEvent evt)
		{
			PlayListsAmount++;
		}

		/// <summary>
		/// Handles when a job/render has been created.
		/// </summary>
		/// <param name="evt">Evt.</param>
		void HandleCreateJob (CreateEvent<Job> evt)
		{
			RendersAmount++;
		}
	}
}