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
using System.Collections.Generic;
using Gdk;
using Gtk;

namespace VAS.UI.Helpers
{
	/// <summary>
	/// Provides extension methods for Gtk+
	/// </summary>
	public static class ExtensionMethods
	{
		const int TEXT_OFFSET = 20;
		const int CHARSWIDTH_OFFSET = 30;

		/// <summary>
		/// Autocomplete the specified entry and list.
		/// </summary>
		/// <returns>The autocomplete.</returns>
		/// <param name="entry">Entry.</param>
		/// <param name="list">List.</param>
		public static void Autocomplete (this Entry entry, List<string> list)
		{
			EntryCompletion completionSeasons = new EntryCompletion ();
			ListStore storeSeasons = new ListStore (typeof (string));

			foreach (string item in list) {
				storeSeasons.AppendValues (item);
			}

			entry.Completion = new EntryCompletion {
				Model = storeSeasons,
				TextColumn = 0
			};
		}

		/// <summary>
		/// Centers a dialog on its parent. Dialogs are centered in Show () only if TransientFor is set,
		/// which has to be done in the constructor with Stetic. When we can't this function can be used instead.
		/// This implementation is a C# port of the C implementation used in from gtk/gtkwindow.c
		/// </summary>
		/// <param name="dialog">Widget to center.</param>
		public static void Center (this Gtk.Dialog dialog)
		{
			int monitorNum;
			int ox, oy, x, y, w, h;
			Widget parent;

			parent = dialog.TransientFor;

			if (parent.GdkWindow != null) {
				monitorNum = Screen.Default.GetMonitorAtWindow (parent.GdkWindow);
			} else {
				monitorNum = -1;
			}

			w = dialog.Allocation.Width;
			h = dialog.Allocation.Height;

			parent.GdkWindow.GetOrigin (out ox, out oy);
			x = ox + (parent.Allocation.Width - dialog.Allocation.Width) / 2;
			y = oy + (parent.Allocation.Height - dialog.Allocation.Height) / 2;

			if (monitorNum >= 0) {
				var monitor = Screen.Default.GetMonitorGeometry (monitorNum);
				ClamWindowToRectangle (ref x, ref y, w, h, monitor);
			}

			dialog.Move (x, y);
		}

		/// <summary>
		/// Set Label to change its size dynamically, by specifiying a minimum width and a maximum width, if maximum is not
		/// specified then it will get the first allocated width of the label.
		/// </summary>
		/// <param name="label">Label.</param>
		/// <param name="minWidth">Minimum width.</param>
		/// <param name="maxWidth">Max width.</param>
		public static void DynamicSize (this Label label, int minWidth, int maxWidth = -1)
		{
			label.SizeAllocated += (o, args) => {
				int newWidth = args.Allocation.Width;
				if (maxWidth == -1 && newWidth > 0) {
					maxWidth = newWidth;
				}
				if (((Label)o).WidthRequest != (newWidth - TEXT_OFFSET) && maxWidth > 0) {
					int size = Math.Max (args.Allocation.Width - TEXT_OFFSET, minWidth);
					size = Math.Min (size, maxWidth);
					((Label)o).WidthRequest = size;
					((Label)o).WidthChars = size - CHARSWIDTH_OFFSET;
				}
			};
		}


		static void Clamp (ref int @base, int extent, int clampBase, int clampExtent)
		{
			if (extent > clampExtent) {
				/* Center */
				@base = clampBase + clampExtent / 2 - extent / 2;
			} else if (@base < clampBase) {
				@base = clampBase;
			} else if (@base + extent > clampBase + clampExtent) {
				@base = clampBase + clampExtent - extent;
			}
		}

		static void ClamWindowToRectangle (ref int x, ref int y, int width, int height, Rectangle rect)
		{
			Clamp (ref x, width, rect.X, rect.Width);
			Clamp (ref y, height, rect.Y, rect.Height);
		}
	}
}
