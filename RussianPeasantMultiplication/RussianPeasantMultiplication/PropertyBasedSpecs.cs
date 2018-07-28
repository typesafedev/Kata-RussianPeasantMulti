namespace RussianPeasantMultiplication
{
    using FsCheck;
    using FsCheck.Xunit;
    using FluentAssertions;
    using System;

    //Multiplication laws for real and complex numbers *** 
    public class PropertyBasedSpecs
    {
        // This law does not hold for multiplication of matrices and quarternions - according to wikipedia
        [Property]
        public Property CommutativeLaw(int x, int y)
        {
            // x * y = y * x
            var sut = new RussianPeasantMultiplier();
            return (sut.Multiply(x, y) == sut.Multiply(y, x)).ToProperty();
        }

        [Property(MaxTest = 10000, StartSize = 10000)]
        public Property AssociativeLaw(int x, int y, int z)
        {
            // (x * y) * z = x * (y * z)
            var sut = new RussianPeasantMultiplier();
            return (sut.Multiply(sut.Multiply(x, y), z) == sut.Multiply(x, sut.Multiply(y, z))).ToProperty();
        }

        [Property]
        public Property DistributiveLaw(int x, int y, int z)
        {
            // x * (y + z) = (x * y) + (x * z)
            var sut = new RussianPeasantMultiplier();
            return (sut.Multiply(x, y + z) == sut.Multiply(x, y) + sut.Multiply(x, z)).ToProperty();
        }

        [Property]
        public Property NegationLaw(int x)
        {
            // -1 * x = -x where -1 * -1 = 1
            var sut = new RussianPeasantMultiplier();
            sut.Multiply(-1, -1).Should().Equals(1);
            return (sut.Multiply(-1, x) == -x).ToProperty();
        }

        [Property]
        public Property IdentityLaw(int x)
        {
            // 1 * x = x
            // x * 1 = x    // right identity is also proven if commutative property holds
            // -1 * x = -x  // left negative identity also proven if negation property holds
            // x * -1 = -x  // right negative identity also proven if cummutative and negation holds
            var sut = new RussianPeasantMultiplier();
            return (sut.Multiply(1, x) == x).ToProperty();
        }

        [Property]
        public Property ZeroLaw(int x)
        {
            // Zero is the absorbing element for multiplication - as opposed to addition which does not have an absorbing element
            // https://en.wikipedia.org/wiki/Absorbing_element
            // 0 * x = 0
            // x * 0 = 0    //Right zero also proven if commutative property holds
            var sut = new RussianPeasantMultiplier();
            return (sut.Multiply(0, x) == 0).ToProperty();
        }

        [Property(Verbose = true)]
        public Property PositiveOrderPreservationLaw(int x, int y, int z)
        {
            // Forall x > 0, if y > z then x * y > x * z
            var sut = new RussianPeasantMultiplier();
            var lhs = sut.Multiply(x, y);
            var rhs = sut.Multiply(x, z);
            Func<bool> property = () => lhs > rhs;
            return property.When(x > 0 && y > z);
        }

        [Property]
        public Property NegativeOrderPreservationLaw(int x, int y, int z)
        {
            // Forall x < 0, if y > z then x * y < x * z
            var sut = new RussianPeasantMultiplier();
            var lhs = sut.Multiply(x, y);
            var rhs = sut.Multiply(x, z);
            Func<bool> property = () => lhs < rhs;
            return property.When(x < 0 && y > z);
        }
    }
}
