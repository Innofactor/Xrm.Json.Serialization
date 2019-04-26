namespace Innofactor.Xrm.Json.Serialization.Tests
{
    using System;
    using Newtonsoft.Json;
    using Xunit;

    public class DateTimeConverterTests
    {
        #region Public Methods

        [Fact]
        public void DateTime_Can_Deserialize()
        {
            // Arrange
            var expected = DateTime.UtcNow;
            var value = $"{{\"_moment\":\"{expected.ToString()}\"}}";

            // Act
            var actual = JsonConvert.DeserializeObject<DateTime>(value, new DateTimeConverter());

            // Assert
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void DateTime_Can_Serialize()
        {
            // Arrange
            var value = DateTime.UtcNow;
            var expected = $"{{\"_moment\":\"{value.ToString()}\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new DateTimeConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}