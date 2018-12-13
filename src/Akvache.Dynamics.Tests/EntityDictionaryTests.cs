namespace Akvache.Dynamics.Tests
{
    using System;
    using System.IO;
    using Akvache.Dynamics.Implementations;
    using Microsoft.Xrm.Sdk;
    using Xunit;

    public class EntityDictionaryTests
    {
        #region Public Methods

        [Fact]
        public void EntityDictionary_Can_Store_And_Retrieve_Value()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new Entity("test", id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"{nameof(EntityDictionaryTests)}.db");

            // Act
            var dictionary = new PersistentDictionary<string, Entity>(path)
            {
                ["test"] = entity
            };

            var result = dictionary["test"];

            // Assert
        }

        #endregion Public Methods
    }
}