using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEventPage : ContentPage
    {
        

        public EditEventPage()
        {
            InitializeComponent();
            dpDate.Date = General.DateTime;
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (dpDate.Date == null || tpTime.Time == null || entrName.Text == null || entrDescription.Text==null)
            {
                DisplayAlert("что-то не так", "Все поля должны быть заполнены", "ок");
            }
            else
            {
                try
                {
                    addEvent();
                }
                catch (Exception ex)
                {
                                        
                    DisplayAlert("ex", "Ошибка при создании объекта\n"+ ex.Message, "ok");
                }


                try
                {
                    General.SaveEvents();
                    DisplayAlert("", "Сохранено", "я понял");
                    Navigation.PopAsync();
                }
                catch (Exception ex)
                {

                    DisplayAlert("ex", "Ошибка при сохранении объекта\n" + ex.Message, "ok");
                }

                

            }
        }


        private void addEvent()
        {
            DateTime d = dpDate.Date;
            EventCollection ev = General.Events;

            if (General.Events.ContainsKey(d))
            {
                List<AdvancedEventModel> todayEvents = null;
                foreach (var item in ev)
                {
                    if (item.Key==d)
                    {
                        todayEvents = (List<AdvancedEventModel>)item.Value;
                    }
                }
               

                
                // insert/add items to observable collection
                todayEvents.Add(new AdvancedEventModel() {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time, });
                //EventCollection list = General.Events;



                //Dictionary<DateTime, List<AdvancedEventModel>> EvNew = new Dictionary<DateTime, List<AdvancedEventModel>>();
                //EvNew.Add(d, new List<AdvancedEventModel>() {
                //    new AdvancedEventModel() {
                //    Name = entrName.Text,
                //    Description = entrDescription.Text,
                //    date = dpDate.Date,
                //    Starting = tpTime.Time, } });

                //foreach (var item in EvNew)
                //{                    
                //        General.Events[item.Key]. item.Value);
                //}


                //list[Convert.ToDateTime(d.ToShortDateString())].Add(new AdvancedEventModel()
                //{
                //    Name = entrName.Text,
                //    Description = entrDescription.Text,
                //    date = dpDate.Date,
                //    Starting = tpTime.Time,
                //} );


            }
            else
            {
                General.Events.Add(d, new ObservableCollection<AdvancedEventModel>() {
                    new AdvancedEventModel() {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time, } });
       
                //var todayEvents = General.Events[d] as List<AdvancedEventModel>;
                //var ev = new AdvancedEventModel();
                   
                
                
            }

            General.Events = ev;
        }
    }
}