using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class ValidatorTest
    {
        Validator _sut = new Validator();

        [TestCase("a", "a")]
        [TestCase("test", "test")]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void Validate_returns_true_if_strings_match(string string1, string string2)
        {
            _sut.Validate(GetInputArray(string1, string2)).Should().BeTrue();
        }

        [TestCase("a", "b")]
        [TestCase("test", "")]
        [TestCase(null, "")]
        [TestCase("a", null)]
        public void Validate_returns_false_if_strings_dont_match(string string1, string string2)
        {
            _sut.Validate(GetInputArray(string1, string2)).Should().BeFalse();
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