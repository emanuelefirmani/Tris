using System;
using FluentAssertions;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class BoardTest
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Board_accept_marks_only_in_positions_0to8(int position)
        {
            var board = new Board();
            board.Invoking(s => s.AddMark(position, "mark"))
                .Should().NotThrow();
        }

        [TestCase(-1)]
        [TestCase(9)]
        [TestCase(10)]
        public void Board_doesnt_accept_marks_in_positions_out_of_0to8(int position)
        {
            var board = new Board();
            board.Invoking(s => s.AddMark(position, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.Contains("Invalid position"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Should_not_accept_empty_marks(string mark)
        {
            var board = new Board();
            board.Invoking(s => s.AddMark(0, mark))
                .Should().Throw<Exception>().Where(e => e.Message.Contains("Invalid mark"));
        }        
        
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void Board_doesnt_accept_marks_on_already_used_positions(int position)
        {
            var sut = new Board();
            sut.AddMark(position, "mark");
            sut.Invoking(s => s.AddMark(position, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.StartsWith("Position already used"));
        }
        
        [Test]
        public void Shouldnt_accept_marks_on_previously_used_position()
        {
            var sut = new Board();
            sut.AddMark(0, "mark");
            sut.AddMark(1, "mark");
            
            sut.Invoking(s => s.AddMark(0, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.StartsWith("Position already used"));
        }
    }
}