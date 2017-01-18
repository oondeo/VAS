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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VAS.Core.Common;
using VAS.Core.Handlers;
using VAS.Core.Interfaces.Drawing;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.Store;
using VAS.Core.Store.Drawables;
using VAS.Core.ViewModel;
using VAS.Drawing.CanvasObjects.Dashboard;
using VASDrawing = VAS.Drawing;

namespace VAS.Drawing.Widgets
{
	public class DashboardCanvas : SelectionCanvas, IView<DashboardVM>
	{
		public event ButtonsSelectedHandler ButtonsSelectedEvent;
		public event ButtonSelectedHandler EditButtonTagsEvent;
		public event ActionLinksSelectedHandler ActionLinksSelectedEvent;
		public event ActionLinkCreatedHandler ActionLinkCreatedEvent;
		public event ShowDashboardMenuHandler ShowMenuEvent;
		public event NewEventHandler NewTagEvent;

		protected int templateWidth, templateHeight;
		protected ActionLinkObject movingLink;
		protected LinkAnchorObject destAnchor;
		protected Dictionary<DashboardButton, DashboardButtonObject> buttonsDict;

		DashboardVM viewModel;

		public DashboardCanvas (IWidget widget) : base (widget)
		{
			Accuracy = 5;
			BackgroundColor = App.Current.Style.PaletteBackground;
			buttonsDict = new Dictionary<DashboardButton, DashboardButtonObject> ();
		}

		public DashboardCanvas () : this (null)
		{
		}

		public DashboardVM ViewModel {
			get {
				return viewModel;
			}

			set {
				if (viewModel != null) {
					viewModel.PropertyChanged -= HandlePropertyChanged;
				}
				ClearCanvas ();
				viewModel = value;
				if (viewModel != null) {
					FillCanvas ();
					viewModel.PropertyChanged += HandlePropertyChanged;
					HandlePropertyChanged (viewModel, null);
				}
			}
		}

		public void SetViewModel (object viewModel)
		{
			ViewModel = (DashboardVM)viewModel;
		}

		public void Click (DashboardButton b, Tag tag = null)
		{
			DashboardButtonObject co = Objects.OfType<DashboardButtonObject> ().FirstOrDefault (o => o.Button == b);
			if (tag != null && co is CategoryObject) {
				(co as CategoryObject).ClickTag (tag);
			} else {
				co.Click ();
			}
		}

		public void RedrawButton (DashboardButton b)
		{
			DashboardButtonObject co = Objects.OfType<DashboardButtonObject> ().FirstOrDefault (o => o.Button == b);
			if (co != null) {
				co.ReDraw ();
			}
		}

		public void Refresh (DashboardButton b = null)
		{
			DashboardButtonObject to;

			if (ViewModel == null) {
				return;
			}
			ClearCanvas ();
			FillCanvas ();
			to = Objects.OfType<DashboardButtonObject> ().
				FirstOrDefault (o => o.Button == b);
			if (to != null) {
				UpdateSelection (new Selection (to, SelectionPosition.All, 0));
			}
		}

		public override void SetWidget (IWidget newWidget)
		{
			base.SetWidget (newWidget);
			HandleSizeChangedEvent ();
		}

		protected override void ShowMenu (Point coords)
		{
			List<DashboardButton> buttons;
			List<ActionLink> links;

			if (ShowMenuEvent == null || Selections.Count == 0)
				return;

			buttons = Selections.Where (s => s.Drawable is DashboardButtonObject).
				Select (s => (s.Drawable as DashboardButtonObject).Button).ToList ();
			links = Selections.Where (s => s.Drawable is ActionLinkObject).
				Select (s => (s.Drawable as ActionLinkObject).Link).ToList ();
			ShowMenuEvent (buttons, links);
		}

