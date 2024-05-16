using OOProject.Models.Languages;
using System;

namespace OOProject.Models
{
    internal class NumericalExpression
    {
        private readonly ulong num;
        private readonly Func<ulong, ILangSettings, string> NumWordConverter;

        internal NumericalExpression(ulong num)
        {
            this.num = num;
            NumWordConverter = ToWord;
        }
        internal NumericalExpression() : this(0) { }

        public override string ToString()
        {
            if (num == 0)
                return "Zero";
            else
                return NumWordConverter(num, new EnglishSettings());
        }

        internal ulong GetValue() => num;

        internal static ulong SumLetters(ulong num)
        {
            ulong charCounter = 0;
            string numStr;

            for (ulong i = 0; i <= num; i++)
            {
                numStr = new NumericalExpression(i).ToString().Replace(" ", "");
                charCounter += (ulong)numStr.Length;
            }
            return charCounter;
        }

        internal static ulong SumLetters(NumericalExpression ne)
        {
            ulong charCounter = 0;
            string numStr;

            for (ulong i = 0; i <= ne.GetValue(); i++)
            {
                numStr = new NumericalExpression(i).ToString().Replace(" ", "");
                charCounter += (ulong)numStr.Length;
            }
            return charCounter;
        }

        private string ToWord(ulong num, ILangSettings ls)
        {
            if (num >= 1 && num <= 19) // 1 - 20
                return ls.ONES[num];

            else if (num >= 20 && num <= 99)  // 20 - 90
            {
                ulong n = num / 10;
                return $"{ls.TENS[n]} {ToWord(num % 10, ls)}";
            }
            else if (num >= 100 && num <= 999)  // 100 - 999
            {
                ulong n = num / 100;
                return $"{ToWord(n, ls)} {ls.PREFIXES[0]} {ToWord(num % 100, ls)}";
            }
            else if (num >= 1000 && num <= 999999)  // 1000 - 999 999
            {
                ulong n = num / 1000;
                return $"{ToWord(n, ls)} {ls.PREFIXES[1]} {ToWord(num % 1000, ls)}";
            }
            else if (num >= 1000000 && num <= 999999999)  // 1 000 000 - 999 999 999
            {
                ulong n = num / 1000000;
                return $"{ToWord(n, ls)} {ls.PREFIXES[2]} {ToWord(num % 1000000, ls)}";
            }
            else if (num >= 1000000000 && num <= 999999999999)  // 1 000 000 000 - 999 999 999 999
            {
                ulong n = num / 1000000000;
                return $"{ToWord(n, ls)} {ls.PREFIXES[3]} {ToWord(num % 1000000000, ls)}";
            }
            else
                return "";
        }
    }
}
