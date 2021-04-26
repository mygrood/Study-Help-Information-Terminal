using Rg.Plugins.Popup.Pages;
using SHIT.Views.Calendar.Model;
using SHIT.Views.Calendar.PageModels;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPickerPopup :PopupPage
    {
        private readonly Action<CalendarPickerResult> _onClosedPopup;

        private SimplePage SimplePage;
        
        public CalendarPickerPopup(Action<CalendarPickerResult> onClosedPopup,SimplePage simple)
        {
            SimplePage = simple;
            _onClosedPopup = onClosedPopup;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is CalendarPickerPopupModel vm)
                vm.Closed += _onClosedPopup;
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is CalendarPickerPopupModel vm)
                vm.Closed -= _onClosedPopup;

            base.OnDisappearing();
        }

        public ICommand SuccessCommand => new Command(async () =>
        {
           
        });

    }
}