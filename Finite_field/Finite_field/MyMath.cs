namespace Finite_field;

public static class MyMath
{
    public static int GetInverseElement(int value, int modulo)
    {
        var g = ExtendedGcd(value, modulo, out var x, out var y);

        if (g != 1)
            throw new ArithmeticException("Impossible find inverse");

        var inverse = (x % modulo + modulo) % modulo;
        return inverse;
    }

    public static int ExtendedGcd(int a, int b, out int x, out int y)
    {
        if (a == 0)
        {
            x = 0;
            y = 1;
            return b;
        }

        var d = ExtendedGcd(b % a, a, out var x1, out var y1);
        x = y1 - (b / a) * x1;
        y = x1;
        return d;
    }
}