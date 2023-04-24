namespace Finite_field;

public class Polynom
{
    public int deg;
    public int[] coeff;
    public int module;
    
    public Polynom(int[] listCoeff, int module)
    {
        coeff = listCoeff;
        deg = listCoeff.Length - 1;
        this.module = module;
        for (int i = 0; i < coeff.Length; i++)
        {
            coeff[i] = coeff[i] % module;
        }
    }
    
    public int this[int index] => index >= coeff.Length ? 0 : coeff[index];
    public static Polynom operator *(Polynom polynom1, Polynom polynom2)
    {
        int[] coeffs = new int[polynom1.coeff.Length + polynom2.coeff.Length - 1];
        for (int i = 0; i < polynom1.coeff.Length; ++i)
        for (int j = 0; j < polynom2.coeff.Length; ++j)
            coeffs[i + j] += polynom1.coeff[i] * polynom2.coeff[j];
        return new Polynom( coeffs, polynom1.module);
    }
    
    public static Polynom operator -(Polynom polynom)
    {
        var coefficients = new int[polynom.deg+1];
        for (var i = 0; i <= polynom.deg; i++)
        {
            coefficients[i] = -polynom.coeff[i];
        }

        return new Polynom(coefficients, polynom.module);
    }
    
    public static Polynom operator +(Polynom left, Polynom right)
    {
        if (left == null || right == null)
            throw new ArgumentNullException();

        var degree = Math.Max(left.deg, right.deg);
        var coefficients = new int[degree + 1];
        for (var i = 0; i < degree + 1; i++)
        {
            coefficients[i] += left[i] + right[i];
        }

        return new Polynom(coefficients, left.module);
    }

    public static Polynom operator -(Polynom left, Polynom right) => left + (-right);
    
    public static Polynom operator %(Polynom dividend, Polynom divisor)
    {
        if (dividend == null || divisor == null)
            throw new ArgumentNullException();

        if (dividend.deg < divisor.deg)
            return dividend;

        var remainder = new Polynom(dividend.coeff, dividend.module);
        var quotient = new int[dividend.deg - divisor.deg + 1];

        for (var i = 0; i < quotient.Length; i++)
        {
            var coefficient = (remainder[remainder.deg - i] * MyMath.GetInverseElement(divisor.coeff.Last(),dividend.module)) % dividend.module;
            quotient[quotient.Length - 1 - i] = coefficient;
            for (var j = 0; j < divisor.coeff.Length; j++)
            {
                remainder.coeff[remainder.deg - i - j] -= coefficient * divisor[divisor.deg - j];
            }
        }
        return remainder;
    }
    
    public override string ToString()
    {
        var result = "";
        result += coeff[0];
        if (coeff.Length > 1)
        {
            result += " + " + coeff[1] + "x + ";
            for (var i = 2; i < coeff.Length; i++)
            {
                result += coeff[i] + "x^" + i + " + ";
            }
        }
        return result.TrimEnd(' ', '+');
    }
}