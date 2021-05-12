using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SHIT.Models;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPage : ContentPage
    {
        public RequestPage()
        {
            InitializeComponent();
        }

        private void btnSendRequest_Clicked(object sender, EventArgs e)
        {
            if (entrFio.Text == null || entrGroup.Text == null || entrSum.Text == null || entrWhy.Text == null)
            {
                DisplayAlert("что-то не так", "Все поля должны быть заполнены", "ок");
            }
            else
            {
                RequestModel request = new RequestModel();
                request.Group = entrGroup.Text;
                request.Student = entrFio.Text;
                request.Birthday = dpBirthday.Date;
                request.Quantity = Convert.ToInt32( entrSum.Text);
                request.Where = entrWhy.Text;
                request.Is_Active = true;
               
                
                DisplayAlert("Заявка принята", "Справка будет готова через 3-5 дней", "я понял");
                Navigation.PopAsync();
            }
            
        }
    }
}