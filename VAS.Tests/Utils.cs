﻿//
//  Copyright (C) 2014 Andoni Morales Alastruey
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Lite;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using VAS.Core;
using VAS.Core.Common;
using VAS.Core.Filters;
using VAS.Core.Handlers;
using VAS.Core.Hotkeys;
using VAS.Core.Interfaces;
using VAS.Core.Interfaces.GUI;
using VAS.Core.Interfaces.Multimedia;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.MVVMC;
using VAS.Core.Serialization;
using VAS.Core.Store;
using VAS.Core.Store.Templates;
using VAS.Core.ViewModel;
using VAS.DB;
using VAS.Drawing.CanvasObjects.Dashboard;
using VAS.Drawing.CanvasObjects.Timeline;
using VAS.Services;
using VAS.Services.Controller;
using VAS.Services.ViewModel;
using Timer = VAS.Core.Store.Timer;

namespace VAS.Tests
{
	public class DummyCouchbaseManager : CouchbaseManager
	{
		public DummyCouchbaseManager (string dbDir) : base (dbDir)
		{
		}

		protected override IStorage CreateStorage (string name)
		{
			return new DummyCouchbaseStorage (this, name);
		}
	}

	public class FailingCouchbaseManager : CouchbaseManager
	{
		public FailingCouchbaseManager (string dbDir) : base (dbDir)
		{
		}

		protected override IStorage CreateStorage (string name)
		{
			throw new CouchbaseLiteException ("Dummy exception");
		}
	}

	public class DummyCouchbaseStorage : CouchbaseStorage
	{
		public DummyCouchbaseStorage (Database db) : base (db)
		{
		}

		public DummyCouchbaseStorage (string dbDir, string storageName) : base (dbDir, storageName)
		{
		}

		public DummyCouchbaseStorage (CouchbaseManager manager, string storageName) : base (manager, storageName)
		{
		}

		protected override Version Version {
			get {
				return new Version (1, 1);
			}
		}
	}

	public class DummyPlaylistsManagerVM : IViewModel, IVideoPlayerDealer, IPlaylistCollectionDealer
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public VideoPlayerVM Player { get; set; }

		public PlaylistCollectionVM Playlists { get; set; }

		public VideoPlayerVM VideoPlayer {
			get {
				return Player;
			}
		}

