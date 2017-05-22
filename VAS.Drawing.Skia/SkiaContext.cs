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
using VAS.Core.Interfaces.Drawing;
using VAS.Core.MVVMC;
using SkiaSharp;

namespace VAS.Drawing.Skia
{
	public class SkiaContext : DisposableBase, IContext
	{
		public SkiaContext (SKSurface surface)
		{
			Value = surface.Canvas;
		}

		public SkiaContext (SKCanvas canvas)
		{
			Value = canvas;
		}

		public object Value {
			get;
			protected set;
		}

		protected override void DisposeManagedResources ()
		{
			base.DisposeManagedResources ();
			(Value as SKCanvas).Dispose ();
		}
	}
}

