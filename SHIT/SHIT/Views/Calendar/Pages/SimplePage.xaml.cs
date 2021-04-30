using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplePage : ContentPage
    {
        EventCollection ev = General.Events;

        public SimplePage()
        {
            Console.WriteLine(General.folderPath);            
            InitializeComponent();
            this.calendarS.Events = ev;
        }

        protected override void OnAppearing()
        {            
            
            base.OnAppearing();
           

        }
    }
}