		public void Dispose ()
		{
		}
	}

	public class DummyUserStatisticsService : UserStatisticsService
	{
		public override void RetrieveUserData ()
		{
		}

		public new Dictionary<string, string> GeneralProperties {
			get {
				return base.GeneralProperties;
			}
		}
	}

	public class DummyAnalysisVM : IAnalysisViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ProjectVM Project {
			get;
			set;
		}

		public VideoPlayerVM VideoPlayer {
			get;
			set;
		}

		public void Dispose ()
		{
		}
	}

	public class DummyView : IView
	{
		public void Dispose ()
		{
			Log.Verbose ($"Disposing {GetType ()}");
			throw new NotImplementedException ();
		}

		public void SetViewModel (object ViewModel)
		{
		}
	}

	public class DummyController : ControllerBase
	{
		public event EventHandler managedDisposeCalled;
		public event EventHandler unmanagedDisposeCalled;

		protected override void DisposeManagedResources ()
		{
			base.DisposeManagedResources ();
			if (managedDisposeCalled != null) {
				managedDisposeCalled (this, new EventArgs ());
			}
		}

		protected override void DisposeUnmanagedResources ()
		{
			base.DisposeUnmanagedResources ();
			if (unmanagedDisposeCalled != null) {
				unmanagedDisposeCalled (this, new EventArgs ());
			}
		}

		public override async Task Start ()
		{
			await base.Start ();
		}

		public override async Task Stop ()
		{
			await base.Stop ();
		}

		public override void SetViewModel (IViewModel viewModel)
		{
		}

		public override IEnumerable<KeyAction> GetDefaultKeyActions ()
		{
			return Enumerable.Empty<KeyAction> ();
		}
	}

	public class DummyViewModel<T> : IViewModel<T>
	{
		public T Model {
			get;
			set;
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		public void Dispose ()
		{
		}
	}

	public class DummyBindable : BindableBase
	{
		public void Raise (string name)
		{
			RaisePropertyChanged (name);
		}
	}


	public class DummyDashboardViewModel : TemplateViewModel<Dashboard>
	{
		public override Image Icon {
			get {
				return null;
			}
			set {
			}
		}
	}

	public class DummyProjectVM : ProjectVM<Project>
	{
		public IEnumerable<TeamVM> teams;

		public DummyProjectVM ()
		{
			teams = new List<TeamVM> ();
		}

		public DummyProjectVM (IEnumerable<TeamVM> teams)
		{
			this.teams = teams;
		}

		public override IEnumerable<TeamVM> Teams {
			get {
				return teams;
			}
		}

		public override void CommitState ()
		{
		}
	}

	public class DummyTeam : Team
	{
	}

	public class DummyPlayerVM : ViewModelBase<Utils.PlayerDummy>
	{
	}

	public class DummyTeamVM : TemplateViewModel<DummyTeam, Player, PlayerVM>
	{
		public override Image Icon {
			get;
			set;
		}
	}

	public class DummyTemplatesController : TemplatesController<Team, TeamVM, Player, PlayerVM>
	{
		Mock<ITemplateProvider<Team>> templatesProviderMock;

		public DummyTemplatesController ()
		{
			ViewModel = new TemplatesManagerViewModel<Team, TeamVM, Player, PlayerVM> ();
			templatesProviderMock = new Mock<ITemplateProvider<Team>> ();
			Provider = templatesProviderMock.Object;
		}

		protected override bool SaveValidations (Team model)
		{
			return true;
		}
	}

	public class DummyTimelineEventView : TimelineEventView, IView
	{
		public void SetViewModel (object viewModel)
		{
		}
	}

	public class DummyDashboardButtonView : DashboardButtonView, IView
	{
		public void SetViewModel (object viewModel)
		{
			ButtonVM = viewModel as DashboardButtonVM;
		}
	}

	public class DummyDashboardManagerVM : TemplatesManagerViewModel<Dashboard, DashboardVM, DashboardButton, DashboardButtonVM>, IDashboardDealer
	{
		public DummyDashboardManagerVM (DashboardVM vm)
		{
			LoadedTemplate = vm;
		}

		public DashboardVM Dashboard {
			get {
				return LoadedTemplate;
			}
		}
	}

	public class DummyTeamManagerVM : TemplatesManagerViewModel<Team, TeamVM, Player, PlayerVM>
	{
		public DummyTeamManagerVM (TeamVM vm)
		{
			LoadedTemplate = vm;
		}

		public TeamVM Team {
			get {
				return LoadedTemplate;
			}
		}
	}

	public class DummyResourcesLocator : ResourcesLocatorBase
	{
		public override Image LoadEmbeddedImage (string resourceId, int width = 0, int height = 0)
		{
			return GetDummyImage (width, height);
		}

		public override Image LoadImage (string name, int width = 0, int height = 0)
		{
			return GetDummyImage (width, height);
		}

		Image GetDummyImage (int width = 0, int height = 0)
		{
			string svg = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<!-- Generator: Adobe Illustrator 16.0.0, SVG Export Plug-In . SVG Version: 6.00 Build 0)  -->\r\n<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\r\n<svg version=\"1.1\" id=\"Layer_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" x=\"0px\" y=\"0px\"\r\n\t width=\"25px\" height=\"25px\" viewBox=\"0 0 25 25\" enable-background=\"new 0 0 25 25\" xml:space=\"preserve\">\r\n<g>\r\n\t<polygon fill=\"#0A0A0A\" points=\"20.12,11.465 12.499,4.219 4.88,11.465 8.225,11.465 8.225,17.572 16.774,17.572 16.774,11.465 \t\r\n\t\t\"/>\r\n\t<rect x=\"7.48\" y=\"18.806\" fill=\"#0A0A0A\" width=\"10.039\" height=\"1.976\"/>\r\n</g>\r\n</svg>";
			using (Stream s = new MemoryStream (Encoding.UTF8.GetBytes (svg))) {
				if (width != 0 && height != 0) {
					return new Image (s, width, height);
				} else {
					return new Image (s);
				}
			}
		}
	}

	/// <summary>
	/// Dummy stopwatch.
	/// </summary>
	public class DummyStopwatch : IStopwatch
	{
		/// <summary>
		/// Gets or sets the elapsed milliseconds.
		/// </summary>
		/// <value>The elapsed milliseconds.</value>
		public long ElapsedMilliseconds {
			get {
				return ElapsedTicks / 10000;
			}
			set {
				ElapsedTicks = value * 10000;
			}
		}

		/// <summary>
		/// Gets or sets the elapsed ticks.
		/// </summary>
		/// <value>The elapsed ticks.</value>
		public long ElapsedTicks {
			get;
			set;
		}

		public double ElapsedSeconds {
			get {
				return (double)ElapsedTicks / Stopwatch.Frequency;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Tests.DummyStopwatch"/> is running.
		/// </summary>
		/// <value><c>true</c> if is running; otherwise, <c>false</c>.</value>
		public bool IsRunning {
			get;
			set;
		}

		/// <summary>
		/// Reset this instance.
		/// </summary>
		public void Reset ()
		{
			ElapsedTicks = 0;
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start ()
		{
			IsRunning = true;
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop ()
		{
			IsRunning = false;
		}
	}

	public static class Utils
	{
		public class PlayerDummy : Player
		{
			//dummy class for abstract validation. Copied from LongoMatch and adapted to VAS.
		}

		public class DashboardDummy : Dashboard
		{
			//dummy class for abstract validation. Copied from LongoMatch and adapted to VAS.
			public static DashboardDummy Default ()
			{
				var dashboard = new DashboardDummy ();
				for (int i = 0; i < 5; i++) {
					var evtType = dashboard.AddDefaultItem (i);
					dashboard.AddDefaultTags (evtType.AnalysisEventType);
				}
				dashboard.InsertTimer ();
				return dashboard;
			}

			public void InsertTimer ()
			{
				var timerButton = new TimerButton {
					Timer = new Timer { Name = "Ball playing" },
					Position = new Point (10 + (10 + CAT_WIDTH) * 6, 10)
				};
				List.Add (timerButton);
			}
		}

		public class EventsFilterDummy : EventsFilter
		{
			//dummy class for abstract validation.
			public EventsFilterDummy (Project project) : base (project)
			{
			}

			#region implemented abstract members of EventsFilter

			protected override void UpdateVisiblePlayers ()
			{
			}

			protected override bool IsVisibleByPlayer (TimelineEvent play)
			{
				return true;
			}

			protected override bool IsVisibleByPeriod (TimelineEvent play)
			{
				return true;
			}

			#endregion
		}

		public class DummyTaggingController : TaggingController
		{
			protected override TimelineEventVM CreateTimelineEventVM (EventType type, Time start, Time stop, Time eventTime, Image miniature)
			{
				TimelineEvent evt;
				string count;
				string name;

				count = String.Format ("{0:000}", project.Model.EventsByType (type).Count + 1);
				name = String.Format ("{0} {1}", type.Name, count);
				evt = new TimelineEvent ();

				evt.Name = name;
				evt.Start = start;
				evt.Stop = stop;
				evt.EventTime = eventTime;
				evt.EventType = type;
				evt.Notes = "";
				evt.Miniature = miniature;
				evt.CamerasConfig = new RangeObservableCollection<CameraConfig> { new CameraConfig (0) };
				evt.FileSet = project.Model.FileSet;
				evt.Project = project.Model;

				return new TimelineEventVM { Model = evt };
			}
		}

		public class DummyEventsFilterController : EventsFilterController
		{
			protected override void InitializePredicates ()
			{
				ViewModel.Filters.Clear ();
				ViewModel.EventsPredicate.Clear ();
				UpdateTeamsPredicates ();
				UpdatePeriodsPredicates ();
				UpdateTimersPredicates ();
				UpdateCommonTagsPredicates ();
				UpdateEventTypesPredicates ();

				ViewModel.EventsPredicate.Add (ViewModel.PeriodsPredicate);
				ViewModel.EventsPredicate.Add (ViewModel.TimersPredicate);
				ViewModel.EventsPredicate.Add (ViewModel.CommonTagsPredicate);
				ViewModel.EventsPredicate.Add (ViewModel.EventTypesPredicate);
				ViewModel.Filters.Add (ViewModel.EventsPredicate);
				ViewModel.Filters.Add (ViewModel.TeamsPredicate);
			}

			protected override void UpdateTeamsPredicates ()
			{
				// do nothing
			}
		}


		//dummy class for abstract validation. Copied from LongoMatch and adapted to VAS.
		public class ProjectDummy : Project
		{
			public string shortDescription;

			#region implemented abstract members of Project
			public ProjectDummy ()
			{
				Dashboard = DashboardDummy.Default ();
				FileSet = new MediaFileSet ();
				UpdateEventTypesAndTimers ();
			}

			public override string ShortDescription => shortDescription;

			public override TimelineEvent CreateEvent (EventType type, Time start, Time stop, Time eventTime,
													   Image miniature, int index)
			{
				TimelineEvent evt;
				string count;
				string name;

				count = String.Format ("{0:000}", EventsByType (type).Count + 1);
				name = String.Format ("{0} {1}", type.Name, count);
				evt = new TimelineEvent ();

				evt.Name = name;
				evt.Start = start;
				evt.Stop = stop;
				evt.EventTime = eventTime;
				evt.EventType = type;
				evt.Notes = "";
				evt.Miniature = miniature;
				evt.CamerasConfig = new RangeObservableCollection<CameraConfig> { new CameraConfig (0) };
				evt.FileSet = FileSet;
				evt.Project = this;

				return evt;
			}

			public override void AddEvent (TimelineEvent play)
			{
				play.FileSet = FileSet;
				play.Project = this;
				Timeline.Add (play);

			}

			#endregion
		}

		static bool debugLine = false;

		public static T SerializeDeserialize<T> (T obj)
		{
			var stream = new MemoryStream ();
			Serializer.Instance.Save (obj, stream, SerializationType.Json);
			stream.Seek (0, SeekOrigin.Begin);
			if (debugLine) {
				var jsonString = new StreamReader (stream).ReadToEnd ();
				Console.WriteLine (jsonString);
			}
			stream.Seek (0, SeekOrigin.Begin);

			return Serializer.Instance.Load<T> (stream, SerializationType.Json);
		}

		/// <summary>
		/// Asserts the Type T instance properties are equal to original instance properties.
		/// </summary>
		/// <param name="original">Original instance.</param>
		/// <param name="target">Target instance.</param>
		/// <typeparam name="T">Type.</typeparam>
		public static void AssertDeserializedStorablePropertyEquality<T> (T original, T target) where T : class
		{
			foreach (var property in (typeof (T).GetProperties ()
									  .Where (info => info.CustomAttributes
											  .FirstOrDefault (attrType => attrType.AttributeType == typeof (JsonIgnoreAttribute)
															   || attrType.AttributeType == typeof (CloneIgnoreAttribute)) == null))) {
				Assert.AreEqual (property.GetValue (target), property.GetValue (original));
			}
		}

		public static void CheckSerialization<T> (T obj, bool ignoreIsChanged = false)
		{
			List<IStorable> children, changed;

			if (!ignoreIsChanged) {
				Assert.IsInstanceOf<IChanged> (obj);
			}
			var stream = new MemoryStream ();
			Serializer.Instance.Save (obj, stream, SerializationType.Json);
			stream.Seek (0, SeekOrigin.Begin);
			var jsonString = new StreamReader (stream).ReadToEnd ();
			if (debugLine) {
				Console.WriteLine (jsonString);
			}
			stream.Seek (0, SeekOrigin.Begin);

			var newobj = Serializer.Instance.Load<T> (stream, SerializationType.Json);
			if (!ignoreIsChanged) {
				ObjectChangedParser parser = new ObjectChangedParser ();
				if (obj is IStorable) {
					StorableNode parentNode;
					Assert.IsTrue (parser.ParseInternal (out parentNode, newobj as IStorable, Serializer.JsonSettings));
					Assert.IsFalse (parentNode.HasChanges ());
				} else {
					Assert.IsFalse ((newobj as IChanged).IsChanged);
				}
			}

			stream = new MemoryStream ();
			Serializer.Instance.Save (newobj, stream, SerializationType.Json);
			stream.Seek (0, SeekOrigin.Begin);
			var newJsonString = new StreamReader (stream).ReadToEnd ();
			if (debugLine) {
				Console.WriteLine (newJsonString);
			}
			Assert.AreEqual (jsonString, newJsonString);
		}

		public static Image LoadImageFromFile (bool scaled = false)
		{
			Image img = null;
			string tmpFile = Path.GetTempFileName ();

			using (Stream resource = Assembly.GetExecutingAssembly ().GetManifestResourceStream ("vas-dibujo.svg")) {
				using (Stream output = File.OpenWrite (tmpFile)) {
					resource.CopyTo (output);
				}
			}
			try {
				if (!scaled) {
					img = new Image (tmpFile);
				} else {
					img = new Image (tmpFile, 20, 20);
				}
			} catch (Exception ex) {
				Assert.Fail (ex.Message);
			} finally {
				File.Delete (tmpFile);
			}
			return img;
		}


		public static Project CreateProject (bool withEvents = true, string description = null)
		{
			TimelineEvent timeLineEvent;
			ProjectDummy project = new ProjectDummy () {
				Dashboard = DashboardDummy.Default (),
				FileSet = new MediaFileSet ()
			};
			project.shortDescription = description;
			project.FileSet.Add (new MediaFile (Path.GetTempFileName (), 34000, 25, true, true, "mp4", "h264",
				"aac", 320, 240, 1.3, null, "Test asset 1"));
			project.FileSet.Add (new MediaFile (Path.GetTempFileName (), 34000, 25, true, true, "mp4", "h264",
				"aac", 320, 240, 1.3, null, "Test asset 2"));
			project.UpdateEventTypesAndTimers ();
			project.IsLoaded = true;

			if (withEvents) {
				var analysisEventButton = project.Dashboard.List [0] as AnalysisEventButton;

				/* No tags, no players */
				timeLineEvent = new TimelineEvent {
					EventType = analysisEventButton.EventType,
					Start = new Time (0),
					Stop = new Time (100),
					FileSet = project.FileSet
				};
				project.Timeline.Add (timeLineEvent);
				/* tags, but no players */
				analysisEventButton = project.Dashboard.List [1] as AnalysisEventButton;
				timeLineEvent = new TimelineEvent {
					EventType = analysisEventButton.EventType,
					Start = new Time (0),
					Stop = new Time (100),
					FileSet = project.FileSet
				};
				timeLineEvent.Tags.Add (analysisEventButton.AnalysisEventType.Tags [0]);
				project.Timeline.Add (timeLineEvent);
				/* tags and players */
				analysisEventButton = project.Dashboard.List [2] as AnalysisEventButton;
				timeLineEvent = new TimelineEvent {
					EventType = analysisEventButton.EventType,
					Start = new Time (0),
					Stop = new Time (100),
					FileSet = project.FileSet
				};
				timeLineEvent.Tags.Add (analysisEventButton.AnalysisEventType.Tags [1]);
				project.Timeline.Add (timeLineEvent);
			}

			return project;
		}

		public static void DeleteProject (Project p)
		{
			foreach (MediaFile mf in p.FileSet) {
				if (File.Exists (mf.FilePath)) {
					File.Delete (mf.FilePath);
				}
			}
		}

		public static Mock<IScreenState> GetScreenStateMocked (string transitionName)
		{
			var screenStateMock = new Mock<IScreenState> ();
			screenStateMock.Setup (x => x.LoadState (It.IsAny<ExpandoObject> ())).Returns (AsyncHelpers.Return (true));
			screenStateMock.Setup (x => x.ShowState ()).Returns (AsyncHelpers.Return (true));
			screenStateMock.Setup (x => x.UnloadState ()).Returns (AsyncHelpers.Return (true));
			screenStateMock.Setup (x => x.HideState ()).Returns (AsyncHelpers.Return (true));
			screenStateMock.Setup (x => x.FreezeState ()).Returns (AsyncHelpers.Return (true));
			screenStateMock.Setup (x => x.UnfreezeState ()).Returns (AsyncHelpers.Return (true));

			screenStateMock.Setup (x => x.Panel).Returns (new Mock<IPanel> ().Object);
			screenStateMock.Setup (x => x.Name).Returns (transitionName);
			return screenStateMock;
		}

		public static void AreEquals (IStorable obj1, IStorable obj2, bool areEquals = true)
		{
			var stream = new MemoryStream ();
			Serializer.Instance.Save (obj1, stream, SerializationType.Json);
			stream.Seek (0, SeekOrigin.Begin);
			var obj1Str = new StreamReader (stream).ReadToEnd ();
			stream = new MemoryStream ();
			Serializer.Instance.Save (obj2, stream, SerializationType.Json);
			stream.Seek (0, SeekOrigin.Begin);
			var obj2Str = new StreamReader (stream).ReadToEnd ();
			if (areEquals) {
				Assert.AreEqual (obj1Str, obj2Str);
			} else {
				Assert.AreNotEqual (obj1Str, obj2Str);
			}
		}

		public static string SaveResource (string name, string path)
		{
			string filePath;
			var assembly = Assembly.GetExecutingAssembly ();
			using (Stream inS = assembly.GetManifestResourceStream (name)) {
				filePath = Path.Combine (path, name);
				using (Stream outS = new FileStream (filePath, FileMode.Create)) {
					inS.CopyTo (outS);
				}
			}
			return filePath;
		}

		public static string GetEmbeddedResourceTextFile (string resourceId)
		{
			string result = "";
			var assembly = Assembly.GetCallingAssembly ();
			using (Stream stream = assembly.GetManifestResourceStream (resourceId)) {
				using (StreamReader reader = new StreamReader (stream)) {
					result = reader.ReadToEnd ();
				}
			}
			return result;
		}

		public static Command GetCommandFromMenu (MenuVM menu, string menuname)
		{
			foreach (var menuNode in menu.ViewModels.Where ((arg) => arg.Submenu == null)) {
				if (menuNode.Name != null && menuNode.Name == menuname) {
					return menuNode.Command;
				} else if (menuNode.Command.Text == menuname) {
					return menuNode.Command;
				}
			}

			foreach (var menuNode in menu.ViewModels.Where ((arg) => arg.Submenu != null)) {
				return GetCommandFromMenu (menuNode.Submenu, menuname);
			}

			return null;
		}
	}

	class CustomDummyClassForTest
	{
		public int Index { get; set; }
	}

	class StorableBaseComparer : IComparer<StorableBase>, IComparer
	{
		bool descending;

		public StorableBaseComparer (bool descending)
		{
			this.descending = descending;
		}

		public int Compare (object x, object y)
		{
			if ((x == null) || !(x is StorableBase) || (y == null) || !(y is StorableBase)) {
				return 0;
			}
			return Compare (x as StorableBase, y as StorableBase);
		}

		public int Compare (StorableBase x, StorableBase y)
		{
			if (descending) {
				return y.CreationDate.CompareTo (x.CreationDate);
			} else {
				return x.CreationDate.CompareTo (y.CreationDate);
			}
		}
	}

	class CustomDummyClassForTestComparer : IComparer<CustomDummyClassForTest>, IComparer
	{
		bool descending;

		public CustomDummyClassForTestComparer (bool descending)
		{
			this.descending = descending;
		}

		public int Compare (object x, object y)
		{
			if ((x == null) || !(x is CustomDummyClassForTest) || (y == null) || !(y is CustomDummyClassForTest)) {
				return 0;
			}
			return Compare (x as CustomDummyClassForTest, y as CustomDummyClassForTest);
		}

		public int Compare (CustomDummyClassForTest x, CustomDummyClassForTest y)
		{
			if (descending) {
				return y.Index.CompareTo (x.Index);
			} else {
				return x.Index.CompareTo (y.Index);
			}
		}
	}

	/// <summary>
	/// Seeker that calls seek as soon as it's called, without timeout.
	/// </summary>
	class InstantSeeker : ISeeker
	{
		public event SeekHandler SeekEvent;

		public void Dispose ()
		{
		}

		public void Seek (SeekType seekType, Time start = null, float rate = 1)
		{
			SeekEvent?.Invoke (seekType, start, rate);
		}
	}

	/// <summary>
	/// Seeker that calls seek when it's triggered and a seek has been called before.
	/// </summary>
	class TriggerableSeeker : ISeeker
	{
		SeekType seekType = SeekType.None;
		Time start;
		float rate;

		public event SeekHandler SeekEvent;

		public void Dispose ()
		{
		}

		public void Seek (SeekType seekType, Time start = null, float rate = 1)
		{
			this.seekType = seekType;
			this.start = start;
			this.rate = rate;
		}

		public void TriggerSeek ()
		{
			if (seekType != SeekType.None) {
				SeekEvent?.Invoke (seekType, start, rate);
			} else {
				throw new InvalidOperationException ("You should call Seek before trying to trigger it");
			}
		}
	}
}

