using System.Collections;
using NUnit.Framework;

namespace Homework.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test, TestCaseSource(typeof(PolynomialTestData), "ExeptionsTestCases")]
        public void ExeptionsTest(decimal[] coeffs)
        {
            Assert.That(() => new Polynomial(coeffs), Throws.Exception);
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "EqualsTestCases")]
        public bool EqualsTest(Polynomial polynomial, object obj)
        {
            return polynomial.Equals(obj);
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "GetHashCodeTestCases")]
        public bool GetHashCodeTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1.GetHashCode() == obj2.GetHashCode();
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "ToStringTestCases")]
        public string ToStringTest(Polynomial obj)
        {
            return obj.ToString();
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "BinaryPlusTestCases")]
        public Polynomial BinaryPlusTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1 + obj2;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "BinaryMinusTestCases")]
        public Polynomial BinaryMinusTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1 - obj2;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "UnaryMinusTestCases")]
        public Polynomial UnaryMinusTest(Polynomial obj)
        {
            return -obj;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "MultiplicationTestCases")]
        public Polynomial MultiplicationTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1 * obj2;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "EqualityTestCases")]
        public bool EqualityTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1 == obj2;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "InequalityTestCases")]
        public bool InequalityTest(Polynomial obj1, Polynomial obj2)
        {
            return obj1 != obj2;
        }

        [Test, TestCaseSource(typeof(PolynomialTestData), "IndexerTestCases")]
        public decimal IndexerTest(Polynomial obj, byte power)
        {
            return obj[power];
        }
    }
}
