namespace Finite_field;

public class Element
{
    public Field field;
    public Polynom polynom;

    public Element(Field field, Polynom polynom)
    {
        this.field = field;
        this.polynom = polynom;
    }

    public static Element operator +(Element element) => element;

    public static Element operator -(Element element) =>
        new Element(element.field, -element.polynom);

    public static Element operator +(Element left, Element right)
    {
        if (left.field != right.field)
            throw new ArgumentException("РАЗНЫЕ ПОЛЯ! КОНЕЦ");

        return new Element(left.field, left.polynom + right.polynom);
    }

    public static Element operator -(Element left, Element right) => left + (-right);

    public static Element operator *(Element left, Element right)
    {
        if (left.field != right.field)
            throw new ArgumentException("Elements from different fields");

        return new Element(left.field, left.polynom * right.polynom % left.field.polynom);
    }

    public static Element operator /(Element left, Element right)
    {
        if (right == right.field.Zero)
        {
            throw new DivideByZeroException("ДЕЛИТЬ НА НОЛЬ НЕЛЬЗЯ");
        }

        return new Element(left.field, left.polynom * right.Inverse.polynom % left.field.polynom);
    }

    public Element Pow(int degree)
    {
        if (degree == 0) return field.One;
        if (degree == 1) return this;

        if (degree % 2 == 0)
        {
            Element n;
            n = Pow(degree / 2);
            return n * n;
        }

        return this * Pow(degree - 1);
    }

    public Element Inverse => Pow(field.q - 2);
}