using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHIT.Views.Calendar.Model;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;
using SHIT.Views.Calendar.Pages;

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

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if (BindingContext is AdvancedEventModel)
            {
                AdvancedEventModel advancedEventModel = (AdvancedEventModel)BindingContext;
                General.thisEvent = advancedEventModel;
                General.isEdit = 1;
                await Navigation.PushAsync(new EditEventPage());
            }
            
            
        }
        
    }
}