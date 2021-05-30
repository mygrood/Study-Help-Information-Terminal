using Newtonsoft.Json;
using SHIT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        public GroupPage()
        {
            InitializeComponent();

            string idS = Helpers.Settings.Specialization.ToString();
            List<Group> groups = GetGroups(idS);                
            lvGroup.ItemsSource = groups;           


        }

        public List<Group> GetGroups(string idS)
        {
            List<Group> groups = null;
            try
            {
                string api = "http://student.ngknn.ru:8001/api/specialties/" + idS;
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    SpGroup spGroup = JsonConvert.DeserializeObject<SpGroup>(result);

                     groups = spGroup.groups;

                    return groups;
                }
            }

            catch (Exception ex)
            {
                DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");
                return groups;

            }
            
        }

        
        private void lvGroup_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Group g = (Group)e.Item;
            DisplayAlert(g.id.ToString(), g.name, "oj");
            int idG = g.id;

            int i = Helpers.Settings.GroupId;

            if (i==0)
            {
                Helpers.Settings.GroupId = g.id;
                Helpers.Settings.GroupName = g.name;
                Navigation.PushModalAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
            }
            else
            {
                Helpers.Settings.GroupId = g.id;
                Helpers.Settings.GroupName = g.name;
                Navigation.PopToRootAsync();
            }


        }
    }

    
}