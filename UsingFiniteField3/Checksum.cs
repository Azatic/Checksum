using System;
using System.Linq;
using Finite_field;

namespace UsingFiniteField3;
/// <summary>
/// Класс, в котором реализованы методы нахождения и проверки контрольной суммы
/// </summary>
public class Controllsum
{
    private Element[] Qt;
    private Element[] Pt;
    private Field _field = new Field(2, 8, new Polynom(new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1 }, 2));
    /// <summary>
    /// Инициализация объекта класса Controllsum
    /// </summary>
    ///<param name="bytes">- массив из 4 байтов</param>
    /// 
    public Controllsum(byte[] bytes)
    {
        if (bytes.Length != 4)
        {
            throw new Exception("Количество байтов не равно 4");
        }
        Qt = bytes.Select(item => _field.GiveElement(new byte[] {item})).Append(_field.One).ToArray();
    }
    /// <summary>
    /// Метод, принимающий сообщение (массив байтов) и выдающий контрольную сумму
    /// </summary>
    public byte[] GetSumm(byte[] message)
    {
        Pt = message.Select(item => _field.GiveElement(new byte[] {item})).ToArray();
        Element[] div = Division(Pt, Qt);
        return div.Select(item => _field.GiveByte(item)[0]).ToArray();
    }
    /// <summary>
    /// Проверка контрольной суммы на подлинность
    /// </summary>
    public bool CheckSum(byte[] message, byte[] summ)
    {
        return GetSumm(message).SequenceEqual(summ);
    }
    /// <summary>
    /// Метод для деления многочленов над полем F_256
    /// </summary>
    private Element[] Division(Element[] dividend, Element[] divisor)
    {
        if (dividend == null || divisor == null)
            throw new ArgumentNullException();

        if (dividend.Length < divisor.Length)
            return dividend;

        var remainder = new Element[dividend.Length];
        Array.Copy(dividend,remainder,dividend.Length);
        var quotient = new Element[dividend.Length - divisor.Length + 1];

        for (var i = 0; i < quotient.Length; i++)
        {
            var coefficient = remainder[remainder.Length - i - 1] / divisor.Last();
            quotient[quotient.Length - 1 - i] = coefficient;
            for (var j = 0; j < divisor.Length; j++)
            {
                remainder[remainder.Length - i - j -1 ] -= coefficient * divisor[divisor.Length - j - 1];
            }
        }
        int b;
        for (b = remainder.Length - 1; b >= 0; b--)
        {
            if (remainder[b].polynom.coeff.Any(item => item != 0))
            {
                break;
            }
        }
        Array.Resize(ref remainder, b+1);
        return remainder;
    }
}