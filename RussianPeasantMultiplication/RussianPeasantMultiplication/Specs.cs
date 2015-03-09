namespace RussianPeasantMultiplication
{
    using Machine.Fakes;
    using Machine.Specifications;

    internal abstract class Russian_peasant_multiplier_specs_base : WithSubject<RussianPeasantMultiplier>
    {
        protected static int x1;

        protected static int x2;

        protected static int Result;

        private Because of = () => Result = Subject.Multiply(x1, x2);
    }

    internal class When_multiplying_1_and_x : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 1;
                x2 = 2;
            };

        public It Should_return_x = () => Result.ShouldEqual(x2);
    }

    internal class When_multiplying_2_and_x : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 2;
                x2 = 5;
            };

        public It Should_return_x_multiplied_by_2 = () => Result.ShouldEqual(2 * x2);
    }

    internal class When_mulitplying_x_and_2 : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 7;
                x2 = 2;
            };

        public It Should_return_x_multiplied_by_2 = () => Result.ShouldEqual(2 * x1);
    }

    internal class When_multiplying_two_large_numbers : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 465;
                x2 = 23;
            };

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    internal class When_x1_is_larger_than_x2 : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 52;
                x2 = 35;
            };

        public It Should_swap_values_around = () =>
            {
                Subject.X1.ShouldEqual(x2);
                Subject.X2.ShouldEqual(x1);
            };

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    internal class When_x1_is_smaller_than_x2 : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 35;
                x2 = 52;
            };

        public It Should_keep_values_in_same_position = () =>
            {
                Subject.X1.ShouldEqual(x1);
                Subject.X2.ShouldEqual(x2);
            };

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    internal class When_x1_is_negative : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = -23;
                x2 = 45;
            };

        public It Should_return_negative_result = () => Result.ShouldBeLessThan(0);

        public It Should_return_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    internal class When_x2_is_negative : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = 45;
                x2 = -23;
            };

        public It Should_return_negative_result = () => Result.ShouldBeLessThan(0);

        public It Should_return_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    internal class When_absolute_value_of_negative_x1_is_greater_than_x2 : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = -65;
                x2 = 33;
            };

        public It Should_swap_values_around = () =>
            {
                Subject.X1.ShouldEqual(x2);
                Subject.X2.ShouldEqual(x1);
            };

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);

    }

    internal class When_both_values_are_negative : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                x1 = -42;
                x2 = -68;
            };

        public It Should_return_a_positive_result = () => Result.ShouldBeGreaterThan(0);

        public It Should_return_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    class When_logging_of_steps_enabled : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                Configure(s => s.For<bool>().Use(true));
                x1 = 12;
                x2 = 45;
            };

        public It Should_add_steps_to_log = () => Subject.Steps.ShouldNotBeEmpty();

        public It Should_have_correct_number_of_steps = () => Subject.Steps.Count.ShouldEqual(4);

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);
    }

    class When_logging_of_steps_disabled : Russian_peasant_multiplier_specs_base
    {
        private Establish context = () =>
            {
                Configure(s => s.For<bool>().Use(false));
                x1 = 67;
                x2 = 42;
            };

        public It Should_not_add_steps_to_the_log = () => Subject.Steps.ShouldBeEmpty();

        public It Should_return_the_correct_result = () => Result.ShouldEqual(x1 * x2);
    }
}
