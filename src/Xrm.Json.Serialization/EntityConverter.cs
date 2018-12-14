namespace Xrm.Json.Serialization
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;

    public class EntityConverter : JsonConverter
    {
        #region Public Methods

        public override bool CanConvert(Type objectType) =>
            objectType == typeof(Entity);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            serializer.ContractResolver = new XrmContractResolver();

            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.ContractResolver = new XrmContractResolver();

            var entity = value as Entity;

            writer.WriteStartObject();
            writer.WritePropertyName("_reference");
            writer.WriteValue($"{entity?.LogicalName}:{entity?.Id.ToString()}");

            foreach (var attribute in entity?.Attributes)
            {
                writer.WritePropertyName(attribute.Key);
                serializer.Serialize(writer, attribute.Value);
            }

            writer.WriteEndObject();
        }

        #endregion Public Methods
    }
}