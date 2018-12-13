﻿namespace Xrm.Json.Serialization.Tests
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Xunit;

    public class EntityReferenceConverterTests
    {
        #region Public Methods

        [Fact]
        public void Can_Deserialize_EntityReference()
        {
            // Arrange
            var name = "test";
            var id = Guid.NewGuid();
            var expected = new EntityReference(name, id);
            var value = $"{{\"_reference\":\"{name}:{id.ToString()}\"}}";

            // Act
            var actual = JsonConvert.DeserializeObject<EntityReference>(value, new EntityReferenceConverter());

            // Assert
            Assert.Equal(expected.LogicalName, actual.LogicalName);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public void Can_Serialize_EntityReference()
        {
            // Arrange
            var name = "test";
            var id = Guid.NewGuid();
            var value = new EntityReference(name, id);
            var expected = $"{{\"_reference\":\"{name}:{id.ToString()}\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new EntityReferenceConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}