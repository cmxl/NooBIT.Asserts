using Xunit;

namespace NooBIT.Asserts.Tests
{
    public class FluentTests
    {
        [Fact]
        public void Foo()
        {
            var foo = "foo";
            foo.Should().Not.Be.Equal("bar");
            foo.Should().Be.Equal("foo");
        }
    }
}
