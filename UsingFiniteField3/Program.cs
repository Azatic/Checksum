using System.Text;
using UsingFiniteField3;

byte[] Polynom = new byte[] { 104, 169, 157, 91 };
var _crc1 = new Controllsum(Polynom);

var actualCheckSum = _crc1.GetSumm(new byte[] { 104, 169, 157, 91 });
var _crc1q = new Controllsum(Polynom);


