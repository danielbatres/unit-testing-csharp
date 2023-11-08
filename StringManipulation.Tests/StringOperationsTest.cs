using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests {
    public class StringOperationsTest {
        [Fact(Skip = "This test is not valid at this moment, TICKET-001")]
        public void ConcatenateStrings() {
            // Arange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact]
        public void IsPalindrome_True() {
            // Arange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False() {
            // Arange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("hello");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void QuantityInWords() {
            // Arange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            // Assert
            Assert.StartsWith("diez", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength_Exception() {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected) {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurences() {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile() {
            var strOperations = new StringOperations();

            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");
            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading file", result);
        }
    }
}
