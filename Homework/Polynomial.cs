using System;
using System.Linq;

namespace Homework
{
    /// <summary>
    /// Class represents one-variable polynomial with real number coefficients and provides methods for work with polynomials
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// String which represents polynomial variable when displaying
        /// </summary>
        private const string VARIABLE = "x";

        /// <summary>
        /// Degree of a polynomial (the highest degree of its monomials)
        /// </summary>
        public readonly byte degree;

        /// <summary>
        /// Polynomial coefficients. First belongs to highest-degree monomial, last - to zero-degree one
        /// </summary>
        private readonly decimal[] coefficients;

        /// <summary>
        /// Constructs a new polynomial with given coefficients of its monomials in descending order of their degrees
        /// </summary>
        /// <param name="coeffs">polynomial coefficients from highest-degree monomial to zero-degree, each for every monomial</param>
        /// <exception cref="ArgumentNullException">Argument array <paramref name="coeffs"/> is null</exception>
        /// <exception cref="ArgumentException">No coefficients are passed as parameters</exception>
        /// <exception cref="ArgumentException">The coefficient of the highest degree monomial is zero</exception>
        /// <exception cref="ArgumentException">The number of coefficients exceeds maximum value</exception>
        public Polynomial(params decimal[] coeffs)
        {
            #region argument validation
            if (coeffs == null)
            {
                throw new ArgumentNullException("coeffs");
            }

            if (coeffs.Length == 0)
            {
                throw new ArgumentException("Cannot create a polynomial without coefficients");
            }

            if (coeffs[0] == 0 && coeffs.Any(c => c != 0))
            {
                throw new ArgumentException("First coefficient cannot be a zero");
            }

            if (coeffs.Length > byte.MaxValue + 1)
            {
                throw new ArgumentException("Maximum number of coefficients is 256");
            }
            #endregion

            if (coeffs.All(c => c == 0))
            {
                coefficients = new decimal[1] { 0 };
            }
            else
            {
                coefficients = new decimal[coeffs.Length];
                coeffs.CopyTo(coefficients, 0);
            }

            degree = (byte)(coefficients.Length - 1);
        }

        /// <summary>
        /// Gets the coefficient of the term with degree <paramref name="power"/>
        /// </summary>
        /// <param name="power">power of a term whose coefficient is needed</param>
        /// <returns>coefficient of a term</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="power"/> exceeds degree</exception>
        public decimal this[byte power]
        {
            get
            {
                if (power > degree)
                {
                    throw new ArgumentOutOfRangeException("Power cannot be greater than polynomial degree");
                }

                return coefficients[degree - power];
            }
        }

        #region overloaded operators

        /// <summary>
        /// Polynomial addition
        /// </summary>
        /// <param name="obj1">first addendum</param>
        /// <param name="obj2">second addendum</param>
        /// <returns>sum</returns>
        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            var resultDegree = obj1.degree >= obj2.degree ? obj1.degree : obj2.degree;
            var resultCoeffs = new decimal[resultDegree + 1];

            for (int i = 0; i < resultCoeffs.Length; i++)
            {
                resultCoeffs[i] = (obj1.degree >= resultDegree - i ? obj1[(byte)(resultDegree - i)] : 0) + (obj2.degree >= resultDegree - i ? obj2[(byte)(resultDegree - i)] : 0);
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Polynomial subtraction
        /// </summary>
        /// <param name="obj1">minuend</param>
        /// <param name="obj2">subtrahend</param>
        /// <returns>difference</returns>
        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {
            return obj1 + -obj2;
        }

        /// <summary>
        /// Polynomial negation
        /// </summary>
        /// <param name="obj">polynomial to negate</param>
        /// <returns>negative to <paramref name="obj"/> polynomial</returns>
        public static Polynomial operator -(Polynomial obj)
        {
            var resultCoeffs = new decimal[obj.coefficients.Length];

            for (int i = 0; i < resultCoeffs.Length; i++)
            {
                resultCoeffs[i] = -obj.coefficients[i];
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Polynomial multiplication
        /// </summary>
        /// <param name="obj1">first factor</param>
        /// <param name="obj2">second factor</param>
        /// <returns>product</returns>
        public static Polynomial operator *(Polynomial obj1, Polynomial obj2)
        {
            var resultCoeffs = new decimal[(obj1.degree + obj2.degree) + 1];

            for (int i = 0; i < obj1.coefficients.Length; i++)
            {
                for (int j = 0; j < obj2.coefficients.Length; j++)
                {
                    resultCoeffs[i + j] += obj1.coefficients[i] * obj2.coefficients[j];
                }
            }

            return new Polynomial(resultCoeffs);
        }

        /// <summary>
        /// Checks two polynomials on equality
        /// </summary>
        /// <param name="obj1">first polynomial</param>
        /// <param name="obj2">second polynomial</param>
        /// <returns>true for equality or false</returns>
        public static bool operator ==(Polynomial obj1, Polynomial obj2)
        {
            return (object)obj1 == obj2 || ((object)obj1 != null ? obj1.Equals(obj2) : obj2.Equals(obj1));
        }

        /// <summary>
        /// Checks two polynomials on inequality
        /// </summary>
        /// <param name="obj1">first polynomial</param>
        /// <param name="obj2">second polynomial</param>
        /// <returns>true for inequality or false</returns>
        public static bool operator !=(Polynomial obj1, Polynomial obj2)
        {
            return !(obj1 == obj2);
        }

        #endregion

        #region overriden from object

        /// <summary>
        /// Checks if a polynomial is equal to polynomial <paramref name="obj"/>
        /// </summary>
        /// <param name="obj">comparable polynomial</param>
        /// <returns>true for equality or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var polynomial = (Polynomial)obj;

            if (degree != polynomial.degree)
            {
                return false;
            }

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != polynomial.coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generates hashcode based on polynomial coefficients
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
        {
            int hash = 7;
            foreach (var coeff in coefficients)
            {
                hash = hash * 13 + coeff.GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Gets human-readable string representation of a polynomial
        /// </summary>
        /// <returns>string representation of a polynomial</returns>
        public override string ToString()
        {
            string str = string.Empty;

            if (coefficients[0] != 0)
            {
                if (degree == 1)
                {
                    str += (coefficients[0] == 1 ? "" : coefficients[0] == -1 ? "-" : coefficients[0].ToString()) + VARIABLE;
                }
                else if (degree == 0)
                {
                    str += coefficients[0];
                }
                else
                {
                    str += (coefficients[0] == 1 ? "" : coefficients[0] == -1 ? "-" : coefficients[0].ToString()) + VARIABLE + '^' + degree;
                }
            }

            for (int i = 1; i < coefficients.Length; i++)
            {

                if (coefficients[i] > 0)
                {
                    str += " + ";
                }
                else if (coefficients[i] < 0)
                {
                    str += " - ";
                }
                else
                {
                    continue;
                }

                string coeff = Math.Abs(coefficients[i]) == 1 && degree - i > 0 ? "" : Math.Abs(coefficients[i]).ToString();
                if (degree - i == 1)
                {
                    str += coeff + VARIABLE;
                }
                else if (degree - i == 0)
                {
                    str += coeff;
                }
                else
                {
                    str += coeff + VARIABLE + '^' + (degree - i);
                }
            }

            return str;
        }

        #endregion
    }
}
