using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SHIT.Views.Calendar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditEventPage : ContentPage
    {
        public EditEventPage()
        {
            InitializeComponent();
            dpDate.Date = General.DateTime;
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (dpDate.Date == null || tpTime.Time == null || entrName.Text == null)
            {
                DisplayAlert("что-то не так", "Все поля должны быть заполнены", "ок");
            }
            else
            {
                DateTime d = dpDate.Date;

                if (General.Events.ContainsKey(d))
                {
                    var todayEvents = General.Events[d] as ObservableCollection<AdvancedEventModel>;
                    todayEvents.Add(new AdvancedEventModel
                    {
                        Name = entrName.Text,
                        Description = entrDescription.Text,
                        date = d,
                        Starting = tpTime.Time
                    });

                }
                else
                {
                    General.Events.Add(d, new ObservableCollection<AdvancedEventModel>());

                    var todayEvents = General.Events[d] as ObservableCollection<AdvancedEventModel>;
                    todayEvents.Add(new AdvancedEventModel
                    {
                        Name = entrName.Text,
                        Description = entrDescription.Text,
                        date = d,
                        Starting = tpTime.Time
                    });

                    DisplayAlert("", "Сохранено", "я понял");
                }

                General.SaveEvents();

            }
        }
    }
}