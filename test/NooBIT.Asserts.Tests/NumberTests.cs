using Xunit;

namespace NooBIT.Asserts.Tests
{
    public class NumberTests
    {
        [Theory(DisplayName = "Positives")]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void Positives(int data) => data.Should().Be.Positive().And.Not.Be.Negative();

        [Theory(DisplayName = "Negatives")]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void Negatives(int data) => data.Should().Be.Negative().And.Not.Be.Positive();

        [Fact(DisplayName = "Zero")]
        public void Zero() => 0.Should().Be.Equal(0).And.Not.Be.Positive().And.Not.Be.Negative();
    }
}
