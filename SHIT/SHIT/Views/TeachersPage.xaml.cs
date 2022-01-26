using Newtonsoft.Json;
using Plugin.Messaging;
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
    public partial class TeachersPage : ContentPage
    {
        public TeachersPage()
        {
            InitializeComponent();

            lvT.ItemsSource = SortTeachers(GetTeachers());
        }

        private List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                //+groupId+"/"
                string api = General.ApiUrl + "teachers/";
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    teachers = JsonConvert.DeserializeObject<List<Teacher>>(result);
                                    
                    return teachers;
                }
            }

            catch (Exception ex)
            {
                //DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");

                return teachers;

            }
        }


        private List<Teacher> SortTeachers(List<Teacher> listT)
        {
            if (listT == null) return listT;
           
            listT.Sort((left, right) => left.name.CompareTo(right.name));

            return listT;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Написать?", "Да", "Нет");
            if (result)
            {
                var source = (Label)sender;
                var email = source.Text;

                var emailMessenger = CrossMessaging.Current.EmailMessenger;
                if (emailMessenger.CanSendEmail)
                {
                    emailMessenger.SendEmail(email);
                }
            }
        }
    }
}