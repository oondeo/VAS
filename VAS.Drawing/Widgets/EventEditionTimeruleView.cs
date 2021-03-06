﻿//
//  Copyright (C) 2017 Fluendo S.A.
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
using System.ComponentModel;
using VAS.Core.Common;
using VAS.Core.Hotkeys;
using VAS.Core.Interfaces.Drawing;
using VAS.Core.MVVMC;
using VAS.Core.Resources.Styles;
using VAS.Core.Store;
using VAS.Core.Store.Drawables;
using VAS.Core.Store.Playlists;
using VAS.Core.ViewModel;
using VAS.Drawing.CanvasObjects.Timeline;

namespace VAS.Drawing.Widgets
{

	[View ("EventEditionTimeruleView")]
	public class EventEditionTimeruleView : SelectionCanvas, ICanvasView<VideoPlayerVM>
	{
		const int BIG_LINE_HEIGHT = 8;
		const int SMALL_LINE_HEIGHT = 3;
		int fontSize;
		VideoPlayerVM viewModel;
		TimeNodeEditorView nodeView;

		public EventEditionTimeruleView (IWidget widget) : base (widget)
		{
			Accuracy = 20;
			FontSize = Sizes.TimelineRulePlayerFontSize;
			nodeView = new TimeNodeEditorView {
				SelectionMode = NodeSelectionMode.Borders,
			};

			AddObject (nodeView);
		}

		public VideoPlayerVM ViewModel {
			get {
				return viewModel;
			}
			set {
				if (viewModel != null) {
					viewModel.PropertyChanged -= HandlePropertyChangedEventHandler;
				}
				viewModel = value;

				if (viewModel != null) {
					viewModel.PropertyChanged += HandlePropertyChangedEventHandler;
				}
			}
		}

		int FontSize {
			get {
				return fontSize;
			}
			set {
				int theight, twidth;
				fontSize = value;
				tk.MeasureText ("99:99:99", out twidth, out theight, "", fontSize, FontWeight.Normal);
				TextWidth = twidth;
			}
		}

		int TextWidth {
			get;
			set;
		}

		public void SetViewModel (object viewModel)
		{
			ViewModel = (VideoPlayerVM)viewModel;
		}

		public override void Draw (IContext context, Area area)
		{
			double editorStartX, editorStopX, nodeStartX, nodeStopX, start, height, width, startWidth;
			double interval = 0, secondsPerPixel, totalSeconds, timeSpacing, intervalLot;

			if (ViewModel.LoadedElement == null || ViewModel.EditEventDurationTimeNode.Model == null) {
				return;
			}
			height = widget.Height;
			width = widget.Width;
			totalSeconds = ViewModel.EditEventDurationTimeNode.Duration.TotalSeconds;
			secondsPerPixel = totalSeconds / width;
			//Calculate the timeSpacing in pixels
			foreach (int i in Constants.MARKER) {
				int pixels = (int)Math.Ceiling (Constants.MINIMUM_TIME_SPACING * (totalSeconds / i));
				if (pixels <= width) {
					if (ViewModel.EditEventDurationTimeNode.Duration.TotalSeconds > 0) {
						timeSpacing = width / (totalSeconds / i);
						interval = i;
					}
					break;
				}
			}

			editorStartX = Utils.TimeToPos (ViewModel.EditEventDurationTimeNode.Start, secondsPerPixel);


			nodeStartX = Utils.TimeToPos (nodeView.ViewModel.Start, secondsPerPixel);
			start = editorStartX - (editorStartX % interval);
			editorStopX = Utils.TimeToPos (ViewModel.EditEventDurationTimeNode.Stop, secondsPerPixel);
			nodeStopX = Utils.TimeToPos (nodeView.ViewModel.Stop, secondsPerPixel);
			intervalLot = ((interval / secondsPerPixel) / 10);
			startWidth = nodeStartX - editorStartX;

			Begin (context);

			tk.LineWidth = 0;
			BackgroundColor = App.Current.Style.TextBaseSecondary;
			DrawBackground ();

			tk.FillColor = App.Current.Style.ScreenBase;
			tk.DrawRectangle (new Point (nodeStartX - editorStartX, 0), nodeStopX - nodeStartX, height);

			tk.StrokeColor = App.Current.Style.TextBase;
			tk.FillColor = App.Current.Style.TextBase;
			tk.LineWidth = Constants.TIMELINE_LINE_WIDTH;
			tk.FontSlant = FontSlant.Normal;
			tk.FontSize = FontSize;
			tk.DrawLine (new Point (0, height), new Point (width, height));

			//Draw a big line each interval start point
			for (double i = start; i <= editorStopX; i += interval / secondsPerPixel) {
				double pos = i - editorStartX;
				tk.DrawLine (new Point (pos, height), new Point (pos, height - BIG_LINE_HEIGHT));
				tk.FontAlignment = FontAlignment.Center;
				string timeText = new Time { TotalSeconds = (int)(i * secondsPerPixel) }.ToSecondsString ();
				tk.DrawText (new Point (pos - TextWidth / 2, 2), TextWidth, height - BIG_LINE_HEIGHT - 2, timeText);

				//Draw 9 small lines to separate each interval in 10 partitions
				for (int j = 1; j < 10; j++) {
					double position = pos + intervalLot * j;
					tk.DrawLine (new Point (position, height), new Point (position, height - SMALL_LINE_HEIGHT));
				}
			}

			nodeView.ScrollX = editorStartX;
			nodeView.SecondsPerPixel = secondsPerPixel;
			nodeView.Draw (tk, null);
			End ();
		}

		protected override void StartMove (Selection sel)
		{
			base.StartMove (sel);
			ViewModel.PauseCommand.Execute (false);
		}

		protected override void StopMove (bool moved)
		{
			if (moved) {
				ViewModel.EditEventDurationCommand.Execute (true);
			}
		}

		void HandlePropertyChangedEventHandler (object sender, PropertyChangedEventArgs e)
		{
			if (!Moving && sender == ViewModel.LoadedElement &&
				(e.PropertyName == nameof (TimeNodeVM.Start) || e.PropertyName == nameof (TimeNodeVM.Stop))) {
				widget?.ReDraw ();
			} else if (e.PropertyName == nameof (VideoPlayerVM.EditEventDurationModeEnabled)) {
				if (ViewModel.EditEventDurationModeEnabled) {
					nodeView.MaxTime = ViewModel.EditEventDurationTimeNode.Stop;
					widget?.ReDraw ();
				}
			} else if (e.PropertyName == nameof (VideoPlayerVM.LoadedElement)) {
				if (ViewModel.LoadedElement != null) {

					if (ViewModel.LoadedElement is PlaylistPlayElementVM) {
						nodeView.ViewModel = (ViewModel.LoadedElement as PlaylistPlayElementVM).Play;
					} else {
						nodeView.ViewModel = ViewModel.LoadedElement as TimeNodeVM;
					}

					widget?.ReDraw ();
				}
			}
		}
	}
}
