using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Plugin.Calendar.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SHIT.Views.Calendar.PageModels;
using SHIT.Views.Calendar.Model;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SHIT.Views.Calendar.Pages;

namespace SHIT.Views.Calendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarFooter : ContentView
    {
        public CalendarFooter()
        {
            InitializeComponent();
        }

        private async void btnAddEvent_Clicked(object sender, EventArgs e)
        {

            General.isEdit = 0;
            General.DateTime = Convert.ToDateTime(lblSelected.Text);
            await Navigation.PushAsync(new EditEventPage());


            //if (General.Events.ContainsKey(DateTime.Now.AddDays(1)))
            //{
            //    var todayEvents = General.Events[DateTime.Now.AddDays(1)] as ObservableCollection<AdvancedEventModel>;
            //    todayEvents.Add(new AdvancedEventModel { Name = "1 event add",
            //        Description = "This is Cool event's description!", 
            //        date=DateTime.Now,
            //        Starting = new TimeSpan() });

            //}
            //else
            //{
            //    General.Events.Add(DateTime.Now.AddDays(1), new ObservableCollection<AdvancedEventModel>());

            //    var todayEvents = General.Events[DateTime.Now.AddDays(1)] as ObservableCollection<AdvancedEventModel>;
            //    todayEvents.Add(new AdvancedEventModel
            //    {
            //        Name = "1 event add",
            //        Description = "This is Cool event's description!",
            //        date = DateTime.Now,
            //        Starting = new TimeSpan()
            //    }) ;


            //}

            //General.SaveEvents();
            //General.OpenEvents();

        }
    }
}