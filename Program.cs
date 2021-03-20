using System;

namespace FractionToLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr1 = new Fraction(1, 1, 2);
            Fraction fr2 = new Fraction(-1, 3);
            Console.WriteLine(fr1);
            Console.WriteLine(fr2);
            Console.WriteLine("fr1+fr2 = " + (fr1 + fr2));
            Console.WriteLine("fr1-fr2 = " + (fr1 - fr2));
            Console.WriteLine("fr1*fr2 = " + (fr1 * fr2));
            Console.WriteLine("fr1/fr2 = " + (2 / fr1));
            Console.WriteLine(fr1.GetDecimalFraction());
        }
    }
}