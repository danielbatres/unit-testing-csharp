﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Tests {
    public class StringOperationsTest {
        [Fact]
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
    }
}
