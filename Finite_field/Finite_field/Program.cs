using Finite_field;

Console.WriteLine("hello");


Field chek = new Field(3,2, new Polynom(new int[3] {1,1,1},3 ));
Element firstElement = new Element(chek, new Polynom(new int[2] {2,2},3));
Element secondElement = new Element(chek, new Polynom(new int[2] {1,2},3));
var resultadd = firstElement+secondElement;
var resultmulti = firstElement*secondElement;
Console.WriteLine(resultadd.polynom.ToString());
Console.WriteLine(resultmulti.polynom.ToString());