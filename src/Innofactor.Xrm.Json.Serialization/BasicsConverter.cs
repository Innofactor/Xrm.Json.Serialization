namespace Innofactor.Xrm.Json.Serialization
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    public class BasicsConverter : JsonConverter
    {
        #region Public Methods

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string)
                || objectType == typeof(int)
                || objectType == typeof(double)
                || objectType == typeof(Guid);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();

            if (objectType == typeof(string))
            {
                return Finish(reader, reader.ReadAsString());
            }

            if (objectType == typeof(int))
            {
                return Finish(reader, (int)reader.ReadAsInt32());
            }

            if (objectType == typeof(double))
            {
                return Finish(reader, (double)reader.ReadAsDouble());
            }

            if (objectType == typeof(Guid))
            {
                return Finish(reader, new Guid(reader.ReadAsString()));
            }

            // Default to string rep
            return Finish(reader, reader.ReadAsString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName($"_{value.GetType().Name}");
            writer.WriteValue(Convert.ToString(value).Replace(',', '.')); // Deserialization will fail if decimal commas are used
            writer.WriteEndObject();
        }

        #endregion Public Methods

        #region Private Methods

        private T Finish<T>(JsonReader reader, T value)
        {
            reader.Read();
            return value;
        }


        #endregion Private Methods
    }
}