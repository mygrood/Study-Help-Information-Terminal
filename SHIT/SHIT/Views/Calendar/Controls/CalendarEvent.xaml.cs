﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIT.Views.Calendar.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace SHIT.Views.Calendar.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarEvent : ContentView
    {
        public static BindableProperty CalendarEventCommandProperty =
            BindableProperty.Create(nameof(CalendarEventCommand), typeof(ICommand), typeof(CalendarEvent), null);

        public CalendarEvent()
        {
            InitializeComponent();
        }

        public ICommand CalendarEventCommand
        {
            get => (ICommand)GetValue(CalendarEventCommandProperty);
            set => SetValue(CalendarEventCommandProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (BindingContext is AdvancedEventModel eventModel)
            {
                //CalendarEventCommand?.Execute(eventModel);
            }
        }

    }
}