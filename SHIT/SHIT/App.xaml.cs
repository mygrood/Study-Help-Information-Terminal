using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Newtonsoft.Json;
using Xamarin.Plugin.Calendar.Models;
using Android;
using Plugin.Permissions;
using SHIT.Views;

namespace SHIT
{
    public partial class App : Application
    {

       
        public Account acc = new Account { Username = "user" };
        public App()
        {
            Console.WriteLine( General.folderPath);   
            
            General.Events = new EventCollection();
            General.OpenEvents();

            int specialKey = Helpers.Settings.Specialization;
                
            InitializeComponent();     
                        

            if (specialKey==0)
            {
                MainPage = new SpecializationPage();
            }
            else
            {
                MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor=Color.DarkRed}; 
            }
            
           

        }

        protected override async void OnStart()
        {
            PermissionStatus status = (PermissionStatus)await CrossPermissions.Current.RequestPermissionAsync<StoragePermission>();

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
