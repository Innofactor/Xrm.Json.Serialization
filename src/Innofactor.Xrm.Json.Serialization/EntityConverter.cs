namespace Innofactor.Xrm.Json.Serialization
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
            reader.Read();

            var reference = EntityReferenceConverter.GetReference(reader);
            var entity = new Entity(reference.LogicalName, reference.Id);

            reader.Read();

            while (reader.TokenType != JsonToken.EndObject)
            {
                // Reading attribute name
                var key = reader.Value.ToString();
                var value = default(object);

                // Noving to next token
                reader.Read();
                if (reader.TokenType == JsonToken.StartObject)
                {
                    // Skipping to first property of the object
                    reader.Read();

                    switch (reader.Value.ToString())
                    {
                        case "_option":
                            // Skipping to property value of the object
                            value = new OptionSetValue((int)reader.ReadAsInt32());
                            reader.Read();
                            break;

                        case "_reference":
                            // Skipping to property value of the object
                            value = EntityReferenceConverter.GetReference(reader);
                            reader.Read();
                            break;

                        case "_money":
                            // Skipping to property value of the object
                            value = new Money((decimal)reader.ReadAsDecimal());
                            reader.Read();
                            break;
                    }
                }
                else
                {
                    value = serializer.Deserialize(reader);
                }

                entity.Attributes.Add(key, value);

                // Skipping closing object definition
                reader.Read();
            }

            return entity;
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