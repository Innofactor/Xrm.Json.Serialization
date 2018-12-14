namespace Xrm.Json.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class EntityConverter : JsonConverter
    {
        #region Public Constructors

        public EntityConverter()
        {
            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    Converters = new List<JsonConverter>
            //    {
            //        new EntityReferenceConverter(),
            //        new MoneyConverter(),
            //        new OptionSetConvertor()
            //    }
            //};
        }

        #endregion Public Constructors

        #region Public Methods

        public override bool CanConvert(Type objectType) =>
            objectType == typeof(Entity);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.ContractResolver = new EntityContactResolver();

            var entity = value as Entity;

            writer.WriteStartObject();
            writer.WritePropertyName("_reference");
            writer.WriteValue($"{entity?.LogicalName}:{entity?.Id.ToString()}");
            
            foreach(var attribute in entity?.Attributes)
            {
                writer.WritePropertyName(attribute.Key);
                serializer.Serialize(writer, attribute.Value);
            }

            writer.WriteEndObject();
        }

        #endregion Public Methods

        #region Private Classes

        private class EntityContactResolver : DefaultContractResolver
        {
            #region Private Fields

            private readonly Dictionary<Type, JsonConverter> converters;

            #endregion Private Fields

            #region Public Constructors

            public EntityContactResolver()
            {
                converters = new Dictionary<Type, JsonConverter>()
                {
                    { typeof(EntityReference), new EntityReferenceConverter() },
                    { typeof(Money), new MoneyConverter() },
                    { typeof(OptionSetValue), new OptionSetConvertor()}
                };
            }

            #endregion Public Constructors

            #region Protected Methods

            protected override JsonConverter ResolveContractConverter(Type objectType) => 
                converters[objectType];

            #endregion Protected Methods
        }

        #endregion Private Classes
    }
}