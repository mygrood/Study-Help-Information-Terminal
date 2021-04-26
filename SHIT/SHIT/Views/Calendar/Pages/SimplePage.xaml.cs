using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplePage : ContentPage
    {
        public SimplePage()
        {            
            InitializeComponent();
            General.OpenEvents();            
            this.calendarS.Events = General.Events;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}