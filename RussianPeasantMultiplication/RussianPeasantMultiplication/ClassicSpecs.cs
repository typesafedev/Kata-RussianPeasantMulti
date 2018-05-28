namespace RussianPeasantMultiplication
{
    using Xunit;
    public class ClassicSpecs
    {
        [Fact]
        public void When_multiplying_1_and_x()
        {
            //Arrange
            var sut = new RussianPeasantMultiplier();
            //Act
            var product = sut.Multiply(1, 2);
            //Assert
            Assert.Equal(2, product);
        }

        [Fact]
        public void When_multiplying_2_and_x()
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(5 + 5, sut.Multiply(2, 5));
        }

        [Fact]
        public void When_multiplying_x_and_2()
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(7 + 7, sut.Multiply(7, 2));
        }

        [Fact]
        public void When_multiplying_two_large_numbers()
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(465 * 23, sut.Multiply(465, 23));
        }

        [Fact]
        public void When_x1_is_larger_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(52 * 35, sut.Multiply(52, 35));
        }

        [Fact]
        public void When_x1_is_smaller_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(52 * 35, sut.Multiply(35, 52));
        }

        [Fact]
        public void When_x1_is_negative()
        {
            var sut = new RussianPeasantMultiplier();
            var product = sut.Multiply(-23, 45);
            Assert.Equal(-23 * 45, product);
            Assert.True(product < 0);
        }

        [Fact]
        public void When_absolute_value_of_negative_x1_is_greater_than_x2()
        {
            var sut = new RussianPeasantMultiplier();
            const int x1 = -65;
            const int x2 = 35;
            Assert.Equal(-65 * 35, sut.Multiply(x1, x2));
            Assert.Equal(x2, sut.X1); //Assert arguments swapped
            Assert.Equal(x1, sut.X2);
        }

        [Fact]
        public void When_both_values_are_negative()
        {
            var sut = new RussianPeasantMultiplier();
            var product = sut.Multiply(-42, -68);
            Assert.Equal(42 * 68, product);
            Assert.True(product > 0);
        }

        [Fact]
        public void When_logging_of_steps_enabled()
        {
            var sut = new RussianPeasantMultiplier(true);
            Assert.Equal(12 * 45, sut.Multiply(12, 45));
            Assert.Equal(4, sut.Steps.Count);
        }

        [Fact]
        public void When_logging_of_steps_disabled()
        {
            var sut = new RussianPeasantMultiplier(false);
            Assert.Equal(67 * 42, sut.Multiply(67, 42));
            Assert.Equal(0, sut.Steps.Count);
        }

        [Theory]
        [InlineData(0, 25)]
        [InlineData(0, 0)]
        public void When_0(int x1, int x2)
        {
            var sut = new RussianPeasantMultiplier();
            Assert.Equal(0, sut.Multiply(x1, x2));
        }

    }
}
