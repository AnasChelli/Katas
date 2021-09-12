using Katas;
using NFluent;
using NUnit.Framework;

namespace KatasTest
{
    public class Tests
    {
        private Solution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution();
        }

        [Test]
        public void Should_return_invalid_index_when_array_is_empty()
        {
            int[] numbers = { };
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = -1;
            Check.That(actualValue).Equals(expectedValue);
        }

        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 10 })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 50 })]
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 10, 20 })]
        [TestCase(new int[] { 20, 30 })]
        [TestCase(new int[] { 30, 40 })]
        public void Should_return_zero_when_array_length_is_one_or_two(int[] numbers)
        {
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = 0;
            Check.That(actualValue).Equals(expectedValue);
        }


        [TestCase(new int[] { 0, 1, 1 })]
        public void Should_return_valid_index(int[] numbers)
        {
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = 1;
            Check.That(actualValue).Equals(expectedValue);
        }

        [TestCase(new int[] { 0, 0, 1 })]
        public void Should_return_0_as_valid_index(int[] numbers)
        {
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = 0;
            Check.That(actualValue).Equals(expectedValue);
        }

        [TestCase(new int[] { 0, 1, 0, 1, 1, 1 })]
        public void Should_return_3_as_valid_index(int[] numbers)
        {
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = 3;
            Check.That(actualValue).Equals(expectedValue);
        }

        [Test]
        public void Should_return_index_for_of_large_repeated_number()
        {
            int[] numbers = { 0, 1, 1, 0, 1, 1, 1 };
            var actualValue = _solution.GetIndex(numbers);
            var expectedValue = 4;
            Check.That(actualValue).Equals(expectedValue);
        }
    }
}