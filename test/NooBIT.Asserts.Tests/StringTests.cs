using Xunit;
using Xunit.Sdk;

namespace NooBIT.Asserts.Tests
{
    public class StringTests
    {
        [Fact(DisplayName = "Equality")]
        public void Equality()
        {
            "foo".Should()
                .Be.Equal("foo")
                .And.Not.Be.Equal("bar");

            Assert.ThrowsAny<XunitException>(() => "foo".Should().Not.Be.Equal("foo"));
        }

        [Theory(DisplayName = "NullOrEmpty")]
        [InlineData("")]
        [InlineData(null)]
        public void NullOrEmpty(string data) => data.Should().Be.NullOrEmpty();

        [Theory(DisplayName = "NullOrWhitespace")]
        [InlineData("")]
        [InlineData("      ")]
        [InlineData(null)]
        public void NullOrWhitespace(string data) => data.Should().Be.NullOrWhitespace();
    }
}
