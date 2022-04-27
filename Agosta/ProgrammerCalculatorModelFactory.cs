using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agosta
{
    static class ProgrammerCalculatorModelFactory
    {
        public static ICalculatorModel Create()
        {
            return new CalculatorModelTemplate();
        }

        private static double And(double n1, double n2) => (long)n1 & (long)n2;

        private static double Or(double n1, double n2) => (long)n1 | (long)n2;

        private static double Nand(double n1, double n2) => Not(And(n1, n2));

        private static double Nor(double n1, double n2) => Not(Or(n1, n2));

        private static double Xor(double n1, double n2) => (long)n1 ^ (long)n2;

        private static double ShiftR(double n1, double n2) => (long)n1 >> (int)n2;

        private static double ShiftL(double n1, double n2) => (long)n1 << (int)n2;

        private static string AddLeadingZerosToByte(string str)
        {
            string unsigned = str.Substring(1);
            while(unsigned.Length % 8 != 0)
            {
                unsigned = "0" + unsigned;
            }
            return char.ToString(str.ElementAt(0)) + unsigned;
        }

        private static double Not(double n1)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(addedZero.ElementAt(0));
            var iter = addedZero.Substring(1).GetEnumerator();
            string ret = "";
            while (iter.MoveNext())
            {
                ret += ("0".Equals(char.ToString(iter.Current))) ? "1" : "0";
            }
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }

        private static double RoR(double n1, double n2)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(conv.ElementAt(0));
            string ret = addedZero.Substring(1);
            ret = ret.Substring(ret.Length - (int)n2) + ret.Substring(0, ret.Length - (int)n2);
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }
        private static double RoL(double n1, double n2)
        {
            string conv = ConversionAlgorithms.ToBase((long)n1, 2);
            string addedZero = AddLeadingZerosToByte(conv);
            string sign = Char.ToString(conv.ElementAt(0));
            string ret = addedZero.Substring(1);
            ret = ret.Substring((int)n2) + ret.Substring(0, (int)n2);
            return ConversionAlgorithms.ToSignedDecimal(sign + ret, 2);
        }

    }
}
