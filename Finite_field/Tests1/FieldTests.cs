using Finite_field;

namespace Tests1;

public class FieldTests
{
    private Field _field;
    [SetUp]
    public void SetUp()
    {
        _field = new Field(2, 8, new Polynom(new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1 }, 2));
    }
    
    [Test]
    public void AddTest()
    {
        var element1 = new Element(_field,new Polynom(new int[] { 1, 0, 1, 1, 1 }, 2 ));
        var element2 = new Element(_field,new Polynom(new int[] { 5, 0, 6, 9, 10 }, 2 ));

        var sum = element1 + element2;
        

        Assert.That(sum.polynom.coeff, Is.EqualTo(new int[] { 0, 0, 1, 0, 1 }));
    }

    [Test]
    public void MultiplicationTest1()
    {
        var element1 = new Element(_field,new Polynom(new[] { 1, 0, 1, 0, 1 }, 2 ));
        var element2 = new Element(_field, new Polynom(new[] { 1, 1, 1, 0, 0 }, 2));
        var mul = element1 * element2;
      

        Assert.That(mul.polynom.coeff, Is.EqualTo(new[] {1, 1, 0, 1, 0, 1, 1 ,0 ,0}));
    }
    [Test]
    public void Elementadd()
    {
        var element1 = _field.GiveElement(new byte[] { 57 });
        var element2 = _field.GiveElement(new byte[] { 32 });
        var element3 = _field.GiveElement(new byte[] { 89 });
        
        

        Assert.That(element3.polynom.coeff, Is.EqualTo((element1+element2).polynom.coeff.Append(1)));
    }

}