		protected override Selection GetSelection (Point coords, bool inMotion = false, bool skipSelected = false)
		{
			Selection sel = null;
			Selection selected = null;

			/* Regular GetSelection */
			if (!ViewModel.ShowLinks)
				return base.GetSelection (coords, inMotion, skipSelected);

			/* With ShowLinks, only links and anchor can be selected */
			if (Selections.Count > 0) {
				selected = Selections.LastOrDefault ();
			}

			foreach (ICanvasSelectableObject co in Objects) {
				sel = co.GetSelection (coords, Accuracy, inMotion);
				if (sel == null || sel.Drawable is DashboardButtonObject)
					continue;
				if (skipSelected && selected != null && sel.Drawable == selected.Drawable)
					continue;
				break;
			}
			return sel;
		}

		protected override void SelectionMoved (Selection sel)
		{
			if (sel.Drawable is DashboardButtonObject) {
				HandleSizeChangedEvent ();
			} else if (sel.Drawable is ActionLinkObject) {
				ActionLinkObject link = sel.Drawable as ActionLinkObject;
				LinkAnchorObject anchor = null;
				Selection destSel;

				destSel = GetSelection (MoveStart, true, true);
				if (destSel != null && destSel.Drawable is LinkAnchorObject) {
					anchor = destSel.Drawable as LinkAnchorObject;
				}
				/* Toggled highlited state */
				if (anchor != destAnchor) {
					if (destAnchor != null) {
						destAnchor.Highlighted = false;
					}
					/* Only highlight valid targets */
					if (link.CanLink (anchor)) {
						anchor.Highlighted = true;
						destAnchor = anchor;
					} else {
						destAnchor = null;
					}
				}
			}
			base.SelectionMoved (sel);
		}

		protected override void SelectionChanged (List<Selection> sel)
		{
			if (sel.Count == 0) {
				if (ButtonsSelectedEvent != null) {
					ButtonsSelectedEvent (new List<DashboardButton> ());
				}
				return;
			}

			if (sel [0].Drawable is DashboardButtonObject) {
				List<DashboardButton> buttons;

				buttons = sel.Select (s => (s.Drawable as DashboardButtonObject).Button).ToList ();
				if (ViewModel.Mode == DashboardMode.Edit) {
					if (ButtonsSelectedEvent != null) {
						ButtonsSelectedEvent (buttons);
					}
				}
			} else if (sel [0].Drawable is ActionLinkObject) {
				List<ActionLink> links;

				links = sel.Select (s => (s.Drawable as ActionLinkObject).Link).ToList ();
				if (ViewModel.Mode == DashboardMode.Edit) {
					if (ActionLinksSelectedEvent != null) {
						ActionLinksSelectedEvent (links);
					}
				}
			}
			base.SelectionChanged (sel);
		}

		protected override void StartMove (Selection sel)
		{
			if (sel != null && sel.Drawable is LinkAnchorObject) {
				LinkAnchorObject anchor = sel.Drawable as LinkAnchorObject;
				ActionLink link = new ActionLink {
					SourceButton = anchor.Button.Button,
					SourceTags = new ObservableCollection<Tag> (anchor.Tags)
				};
				movingLink = new ActionLinkObject (anchor, null, link);
				AddObject (movingLink);
				ClearSelection ();
				UpdateSelection (new Selection (movingLink, SelectionPosition.LineStop, 0), false);
			}
			base.StartMove (sel);
		}

		protected override void StopMove (bool moved)
		{
			Selection sel = Selections.FirstOrDefault ();

			if (movingLink != null) {
				if (destAnchor != null) {
					ActionLink link = movingLink.Link;
					link.DestinationButton = destAnchor.Button.Button;
					link.DestinationTags = new ObservableCollection<Tag> (destAnchor.Tags);
					link.SourceButton.ActionLinks.Add (link);
					movingLink.Destination = destAnchor;
					destAnchor.Highlighted = false;
					if (ActionLinkCreatedEvent != null) {
						ActionLinkCreatedEvent (link);
					}
				} else {
					RemoveObject (movingLink);
					widget.ReDraw ();
				}
				ClearSelection ();
				movingLink = null;
				destAnchor = null;
				return;
			}

			if (sel != null && moved) {
				if (sel.Drawable is DashboardButtonObject) {
					/* Round the position of the button to match a corner in the grid */
					int i = VASDrawing.Constants.CATEGORY_TPL_GRID;
					DashboardButton tb = (sel.Drawable as DashboardButtonObject).Button;
					tb.Position.X = VASDrawing.Utils.Round (tb.Position.X, i);
					tb.Position.Y = VASDrawing.Utils.Round (tb.Position.Y, i);
					tb.Width = (int)VASDrawing.Utils.Round (tb.Width, i);
					tb.Height = (int)VASDrawing.Utils.Round (tb.Height, i);
					(sel.Drawable as DashboardButtonObject).ResetDrawArea ();
					widget.ReDraw ();
				}
			}
			base.StopMove (moved);
		}

