//
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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.MVVMC;

#if HAVE_GTK
using SImage = Gdk.Pixbuf;
#endif

namespace VAS.Core.Store.Playlists
{
	[Serializable]
	public class PlaylistImage : BindableBase, IPlaylistElement
	{
		public PlaylistImage (Image image, Time duration)
		{
			Image = image;
			Miniature = image.Scale (Constants.MAX_THUMBNAIL_SIZE,
				Constants.MAX_THUMBNAIL_SIZE);
			Duration = duration;
			CamerasConfig = new RangeObservableCollection<CameraConfig> { new CameraConfig (0) };
			CamerasLayout = null;
		}

		protected override void DisposeManagedResources ()
		{
			base.DisposeManagedResources ();
			Image?.Dispose ();
			Image = null;
			Miniature?.Dispose ();
			Miniature = null;
		}

		public Image Image {
			get;
			set;
		}

		public Time Duration {
			get;
			set;
		}

		public Image Miniature {
			get;
			set;
		}

		public string Description {
			get {
				return $"{Catalog.GetString ("Image")} ({Duration.ToSecondsString ()})";
			}
		}

		[JsonIgnore]
		public RangeObservableCollection<CameraConfig> CamerasConfig {
			get;
			private set;
		}

		[JsonIgnore]
		public object CamerasLayout {
			get;
			private set;
		}
	}
}

