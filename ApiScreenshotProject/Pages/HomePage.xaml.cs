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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ApiScreenshotProject.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public Show Show { get; set; } = new Show();
        public HomePage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ResultPage), Show);
        }
    }
    public class Show
    {
        private string _url;

        public string url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
