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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VAS.Core;
using VAS.Core.Common;
using VAS.Core.Events;
using VAS.Core.Filters;
using VAS.Core.Hotkeys;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.MVVMC;
using VAS.Core.Store;
using VAS.Core.Store.Playlists;
using VAS.Core.ViewModel;

namespace VAS.Services.Controller
{
	public class PlaylistController : DisposableBase, IController
	{
		PlaylistCollectionVM viewModel;
		ProjectVM projectViewModel;

		public PlaylistController (VideoPlayerVM playerVM)
		{
			PlayerVM = playerVM;
		}

		public VideoPlayerVM PlayerVM {
			get;
			set;
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			Stop ();
		}

		protected EventsFilter Filter { get; set; }

		protected Project OpenedProject {
			get {
				return projectViewModel?.Model;
			}
			set {
				if (projectViewModel == null) {
					projectViewModel = new ProjectVM<Project> ();
				}
				projectViewModel.Model = value;
			}
		}

		protected ProjectType OpenedProjectType {
			get;
			set;
		}

		#region IController implementation

		public void Start ()
		{
			App.Current.EventsBroker.SubscribeAsync<AddPlaylistElementEvent> (HandleAddPlaylistElement);
			App.Current.EventsBroker.SubscribeAsync<CreateEvent<Playlist>> (HandleNewPlaylist);
			App.Current.EventsBroker.SubscribeAsync<DeletePlaylistEvent> (HandleDeletePlaylist);
			App.Current.EventsBroker.Subscribe<RenderPlaylistEvent> (HandleRenderPlaylist);
			App.Current.EventsBroker.Subscribe<LoadPlaylistElementEvent> (HandleLoadPlaylistElement);
			App.Current.EventsBroker.Subscribe<OpenedProjectEvent> (HandleOpenedProjectChanged);
			App.Current.EventsBroker.Subscribe<LoadEventEvent> (HandleLoadPlayEvent);
			App.Current.EventsBroker.Subscribe<TimeNodeChangedEvent> (HandlePlayChanged);
			App.Current.EventsBroker.Subscribe<MoveElementsEvent<PlaylistVM, PlaylistElementVM>> (HandleMoveElements);
		}

		public void Stop ()
		{
			App.Current.EventsBroker.UnsubscribeAsync<AddPlaylistElementEvent> (HandleAddPlaylistElement);
			App.Current.EventsBroker.UnsubscribeAsync<CreateEvent<Playlist>> (HandleNewPlaylist);
			App.Current.EventsBroker.UnsubscribeAsync<DeletePlaylistEvent> (HandleDeletePlaylist);
			App.Current.EventsBroker.Unsubscribe<RenderPlaylistEvent> (HandleRenderPlaylist);
			App.Current.EventsBroker.Unsubscribe<LoadPlaylistElementEvent> (HandleLoadPlaylistElement);
			App.Current.EventsBroker.Unsubscribe<OpenedProjectEvent> (HandleOpenedProjectChanged);
			App.Current.EventsBroker.Unsubscribe<LoadEventEvent> (HandleLoadPlayEvent);
			App.Current.EventsBroker.Unsubscribe<TimeNodeChangedEvent> (HandlePlayChanged);
			App.Current.EventsBroker.Unsubscribe<MoveElementsEvent<PlaylistVM, PlaylistElementVM>> (HandleMoveElements);
		}

		public void SetViewModel (IViewModel viewModel)
		{
			if (viewModel == null) {
				return;
			}
			this.viewModel = (PlaylistCollectionVM)(viewModel as dynamic);
			// projectViewModel can be set to null...
			this.projectViewModel = (ProjectVM)(viewModel as dynamic);
		}

		public IEnumerable<KeyAction> GetDefaultKeyActions ()
		{
			return Enumerable.Empty<KeyAction> ();
		}

		#endregion

		protected void LoadPlay (TimelineEvent play, Time seekTime, bool playing)
		{
			if (play != null && PlayerVM != null && PlayerVM.Player != null) {
				play.Playing = true;
				PlayerVM.Player.LoadEvent (
					play, seekTime, playing);
				if (playing) {
					PlayerVM.Player.Play ();
				}
			}
		}

