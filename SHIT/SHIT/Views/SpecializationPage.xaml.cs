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
        public SpecializationPage()
        {
            InitializeComponent();
        }

        
        private void Bank_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 1;
            
        }

        private void Logist_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 2;
        }

        private void Pravo_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 3;
        }

        private void Economika_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 4;
        }

        private void Arkhiv_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 5;
        }

        private void Tovar_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 6;
        }

        private void IT_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 7;
        }

        private void Commerce_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 8;
        }

        private void Doshkolnoe_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 9;
        }

        private void School_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 10;
        }

        private void Music_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 11;
        }

        private void Strah_Tapped(object sender, EventArgs e)
        {
            General.thisSpecialisation = 12;
        }
    }
}