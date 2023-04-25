using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UsingFiniteField3;

namespace Tests2;

public class Tests
{
    private byte[] _message;
    private byte[] _bigmessage;
    private byte[] _byteMessage1;
    private byte[] _byteMessage2;

    private const int Number = 0x04C11DB7;
    byte[] Polynom = new byte[] { 104, 169, 157, 91 };
    private Controllsum _crc1;

    [SetUp]
    public void Setup()
    {
        _crc1 = new Controllsum(Polynom);
        _message = new byte[] { 104, 169, 157, 91 };
        _bigmessage = new byte[] { 104, 169, 157, 91 ,35,64,23,100};
        _byteMessage1 = _message;
        _byteMessage2 = _byteMessage1.Reverse().ToArray();
    }
    [Test]
    public void GetCertainCheckSumTest()
    {
        var expectedCheckSum = new byte[] { 104, 169, 157, 91 };

        var actualCheckSum = _crc1.GetSumm(_byteMessage1);

        Assert.IsTrue(actualCheckSum.SequenceEqual(expectedCheckSum));
    }
    [Test]
    public void GetCertainCheckSumTest2()
    {
        var actualCheckSum = _crc1.GetSumm(_bigmessage);

        Assert.IsTrue(actualCheckSum.SequenceEqual(new byte[] {56,153,44,137}));
    }
    [Test]
    public void EqualCheckSumTrueTest()
    {
        var checkSum1 = _crc1.GetSumm(_byteMessage1);
        var checkSum2 = _crc1.GetSumm(_byteMessage1);

        Assert.IsTrue(checkSum1.SequenceEqual(checkSum2));
    }
    [Test]
    public void EqualCheckSumFalseTest()
    {
        var checkSum1 = _crc1.GetSumm(_byteMessage1);
        var checkSum2 = _crc1.GetSumm(_byteMessage2);

        Assert.IsFalse(checkSum1.SequenceEqual(checkSum2));
    }
    [Test]
    public void CheckTrueTest()
    {
        var checkSum1 = _crc1.GetSumm(_byteMessage1);

        Assert.IsTrue(_crc1.CheckSum(_byteMessage1, checkSum1));
    }

}