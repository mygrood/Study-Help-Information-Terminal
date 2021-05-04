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

        AdvancedEventModel thisEventEdit;

        public EditEventPage()
        {
            InitializeComponent();
            if (General.isEdit==0)
            {
                dpDate.Date = General.DateTime;
                btnDelete.IsVisible = false;
                btnChanges.IsVisible = false;
            }
            else
            {
                btnSave.IsVisible = false;
                thisEventEdit = General.thisEvent;
                dpDate.Date=thisEventEdit.date;
                tpTime.Time = thisEventEdit.Starting;
                entrName.Text = thisEventEdit.Name;
                entrDescription.Text = thisEventEdit.Description;

            }
            
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
                    General.OpenEvents();
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
            

            if (General.Events.ContainsKey(d))
            {
                
                var todayEvents = General.Events[d] as ObservableCollection<AdvancedEventModel>;

                if (todayEvents==null)
                {
                    DisplayAlert("какова хуя", "todayEvents==null", "ok");
                    return;
                }

                todayEvents.Add(new AdvancedEventModel()
                {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time,
                });


                //List<AdvancedEventModel> todayEvents = null;
                //foreach (var item in ev)
                //{
                //    if (item.Key==d)
                //    {
                //        todayEvents = (List<AdvancedEventModel>)item.Value;
                //    }
                //}



              

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

            
        }

        private void btnChanges_Clicked(object sender, EventArgs e)
        {
            if (dpDate.Date == null || tpTime.Time == null || entrName.Text == null || entrDescription.Text == null)
            {
                DisplayAlert("что-то не так", "Все поля должны быть заполнены", "ок");
            }
            else
            {
                EventCollection ev = General.Events;
                ObservableCollection<AdvancedEventModel> aemList = new ObservableCollection<AdvancedEventModel>();

                string Name = entrName.Text;
                string Description = entrDescription.Text;
                DateTime date = dpDate.Date;
                TimeSpan Starting = tpTime.Time;

                AdvancedEventModel newEvent = new AdvancedEventModel()
                {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time,
                };

                foreach (var item in ev)
                {
                    aemList = (ObservableCollection<AdvancedEventModel>)item.Value;
                    if (aemList.Contains(thisEventEdit))
                    {
                        aemList.Remove(thisEventEdit);
                        aemList.Add(newEvent);
                    }                    
                }
                General.Events = ev;
                               
            }
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            EventCollection ev = General.Events;
            ObservableCollection<AdvancedEventModel> aemList = new ObservableCollection<AdvancedEventModel>();

            

            foreach (var item in ev)
            {
                aemList = (ObservableCollection<AdvancedEventModel>)item.Value;
                if (aemList.Contains(thisEventEdit))
                {
                    aemList.Remove(thisEventEdit);                    
                }
            }
            General.Events = ev;
        }
    }
}