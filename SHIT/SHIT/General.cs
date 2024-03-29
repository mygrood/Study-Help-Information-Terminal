﻿using Newtonsoft.Json;
using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Plugin.Calendar.Models;
using Android;
using Android.Content;


namespace SHIT
{

    public class General
    {
        public const string ApiUrl = "http://student.ngknn.ru:8001/api/";
        public const string dateFormat = "yyyy-MM-d";

        public static bool storagePerm = false;
        public static EventCollection Events { get; set; }

        //public static string folderPath = FileSystem.AppDataDirectory; 
        //public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        static string CalendSavesFile = "calendarEvents.json";

        public static string folderPath = GetExternalStorage();

        static string file = Path.Combine(folderPath, CalendSavesFile);

        /* 1 - банковское дело
         * 2 - логистика
         * 3 - право
         * 4 - экономика
         * 5 - архивоведение
         * 6 - товароведение
         * 7 - прикладная информатика и прогр
         * 8 - коммерция
         * 9 - дошкольное обр
         * 10 - преподавание в нач классах
         * 11 - музыкальное обр
         * 12 - страховое дело
         */
        public static int thisSpecialisation;


        public static DateTime DateTime;
        public static AdvancedEventModel thisEvent;
        public static int isEdit = 0;
        




        public static void SaveEvents()
        {                              

            EventCollection list = Events;
            

          
            int i = 0;
            List<AdvancedEventModel> listEv = new List<AdvancedEventModel>();
            foreach (var item in list)
            {
                ObservableCollection<AdvancedEventModel> eventModels = SortEvents(item.Value as ObservableCollection<AdvancedEventModel>);                
                foreach (AdvancedEventModel t in eventModels)
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

            if (String.IsNullOrEmpty(e)) return;
            // перезаписываем файл
            File.WriteAllText(file, e);
        }
        public static void OpenEvents()
        {            
            if (File.Exists(file))
            {
                string inputJSON = File.ReadAllText(file);
               
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
                //if (!General.Events.Keys.Contains(DateTime.MinValue))
                //{
                //    General.Events.Add(DateTime.MinValue, new ObservableCollection<AdvancedEventModel>());
                //    var todayEvents = General.Events[DateTime.MinValue] as ObservableCollection<AdvancedEventModel>;
                //    todayEvents.Add(new AdvancedEventModel
                //    {
                //        Name = "please",
                //        Description = "dont delete",
                //        date = DateTime.MinValue,
                //        Starting = new TimeSpan()
                //    });
                //}
                
            }           
        }
        public static void CalendarClear()
        {                       
            // удаляем файл
            File.Delete(file);
           
        }

        public static string GetExternalStorage()
        {
            Context context = Android.App.Application.Context;
            var filepath = context.GetExternalFilesDir("");
            return filepath.Path;
        }

        public static ObservableCollection<AdvancedEventModel> SortEvents(ObservableCollection<AdvancedEventModel> ev)
        {
            if (ev == null) return ev;
            AdvancedEventModel[] sortEv = new AdvancedEventModel[ev.Count];
            for (int i = 0; i < ev.Count; i++)
            {

                sortEv[i] = ev[i];
            }             
            AdvancedEventModel temp;
            for (int i = 0; i < sortEv.Length; i++)
            {
                for (int j = i+1; j < sortEv.Length; j++)
                {
                    if (sortEv[i].Starting>sortEv[j].Starting)
                    {
                        temp = sortEv[i];
                        sortEv[i] = sortEv[j];
                        sortEv[j] = temp;
                    }
                }
            }
           
            ObservableCollection<AdvancedEventModel> newEv = new ObservableCollection<AdvancedEventModel>(sortEv.ToList());
                      

            return newEv;
        }
    }

    
}
