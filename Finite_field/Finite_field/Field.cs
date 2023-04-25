using System.ComponentModel;

namespace Finite_field;

public class Field
{
    public int p { get; }
    public int n { get; }
    public int q { get; } // = p^n
    public Polynom polynom { get; }

    public Field(int p, int n, Polynom polynom)
    {
        this.p = p;
        this.n = n;
        q = (int)Math.Pow(p, n);
        this.polynom = polynom;
    }

    public Element Zero =>
        new Element(this, new Polynom(new[] { 0 }, p));

    public Element One =>
        new Element(this, new Polynom(new[] { 1 }, p));

    public Element GiveElement(byte[] bytik) //по байту получаем элемент поля
    {
        if (p == 2 && n % 8 == 0)
        {
            var bytik2 = new byte[4 - bytik.Length];
            bytik = bytik.Concat(bytik2).ToArray();
            var bytik3 = BitConverter.ToInt32(bytik);
            var bytik4 = Convert.ToString(bytik3, 2);
            var pol2 = bytik4.Reverse();
            var coeff = pol2.Select(a => a - '0').ToArray();
            return new Element(this, new Polynom(coeff, p));
        }
        else
        {
            throw new Exception("поле не характеристики 2");
        }
    }

    public byte[] GiveByte(Element element)
    {
        if (p == 2 && n % 8 == 0)
        {
            string coeffs = string.Join("", element.polynom.coeff);
            string coeffs_rev = new string(coeffs.Reverse().ToArray());
            int coeff = Convert.ToInt32(coeffs_rev, 2);
            return BitConverter.GetBytes(coeff);
        }
        else
        {
            throw new Exception("поле или не имеет характеристику два или n не кратно 8");
        }
    }
}