using Finite_field;

namespace Tests1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Polynomsumm()
    {
        var polynom1 = new Polynom(new[] { 1, 2, 3, 4, 5, 6 }, 10);
        var polynom2 = new Polynom(new[] { 1, 2, 3, 4, 5, 6 }, 10);
        var polynomsumm = new Polynom(new[] { 2, 4, 6, 8, 0, 2 }, 10);
        Assert.That((polynom1+polynom2).coeff,Is.EqualTo(polynomsumm.coeff));
    }
    
    [Test]
    
    public void Polynommulty()
    {
        var polynomial1 = new Polynom(new[] { 1, 2, 3, 4, 5, 6 }, 10);
        var polynomial2 = new Polynom(new[] { 6,5,4,3,2,1 }, 10);

        Assert.That((polynomial1*polynomial2).coeff, Is.EqualTo(new[]{6,7,2,0,0,1,0,0,2,7,6}));
    }
    
    [Test]
    public void FindRemainderTest()
    {
        var polynomial1 = new Polynom(new[] { 42, 0, 12, 1 }, 10);
        var polynomial2 = new Polynom(new[] { 3, 1 }, 10);

        var remainder = polynomial1 % polynomial2;
        var expectedResult = new Polynom(new[] { -7,0,0,0 }, 10);

        Assert.That(remainder.coeff, Is.EqualTo(expectedResult.coeff));
    }
    
    
}