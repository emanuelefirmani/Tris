﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class ValidatorTest
    {
        Validator _sut = new Validator();

        [TestCase("a", "b")]
        [TestCase("test", "")]
        [TestCase(null, "")]
        [TestCase("a", null)]
        public void Validate_returns_false_if_strings_dont_match(string string1, string string2)
        {
            _sut.Validate(GetInputArray(string1, string2)).Should().BeFalse();
        }

        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("a", null)]
        public void Validate_returns_false_if_any_string_is_null(string string1, string string2)
        {
            _sut.Validate(GetInputArray(string1, string2)).Should().BeFalse();
        }

                
        [TestCase("a")]
        [TestCase("test")]
        [TestCase("")]
        public void Validate_returns_true_if_strings_012_match(string value)
        {
            var input = new string[9];
            input[0] = value;
            input[1] = value;
            input[2] = value;

            _sut.Validate(GetInputStrings(0, 1, 2, value)).Should().BeTrue();
        }

        [TestCase(0, 1, 2)]
        [TestCase(3, 4, 5)]
        [TestCase(6, 7, 8)]
        public void Validate_returns_true_if_any_row_values_match(int i1, int i2, int i3)
        {
            _sut.Validate(GetInputStrings(i1, i2, i3, "test")).Should().BeTrue();
        }
        
        [TestCase(0, 3, 6)]
        [TestCase(1, 4, 7)]
        [TestCase(2, 5, 8)]
        public void Validate_returns_true_if_any_column_values_match(int i1, int i2, int i3)
        {
            _sut.Validate(GetInputStrings(i1, i2, i3, "test")).Should().BeTrue();
        }

        [TestCase(0, 4, 8)]
        [TestCase(2, 4, 6)]
        public void Validate_returns_true_if_any_diagonal_values_match(int i1, int i2, int i3)
        {
            _sut.Validate(GetInputStrings(i1, i2, i3, "test")).Should().BeTrue();
        }

        private static string[] GetInputStrings(int i1, int i2, int i3, string value)
        {
            var input = new string[9];
            input[i1] = value;
            input[i2] = value;
            input[i3] = value;
            return input;
        }

        [TestCase(1)]
        [TestCase(8)]
        [TestCase(10)]
        public void Validate_accepts_only_arrays_with_9_elements(int count)
        {
            _sut.Invoking(s => s.Validate(new string[count])).Should().Throw<Exception>()
                .Where(e => e.Message.Contains("9 elements"));
        }

        private static string[] GetInputArray(string string1, string string2)
        {
            var output = new string[9];
            output[0] = string1;
            output[1] = string2;
            return output;
        }
    }
} 