		protected virtual async Task<Playlist> CreateNewPlaylist ()
		{
			string name = Catalog.GetString ("New playlist");
			Playlist playlist = null;
			bool done = false;
			while (name != null && !done) {
				name = await App.Current.Dialogs.QueryMessage (Catalog.GetString ("Playlist name:"), null, name);
				if (name != null) {
					done = true;
					if (viewModel.ViewModels.Any (p => p.Name == name)) {
						string msg = Catalog.GetString ("A playlist already exists with the same name");
						App.Current.Dialogs.ErrorMessage (msg);
						done = false;
					}
				}
			}
			if (name != null) {
				playlist = new Playlist { Name = name };
				viewModel.Model.Add (playlist);
				Save (playlist, true);
			}
			return playlist;
		}

		protected virtual async Task HandleAddPlaylistElement (AddPlaylistElementEvent e)
		{
			//FIXME: should use PlaylistVM
			if (e.Playlist == null) {
				e.Playlist = await CreateNewPlaylist ();
				if (e.Playlist == null) {
					return;
				}
			}
			foreach (var item in e.PlaylistElements) {
				e.Playlist.Elements.Add (item);
			}
			Save (e.Playlist, true);
		}

		protected virtual Task HandleDeletePlaylist (DeletePlaylistEvent e)
		{
			App.Current.DatabaseManager.ActiveDB.Delete (e.Playlist);
			viewModel.Model.Remove (e.Playlist);
			return AsyncHelpers.Return (true);
		}

		protected virtual void HandleLoadPlayEvent (LoadEventEvent e)
		{
			if (e.TimelineEvent?.Duration.MSeconds == 0) {
				// These events don't have duration, we start playing as if it was a seek
				PlayerVM.Player.Switch (null, null, null);
				PlayerVM.Player.UnloadCurrentEvent ();
				PlayerVM.Player.Seek (e.TimelineEvent.EventTime, true);
				PlayerVM.Player.Play ();
			} else {
				if (e.TimelineEvent != null) {
					LoadPlay (e.TimelineEvent, new Time (0), true);
				} else if (PlayerVM != null && PlayerVM.Player != null) {
					PlayerVM.Player.UnloadCurrentEvent ();
				}
			}
		}

		async Task HandleNewPlaylist (CreateEvent<Playlist> e)
		{
			e.Object = await CreateNewPlaylist ();
			e.ReturnValue = e.Object != null;
		}

		void Save (Playlist playlist, bool force = false)
		{
			if (playlist != null && projectViewModel == null) {
				App.Current.DatabaseManager.ActiveDB.Store (playlist, force);
			}
		}

		void HandleLoadPlaylistElement (LoadPlaylistElementEvent e)
		{
			if (e.Element != null) {
				e.Playlist.SetActive (e.Element);
			}
			if (e.Playlist.Elements.Count > 0 && PlayerVM != null) {
				PlayerVM.LoadPlaylistEvent (e.Playlist, e.Element, e.Playing);
			}
		}

		void HandleRenderPlaylist (RenderPlaylistEvent e)
		{
			List<EditionJob> jobs = App.Current.GUIToolkit.ConfigureRenderingJob (e.Playlist);
			if (jobs == null)
				return;
			foreach (Job job in jobs) {
				App.Current.JobsManager.Add (job);
			}
		}

		//FIXME: this should be in Player controller when decoupled from PalyerVM
		void HandlePlayChanged (TimeNodeChangedEvent e)
		{
			if (e.TimeNode is TimelineEvent) {
				LoadPlay (e.TimeNode as TimelineEvent, e.Time, false);
				if (Filter != null) {
					Filter.Update ();
				}
			}
		}

		void HandleOpenedProjectChanged (OpenedProjectEvent e)
		{
			OpenedProject = e.Project;
			OpenedProjectType = e.ProjectType;
			PlayerVM.Player.LoadedPlaylist = null;
		}

		void HandleMoveElements (MoveElementsEvent<PlaylistVM, PlaylistElementVM> e)
		{
			int indexCopy = e.Index;
			for (int i = 0; i < indexCopy; i++) {
				if (e.ElementsToAdd.Value.Contains (e.ElementsToAdd.Key.ViewModels [i])) {
					e.Index--;
				}
			}
			foreach (var playlist in e.ElementsToRemove) {
				playlist.Key.ViewModels.RemoveRange (playlist.Value);
				Save (playlist.Key.Model, true);
			}
			e.Index = e.Index.Clamp (0, e.ElementsToAdd.Key.ViewModels.Count);
			e.ElementsToAdd.Key.ViewModels.InsertRange (e.Index, e.ElementsToAdd.Value);
			Save (e.ElementsToAdd.Key.Model, true);
		}
	}
}

