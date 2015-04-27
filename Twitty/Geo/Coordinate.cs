﻿using System;
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
                   Collection<Coordinate> result = existingValue as Collection<Coordinate>;

                   if (result == null)
                       result = new Collection<Coordinate>();

                   int startDepth = reader.Depth;

                   if (reader.TokenType != JsonToken.StartArray)
                   {
                       return null;
                   }

                   //int depth = reader.Depth + 1;
                   double count = 1;

                   while (reader.Read() && reader.Depth > startDepth)
                   {
                       if (((IList) new[] {JsonToken.StartArray, JsonToken.EndArray}).Contains(reader.TokenType))
                           continue;

                       int itemIndex = Convert.ToInt32(Math.Ceiling(count / 2) - 1);

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
