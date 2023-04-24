using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UsingFiniteField3;

namespace Tests2;

public class Tests
{
    private Controllsum _crc;
    private string _message;
    private byte[] _byteMessage1;
    private byte[] _byteMessage2;

    private const int Number = 0x04C11DB7;

    [SetUp]
    public void Setup()
    {
        _crc = new Controllsum(BitConverter.GetBytes(Number));
        _message = "0123456789";
        _byteMessage1 = Encoding.UTF8.GetBytes(_message);
        _byteMessage2 = _byteMessage1.Reverse().ToArray();
    }

    [Test]
    public void GetCertainCheckSumTest()
    {
        var expectedCheckSum = new byte[] { 104, 169, 157, 91 };

        var actualCheckSum = _crc.GetSumm(_byteMessage1);

        Assert.IsTrue(actualCheckSum.SequenceEqual(expectedCheckSum));
    }
    [Test]
    public void EqualCheckSumTrueTest()
    {
        var checkSum1 = _crc.GetSumm(_byteMessage1);
        var checkSum2 = _crc.GetSumm(_byteMessage1);

        Assert.IsTrue(checkSum1.SequenceEqual(checkSum2));
    }
    [Test]
    public void EqualCheckSumFalseTest()
    {
        var checkSum1 = _crc.GetSumm(_byteMessage1);
        var checkSum2 = _crc.GetSumm(_byteMessage2);

        Assert.IsFalse(checkSum1.SequenceEqual(checkSum2));
    }
    [Test]
    public void CheckTrueTest()
    {
        var checkSum1 = _crc.GetSumm(_byteMessage1);

        Assert.IsTrue(_crc.CheckSum(_byteMessage1, checkSum1));
    }
}