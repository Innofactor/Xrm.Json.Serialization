﻿namespace Xrm.Json.Serialization.Tests
{
    using System;
    using Innofactor.Xrm.Json.Serialization;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Xunit;

    public class EntityConverterTests
    {
        #region Public Methods

        [Fact]
        public void Entity_Can_Deserialize()
        {
            // Arrange
            var name = "test";
            var id = Guid.NewGuid();
            var expected = new Entity(name, id);
            expected.Attributes.Add("attribute1", new OptionSetValue(1));
            var value = $"{{\"_reference\":\"{name}:{id.ToString()}\",\"attribute1\":{{\"_option\":1}}}}"; ;

            // Act
            var actual = JsonConvert.DeserializeObject<Entity>(value, new EntityConverter());

            // Assert
            Assert.Equal(expected.LogicalName, actual.LogicalName);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal((expected.Attributes["attribute1"] as OptionSetValue).Value, (actual.Attributes["attribute1"] as OptionSetValue).Value);
        }

        [Fact]
        public void Entity_Can_Serialize()
        {
            // Arrange
            var name = "test";
            var id = Guid.NewGuid();
            var value = new Entity(name, id);
            value.Attributes.Add("attribute1", new OptionSetValue(1));
            var expected = $"{{\"_reference\":\"{name}:{id.ToString()}\",\"attribute1\":{{\"_option\":1}}}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new EntityConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}