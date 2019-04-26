namespace Innofactor.Xrm.Json.Serialization
{
    using System;
    using Newtonsoft.Json;

    public class DateTimeConverter : JsonConverter
    {
        #region Public Methods

        public override bool CanConvert(Type objectType) =>
            objectType == typeof(DateTime);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = DateTime.Parse(reader.ReadAsString());
            reader.Read();

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("_moment");
            writer.WriteValue((((DateTime)value).ToString()));
            writer.WriteEndObject();
        }

        #endregion Public Methods
    }
}