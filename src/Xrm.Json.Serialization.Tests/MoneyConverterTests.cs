namespace Xrm.Json.Serialization.Tests
{
    using Microsoft.Xrm.Sdk;
    using Newtonsoft.Json;
    using Xunit;

    public class MoneyConverterTests
    {
        #region Public Methods

        [Fact]
        public void Can_Deserialize_Money()
        {
            // Arrange
            var optionSet = new Money(9.95m);
            var value = "{\"_money\":9.95}";

            // Act
            var result = JsonConvert.DeserializeObject<OptionSetValue>(value, new MoneyConverter());

            // Assert
            Assert.Equal(optionSet.Value, result.Value);
        }

        [Fact]
        public void Can_Serialize_Money()
        {
            // Arrange
            var optionSet = new Money(9.95m);

            // Act
            var result = JsonConvert.SerializeObject(optionSet, Formatting.None, new MoneyConverter());

            // Assert
            Assert.Equal("{\"_money\":9.95}", result);
        }

        #endregion Public Methods
    }
}