using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Twitty.Geo
{
       [Serializable]

    [DataContract]
    public class Coordinate
    {
        public float Longitude { get; set; }

        public float Latitude { get; set; }

       internal class Converter : JsonConverter
       {
           public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
           {
               //TODO: override it
           }

           public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
           {
               try
               {
                   var result = existingValue as Collection<Coordinate> ??
                                                   new Collection<Coordinate>();

                   var startDepth = reader.Depth;

                   if (reader.TokenType != JsonToken.StartArray)
                   {
                       return null;
                   }

                   double count = 1;

                   while (reader.Read() && reader.Depth > startDepth)
                   {
                       if (((IList) new[] {JsonToken.StartArray, JsonToken.EndArray}).Contains(reader.TokenType))
                           continue;

                       var itemIndex = Convert.ToInt32(Math.Ceiling(count / 2) - 1);

                       if (count % 2 > 0)
                       {
                           result.Add(new Coordinate());
                           result[itemIndex].Latitude = (float) Convert.ToDouble(reader.Value);
                       }
                       else
                       {
                           result[itemIndex].Longitude = (float) Convert.ToDouble(reader.Value);
                       }

                       count++;
                   }
                   return result;
               }
               catch
               {
                   return null;
               }
           }

           public override bool CanConvert(Type objectType)
           {
               return objectType == typeof(Collection<Coordinate>);
           }
       }
    }
}
