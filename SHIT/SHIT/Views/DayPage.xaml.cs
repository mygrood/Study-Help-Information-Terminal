using SHIT.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayPage : ContentPage
    {
        List<DayLesson> dayLessons = new List<DayLesson>();
        public DayPage()
        {
            InitializeComponent();
        }
        public DayPage(List<Lesson> lessons, bool isTop, DateTime date)
        {
            InitializeComponent();

            lblDay.Text = date.ToString("M");
            lblDayOfWeek.Text = date.ToString("dddd");       
                        
            if (lessons.Count == 0)
            {
                dayNoTT.IsVisible = true;
                dayTT.IsVisible = false;
            }
            else
            {
                GetLessons(lessons);
            }
            if (!isTop)
            {
                lblTopWeek.Text = "Нижняя неделя";
            }

            dayTT.ItemsSource = dayLessons;
        }

        public DayPage(List<Lesson> lessons,bool isTop,int dayofweek)
        {
                
            InitializeComponent();

            if (lessons.Count == 0)
            {
                dayNoTT.IsVisible = true;
                dayTT.IsVisible = false;
            }
            else
            {
                GetLessons(lessons);
            }
            if (!isTop)
            {
                lblTopWeek.Text = "Нижняя неделя";
            }

            switch (dayofweek)
            {
                //sunday
                case 0:
                    {
                        lblDayOfWeek.Text = "воскресенье";

                        break;
                    }
                //monday
                case 1:
                    {
                        lblDayOfWeek.Text = "понедельник";
                        break;
                    }
                //tuesday
                case 2:
                    {
                        lblDayOfWeek.Text = "вторник";
                        break;
                    }
                //wednesday
                case 3:
                    {
                        lblDayOfWeek.Text = "среда";
                        break;
                    }
                //thursday
                case 4:
                    {
                        lblDayOfWeek.Text = "четверг";
                        break;
                    }
                //friday
                case 5:
                    {
                        lblDayOfWeek.Text = "пятница";
                        break;
                    }
                //saturday
                case 6:
                    {
                        lblDayOfWeek.Text = "суббота";
                        break;
                    }
                default:
                    break;
            }



            dayTT.ItemsSource = dayLessons;
            
        }


        private void GetLessons(List<Lesson> lessons)
        {
            foreach (var item in lessons)
            {
                DayLesson dayL = new DayLesson();
                dayL.id = item.id;
                dayL.week_day = item.week_day;
                dayL.start_time = item.start_time;
                DateTime t = Convert.ToDateTime(item.start_time).AddMinutes(item.duration);
                dayL.end_time = t.ToString("HH:mm");
                dayL.group = item.group;
                dayL.is_top = item.is_top;
                dayL.subject = item.subject;
                dayL.teacher = item.teacher;
                dayL.classroom = item.classroom;

                dayLessons.Add(dayL);
            }
        }
    }
}