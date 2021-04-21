using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHIT
{
    public partial class App : Application
    {
        public App()
        {            
            InitializeComponent();

            MainPage = new MainPage();

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
