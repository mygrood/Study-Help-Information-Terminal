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
                entrFio.Text = null;
                entrGroup.Text = null;
                entrSum.Text = null;
                entrWhy.Text = null;
                DisplayAlert("Заявка принята", "Справка будет готова через 3-5 дней", "я понял");
            }
            
        }
    }
}