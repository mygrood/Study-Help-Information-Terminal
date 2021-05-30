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
    public partial class SpecializationPage : ContentPage
    {
        int thisSpecialization = Helpers.Settings.Specialization;

        public SpecializationPage()
        {
            InitializeComponent();
        }

        
        private void Bank_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization==0)
            {
                General.thisSpecialisation = 1;
                Helpers.Settings.Specialization = 1;
                Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
            }
            else
            {
                General.thisSpecialisation = 1;
                Helpers.Settings.Specialization = 1;
            }

        }

        private void Logist_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 2;
                Helpers.Settings.Specialization = 2;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 2;
                Helpers.Settings.Specialization = 2;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Pravo_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 3;
                Helpers.Settings.Specialization = 3;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 3;
                Helpers.Settings.Specialization = 3;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Economika_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 4;
                Helpers.Settings.Specialization = 4;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 4;
                Helpers.Settings.Specialization = 4;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Arkhiv_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 5;
                Helpers.Settings.Specialization = 5;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 5;
                Helpers.Settings.Specialization = 5;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Tovar_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 6;
                Helpers.Settings.Specialization = 6;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());

            }
            else
            {
                General.thisSpecialisation = 6;
                Helpers.Settings.Specialization = 6;
                Navigation.PushAsync(new GroupPage());
            }
        }

            private void IT_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 7;
                Helpers.Settings.Specialization = 7;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 7;
                Helpers.Settings.Specialization = 7;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Commerce_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 8;
                Helpers.Settings.Specialization = 8;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 8;
                Helpers.Settings.Specialization = 8;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Doshkolnoe_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 9;
                Helpers.Settings.Specialization = 9;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 9;
                Helpers.Settings.Specialization = 9;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void School_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 10;
                Helpers.Settings.Specialization = 10;
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 10;
                Helpers.Settings.Specialization = 10;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Music_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 11;
                Helpers.Settings.Specialization = 11;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 11;
                Helpers.Settings.Specialization = 11;
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void Strah_Tapped(object sender, EventArgs e)
        {
            if (thisSpecialization == 0)
            {
                General.thisSpecialisation = 12;
                Helpers.Settings.Specialization = 12;
                //Navigation.PushAsync(new NavigationPage(new MainPage()) { BarBackgroundColor = Color.DarkRed });
                Navigation.PushAsync(new GroupPage());
            }
            else
            {
                General.thisSpecialisation = 12;
                Helpers.Settings.Specialization = 12;
                Navigation.PushAsync(new GroupPage());
            }
        }
    }
}