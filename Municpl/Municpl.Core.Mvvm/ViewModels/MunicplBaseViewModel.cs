using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Municpl.Core.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Municpl.Core.ViewModels
{
    public class MunicplBaseViewModel : ViewModelBase
    {
        public INavigationService NavigationService { get; protected set; }

        public INextbusDataService NextbusDataService { get; protected set; }

        protected MunicplBaseViewModel()
        {

        }

        protected MunicplBaseViewModel(string id, string title, INavigationService navigationService = null, INextbusDataService nextbusDataService = null)
        {
            Id = id;
            Title = title;

            NavigationService = navigationService ?? SimpleIoc.Default.GetInstance<INavigationService>();
            NextbusDataService = nextbusDataService ?? SimpleIoc.Default.GetInstance<INextbusDataService>();
        }

        public string Id { get; set; }

        private string _title = String.Empty;
        public string Title
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        private bool _isLoaded = false;
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { Set(ref _isLoaded, value); }
        }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        protected void HandleException(Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.Message);

            ShowMessageDialogAsync(String.Format("There was an error: {0}", ex.Message), "Uh-oh!").ContinueWith((task) => { return; }, TaskContinuationOptions.OnlyOnCanceled);
        }

        protected async Task ShowMessageDialogAsync(string message, string title)
        {
            // TODO
        }

        public virtual void Initialize(object parameter)
        {
            // For overriding
        }
    }
}