		public override void Draw (IContext context, Area area)
		{
			tk.Context = context;
			DrawBackground ();
			Begin (context);
			if (ViewModel.Mode != DashboardMode.Code) {
				/* Draw grid */
				tk.LineWidth = 1;
				tk.StrokeColor = Color.Grey1;
				tk.FillColor = Color.Grey1;
				/* Vertical lines */
				for (int i = 0; i <= templateHeight; i += VASDrawing.Constants.CATEGORY_TPL_GRID) {
					tk.DrawLine (new Point (0, i), new Point (templateWidth, i));
				}
				/* Horizontal lines */
				for (int i = 0; i < templateWidth; i += VASDrawing.Constants.CATEGORY_TPL_GRID) {
					tk.DrawLine (new Point (i, 0), new Point (i, templateHeight));
				}
			}
			DrawObjects (area);
			End ();
		}

		public void AddButton (DashboardButtonObject button)
		{
			button.ShowLinks = ViewModel.ShowLinks;
			AddObject (button);
			buttonsDict.Add (button.Button, button);
		}

		protected virtual void ClearCanvas ()
		{
			ClearObjects ();
			buttonsDict.Clear ();
		}

		protected virtual void FillCanvas ()
		{
			foreach (DashboardButtonVM vm in ViewModel.ViewModels) {
				IView view = App.Current.ViewLocator.Retrieve (vm.View);
				view.SetViewModel (vm);
				var viewButton = view as DashboardButtonObject;
				viewButton.ClickedEvent += HandleTaggerClickedEvent;
				viewButton.Mode = ViewModel.Mode;
				if (viewButton is CategoryObject) {
					((CategoryObject)viewButton).EditButtonTagsEvent += (t) => {
						if (EditButtonTagsEvent != null)
							EditButtonTagsEvent (t);
					};
				}
				AddButton (viewButton);
			}

			foreach (DashboardButtonObject buttonObject in buttonsDict.Values) {
				foreach (ActionLink link in buttonObject.Button.ActionLinks) {
					LinkAnchorObject sourceAnchor, destAnchor;
					ActionLinkObject linkObject;

					sourceAnchor = buttonObject.GetAnchor (link.SourceTags);
					try {
						destAnchor = buttonsDict [link.DestinationButton].GetAnchor (link.DestinationTags);
					} catch {
						Log.Error ("Skipping link with invalid destination tags");
						continue;
					}
					linkObject = new ActionLinkObject (sourceAnchor, destAnchor, link);
					link.SourceButton = buttonObject.Button;
					linkObject.Visible = ViewModel.ShowLinks;
					AddObject (linkObject);
				}
			}
			HandleSizeChangedEvent ();
		}

		protected override void HandleSizeChangedEvent ()
		{
			if (ViewModel == null || widget == null) {
				return;
			}

			base.HandleSizeChangedEvent ();

			FitMode prevFitMode = ViewModel.FitMode;
			templateHeight = ViewModel.CanvasHeight + 10;
			templateWidth = ViewModel.CanvasWidth + 10;
			/* When going from Original to Fill or Fit, we can't know the new 
			 * size of the shrinked object until we have a resize */
			if (ViewModel.FitMode == FitMode.Original) {
				widget.Width = templateWidth;
				widget.Height = templateHeight;
				ScaleX = ScaleY = 1;
				Translation = new Point (0, 0);
			} else if (ViewModel.FitMode == FitMode.Fill) {
				ScaleX = (double)widget.Width / templateWidth;
				ScaleY = (double)widget.Height / templateHeight;
				Translation = new Point (0, 0);
			} else if (ViewModel.FitMode == FitMode.Fit) {
				double scaleX, scaleY;
				Point translation;
				Image.ScaleFactor (templateWidth, templateHeight,
					(int)widget.Width, (int)widget.Height, ScaleMode.AspectFit,
					out scaleX, out scaleY, out translation);
				ScaleX = scaleX;
				ScaleY = scaleY;
				Translation = translation;
			}

			widget.ReDraw ();
		}

