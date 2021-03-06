﻿using System;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Tris.Game.Test
{
    public class BoardTest
    {
        private readonly IValidator _validator = NSubstitute.Substitute.For<IValidator>();
        private Board _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Board(_validator);
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
        public void Board_accept_marks_only_in_positions_0to8(int position)
        {
            _validator.Validate(Arg.Any<string[]>()).Returns(false);

            _sut.Invoking(s => s.AddMark(position, "mark"))
                .Should().NotThrow();
        }

        [TestCase(-1)]
        [TestCase(9)]
        [TestCase(10)]
        public void Board_doesnt_accept_marks_in_positions_out_of_0to8(int position)
        {
            _sut.Invoking(s => s.AddMark(position, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.Contains("Invalid position"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Should_not_accept_empty_marks(string mark)
        {
            _sut.Invoking(s => s.AddMark(0, mark))
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
            _validator.Validate(Arg.Any<string[]>()).Returns(false);

            _sut.AddMark(position, "mark");
            _sut.Invoking(s => s.AddMark(position, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.StartsWith("Position already used"));
        }
        
        [Test]
        public void Shouldnt_accept_marks_on_previously_used_position()
        {
            _validator.Validate(Arg.Any<string[]>()).Returns(false);

            _sut.AddMark(0, "mark");
            _sut.AddMark(1, "mark");
            
            _sut.Invoking(s => s.AddMark(0, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.StartsWith("Position already used"));
        }
        
        [Test]
        public void AddMark_should_return_true_as_long_as_isnt_valid()
        {
            _validator.Validate(Arg.Any<string[]>()).Returns(false);
            _sut.AddMark(0, "mark").Should().BeTrue();
        }

        [Test]
        public void AddMark_should_return_false_as_soon_as_is_valid()
        {
            _validator.Validate(Arg.Is<string[]>(x => x[0] != "mark")).Returns(false);
            _validator.Validate(Arg.Is<string[]>(x => x[0] == "mark")).Returns(true);
            _sut.AddMark(0, "mark").Should().BeFalse();
        }

        [Test]
        public void AddMark_should_pass_marks_to_validator()
        {
            var expected = new string[9];

            _sut = new Board(expected, _validator);
            _sut.AddMark(0, "a");

            _validator.Received(2).Validate(Arg.Is<string[]>(x => x.Equals(expected)));
        }
        
        [Test]
        public void AddMark_should_throw_if_already_valid()
        {
            _validator.Validate(Arg.Any<string[]>()).Returns(true);
            
            _sut.Invoking(s => s.AddMark(0, "mark"))
                .Should().Throw<Exception>().Where(e => e.Message.StartsWith("Game already completed"));
        }
    }
}