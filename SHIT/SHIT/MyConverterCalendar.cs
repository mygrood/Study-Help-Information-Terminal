using Newtonsoft.Json;
using SHIT.Views.Calendar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Plugin.Calendar.Models;

namespace SHIT
{
    public class MyConverterCalendar : JsonConverter
    {
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            EventCollection list = value as EventCollection;
            writer.WriteStartArray();
            foreach (var item in list)
            {
                writer.WriteStartObject();

                writer.WritePropertyName(item.Key.ToShortDateString());
                var jsonvalue = JsonConvert.SerializeObject(item.Value);
                writer.WriteValue(jsonvalue);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObservableCollection<KeyValuePair<DateTime, ObservableCollection<AdvancedEventModel>>>);
        }

    }
}
