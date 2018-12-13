namespace Akvache.Dynamics.Tests.Converters
{
    using Akvache.Dynamics.Implementations.Converters;
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Xunit;

    public class OptionSetValueTests
    {
        #region Public Methods

        [Fact]
        public void Can_Serialize_OptionSet()
        {
            // Arrange
            var optionSet = new OptionSetValue(100);

            // Act
            var result = JsonConvert.SerializeObject(optionSet, Formatting.None, new OptionSetConvertor());

            // Assert
            Assert.Equal("{\"_option\":100}", result);
        }

        [Fact]
        public void Can_Deserialize_OptionSet()
        {
            // Arrange
            var optionSet = new OptionSetValue(100);
            var value = "{\"_option\":100}";

            // Act
            var result = JsonConvert.DeserializeObject<OptionSetValue>(value, new OptionSetConvertor());

            // Assert
            Assert.Equal(optionSet.Value, result.Value);
        }

        #endregion Public Methods
    }
}