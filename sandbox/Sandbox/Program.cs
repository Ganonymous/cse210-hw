using System;

class Program
{
    static void Main(string[] args)
    {
        TestClass test1 = new TestClass();
        test1.test = "hello ";
        TestClass test2 = test1;
        test2.test = "world";
        Console.WriteLine($"{test1.test}{test2.test}");
    }
}