using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCalcForm
{
    static class LogicOps
    {
        public static bool Conjunction(bool x, bool y)
        {
            return x && y;
        }

        public static bool Disjunction(bool x, bool y)
        {
            return x || y;
        }

        public static bool Implication(bool x, bool y)
        {
            return !x || y;
        }

        public static bool Equivalent(bool x, bool y)
        {
            return x == y;
        }

    }
}
