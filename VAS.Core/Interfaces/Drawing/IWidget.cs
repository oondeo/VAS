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
using VAS.Core.Handlers.Drawing;
using VAS.Core.Common;

namespace VAS.Core.Interfaces.Drawing
{
	public interface IWidget : IDisposable
	{
		event DrawingHandler DrawEvent;
		event ButtonPressedHandler ButtonPressEvent;
		event ButtonReleasedHandler ButtonReleasedEvent;
		event MotionHandler MotionEvent;
		event SizeChangedHandler SizeChangedEvent;
		event ShowTooltipHandler ShowTooltipEvent;

		/// <summary>
		/// Fast button clicks sometimes produced a small move that
		/// should be ignored. Start moving only when the button has been
		/// pressed for more than MoveWaitMS.
		/// </summary>
		/// <value>Milliseconds to wait before moving.</value>
		uint MoveWaitMS { get; set; }

		double Width { get; set; }

		double Height { get; set; }

		void ReDraw (Area area = null);

		void ReDraw (IMovableObject drawable);

		void SetCursor (CursorType type);

		void SetCursorForTool (DrawTool tool);

		void ShowTooltip (string text);
	}
}

