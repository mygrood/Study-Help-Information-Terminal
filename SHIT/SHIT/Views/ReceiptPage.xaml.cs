using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SHIT.Models;
using System.Net;
using System.IO;

namespace SHIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceiptPage : ContentPage
    {
        List<string> r = new List<string>();
        public ReceiptPage()
        {
            r = GetGroups();

            InitializeComponent();
            cbGroup.ItemsSource = r;

        }

        private void btnSendReceipt_Clicked(object sender, EventArgs e)
        {
            if (entrFio.Text == null || cbGroup.Text == null || entrSum.Text == null || entrWhy.Text == null)
            {
                DisplayAlert("что-то не так", "Все поля должны быть заполнены", "ок");
            }
            else
            {
                Receipt receipt = new Receipt();
                receipt.group = cbGroup.Text;
                receipt.student = entrFio.Text;
                string date = dpBirthday.Date.ToString("yyyy-MM-d");
                receipt.birthday = date;
                receipt.quantity = Convert.ToInt32( entrSum.Text);
                receipt.where = entrWhy.Text;
                if (entrMilitaryCom.Text==null)
                {
                    receipt.military_commissariat = "";
                }
                else
                {
                    receipt.military_commissariat = entrMilitaryCom.Text;
                }                
                receipt.is_active = true;

                string api = General.ApiUrl + "receipts/";
                var request = (HttpWebRequest)WebRequest.Create(api);
                request.Method = "POST";

               request.ContentType = "application/json";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(receipt);
                    streamWriter.Write(json);
                }

                HttpWebResponse respose = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(respose.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    //DisplayAlert("", result, "ok");                     
                }

                DisplayAlert("Заявка принята", "Справка будет готова через 3-5 дней", "я понял");
                Navigation.PopAsync();
            }
            
        }


        public List<string> GetGroups()
        {
            List<string> groups = new List<string>();
            try
            {
                // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

                string api = General.ApiUrl+"groups/";
                var httpRequestGroup = (HttpWebRequest)WebRequest.Create(api);
                httpRequestGroup.Method = "GET";
                httpRequestGroup.ContentType = "application/json";
                var httpResponseGroup = (HttpWebResponse)httpRequestGroup.GetResponse();
                using (var streamReader = new StreamReader(httpResponseGroup.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    List<Root> myroot = JsonConvert.DeserializeObject<List<Root>>(result);

                    foreach (var item in myroot)
                    {
                        groups.Add(item.name);
                    }

                    return groups;
                }
            }

            catch (Exception ex)
            {
                //DisplayAlert("ex", ex.Message, "ok");
                DisplayAlert("ex", "Ошибка подключения к серверу", "ok");
                return groups;

            }

        }

        private void entrWhy_Completed(object sender, EventArgs e)
        {
            if (entrWhy.Text=="Военкомат"|| entrWhy.Text == "военкомат" || entrWhy.Text == "военкомат " || entrWhy.Text == "Военкомат ")
            {
                stMilCom.IsVisible = true;
            }
            else
            {
                stMilCom.IsVisible = false;
            }
        }

        public Func<string, ICollection<string>, ICollection<string>> SortingAlgorithm { get; } =
            (text, values) => values
                .Where(x => x.ToLower().StartsWith(text.ToLower()))
                .OrderBy(x => x)
                .ToList();

        private void cbGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbGroup.ItemsSource=SortingAlgorithm(cbGroup.Text, r);
        }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
    }


}