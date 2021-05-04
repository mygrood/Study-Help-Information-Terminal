using Android.Text.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]    

    public partial class TimeTablePage : ContentPage
    {

        DateTime todayDate;
        int dayOfWeekInt;
        System.DayOfWeek day;

        public TimeTablePage()
        {
            InitializeComponent();
            todayDate = DateTime.Now;
            dayOfWeekInt = (int)todayDate.DayOfWeek;
            day = todayDate.DayOfWeek;
            int daymin = day - System.DayOfWeek.Monday;
            DateTime startweek = todayDate.AddDays(-daymin);
            datemonTT.Text = startweek.ToLongDateString();
            datetueTT.Text = startweek.AddDays(1).ToLongDateString();
            datewedTT.Text = startweek.AddDays(2).ToLongDateString();
            datethuTT.Text = startweek.AddDays(3).ToLongDateString();
            datefriTT.Text = startweek.AddDays(4).ToLongDateString();
            datesatTT.Text = startweek.AddDays(5).ToLongDateString();
            datesunTT.Text = startweek.AddDays(6).ToLongDateString();
          


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            switch (dayOfWeekInt)
            {
                //sunday
                case 0:
                    {
                        titlesunTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblsunTT.TextColor = Color.WhiteSmoke;
                        datesunTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, sunTT.Y, true);

                        break;
                    }
                //monday
                case 1:
                    {
                        titlemonTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblmonTT.TextColor = Color.WhiteSmoke;
                        datemonTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, monTT.Y, true);
                        break;
                    }
                //tuesday
                case 2:
                    {
                        titletueTT.Style = this.Resources["todayTTTitle"] as Style;
                        lbltueTT.TextColor = Color.WhiteSmoke;
                        datetueTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, tueTT.Y, true);
                        break;
                    }
                //wednesday
                case 3:
                    {
                        titlewedTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblwedTT.TextColor = Color.WhiteSmoke;
                        datewedTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, wedTT.Y, true);
                        break;
                    }
                //thursday
                case 4:
                    {
                        titlethuTT.Style = this.Resources["todayTTTitle"] as Style;
                        lbltueTT.TextColor = Color.WhiteSmoke;
                        datethuTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, thuTT.Y, true);
                        break;
                    }
                //friday
                case 5:
                    {
                        titlefriTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblfriTT.TextColor = Color.WhiteSmoke;
                        datefriTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, friTT.Y, true);
                        break;
                    }
                //saturday
                case 6:
                    {
                        titlesatTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblsatTT.TextColor = Color.WhiteSmoke;
                        datesatTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, satTT.Y, true);
                        break;
                    }






            }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("тап по дню", "тут должна открыться страничка с днем и подробностями", "ок");
        }

        
    }
}