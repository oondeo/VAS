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
using System.ComponentModel;
using System.Linq.Expressions;
using Gtk;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.MVVMC;

namespace VAS.UI.Helpers.Bindings
{
	/// <summary>
	/// Property bindings for labels.
	/// </summary>
	public class LabelBinding<TSourceProperty> : PropertyBinding<TSourceProperty, string>
	{
		Label label;

		public LabelBinding (Label label, Expression<Func<IViewModel, TSourceProperty>> sourcePropertyExpression, TypeConverter converter = null) : base (sourcePropertyExpression, converter)
		{
			this.label = label;
		}

		protected override void BindView ()
		{
		}

		protected override void UnbindView ()
		{
		}

		protected override void WriteViewValue (string val)
		{
			label.Text = val;
		}
	}
}
