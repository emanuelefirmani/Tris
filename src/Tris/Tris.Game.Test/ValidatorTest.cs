using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class ValidatorTest
    {
        Validator _sut = new Validator();

        [Test]
        public void Validate_returns_false()
        {
            _sut.Validate().Should().BeFalse();
        }
    }
}