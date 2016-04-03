using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Controls;

namespace Municpl.Views
{
    public class BaseNavigationAwarePage : Page
    {
        public BaseNavigationAwarePage()
        {
            //if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                //HardwareButtons.BackPressed += OnBackPressed;
        }

        private void OnBackPressed(object sender, BackPressedEventArgs e)
        {
            GoBack();
        }

        protected virtual void GoBack()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
