using NUnit.Framework;
using System.Collections;

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

    #region test data
    public class PolynomialTestData
    {
        public static IEnumerable EqualsTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(2, 0), null).Returns(false);
                yield return new TestCaseData(new Polynomial(1, 2, 7, 0), new Polynomial(1, 2, 7, 0)).Returns(true);
                yield return new TestCaseData(new Polynomial(2, 3), 23).Returns(false);
                yield return new TestCaseData(new Polynomial(1, 2, 3, 4), new Polynomial(1, 2, 3, 4, 4)).Returns(false);
                yield return new TestCaseData(new Polynomial(1, 2, 3, 4, 4), new Polynomial(1, 2, 3, 4)).Returns(false);
                yield return new TestCaseData(new Polynomial(1), new Polynomial(-1)).Returns(false);
                yield return new TestCaseData(new Polynomial(6, 5), new Polynomial(5, 6)).Returns(false);
            }
        }

        public static IEnumerable GetHashCodeTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 3, 0, 5), new Polynomial(1, 3, 0, 5)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 3, 0, 6), new Polynomial(1, 3, 0, 5)).Returns(false);
                yield return new TestCaseData(new Polynomial(1, 3, 0, 4), new Polynomial(1, 3, 0, 5)).Returns(false);
                yield return new TestCaseData(new Polynomial(0), new Polynomial(0)).Returns(true);
                yield return new TestCaseData(new Polynomial(22, 33, 0, 0), new Polynomial(22, 33, 0, 0, 0)).Returns(false);
            }
        }

        public static IEnumerable ToStringTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 3, 4, 5)).Returns("x^4 + 2x^3 + 3x^2 + 4x + 5");
                yield return new TestCaseData(new Polynomial(-155, 0, 3, 0, -1, 6, 0)).Returns("-155x^6 + 3x^4 - x^2 + 6x");
                yield return new TestCaseData(new Polynomial(-1, 2, -3, 4, -5)).Returns("-x^4 + 2x^3 - 3x^2 + 4x - 5");
                yield return new TestCaseData(new Polynomial(33.2m, 0, 0, 1, -5.11m, 0, 0, 0)).Returns("33,2x^7 + x^4 - 5,11x^3");
                yield return new TestCaseData(new Polynomial(-22.00m, -125, 210, 0, -1, -1)).Returns("-22,00x^5 - 125x^4 + 210x^3 - x - 1");
                yield return new TestCaseData(new Polynomial(732, -1, 13.35m)).Returns("732x^2 - x + 13,35");
                yield return new TestCaseData(new Polynomial(5, -10, 0, 0)).Returns("5x^3 - 10x^2");
            }
        }

        public static IEnumerable BinaryPlusTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 3, 4, 5), new Polynomial(5, 4, 3, 2, 1)).Returns(new Polynomial(6, 6, 6, 6, 6));
                yield return new TestCaseData(new Polynomial(1, 2, 3, 4, 5), new Polynomial(6, 7)).Returns(new Polynomial(1, 2, 3, 10, 12));
                yield return new TestCaseData(new Polynomial(1, 1), new Polynomial(10, 20, 30, 40, 50)).Returns(new Polynomial(10, 20, 30, 41, 51));
                yield return new TestCaseData(new Polynomial(3, 0, 0, 0), new Polynomial(5, 7, 0, 0, 8, 9, 10)).Returns(new Polynomial(5, 7, 0, 3, 8, 9, 10));
                yield return new TestCaseData(new Polynomial(-10, -2, -33, 20), new Polynomial(22, 0, -15)).Returns(new Polynomial(-10, 20, -33, 5));
                yield return new TestCaseData(new Polynomial(123.05m, -0.33m, 11, -555.555m), new Polynomial(0.1m, 0.1m, 0, 22, -12.45m, -55.105m)).Returns(new Polynomial(0.1m, 0.1m, 123.05m, 21.67m, -1.45m, -610.66m));
            }
        }

        public static IEnumerable BinaryMinusTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 4, 5), new Polynomial(1, 2, 4, 5)).Returns(new Polynomial(0));
                yield return new TestCaseData(new Polynomial(2, 6, 4, 1, 1), new Polynomial(1, 2, 3)).Returns(new Polynomial(2, 6, 3, -1, -2));
                yield return new TestCaseData(new Polynomial(-23, -15, 0, -11, 2), new Polynomial(-10, 0, -2, -3, -4, -5)).Returns(new Polynomial(10, -23, -13, 3, -7, 7));
                yield return new TestCaseData(new Polynomial(23.45m, -10.002m, 0.00354m, -1000.0001m, 123.987m), new Polynomial(-14, -0.002m, -19.94m, 20.002m, 0.0042m)).Returns(new Polynomial(37.45m, -10, 19.94354m, -1020.0021m, 123.9828m));
            }
        }

        public static IEnumerable UnaryMinusTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(14, 5, 2, 0)).Returns(new Polynomial(-14, -5, -2, 0));
                yield return new TestCaseData(new Polynomial(0)).Returns(new Polynomial(0));
                yield return new TestCaseData(new Polynomial(-4, -5, 0, -11)).Returns(new Polynomial(4, 5, 0, 11));
                yield return new TestCaseData(new Polynomial(2, -3, 0, 3, -2)).Returns(new Polynomial(-2, 3, 0, -3, 2));
            }
        }

        public static IEnumerable MultiplicationTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(0), new Polynomial(0)).Returns(new Polynomial(0));
                yield return new TestCaseData(new Polynomial(2, -5, 1, 9, 24, -22), new Polynomial(0)).Returns(new Polynomial(0));
                yield return new TestCaseData(new Polynomial(0), new Polynomial(-2, 44, -5, -11)).Returns(new Polynomial(0));
                yield return new TestCaseData(new Polynomial(3, 0, -2, -14, -4, 55), new Polynomial(12, 42, 0, -15)).Returns(new Polynomial(36, 126, -24, -297, -636, 522, 2520, 60, -825));
                yield return new TestCaseData(new Polynomial(-12.53m, 0.0025m, 400, 0), new Polynomial(124, 99.999m, -19.955m, 0, 10, 0.00059m)).Returns(new Polynomial(-1553.72m, -1252.67747m, 49850.2861475m, 39999.5501125m, -8107.3000m, 0.0176073m, 4000.000001475m, 0.23600m, 0));
            }
        }

        public static IEnumerable EqualityTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Returns(true);
                yield return new TestCaseData(null, new Polynomial(0)).Returns(false);
                yield return new TestCaseData(new Polynomial(12), null).Returns(false);
                yield return new TestCaseData(new Polynomial(-1, -2, -3), new Polynomial(-1, -2, -3)).Returns(true);
                yield return new TestCaseData(new Polynomial(1, 2, 3), new Polynomial(1, 2, 3, 0)).Returns(false);
            }
        }

        public static IEnumerable InequalityTestCases
        {
            get
            {
                yield return new TestCaseData(null, null).Returns(false);
                yield return new TestCaseData(null, new Polynomial(0)).Returns(true);
                yield return new TestCaseData(new Polynomial(10), null).Returns(true);
                yield return new TestCaseData(new Polynomial(2, 2, 2), new Polynomial(2, 2, 2, 2)).Returns(true);
                yield return new TestCaseData(new Polynomial(0), new Polynomial(0)).Returns(false);
            }
        }

        public static IEnumerable IndexerTestCases
        {
            get
            {
                yield return new TestCaseData(new Polynomial(1, 2, 3, 0), (byte)0).Returns(0);
                yield return new TestCaseData(new Polynomial(2, 5, 1, 99), (byte)3).Returns(2);
                yield return new TestCaseData(new Polynomial(4, -10, 4, 99, 824, 22), (byte)4).Returns(-10);
                yield return new TestCaseData(new Polynomial(1, 0, 0, 0, 0, 0, 1, 0, 0), (byte)2).Returns(1);
            }
        }

        public static IEnumerable ExeptionsTestCases
        {
            get
            {
                yield return new TestCaseData(null);
                yield return new TestCaseData(new decimal[0]);
                yield return new TestCaseData(new decimal[] { 0, 2 });
                yield return new TestCaseData(new decimal[300]);
            }
        }
    }
    #endregion
}
