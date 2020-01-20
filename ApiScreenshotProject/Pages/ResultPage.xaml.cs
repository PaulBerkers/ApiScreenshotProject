using System;
using System.Net;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ApiScreenshotProject.Classes;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ApiScreenshotProject.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultPage : Page
    {

        string url;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ResultPage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if ((Show)e.Parameter == null)
            {

            }
            else
            {
                Show s = (Show)e.Parameter;

                url += s.url;
                DownloadImage(url);

                if (url.ToLower().Contains("/"))
                {
                    string result = url.Substring(0, url.IndexOf("/"));
                    img.Source = null;
                    BitmapImage image = new BitmapImage(new Uri(@"C:\Users\PaulB\source\repos\ApiScreenshotProject\ApiScreenshotProject\bin\x86\Debug\AppX\" + result + ".jpeg", UriKind.Absolute));
                    img.Source = image;
                }
                else
                {
                    img.Source = null;
                    BitmapImage image = new BitmapImage(new Uri(@"C:\Users\PaulB\source\repos\ApiScreenshotProject\ApiScreenshotProject\bin\x86\Debug\AppX\" + url + ".jpeg", UriKind.Absolute));
                    img.Source = image;
                }

            }
        }

        private const string ApiFlashEndpoint = "https://api.apiflash.com/v1/urltoimage";

        public static void DownloadImage(string url)
        {
            using (var webClient = new WebClient())
            {
                var parameters = System.Web.HttpUtility.ParseQueryString(string.Empty);
                parameters["access_key"] = "6219faeccf684802aa051e82ba340a8f";
                parameters["url"] = $"https://{url}";
                parameters["full_page"] = "true";
                parameters["scroll_page"] = "true";
                parameters["fresh"] = "true";

                if (url.ToLower().Contains("/"))
                {
                    string result = url.Substring(0, url.IndexOf("/"));
                    webClient.DownloadFile(ApiFlashEndpoint + "?" + parameters, $"{result}.jpeg");

                }
                else
                {
                    webClient.DownloadFile(ApiFlashEndpoint + "?" + parameters, $"{url}.jpeg");

                }

            }
        }
    }
}
