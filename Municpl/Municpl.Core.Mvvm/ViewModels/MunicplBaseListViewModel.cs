using GalaSoft.MvvmLight.Views;
using Municpl.Core.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.ViewModels
{
    public class MunicplBaseListViewModel<T> : MunicplBaseViewModel
    {
        protected MunicplBaseListViewModel(string id, string title, INavigationService navigationService = null, INextbusDataService nextbusDataService = null)
            : base(id, title, navigationService, nextbusDataService)
        {
            Items = new ObservableCollection<T>();
        }

        private T _selectedItem;
        public T SelectedItem
        {
            get { return _selectedItem; }
            set { Set(nameof(SelectedItem), ref _selectedItem, value); }
        }

        private ObservableCollection<T> _items;
        public ObservableCollection<T> Items
        {
            get { return _items; }
            set { Set(nameof(Items), ref _items, value); }
        }

        public async Task LoadItemsAsync(bool refresh = false)
        {
            if (IsLoading)
                return;

            if (IsLoaded && !refresh)
                return;

            IsLoading = true;

            try
            {
                var items = await GetItemsAsync();

                foreach (var i in items)
                    Items.Add(i);

                IsLoaded = true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            IsLoading = false;
        }

        protected virtual async Task<IEnumerable<T>> GetItemsAsync()
        {
            throw new NotImplementedException("You must override GetItemsAsync() when inheriting from BaseListViewModel<T>");
        }
    }
}
