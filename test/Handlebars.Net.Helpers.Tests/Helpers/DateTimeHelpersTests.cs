using System;
using FluentAssertions;
using HandlebarsDotNet.Helpers.Helpers;
using Moq;
using Xunit;

namespace HandlebarsDotNet.Helpers.Tests.Helpers
{
    public class DateTimeHelpersTests
    {
        private readonly Mock<IHandlebars> _contextMock;

        private readonly DateTimeHelpers _sut;

        public DateTimeHelpersTests()
        {
            _contextMock = new Mock<IHandlebars>();
            _contextMock.SetupGet(c => c.Configuration).Returns(new HandlebarsConfiguration());

            _sut = new DateTimeHelpers(_contextMock.Object);
        }

        [Theory]
        [InlineData("d", "4/15/2020")]
        [InlineData("o", "2020-04-15T23:59:58.0000000")]
        [InlineData("MM-dd-yyy", "04-15-2020")]
        public void Format(string format, string expected)
        {
            // Arrange
            var value = new DateTime(2020, 4, 15, 23, 59, 58);

            // Act
            var result = _sut.Format(value, format);

            // Assert
            result.Should().Be(expected);
        }
    }
}