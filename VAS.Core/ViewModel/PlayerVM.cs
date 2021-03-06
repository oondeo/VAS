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
using VAS.Core.Common;
using VAS.Core.MVVMC;
using VAS.Core.Store;

namespace VAS.Core.ViewModel
{
	public class PlayerVM : ViewModelBase<Player>
	{
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:RiftAnalyst.Core.ViewModel.RAPlayerVM"/> is locked.
		/// </summary>
		/// <value><c>true</c> if locked; otherwise, <c>false</c>.</value>
		public bool Locked {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the player name.
		/// </summary>
		/// <value>The name.</value>
		public string Name {
			get {
				return Model.Name;
			}
			set {
				Model.Name = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:RiftAnalyst.Core.ViewModel.RAPlayerVM"/> is tagged.
		/// </summary>
		/// <value><c>true</c> if tagged; otherwise, <c>false</c>.</value>
		public bool Tagged {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		/// <value>The color.</value>
		public Color Color {
			get { return Model.Color; }
			set { Model.Color = value; }
		}

		/// <summary>
		/// Gets or sets the photo.
		/// </summary>
		/// <value>The photo.</value>
		public Image Photo {
			get { return Model.Photo; }
			set { Model.Photo = value; }
		}
	}
}
