using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Newtonsoft.Json;
using Xamarin.Plugin.Calendar.Models;

namespace SHIT
{
    public partial class App : Application
    {

        public Account acc = new Account { Username = "user" };
        public App()
        {
                        
            
            InitializeComponent();          


            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor=Color.DarkRed}; 

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
