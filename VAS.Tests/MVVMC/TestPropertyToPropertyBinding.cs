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
using NUnit.Framework;
using VAS.Core.License;
using VAS.Core.MVVMC;
using VAS.Core.ViewModel;
using VAS.Core.ViewModel.Statistics;

namespace VAS.Tests.MVVMC
{
	[TestFixture]
	public class TestPropertyToPropertyBinding
	{
		[Test]
		public void PropertyToPropertyBinding_WriteSource_DestinationUpdated ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			binding.ViewModel = source;

			// Act
			source.Count = 999;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreEqual (source.Count, destination.Count);
		}

		[Test]
		public void PropertyToPropertyBinding_WriteDestination_SourceNotUpdated ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			binding.ViewModel = source;

			// Act
			destination.Count = 999;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreNotEqual (destination.Count, source.Count);
		}

		[Test]
		public void PropertyToPropertyBinding_DifferentPropertySameType_BindedCorrectly ()
		{
			// Arrange
			ChartVM source = new ChartVM {
				BottomPadding = 0,
				LeftPadding = 0,
				RightPadding = 0,
				TopPadding = 0,
			};
			ChartVM destination = new ChartVM {
				BottomPadding = 10,
				LeftPadding = 10,
				RightPadding = 10,
				TopPadding = 10,
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
															  (vm) => ((ChartVM)vm).BottomPadding,
															  (vm) => ((ChartVM)vm).RightPadding);

			binding.ViewModel = source;

			// Act
			source.RightPadding = 999;

			// Assert
			Assert.AreNotEqual (source.BottomPadding, destination.BottomPadding);
			Assert.AreEqual (source.RightPadding, destination.BottomPadding);
		}

		[Test]
		public void PropertyToPropertyBinding_DestinationNotWritable_CannotBind ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			// Act & Assert
			// Maximum only has a getter
			Assert.Throws<InvalidOperationException> (() =>
													  new PropertyToPropertyBinding<int> (
														  destination,
														  (vm) => ((CountLimitationVM)vm).Maximum,
														  (vm) => ((CountLimitationVM)vm).Count)
													 );
		}

		[Test]
		public void PropertyToPropertyBinding_SetSource_DestinationUpdated ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			// Act
			binding.ViewModel = source;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreEqual (source, binding.ViewModel);
			Assert.AreEqual (source.Count, destination.Count);
			Assert.AreEqual (1, destination.Count);
		}

		[Test]
		public void PropertyToPropertyBinding_ChangedSource_BindedWithLast ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM source2 = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source2",
					RegisterName = "source2",
					Count = 2,
					Maximum = 10,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			// Act
			binding.ViewModel = source;
			binding.ViewModel = source2;
			source.Count = 777;
			source2.Count = 999;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreEqual ("source2", source2.DisplayName);
			Assert.AreEqual (source2, binding.ViewModel);
			Assert.AreEqual (source2.Count, destination.Count);
			Assert.AreNotEqual (source.Count, source2.Count);
		}

		[Test]
		public void PropertyToPropertyBinding_RemovedSource_Unbinded ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			// Act
			binding.ViewModel = source;
			binding.ViewModel = null;
			source.Count = 999;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreEqual (null, binding.ViewModel);
			Assert.AreNotEqual (source.Count, destination.Count);
			Assert.AreEqual (1, destination.Count);
		}

		[Test]
		public void PropertyToPropertyBinding_RemovedSourceAfterTrigger_Unbinded ()
		{
			// Arrange
			CountLimitationVM source = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "source",
					RegisterName = "source",
					Count = 1,
					Maximum = 5,
					Enabled = true
				}
			};
			CountLimitationVM destination = new CountLimitationVM {
				Model = new CountLicenseLimitation {
					DisplayName = "destination",
					RegisterName = "destination",
					Count = 0,
					Maximum = 0,
					Enabled = false
				}
			};

			var binding = new PropertyToPropertyBinding<int> (destination,
												(vm) => ((CountLimitationVM)vm).Count,
												(vm) => ((CountLimitationVM)vm).Count);

			// Act
			binding.ViewModel = source;
			source.Count = 999;
			binding.ViewModel = null;
			source.Count = 777;

			// Assert
			Assert.AreEqual ("destination", destination.DisplayName);
			Assert.AreEqual ("source", source.DisplayName);
			Assert.AreEqual (null, binding.ViewModel);
			Assert.AreNotEqual (source.Count, destination.Count);
			Assert.AreEqual (999, destination.Count);
		}
	}
}
