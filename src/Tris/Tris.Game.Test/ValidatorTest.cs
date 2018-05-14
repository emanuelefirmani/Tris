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
            _sut.Validate(new[] {string1, string2}).Should().BeTrue();
        }

        [TestCase("a", "b")]
        [TestCase("test", "")]
        [TestCase(null, "")]
        [TestCase("a", null)]
        public void Validate_returns_false_if_strings_dont_match(string string1, string string2)
        {
            _sut.Validate(new[] {string1, string2}).Should().BeFalse();
        }
    }
} 