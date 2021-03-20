using System;
using System.Collections.Generic;
using System.Text;

namespace FractionToLesson
{
    class Fraction
    {
        public int IntegerPart { get; private set; }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        private int sign;
        public int Sign { get => sign; set => sign = Math.Sign(value) != 0 ? Math.Sign(value) : 1; }

        public Fraction(int integerPart, int numerator, int denominator)
        {
            IntegerPart = Math.Abs(integerPart);
            Numerator = Math.Abs(numerator);
            Denominator = Math.Abs(denominator);
            sign = Math.Sign(integerPart) != 0 ? Math.Sign(integerPart) : 1;
        }
        public Fraction(int numerator, int denominator)
        {
            IntegerPart = 0;
            Numerator = Math.Abs(numerator);
            Denominator = Math.Abs(denominator);
            sign = Math.Sign(numerator) != 0 ? Math.Sign(numerator) : 1;
        }

        public override string ToString()
        {
            if (IntegerPart != 0)
                return (IntegerPart * sign).ToString() + " " + Numerator.ToString() + "/" + Denominator.ToString();
            else if (Numerator == Denominator)
                return sign.ToString();
            else
                return (Numerator * sign).ToString() + "/" + Denominator.ToString();
        }

        public double GetDecimalFraction()
        {
            return (IntegerPart * Denominator + Numerator) / (double)Denominator;
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            if (fr1.Sign == fr2.Sign)
                if (fr1.Denominator == fr2.Denominator)
                    return new Fraction(
                        (fr1.IntegerPart + fr2.IntegerPart) * fr1.sign,
                        fr1.Numerator + fr2.Numerator,
                        fr1.Denominator);
                else
                    return new Fraction(
                            (fr1.IntegerPart + fr2.IntegerPart) * fr1.sign,
                            fr1.Numerator * fr2.Denominator + fr2.Numerator * fr1.Denominator,
                            fr1.Denominator * fr2.Denominator);
            else if (fr1.sign > 0)
                return fr1 - new Fraction(fr2.IntegerPart, fr2.Numerator, fr2.Denominator);
            else
                return fr2 - new Fraction(fr1.IntegerPart, fr1.Numerator, fr1.Denominator);

        }
        public static Fraction operator +(Fraction fr1, int num)
        {
            if (fr1.sign == Math.Sign(num))
                return new Fraction(
                    fr1.IntegerPart + num,
                    fr1.Numerator,
                    fr1.Denominator);
            else if (fr1.sign > 0)
                return fr1 - num;
            else
                return num - new Fraction(fr1.IntegerPart, fr1.Numerator, fr1.Denominator);
        }
        public static Fraction operator +(int num, Fraction fr1)
        {
            if (fr1.sign == Math.Sign(num))
                return new Fraction(
                    fr1.IntegerPart + num,
                    fr1.Numerator,
                    fr1.Denominator);
            else if (fr1.sign > 0)
                return fr1 - num;
            else
                return num - new Fraction(fr1.IntegerPart, fr1.Numerator, fr1.Denominator);
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            if (fr1.sign == fr2.sign && fr1.sign > 0)
                if (fr1.Denominator == fr2.Denominator)
                    if (fr1.Numerator - fr2.Numerator > 0)
                        return new Fraction(
                            fr1.IntegerPart - fr2.IntegerPart,
                            fr1.Numerator - fr2.Numerator,
                            fr1.Denominator);
                    else
                        return new Fraction(
                            fr1.IntegerPart - fr2.IntegerPart - 1,
                            (fr1.Numerator + fr1.IntegerPart * fr1.Denominator) - fr2.Numerator,
                            fr1.Denominator);
                else
                    if (fr1.Numerator - fr2.Numerator > 0)
                    return new Fraction(
                            fr1.IntegerPart - fr2.IntegerPart,
                            fr1.Numerator * fr2.Denominator - fr2.Numerator * fr1.Denominator,
                            fr1.Denominator * fr2.Denominator);
                else
                    return new Fraction(
                                    fr1.IntegerPart - fr2.IntegerPart - 1,
                                    (fr1.Numerator + fr1.IntegerPart * fr1.Denominator) * fr2.Denominator - fr2.Numerator * fr1.Denominator,
                                    fr1.Denominator * fr2.Denominator);
            else if (fr1.sign == fr2.sign && fr1.sign < 0)
                return fr2 - new Fraction(fr1.IntegerPart, fr1.Numerator, fr1.Denominator);
            else if (fr1.sign > 0)
                return fr1 + new Fraction(fr2.IntegerPart, fr2.Numerator, fr2.Denominator);
            else
                return fr1 + fr2;
        }
        public static Fraction operator -(Fraction fr1, int num)
        {
            if (fr1.sign == Math.Sign(num) && fr1.sign > 0)
                return new Fraction(
                    fr1.IntegerPart - num,
                    fr1.Numerator,
                    fr1.Denominator);
            else if (fr1.sign == Math.Sign(num) && fr1.sign < 0)
                return num - new Fraction(fr1.IntegerPart, fr1.Numerator, fr1.Denominator);
            else
                return fr1 + num;
        }
        public static Fraction operator -(int num, Fraction fr1)
        {
            if (fr1.sign == Math.Sign(num) && fr1.sign > 0)
                return new Fraction(num, 1, 1) - fr1;
            else if (fr1.sign == Math.Sign(num) && fr1.sign < 0)
                return fr1 - num;
            else
                return fr1 + num;
        }

        public static Fraction operator *(Fraction fr1, Fraction fr2)
        {
            return new Fraction(
                        0,
                        (fr1.Numerator + fr1.IntegerPart * fr1.Denominator) * (fr2.Numerator + fr2.IntegerPart * fr2.Denominator) * (fr1.sign * fr2.sign),
                        fr1.Denominator * fr2.Denominator);
        }
        public static Fraction operator *(Fraction fr1, int num)
        {
            return new Fraction(
                fr1.IntegerPart * num * fr1.sign,
                fr1.Numerator * num,
                fr1.Denominator);
        }
        public static Fraction operator *(int num, Fraction fr1)
        {
            return new Fraction(
                fr1.IntegerPart * num * fr1.sign,
                fr1.Numerator * num,
                fr1.Denominator);
        }

        public static Fraction operator /(Fraction fr1, Fraction fr2)
        {
            return new Fraction(
                        0,
                        (fr1.Numerator + fr1.IntegerPart * fr1.Denominator) * fr2.Denominator * (fr1.sign * fr2.sign),
                        (fr2.Numerator + fr2.IntegerPart * fr2.Denominator) * fr1.Denominator);
        }
        public static Fraction operator /(Fraction fr1, int num)
        {
            return fr1 / new Fraction(num, 1, 1);
        }
        public static Fraction operator /(int num, Fraction fr1)
        {
            return new Fraction(num, 0, 1) / fr1;
        }
    }
}
//P.S. Я не совсем уверен, что всё из этого правильно работает. По хорошему, мне ещё нужно было провести пару тестов, чтобы удостовериться в отсудствии ошибок
//Дробь плохо работает с нулями и может выдавать "интересные" результаты


