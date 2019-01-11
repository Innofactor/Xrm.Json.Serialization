namespace Innofactor.Xrm.Json.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    internal class XrmContractResolver : DefaultContractResolver
    {
        #region Private Fields

        private readonly Dictionary<Type, JsonConverter> converters;

        #endregion Private Fields

        #region Public Constructors

        public XrmContractResolver()
        {
            converters = new Dictionary<Type, JsonConverter>()
            {
                { typeof(EntityCollection), new EntityCollectionConverter() },
                { typeof(Entity), new EntityConverter() },
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
}