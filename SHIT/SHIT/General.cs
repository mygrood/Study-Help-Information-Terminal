using Newtonsoft.Json;
using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Plugin.Calendar.Models;

namespace SHIT
{
    class General
    {

        
        public static EventCollection Events { get; set; }

        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static string CalendSavesFile = "calendarEvents.json";

        public static DateTime DateTime;





        public static void SaveEvents()
        {
            if (!General.Events.ContainsKey(DateTime.MinValue))
            {
                General.Events.Add(DateTime.MinValue, new ObservableCollection<AdvancedEventModel>());
                var todayEvents = General.Events[DateTime.MinValue] as ObservableCollection<AdvancedEventModel>;
                todayEvents.Add(new AdvancedEventModel
                {
                    Name = "please",
                    Description = "dont delete",
                    date = DateTime.MinValue,
                    Starting = new TimeSpan()
                });

            }
                        

            EventCollection list = Events;
            

          
            int i = 0;
            List<AdvancedEventModel> listEv = new List<AdvancedEventModel>();
            foreach (var item in list)
            {
                var todayEvents = General.Events[item.Key] as ObservableCollection<AdvancedEventModel>;

                
                foreach (var t in todayEvents)
                {
                    listEv.Add(t);
                    //writer.WriteStartObject();
                    ////writer.WritePropertyName(i.ToString());

                    //var jsonvalue = JsonConvert.SerializeObject(t);

                    //writer.WriteValue(jsonvalue);                         
                    //writer.WriteEndObject();
                    //i++;    
               }             

            }
            //writer.WriteEndArray();

            string e = JsonConvert.SerializeObject(listEv);

            

            //JsonSerializerSettings settings = new JsonSerializerSettings { Converters = new[] { new MyConverterCalendar() } };
            //string output = JsonConvert.SerializeObject(General.Events,settings);

            //if (String.IsNullOrEmpty(e)) return;
            // перезаписываем файл
            File.WriteAllText(Path.Combine(folderPath, CalendSavesFile), e);
        }
        public static void OpenEvents()
        {            
            if (File.Exists(Path.Combine(folderPath, CalendSavesFile)))
            {
                string inputJSON = File.ReadAllText(Path.Combine(folderPath, CalendSavesFile));
               
                var results = JsonConvert.DeserializeObject<List<AdvancedEventModel>>(inputJSON);
               // ObservableCollection<AdvancedEventModel> inputDes = new ObservableCollection<AdvancedEventModel>(results);

                Dictionary<DateTime,List<AdvancedEventModel>> EvNew = new Dictionary<DateTime, List<AdvancedEventModel>>();
                ObservableCollection<AdvancedEventModel> tD = new ObservableCollection<AdvancedEventModel>();
                foreach (var item in results)
                {
                    Console.WriteLine(item.Name," ",item.Description);
                    if (EvNew.Keys.Contains(Convert.ToDateTime(item.date.ToShortDateString())))
                    {
                        EvNew[Convert.ToDateTime(item.date.ToShortDateString())].Add(item);
                    }
                    else
                    {
                        List<AdvancedEventModel> evList = new List<AdvancedEventModel>();
                        evList.Add(item);
                        EvNew.Add(Convert.ToDateTime(item.date.ToShortDateString()),evList);
                    }
                }

                foreach (var item in EvNew)
                {
                    if(!General.Events.Keys.Contains(item.Key))
                        General.Events.Add(item.Key, item.Value);
                }              
                

            }
        }
        public static void CalendarClear()
        {                       
            // удаляем файл
            File.Delete(Path.Combine(folderPath, CalendSavesFile));
           
        }        
       
    }

    
}
