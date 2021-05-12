using Plugin.Messaging;
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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void phone_Tapped(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы уверены, что хотите удалить событие?", "Да", "Нет");
            if (result)
            {
                var source = (Label)sender;
                var phone = source.Text;

                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                {
                    phoneDialer.MakePhoneCall(phone);
                }
            }
        }
    }
}