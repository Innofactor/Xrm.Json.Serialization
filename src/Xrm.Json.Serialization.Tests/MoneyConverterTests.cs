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
            var result = JsonConvert.DeserializeObject<Money>(value, new MoneyConverter());

            // Assert
            Assert.Equal(optionSet.Value, result.Value);
        }

        [Fact]
        public void Can_Serialize_Money()
        {
            // Arrange
            var value = new Money(9.95m);
            var expected = "{\"_money\":9.95}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new MoneyConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}