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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.Interfaces.MVVMC;

namespace VAS.Core.MVVMC
{
	/// <summary>
	/// Base class for ViewModel representing a collection of ViewModel, like for example a list
	/// of <see cref="VAS.Core.Store.Templates.Dashboard"/>.
	/// The base class keeps in sync the ViewModel and the Model collection and provides support
	/// for selecting items within the collection.
	/// </summary>
	public class CollectionViewModel<TModel, TViewModel> : NestedViewModel<TViewModel>
		where TViewModel : IViewModel<TModel>, new()
	{
		protected bool editing;
		protected Dictionary<TModel, TViewModel> modelToViewModel;
		protected RangeObservableCollection<TModel> model;
		IViewModelFactoryService viewModelFactory;

		public CollectionViewModel ()
		{
			Model = new RangeObservableCollection<TModel> ();
			viewModelFactory = App.Current.DependencyRegistry.Retrieve<IViewModelFactoryService> ();
		}

		protected override void DisposeManagedResources ()
		{
			ViewModels.IgnoreEvents = true;
			Model.IgnoreEvents = true;
			ViewModels.CollectionChanged -= HandleViewModelsCollectionChanged;
			Model.CollectionChanged -= HandleModelsCollectionChanged;
			base.DisposeManagedResources ();
			modelToViewModel.Clear ();
			Model = null;
		}

		/// <summary>
		/// Gets or sets the model used in this ViewModel.
		/// </summary>
		/// <value>The model.</value>
		public RangeObservableCollection<TModel> Model {
			set {
				SetModel (value);
			}
			get {
				return model;
			}
		}

		/// <summary>
		/// Selects the specified item from the list.
		/// </summary>
		/// <param name="item">The item to select.</param>
		public void Select (TModel item)
		{
			if (item == null) {
				return;
			}
			Select (ViewModels.FirstOrDefault (vm => vm.Model.Equals (item)));
		}

		protected virtual void SetModel (RangeObservableCollection<TModel> model)
		{
			if (ViewModels != null) {
				ViewModels.CollectionChanged -= HandleViewModelsCollectionChanged;
				ViewModels.Clear ();
			}
			if (this.model != null) {
				this.model.CollectionChanged -= HandleModelsCollectionChanged;
			}
			modelToViewModel = new Dictionary<TModel, TViewModel> ();
			this.model = model;
			if (Disposed || model == null) {
				return;
			}
			AddViewModels (0, this.model);
			ViewModels.CollectionChanged += HandleViewModelsCollectionChanged;
			this.model.CollectionChanged += HandleModelsCollectionChanged;
		}

		protected virtual void AddViewModels (int index, IEnumerable<TModel> models)
		{
			if (models == null) {
				return;
			}

			var viewModels = new List<TViewModel> ();
			foreach (TModel tModel in models) {
				// It is possible that some viewmodel has been created first as dependency of another
				var viewModel = GetOrCreateViewModel (tModel);
				viewModels.Add (viewModel);
			}
			ViewModels.InsertRange (index, viewModels);
		}

		protected virtual TViewModel CreateInstance (TModel model)
		{
			var vm = viewModelFactory.CreateViewModel<TViewModel, TModel> (model);
			modelToViewModel [model] = vm;
			return vm;
		}

		protected TViewModel GetOrCreateViewModel (TModel model)
		{
			if (modelToViewModel.ContainsKey (model)) {
				return modelToViewModel [model];
			}

			var viewModel = CreateInstance (model);
			if (!modelToViewModel.ContainsKey (model)) {
				modelToViewModel [model] = viewModel;
			}
			return viewModel;
		}

		protected virtual void HandleViewModelsCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (editing) {
				return;
			}
			editing = true;
			switch (e.Action) {
			case NotifyCollectionChangedAction.Add:
				model.InsertRange (e.NewStartingIndex, e.NewItems.OfType<TViewModel> ().Select ((arg) => arg.Model));
				foreach (TViewModel vm in e.NewItems) {
					modelToViewModel [vm.Model] = vm;
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				model.RemoveRange (e.OldItems.OfType<TViewModel> ().Select ((arg) => arg.Model));
				foreach (TViewModel vm in e.OldItems) {
					modelToViewModel [vm.Model] = vm;
				}
				break;
			case NotifyCollectionChangedAction.Replace:
				model.Reset (ViewModels.Select (vm => vm.Model));
				foreach (TViewModel vm in ViewModels) {
					modelToViewModel [vm.Model] = vm;
				}

				break;
			case NotifyCollectionChangedAction.Reset:
				model.Reset (ViewModels.Select (vm => vm.Model));
				modelToViewModel.Clear ();
				foreach (TViewModel vm in ViewModels) {
					modelToViewModel.Add (vm.Model, vm);
				}
				break;
			}
			editing = false;
		}

		protected virtual void HandleModelsCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (editing) {
				return;
			}
			editing = true;
			switch (e.Action) {
			case NotifyCollectionChangedAction.Add:
				AddViewModels (e.NewStartingIndex, e.NewItems.OfType<TModel> ());
				break;
			case NotifyCollectionChangedAction.Remove:
				ViewModels.RemoveRange (e.OldItems.OfType<TModel> ().Select ((arg) => modelToViewModel [arg]));
				foreach (TModel model in e.OldItems) {
					modelToViewModel.Remove (model);
				}
				break;
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Reset:
				ViewModels.Clear ();
				AddViewModels (0, Model);
				break;
			}
			editing = false;
		}
	}
}
