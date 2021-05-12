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

            int thisSpecialization = Helpers.Settings.Specialization;

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

            switch (thisSpecialization)
            {
                case 1:
                    lblSpecialization.Text = "Банковское дело";
                    break;
                case 2:
                    lblSpecialization.Text = "Операционная деятельность в логистике";
                    break;
                case 3:
                    lblSpecialization.Text = "Право и организация соц.обеспечения";
                    break;
                case 4:
                    lblSpecialization.Text = "Экономика и бухгалтерский учет";
                    break;
                case 5:
                    lblSpecialization.Text = "Документация и архивоведение";
                    break;
                case 6:
                    lblSpecialization.Text = "Товароведение";
                    break;
                case 7:
                    lblSpecialization.Text = "Прикладная информатика и программирование";
                    break;
                case 8:
                    lblSpecialization.Text = "Коммерция";
                    break;
                case 9:
                    lblSpecialization.Text = "Дошкольное образование";
                    break;
                case 10:
                    lblSpecialization.Text = "Преподавание в начальных классах";
                    break;
                case 11:
                    lblSpecialization.Text = "Музыкальное образование";
                    break;
                case 12:
                    lblSpecialization.Text = "Страховое дело";
                    break;
                default:
                    break;
            }

        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("тап по дню", "тут должна открыться страничка с днем и подробностями", "ок");
        }

        
    }
}