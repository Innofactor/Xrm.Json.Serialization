namespace Xrm.Json.Serialization.Tests
{
    using System;
    using System.Globalization;
    using Innofactor.Xrm.Json.Serialization;
    using Newtonsoft.Json;
    using Xunit;

    public class BasicsConverterTests
    {
        #region Public Methods

        [Fact]
        public void String_Can_Deserialize()
        {
            // Arrange
            var expected = "testString";
            var json = $"{{\"_string\":\"{expected}\"}}";

            // Act
            var actual = JsonConvert.DeserializeObject<string>(json, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void String_Can_Serialize()
        {
            // Arrange
            var value = "testString";

            var expected = $"{{\"_String\":\"{value}\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Int_Can_Serialize()
        {
            // Arrange
            var value = 42;
            var expected = $"{{\"_Int32\":\"42\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Int_Can_Deserialize()
        {
            // Arrange
            var value = $"{{\"_Int32\":\"42\"}}";
            var expected = 42;


            // Act
            var actual = JsonConvert.DeserializeObject<int>(value, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Double_Can_Serialize()
        {
            // Arrange
            var value = 13.37;
            var expected = $"{{\"_Double\":\"13.37\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Double_Can_Deserialize()
        {
            // Arrange
            var value = $"{{\"_Double\":\"13.37\"}}";
            var expected = 13.37;


            // Act
            var actual = JsonConvert.DeserializeObject<double>(value, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Guid_Can_Serialize()
        {
            // Arrange
            var value = new Guid();
            var expected = $"{{\"_Guid\":\"{value.ToString()}\"}}";

            // Act
            var actual = JsonConvert.SerializeObject(value, Formatting.None, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Guid_Can_Deserialize()
        {
            // Arrange
            var expected = new Guid();
            var value = $"{{\"_Guid\":\"{expected.ToString()}\"}}";      


            // Act
            var actual = JsonConvert.DeserializeObject<Guid>(value, new BasicsConverter());

            // Assert
            Assert.Equal(expected, actual);
        }

        #endregion Public Methods
    }
}