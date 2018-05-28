namespace RussianPeasantMultiplication
{
    using FluentAssertions;
    using System;
    using Xunit;

    //Questionable utility. Test machine will have to be stable for this to work.
    public class PerformanceTests
    {
        [Fact]
        public void ObjectOrientedMultiply()
        {
            var sut = new RussianPeasantMultiplier();
            sut.ExecutionTimeOf(s => s.Multiply(1000, 1000)).Should().BeLessThan(TimeSpan.FromMilliseconds(100));
        }

        [Fact]
        public void FunctionalMultiply()
        {
            Action action = () => Functional.Multiply(1000, 1000);
            action.ExecutionTime().Should().BeLessThan(TimeSpan.FromMilliseconds(100));
        }

    }
}
