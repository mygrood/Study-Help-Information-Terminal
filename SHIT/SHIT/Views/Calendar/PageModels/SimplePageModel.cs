﻿using Xamarin.Plugin.Calendar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using SHIT.Views.Calendar.Model;
using Rg.Plugins.Popup.Services;
using SHIT.Views.Calendar.Pages;

namespace SHIT.Views.Calendar.PageModels
{
    public class SimplePageModel : BasePageModel, INotifyPropertyChanged
    {
        public ICommand DayTappedCommand => new Command<DateTime>(async (date) => await DayTapped(date));
        public ICommand SwipeLeftCommand => new Command(() => { MonthYear = MonthYear.AddMonths(2); });
        public ICommand SwipeRightCommand => new Command(() => { MonthYear = MonthYear.AddMonths(-2); });
        public ICommand SwipeUpCommand => new Command(() => { MonthYear = DateTime.Today; });

        public ICommand OpenPickerCommand => new Command(async () =>
        {
            
        });

       public ICommand EventSelectedCommand => new Command(async (item) =>  ExecuteEventSelectedCommand(item));

        public SimplePageModel() : base()
        {
            
            Culture = CultureInfo.CreateSpecificCulture("ru");


            // testing all kinds of adding events
            // when initializing collection
            //General.Events = new EventCollection();
                //{
            //    //[DateTime.Now.AddDays(-3)] = new List<AdvancedEventModel>(GenerateEvents(10, "Cool")),
            //    //[DateTime.Now.AddDays(-6)] = new DayEventCollection<AdvancedEventModel>(Color.Purple, Color.Purple)
            //    //{
            //    //    new AdvancedEventModel { Name = "Cool event1", Description = "This is Cool event1's description!", Starting= new DateTime() },
            //    //    new AdvancedEventModel { Name = "Cool event2", Description = "This is Cool event2's description!", Starting= new DateTime()}
            //    //}
            //};

            ////Adding a day with a different dot color
            //General.Events.Add(DateTime.Now.AddDays(-2), new DayEventCollection<AdvancedEventModel>(GenerateEvents (10, "Cool")) { EventIndicatorColor = Color.Blue, EventIndicatorSelectedColor = Color.Blue });
            //General.Events .Add(DateTime.Now.AddDays(-4), new DayEventCollection<AdvancedEventModel>(GenerateEvents (10, "Cool")) { EventIndicatorColor = Color.Green, EventIndicatorSelectedColor = Color.White });
            //General.Events .Add(DateTime.Now.AddDays(-5), new DayEventCollection<AdvancedEventModel>(GenerateEvents (10, "Cool")) { EventIndicatorColor = Color.Orange, EventIndicatorSelectedColor = Color.Orange });

            //// with add method
            //General.Events .Add(DateTime.Now.AddDays(-1), new List<AdvancedEventModel>(GenerateEvents(5, "Cool")));

            //// with indexer
            //General.Events[DateTime.Now] = new List<AdvancedEventModel>(GenerateEvents (2, "Boring"));

           

            //Task.Delay(5000).ContinueWith(_ =>
            //{
            //    // indexer - update later
            //    General.Events[DateTime.Now] = new ObservableCollection<AdvancedEventModel>(GenerateEvents(10, "Cool"));

            //    // add later
            //    General.Events.Add(DateTime.Now.AddDays(3), new List<AdvancedEventModel>(GenerateEvents(5, "Cool")));

            //    // indexer later
            //    General.Events[DateTime.Now.AddDays(10)] = new List<AdvancedEventModel>(GenerateEvents(10, "Boring"));

            //    // add later
            //    General.Events.Add(DateTime.Now.AddDays(15), new List<AdvancedEventModel>(GenerateEvents(10, "Cool")));


            //    Task.Delay(3000).ContinueWith(t =>
            //    {
                    

            //        // get observable collection later
            //        var todayEvents = General.Events[DateTime.Now] as ObservableCollection<AdvancedEventModel>;

            //        // insert/add items to observable collection
            //        todayEvents.Insert(0, new AdvancedEventModel { Name = "Cool event insert", Description = "This is Cool event's description!", Starting = new DateTime() });
            //        todayEvents.Add(new AdvancedEventModel { Name = "Cool event add", Description = "This is Cool event's description!", Starting = new DateTime() });

            //    }, TaskScheduler.FromCurrentSynchronizationContext());
            //}, TaskScheduler.FromCurrentSynchronizationContext());
        }

        //private IEnumerable<AdvancedEventModel> GenerateEvents(int count, string name)
        //{
        //    return Enumerable.Range(1, count).Select(x => new AdvancedEventModel
        //    {
        //        Name = $"{name} event{x}",
        //        Description = $"This is {name} event{x}'s description!",
        //        Starting = new DateTime(2000, 1, 1, (x * 2) % 24, (x * 3) % 60, 0)
        //    });
        //}

       

        private DateTime _monthYear = DateTime.Today;
        public DateTime MonthYear
        {
            get => _monthYear;
            set => SetProperty(ref _monthYear, value);
        }

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }


        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value); //INotifyPropertyChanged
        }

        private static async Task DayTapped(DateTime date)
        {
            var message = $"Касание по дате: {date}";
            //await App.Current.MainPage.DisplayAlert("День", message, "Ок");
            Console.WriteLine(message);
        }

        private async void ExecuteEventSelectedCommand(object item)
        {
            //return item;
            if (item is AdvancedEventModel eventModel)
            {
                var title = $"{eventModel.Name}";
                var message = "Начало: " + eventModel.Starting + "\nОписание: " + eventModel.Description;
                await App.Current.MainPage.DisplayAlert(title, message, "ок");
                Console.WriteLine(message);
            }
        }
    }
}