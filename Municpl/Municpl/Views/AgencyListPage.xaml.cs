using Municpl.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Municpl.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AgencyListPage : BaseNavigationAwarePage
    {
        public AgencyListPage()
            : base()
        {
            InitializeComponent();
        }

        public AgencyListViewModel ViewModel
        {
            get { return DataContext as AgencyListViewModel; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            await ViewModel.LoadItemsAsync();
        }

        private void agencyListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedItem = e.ClickedItem as AgencyItemViewModel;
            ViewModel.NavigationService.NavigateTo(nameof(RouteListPage));
        }
    }
}
