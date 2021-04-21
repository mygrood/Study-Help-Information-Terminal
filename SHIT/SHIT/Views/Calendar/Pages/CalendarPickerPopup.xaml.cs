using Rg.Plugins.Popup.Pages;
using SHIT.Views.Calendar.Model;
using SHIT.Views.Calendar.PageModels;
using System;
using Xamarin.Forms.Xaml;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPickerPopup :PopupPage
    {
        private readonly Action<CalendarPickerResult> _onClosedPopup;

        
        public CalendarPickerPopup(Action<CalendarPickerResult> onClosedPopup)
        {
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
    }
}