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
using System.Collections.Generic;
using Gtk;
using System.Linq;
using Misc = VAS.UI.Helpers.Misc;

namespace VAS.UI.Dialog
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class ChooseOptionDialog : Gtk.Dialog
	{
		public ChooseOptionDialog (Window parent)
		{
			TransientFor = parent;
			this.Build ();
			Icon = Misc.LoadIcon (App.Current.SoftwareIconName, IconSize.Button, 0);
		}

		public Dictionary<string, object> Options {
			set {
				RadioButton first = null;
				SelectedOption = value.Values.FirstOrDefault ();
				foreach (string desc in value.Keys) {
					first = new RadioButton (first, desc);
					first.Toggled += (sender, e) => {
						if ((sender as RadioButton).Active) {
							SelectedOption = value [desc];
						}
					};
					first.ShowAll ();
					optionsbox.PackStart (first, false, true, 0);
				}
			}
		}

		public object SelectedOption {
			get;
			protected set;
		}
	}
}