		protected virtual void HandleTaggerClickedEvent (ICanvasObject co)
		{
			DashboardButtonObject tagger;
			EventButton button;
			Time start = null, stop = null, eventTime = null;
			List<Tag> tags = null;

			tagger = co as DashboardButtonObject;

			if (tagger is TagObject) {
				TagObject tag = tagger as TagObject;
				if (tag.Active) {
					/* All tag buttons from the same group that are active */
					foreach (TagObject to in Objects.OfType<TagObject> ().
						Where (t => t.TagButton.Tag.Group == tag.TagButton.Tag.Group &&
							t.Active && t != tagger)) {
						to.Active = false;
					}
				}
				return;
			}

			if (NewTagEvent == null || !(tagger.Button is EventButton)) {
				return;
			}

			button = tagger.Button as EventButton;

			if (ViewModel.Mode == DashboardMode.Edit) {
				return;
			}

			if (button.TagMode == TagMode.Predefined) {
				stop = ViewModel.CurrentTime + button.Stop;
				start = ViewModel.CurrentTime - button.Start;
				eventTime = ViewModel.CurrentTime;
			} else {
				stop = ViewModel.CurrentTime;
				start = tagger.Start - button.Start;
				eventTime = tagger.Start;
			}

			tags = new List<Tag> ();
			if (tagger is CategoryObject) {
				tags.AddRange ((tagger as CategoryObject).SelectedTags);
			}
			foreach (TagObject to in Objects.OfType<TagObject> ()) {
				if (to.Active) {
					tags.Add (to.TagButton.Tag);
				}
				to.Active = false;
			}
			NewTagEvent (button.EventType, null, null, tags, start, stop, eventTime, button);
		}

		void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (sender != ViewModel) {
				return;
			}

			if (e == null || e.PropertyName == "Mode") {
				HandleModeChanged ();
			} else if (e == null || e.PropertyName == "ShowLinks") {
				HandleShowLinksChanged ();
			} else if (e == null || e.PropertyName == "CurrentTime") {
				HandleCurrentTimeChanged ();
			} else if (e == null || e.PropertyName == "FitMode") {
				HandleSizeChangedEvent ();
			}
		}

		void HandleModeChanged ()
		{
			ObjectsCanMove = ViewModel.Mode == DashboardMode.Edit;
			foreach (DashboardButtonObject to in Objects.OfType<DashboardButtonObject> ()) {
				to.Mode = ViewModel.Mode;
			}
			ClearSelection ();
		}

		void HandleShowLinksChanged ()
		{
			foreach (DashboardButtonObject to in Objects.OfType<DashboardButtonObject> ()) {
				to.ShowLinks = ViewModel.ShowLinks;
				to.ResetDrawArea ();
			}
			foreach (ActionLinkObject ao in Objects.OfType<ActionLinkObject> ()) {
				ao.Visible = ViewModel.ShowLinks;
				ao.ResetDrawArea ();
			}
			ClearSelection ();
			widget?.ReDraw ();
		}

		void HandleCurrentTimeChanged ()
		{
			//FIXME: This can easily be treated at the DashboardVM by proxying
			// the CurrentTime to its Childs ViewModels
			foreach (TimerObject to in Objects.OfType<TimerObject> ()) {
				to.CurrentTime = ViewModel.CurrentTime;
			}
			foreach (TimedTaggerObject to in Objects.OfType<TimedTaggerObject> ()) {
				if (to.TimedButton.TagMode == TagMode.Free) {
					to.CurrentTime = ViewModel.CurrentTime;
				}
			}
		}
	}
}

