namespace RussianPeasantMultiplication
{
    using FluentAssertions;
    using Xunit;

    public class FluentSpecs
    {
        [Fact]
        public void When_multiplying_1_and_x()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(1, 2).Should().Equals(2);
        }

        [Fact]
        public void When_multiplying_2_and_x()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(2, 5).Should().Equals(5 + 5);
        }

        [Fact]
        public void When_multiplying_x_and_2()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(7, 2).Should().Equals(7 + 7);
        }

        [Fact]
        public void When_multiplying_two_large_numbers()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(465, 23).Should().Equals(465 * 23);
        }

        [Fact]
        public void When_x1_is_larger_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(52, 35).Should().Equals(52 * 35);
        }

        [Fact]
        public void When_x1_is_smaller_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(35, 52).Should().Equals(52 * 35);
        }

        [Fact]
        public void When_x1_is_negative()
        {
            var sut = new RussianPeasantMultiplier();
            var product = sut.Multiply(-23, 45);
            product.Should().Equals(-23 * 45);
            product.Should().BeNegative();
        }

        [Fact]
        public void When_absolute_value_of_negative_x1_is_greater_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            const int x1 = -65;
            const int x2 = 35;
            sut.Multiply(x1, x2).Should().Equals(-65 * 35);
            sut.X1.Should().Equals(x2); //Assert arguments swapped
            sut.X2.Should().Equals(x1);
        }

        [Fact]
        public void When_both_values_are_negative()
        {
            var sut = new RussianPeasantMultiplier();
            var product = sut.Multiply(-42, -68);
            product.Should().Equals(42 * 68);
            product.Should().BePositive();
        }

        [Fact]
        public void When_logging_of_steps_enabled()
        {
            var sut = new RussianPeasantMultiplier(true);
            sut.Multiply(12, 45).Should().Equals(12 * 45);
            sut.Steps.Count.Should().Equals(4);
        }

        [Fact]
        public void When_logging_of_steps_disabled()
        {
            var sut = new RussianPeasantMultiplier(false);
            sut.Multiply(67, 42).Should().Equals(67 * 42);
            sut.Steps.Count.Should().Equals(0);
        }

        [Fact]
        public void When_x1_or_x2_is_0()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(0, 25).Should().Equals(0);
        }

        [Fact]
        public void When_x1_and_x2_is_0()
        {
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(0, 0).Should().Equals(0);
        }
    }
}
