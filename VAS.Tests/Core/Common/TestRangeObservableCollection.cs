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
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;
using VAS.Core.Common;

namespace VAS.Tests.Core.Common
{
	[TestFixture ()]
	public class TestRangeObservableCollection
	{
		RangeObservableCollection<int> collection;
		int index;
		NotifyCollectionChangedAction actionPerformed;

		[SetUp ()]
		public void SetUp ()
		{
			if (collection != null) {
				collection.CollectionChanged -= CollectionChanged;
			}
			collection = new RangeObservableCollection<int> (new List<int> { 0, 1, 2, 3, 4 });
			index = -2;
			actionPerformed = NotifyCollectionChangedAction.Move;
			collection.CollectionChanged += CollectionChanged;
		}

		[Test ()]
		public void TestAddRange ()
		{
			int indexToVerify;

			indexToVerify = collection.Count;
			collection.AddRange (new List<int> { 5, 6 });

			Assert.AreEqual (indexToVerify, index);
			Assert.AreEqual (7, collection.Count);
			Assert.AreEqual (6, collection.Last ());
			Assert.AreEqual (actionPerformed, NotifyCollectionChangedAction.Add);
		}

		[Test ()]
		public void TestRemoveRange ()
		{
			collection.RemoveRange (new List<int> { 1, 3 });

			Assert.AreEqual (3, collection.Count);
			Assert.AreEqual (2, collection [1]);
			Assert.AreEqual (actionPerformed, NotifyCollectionChangedAction.Remove);
		}

		[Test ()]
		public void TestInsertRange ()
		{
			collection.InsertRange (2, new List<int> { 5, 6 });

			Assert.AreEqual (2, index);
			Assert.AreEqual (5, collection [index]);
			Assert.AreEqual (actionPerformed, NotifyCollectionChangedAction.Add);
		}

		[Test ()]
		public void TestReplace ()
		{
			RangeObservableCollection<int> collectionToReplace = new RangeObservableCollection<int> (new List<int> { 5, 6, 7 });
			collection.Replace (collectionToReplace);

			Assert.AreEqual (collection, collectionToReplace);
			Assert.AreEqual (actionPerformed, NotifyCollectionChangedAction.Reset);
		}

		void CollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add) {
				index = e.NewStartingIndex;
			}
			actionPerformed = e.Action;
		}
	}
}