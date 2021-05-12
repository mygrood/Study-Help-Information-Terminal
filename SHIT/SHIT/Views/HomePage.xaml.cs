using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void btnRequest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage());

        }

        private void btnAbout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
           // DisplayAlert("Информация", "тут должна быть основная информация о колледже: " +
           //     "полное и сокращенное название, адрес главного корпуса, имя директора, телефон секретаря", "я понял");
        }

        private void btnSpecialization_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SpecializationPage());
        }

        private void btnTeachers_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAllLessons_Clicked(object sender, EventArgs e)
        {

        }
    }
}