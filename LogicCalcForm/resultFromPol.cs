using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogicCalcForm.LogicOps;
namespace LogicCalcForm
{
    static class ResultFromPol
    {
        public static List<string> Operands = new List<string> { "0", "1", "x", "y", "z" };
        public static List<string> Operators = new List<string> { "^", "+", "->", "<->" };

        public static string Result(Stack<string> poland)
        {
            Stack<string> buffer = new Stack<string>();

            foreach (var token in poland)
            {
                if (Operands.Contains(token))
                {
                    buffer.Push(token);
                }
                else if (Operators.Contains(token))
                {
                    if (token == "^")
                    {
                        var y = buffer.Pop() == "1";
                        var x = buffer.Pop() == "1";
                        var z =  (LogicOps.Conjunction(x, y) ? "1" : "0");
                        buffer.Push(z);
                    }
                    else if (token == "+")
                    {
                        var y = buffer.Pop() == "1";
                        var x = buffer.Pop() == "1";
                        var z = (LogicOps.Disjunction(x, y) ? "1" : "0");
                        buffer.Push(z);
                    }
                    else if (token == "->")
                    {
                        var y = buffer.Pop() == "1";
                        var x = buffer.Pop() == "1";
                        var z = (LogicOps.Implication(x, y) ? "1" : "0");
                        buffer.Push(z);
                    }
                    else if (token == "<->")
                    {
                        var y = buffer.Pop() == "1";
                        var x = buffer.Pop() == "1";
                        var z = (LogicOps.Equivalent(x, y) ? "1" : "0");
                        buffer.Push(z);
                    }
                }
                else if (token == "!")
                {
                    var x = buffer.Pop() != "1";
                    var z = (x ? "1" : "0");
                    buffer.Push(z);
                }
            }

            return buffer.Pop();
        }
    }
}
