using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test.Integration
{
    public class BoardTest
    {
        [Test]
        public void Should_work_for_happycase_1()
        {
            var sut = new Board();

            sut.AddMark(0, "a").Should().BeTrue();
            sut.AddMark(1, "a").Should().BeTrue();
            sut.AddMark(2, "a").Should().BeFalse();
        }

        [Test]
        public void Should_work_for_happycase_2()
        {
            var sut = new Board();

            sut.AddMark(0, "a").Should().BeTrue();
            sut.AddMark(4, "a").Should().BeTrue();
            sut.AddMark(8, "a").Should().BeFalse();
        }

        [Test]
        public void Should_work_for_happycase_3()
        {
            var sut = new Board();

            sut.AddMark(0, "a").Should().BeTrue();
            sut.AddMark(1, "b").Should().BeTrue();
            sut.AddMark(4, "a").Should().BeTrue();
            sut.AddMark(2, "b").Should().BeTrue();
            sut.AddMark(8, "a").Should().BeFalse();
        }

        [Test]
        public void Should_work_for_cornercase_1()
        {
            var sut = new Board();

            sut.AddMark(0, "a").Should().BeTrue();
            sut.AddMark(1, "a").Should().BeTrue();
            sut.AddMark(4, "a").Should().BeTrue();
            sut.AddMark(3, "a").Should().BeTrue();
            sut.AddMark(8, "a").Should().BeFalse();
        }
    }
}