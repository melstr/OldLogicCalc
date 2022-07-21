using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCalcForm
{
    class PolandReverseConvert
    {
        private Stack<string> revPol;
        private Stack<string> station;
        public string InputString;
        public List<string> Operands;
        public List<string> Operators;
        public string token;

        public PolandReverseConvert(string s)
        {
            InputString = s;
            Operands = new List<string> { "0", "1", "x", "y", "z" };
            Operators = new List<string> { "^", "+", "->", "<->" };
            SetRevPol(new Stack<string>());
            SetStation(new Stack<string>());
            InputString = InputString.Replace(" ", string.Empty);
            Translate();
        }

        public Stack<string> GetRevPol()
        {
            return revPol;
        }

        public void SetRevPol(Stack<string> value)
        {
            revPol = value;
        }

        public Stack<string> GetStation()
        {
            return station;
        }

        public void SetStation(Stack<string> value)
        {
            station = value;
        }

        public void Translate()
        {
            for (var i = 0; i < InputString.Length; i++)
            {
                

                if (InputString[i] == '!')
                {
                    token = "!";
                    GetStation().Push(token);
                    continue;
                }

                if (InputString[i] == '(')
                {
                    GetStation().Push("(");
                    continue;
                }

                if (InputString[i] == ')')
                {
                    while (GetStation().Peek() != "(")
                    {
                        GetRevPol().Push(GetStation().Pop());
                    }

                    GetStation().Pop();
                    continue;
                }

                if (Operands.Contains(InputString[i].ToString()))
                {
                    token = InputString[i].ToString();
                    GetRevPol().Push(token);
                    continue;
                }


                if (InputString[i] == '-')
                {
                    if (InputString[i + 1] == '>')
                    {
                        token = "->";
                        i++;
                    }
                }
                else if (InputString[i] == '<')
                {
                    if ((InputString[i + 1] == '-') && (InputString[i + 2] == '>'))
                    {
                        token = "<->";
                        i += 2;
                    }
                }
                else if (Operators.Contains(InputString[i].ToString()))
                {
                    token = InputString[i].ToString();
                }
                

                if (Operators.Contains(token))
                {
                    var flag = true;
                    while (flag)
                    {

                        if (GetStation().Count == 0)
                        {
                            GetStation().Push(token);
                            flag = false;
                        }
                        else if (((Operators.IndexOf(GetStation().Peek()) <= Operators.IndexOf(token)) || (GetStation().Peek() == "!")) && (GetStation().Peek() != "("))
                        {
                            GetRevPol().Push(GetStation().Pop());
                        }
                        else
                        {
                            GetStation().Push(token);
                            flag = false;
                        }
                    }
                }
            }

            while (GetStation().Count > 0)
            {
                GetRevPol().Push(GetStation().Pop());
            }
        }
    }
}
