using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class BoardTest
    {
        Board _sut = new Board();

        [Test]
        public void Board_accept_marks()
        {
            _sut.Invoking(s => s.AddMark(0, "mark"))
                .Should().NotThrow();
        }
    }
}