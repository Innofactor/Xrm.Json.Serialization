namespace Xrm.Json.Serialization.Tests
{
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Xunit;

    public class OptionSetValueConverterTests
    {
        #region Public Methods

        [Fact]
        public void Can_Deserialize_OptionSet()
        {
            // Arrange
            var value = "{\"_option\":100}";
            var expected = new OptionSetValue(100);

            // Act
            var actual = JsonConvert.DeserializeObject<OptionSetValue>(value, new OptionSetConvertor());

            // Assert
            Assert.Equal(expected.Value, actual.Value);
        }

        [Fact]
        public void Can_Serialize_OptionSet()
        {
            // Arrange
            var value = new OptionSetValue(100);
            var expected = "{\"_option\":100}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new OptionSetConvertor());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}