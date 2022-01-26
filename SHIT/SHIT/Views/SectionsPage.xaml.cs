using Newtonsoft.Json;
using SHIT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionsPage : ContentPage
    {
        public SectionsPage()
        {
            

            InitializeComponent();

            lvS.ItemsSource= GetSections();
        }

        private List<Section> GetSections()
        {
            List<Section> sections = new List<Section>();
            try
            {
                //+groupId+"/"
                string api = General.ApiUrl + "sections/";
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    sections = JsonConvert.DeserializeObject<List<Section>>(result);

                    foreach (var item in sections)
                    {
                        item.image = General.ApiUrl.Remove(General.ApiUrl.Length-1) + item.image;
                    }

                    return sections;
                }
            }

            catch (Exception ex)
            {
                //DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");

                return sections;

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Label send = (Label)sender;

            string uri = send.Text;
            
            Launcher.OpenAsync(new Uri(uri));

        }
    }
}