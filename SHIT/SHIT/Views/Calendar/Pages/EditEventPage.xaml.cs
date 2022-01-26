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
        DateTime dateTime;
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
                dateTime = thisEventEdit.date;
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
                AdvancedEventModel newEvent = new AdvancedEventModel()
                {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time,
                };
                try
                {
                    addEvent(newEvent);
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


        private void addEvent( AdvancedEventModel eventModel)
        {
            DateTime d = dpDate.Date;
            

            if (General.Events.ContainsKey(d))
            {
              
               ObservableCollection<AdvancedEventModel> todayEvents;
                
                foreach (var item in General.Events)
                {
                    
                    if (item.Key==d)
                    {
                        AdvancedEventModel[] array;
                        array = new AdvancedEventModel[item.Value.Count+1];
                        item.Value.CopyTo( array,0);
                        
                        if (array == null)
                        {
                            //DisplayAlert("какого чёрта", "todayEvents==null", "ok");
                            return;
                        }
                        Console.WriteLine(array.Length);
                        array[array.Length-1] = eventModel;
                        General.Events[d] = new ObservableCollection<AdvancedEventModel>(array.ToList());
                        return;
                    }
                    

                  

                }





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
                General.Events.Add(d, new ObservableCollection<AdvancedEventModel>() { eventModel });
       
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


                AdvancedEventModel newEvent = new AdvancedEventModel()
                {
                    Name = entrName.Text,
                    Description = entrDescription.Text,
                    date = dpDate.Date,
                    Starting = tpTime.Time,
                };

                foreach (var item in General.Events)
                {

                    if (item.Key == dateTime)
                    {
                        AdvancedEventModel[] array;
                        array = new AdvancedEventModel[item.Value.Count + 1];
                        item.Value.CopyTo(array, 0);

                        if (array == null)
                        {
                           // DisplayAlert("какого чёрта", "todayEvents==null", "ok");
                            return;
                        }
                        AdvancedEventModel[] newArray = { thisEventEdit};
                        array = (from x in array where !newArray.Contains(x) select x).ToArray();
                        Array.Resize(ref array, array.Length - 1);
                        General.Events[dateTime] = new ObservableCollection<AdvancedEventModel>(array.ToList());
                        break;
                    }
                }

                addEvent(newEvent);

                General.SaveEvents();
                DisplayAlert("", " Изменения сохранены", "я понял");
                General.OpenEvents();
                Navigation.PopAsync();

            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы уверены, что хотите удалить событие?", "Да","Нет");
            if (result)
            {
                EventCollection ev = General.Events;
                ObservableCollection<AdvancedEventModel> aemList = new ObservableCollection<AdvancedEventModel>();

                foreach (var item in General.Events)
                {
                    if (item.Key == dateTime)
                    {
                        AdvancedEventModel[] array;
                        array = new AdvancedEventModel[item.Value.Count];
                        item.Value.CopyTo(array, 0);

                        if (array[0] == null)
                        {
                           // DisplayAlert("какого чёрта", "todayEvents==null", "ok");
                            return;
                        }
                        AdvancedEventModel[] newArray = { thisEventEdit };
                        array = (from x in array where !newArray.Contains(x) select x).ToArray();
                        //Array.Resize(ref array, array.Length - 1);
                        General.Events[dateTime] = new ObservableCollection<AdvancedEventModel>(array.ToList());
                        break;
                    }
                }
               
                General.SaveEvents();
                DisplayAlert("", "Сохранено", "я понял");
                General.OpenEvents();
                Navigation.PopAsync();
            }
            
        }
    }
}