using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agosta
{
    static class StandardCalculatorModelFactory
    {
        public static ICalculatorModel Create()
        {




            return new CalculatorModelTemplate();
        }

        private static double sum(double n1, double n2) => n1 + n2;
        private static double sub(double n1, double n2) => n1 - n2;
        private static double mult(double n1, double n2) => n1 * n2;
        private static double div(double n1, double n2) => (n2 == 0) ? 
            (n1 > 0) ? double.PositiveInfinity : double.NegativeInfinity 
            : n1 / n2;

        private static double root(double n1) => (n1 < 0) ? double.NaN : Math.Sqrt(n1);

        private static double inverse(double n1) => (n1 == 0) ? double.PositiveInfinity : 1 / n1;

        private static double square(double n1) => n1 * n1;
    }
}
