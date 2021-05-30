using Newtonsoft.Json;
using SHIT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTimeTablePage : ContentPage
    {
        static DateTime todayDate = DateTime.Now;
        int dayOfWeekInt = (int)todayDate.DayOfWeek;

        List<Lesson> monLessons = new List<Lesson>();
        List<Lesson> tueLessons = new List<Lesson>();
        List<Lesson> wedLessons = new List<Lesson>();
        List<Lesson> thuLessons = new List<Lesson>();
        List<Lesson> friLessons = new List<Lesson>();
        List<Lesson> satLessons = new List<Lesson>();
        List<Lesson> sunLessons = new List<Lesson>();

        public MainTimeTablePage()
        {
            monLessons = GetTT(1);
            tueLessons = GetTT(2);
            wedLessons = GetTT(3);
            thuLessons = GetTT(4);
            friLessons = GetTT(5);
            satLessons = GetTT(6);
            sunLessons = GetTT(7);


            InitializeComponent();

            SetTT(true);

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
                        scrollView.ScrollToAsync(0, sunTT.Y, true);

                        break;
                    }
                //monday
                case 1:
                    {
                        titlemonTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblmonTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, monTT.Y, true);
                        break;
                    }
                //tuesday
                case 2:
                    {
                        titletueTT.Style = this.Resources["todayTTTitle"] as Style;
                        lbltueTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, tueTT.Y, true);
                        break;
                    }
                //wednesday
                case 3:
                    {
                        titlewedTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblwedTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, wedTT.Y, true);
                        break;
                    }
                //thursday
                case 4:
                    {
                        titlethuTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblthuTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, thuTT.Y, true);
                        break;
                    }
                //friday
                case 5:
                    {
                        titlefriTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblfriTT.TextColor = Color.WhiteSmoke;
                        scrollView.ScrollToAsync(0, friTT.Y, true);
                        break;
                    }
                //saturday
                case 6:
                    {
                        titlesatTT.Style = this.Resources["todayTTTitle"] as Style;
                        lblsatTT.TextColor = Color.WhiteSmoke;
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

            lblGroup.Text = Helpers.Settings.GroupName;
        }

        private void swIsTop_Toggled(object sender, ToggledEventArgs e)
        {
            bool t = swIsTop.IsToggled;
            if (t)
            {
                swLbl.Text = "Верхняя неделя";                
            }
            else
            {
                swLbl.Text = "Нижняя неделя";                
            }
            SetTT(t);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            string day = new { sender }.GetType().GetProperties()[0].Name;

            bool t = swIsTop.IsToggled;


            StackLayout dayS = (StackLayout)sender;

            if (dayS.Equals(monTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(monLessons, t),t,1));
            }
            else if (dayS.Equals(tueTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(tueLessons, t), t,2));
            }
            else if (dayS.Equals(wedTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(wedLessons, t), t,3));
            }
            else if (dayS.Equals(thuTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(thuLessons, t), t,4));
            }
            else if (dayS.Equals(friTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(friLessons, t), t,5));
            }
            else if (dayS.Equals(satTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(satLessons, t), t,6));
            }
            else if (dayS.Equals(sunTT))
            {
                Navigation.PushAsync(new DayPage(SortTopLessons(sunLessons, t), t,0));
            }

        }

        private List<Lesson> GetTT(int wd)
        {
            List<Lesson> listLessons = new List<Lesson>();
            string groupId = Helpers.Settings.GroupId.ToString();
            string swd = wd.ToString();
            try
            {
                //+groupId+"/"
                string api = General.ApiUrl + "lessons/" + groupId + "/" + swd + "/";
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    listLessons = JsonConvert.DeserializeObject<List<Lesson>>(result);

                    return listLessons;
                }
            }

            catch (Exception ex)
            {
                DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");

                return listLessons;

            }
        }

        private List<Lesson> SortTopLessons(List<Lesson> listLessons, bool isTop)
        {
            if (listLessons == null) return listLessons;
            List<Lesson> lessons = new List<Lesson>();

            //сортировка верх/низ
            foreach (var item in listLessons)
            {
                if (item.is_top == isTop || item.is_top == null)
                {
                    item.start_time = Convert.ToDateTime(item.start_time).ToString("HH:mm");
                    lessons.Add(item);
                }
            }
            if (lessons == null) return lessons;

            //сортировка по времени
            Lesson[] sortL = lessons.ToArray();
            Lesson temp;
            for (int i = 0; i < sortL.Length; i++)
            {
                for (int j = i + 1; j < sortL.Length; j++)
                {
                    DateTime sli = Convert.ToDateTime(sortL[i].start_time);
                    DateTime slj = Convert.ToDateTime(sortL[j].start_time);
                    if (sli > slj)
                    {
                        temp = sortL[i];
                        sortL[i] = sortL[j];
                        sortL[j] = temp;
                    }
                }
            }
            lessons = sortL.ToList();

            return lessons;
        }

        private void SetTT(bool isTop)
        {
            List<Lesson> monIsTop = SortTopLessons(monLessons, isTop);
            if (monIsTop.Count == 0)
            {
                noLMon.IsVisible = true;
            }
            else
            {
                lvMon.ItemsSource = monIsTop;
            }

            List<Lesson> tueIsTop = SortTopLessons(tueLessons, isTop);
            if (tueIsTop.Count == 0)
            {
                noLTue.IsVisible = true;
            }
            else
            {
                lvTue.ItemsSource = tueIsTop;
            }

            List<Lesson> wedIsTop = SortTopLessons(wedLessons, isTop);
            if (wedIsTop.Count == 0)
            {
                noLWed.IsVisible = true;
            }
            else
            {
                lvWed.ItemsSource = wedIsTop;
            }

            List<Lesson> thuIsTop = SortTopLessons(thuLessons, isTop);
            if (thuIsTop.Count == 0)
            {
                noLThu.IsVisible = true;
            }
            else
            {
                lvThu.ItemsSource = thuIsTop;
            }

            List<Lesson> friIsTop = SortTopLessons(friLessons, isTop);
            if (friIsTop.Count == 0)
            {
                noLFri.IsVisible = true;
            }
            else
            {
                lvFri.ItemsSource = friIsTop;
            }

            List<Lesson> satIsTop = SortTopLessons(satLessons, isTop);
            if (satIsTop.Count == 0)
            {
                noLSat.IsVisible = true;
            }
            else
            {
                lvSat.ItemsSource = satIsTop;
            }

            List<Lesson> sunIsTop = SortTopLessons(sunLessons, isTop);
            if (sunIsTop.Count == 0)
            {
                noLSun.IsVisible = true;
            }
            else
            {
                lvSun.ItemsSource = sunIsTop;
            }
        }
    }
}