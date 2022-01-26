using Android.Text.Format;
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

    public partial class TimeTablePage : ContentPage
    {

        DateTime todayDate;
        DateTime thisMonday;
        int dayOfWeekInt;
        System.DayOfWeek day;

        bool isNow;

        bool isTopWeek;

        List<Lesson> monLessons = new List<Lesson>();
        List<Lesson> tueLessons = new List<Lesson>();
        List<Lesson> wedLessons = new List<Lesson>();
        List<Lesson> thuLessons = new List<Lesson>();
        List<Lesson> friLessons = new List<Lesson>();
        List<Lesson> satLessons = new List<Lesson>();
        List<Lesson> sunLessons = new List<Lesson>();

        public TimeTablePage()
        {
            DateTime today = DateTime.Now;
            int dow = (int)today.DayOfWeek;
            int daymin = dow - (int)System.DayOfWeek.Monday;
            thisMonday = todayDate.AddDays(-daymin);

            isNow = true;

            InitializeComponent();



            setWeek(DateTime.Today);
            ScrollWeek();

        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            setWeek(DateTime.Today);
            ScrollWeek();

            int thisSpecialization = Helpers.Settings.Specialization;
           
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


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            string day = new { sender }.GetType().GetProperties()[0].Name;


            StackLayout dayS = (StackLayout)sender;

            if (dayS.Equals(monTT))
            {
                
                Navigation.PushAsync(new DayPage(monLessons, isTopWeek, Convert.ToDateTime(datemonTT.Text))); 
                
            }
            else if (dayS.Equals(tueTT))
            {
                Navigation.PushAsync(new DayPage(tueLessons, isTopWeek, Convert.ToDateTime(datetueTT.Text)));
            }
            else if (dayS.Equals(wedTT))
            {
                Navigation.PushAsync(new DayPage(wedLessons, isTopWeek, Convert.ToDateTime(datewedTT.Text)));
            }
            else if (dayS.Equals(thuTT))
            {
                Navigation.PushAsync(new DayPage(thuLessons, isTopWeek, Convert.ToDateTime(datethuTT.Text)));
            }
            else if (dayS.Equals(friTT))
            {
                Navigation.PushAsync(new DayPage(friLessons, isTopWeek, Convert.ToDateTime(datefriTT.Text)));
            }
            else if (dayS.Equals(satTT))
            {
                Navigation.PushAsync(new DayPage(satLessons, isTopWeek, Convert.ToDateTime(datesatTT.Text)));
            }
            else if (dayS.Equals(sunTT))
            {
                Navigation.PushAsync(new DayPage(sunLessons, isTopWeek, Convert.ToDateTime(datesunTT.Text)));
            }

        }

        private void btnMainTimeTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainTimeTablePage());
        }

        private void btnNextWeek_Clicked(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(datemonTT.Text);
            dt = dt.AddDays(7);
            if (dt == thisMonday)
            {
                isNow = true;
            }
            else
            {
                isNow = false;
            }

            setWeek(dt);
            ScrollWeek();
        }

        private void btnLastWeek_Clicked(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(datemonTT.Text);
            dt = dt.AddDays(-7);
            if (dt == thisMonday)
            {
                isNow = true;
            }
            else
            {
                isNow = false;
            }

            setWeek(dt);
            ScrollWeek();
        }

        private void setWeek(DateTime dt)
        {
            todayDate = dt;
            dayOfWeekInt = (int)todayDate.DayOfWeek;
            day = todayDate.DayOfWeek;
            int daymin = day - System.DayOfWeek.Monday;
            DateTime startweek = todayDate.AddDays(-daymin);

            DateTime datemon = startweek;
            DateTime datetue = startweek.AddDays(1);
            DateTime datewed = startweek.AddDays(2);
            DateTime datethu = startweek.AddDays(3);
            DateTime datefri = startweek.AddDays(4);
            DateTime datesat = startweek.AddDays(5);
            DateTime datesun = startweek.AddDays(6);

            isTopWeek = IsWeek(datemon);
            if (isTopWeek)
            {
                lblWeek.Text = "Верхняя неделя";
            }
            else
            {
                lblWeek.Text = "Нижняя неделя";
            }

            monLessons = SortTopLessons(SortChanges(GetLessons(datemon)), isTopWeek);
            tueLessons = SortTopLessons(SortChanges(GetLessons(datetue)), isTopWeek);
            wedLessons = SortTopLessons(SortChanges(GetLessons(datewed)), isTopWeek);
            thuLessons = SortTopLessons(SortChanges(GetLessons(datethu)), isTopWeek);
            friLessons = SortTopLessons(SortChanges(GetLessons(datefri)), isTopWeek);
            satLessons = SortTopLessons(SortChanges(GetLessons(datesat)), isTopWeek);
            sunLessons = SortTopLessons(SortChanges(GetLessons(datesun)), isTopWeek);

            if (monLessons.Count == 0)
            {
                noLMon.IsVisible = true;
            }
            else
            {
                lvMon.ItemsSource = monLessons;
            }


            if (tueLessons.Count == 0)
            {
                noLTue.IsVisible = true;
            }
            else
            {
                lvTue.ItemsSource = tueLessons;
            }


            if (wedLessons.Count == 0)
            {
                noLWed.IsVisible = true;
            }
            else
            {
                lvWed.ItemsSource = wedLessons;
            }


            if (thuLessons.Count == 0)
            {
                noLThu.IsVisible = true;
            }
            else
            {
                lvThu.ItemsSource = thuLessons;
            }


            if (friLessons.Count == 0)
            {
                noLFri.IsVisible = true;
            }
            else
            {
                lvFri.ItemsSource = friLessons;
            }


            if (satLessons.Count == 0)
            {
                noLSat.IsVisible = true;
            }
            else
            {
                lvSat.ItemsSource = satLessons;
            }

            if (sunLessons.Count == 0)
            {
                noLSun.IsVisible = true;
            }
            else
            {
                lvSun.ItemsSource = sunLessons;
            }



            datemonTT.Text = datemon.ToLongDateString();
            datetueTT.Text = datetue.ToLongDateString();
            datewedTT.Text = datewed.ToLongDateString();
            datethuTT.Text = datethu.ToLongDateString();
            datefriTT.Text = datefri.ToLongDateString();
            datesatTT.Text = datesat.ToLongDateString();
            datesunTT.Text = datesun.ToLongDateString();
        }


        private RootChanges GetLessons(DateTime date)
        {
            RootChanges rootChanges = new RootChanges();
            string groupId = Helpers.Settings.GroupId.ToString();
            string sdt = date.ToString(General.dateFormat);

            try
            {
                //api/lessons_with_changes/{group_id}/{date}/
                string api = General.ApiUrl + "lessons_with_changes/" + groupId + "/" + sdt + "/";
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    rootChanges = JsonConvert.DeserializeObject<RootChanges>(result);


                    return rootChanges;
                }
            }

            catch (Exception ex)
            {
                //DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");

                return rootChanges;

            }
        }

        private List<Lesson> SortChanges(RootChanges rootChanges)
        {
            List<Lesson> lessons = rootChanges.lessons;
            List<Change> changes = rootChanges.changes;


            foreach (var i in lessons)
            {
                foreach (var j in changes)
                {
                    if (j.lesson == i.id)
                    {
                        i.start_time = j.start_time;
                        i.duration = j.duration;
                        i.subject = j.subject;
                        i.teacher = j.teacher;
                        i.classroom = j.classroom;
                        i.is_top = null;
                    }
                }
            }

            return lessons;
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

        private bool IsWeek(DateTime date)
        {
            var year = date.Year;
            var begin = date.Month > 8 ? new DateTime(year, 09, 01) : new DateTime(year, 01, 01);

            var dayWeek = (int)begin.DayOfWeek;
            var week = Math.Ceiling((((date - begin).TotalMilliseconds / 1000 / 60 / 60 / 24 + dayWeek - 1) / 7));

            week = week % 2 != 0 ? 0 : 1;

            bool isTop = Convert.ToBoolean(week);
            return isTop;
        }

        private void ScrollWeek()
        {
            if (isNow)
            {
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
                            lblthuTT.TextColor = Color.WhiteSmoke;
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


        }
    }
}