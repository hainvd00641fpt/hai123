using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ASM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            string appName = Windows.ApplicationModel.Package.Current.DisplayName;
          //  NavView.MenuItemsSource = new NavViewItems();
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if(args.IsSettingsSelected){
                myframe.Navigate(typeof(View.SignUp1));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "signUp":
                        myframe.Navigate(typeof(View.SignUp1));
                        NavView.Header = "Sign Up";
                        break;
                    case "signIn":
                        myframe.Navigate(typeof(View.SignIn));
                        break;
                    case "information":
                        myframe.Navigate(typeof(View.Information));
                        break;
                    case "music":
                        myframe.Navigate(typeof(Music.Music));
                        break;
                    case "updataMusic":
                        myframe.Navigate(typeof(Music.Music));
                        break;

                }
            }
        }

    }
}
