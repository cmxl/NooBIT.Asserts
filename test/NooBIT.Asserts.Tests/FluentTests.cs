using Xunit;
using Xunit.Sdk;

namespace NooBIT.Asserts.Tests
{
    public class FluentTests
    {
        [Fact]
        public void Foo()
        {
            "foo".Should().Be.And.Be.And.Be.And
                .Not.Be.Equal("bar")
                .And.Be.Equal("foo");

            Assert.ThrowsAny<XunitException>(() => "foo".Should().Not.Be.Equal("foo"));

            0.1d.Should()
                .Not.Be.Equal(0.0d)
                .And.Not.Be.Negative()
                .And.Be.Positive();
        }
    }
}
