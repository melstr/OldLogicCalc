using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LogicCalcForm
{
    static class Exception
    {
        public static List<string> Operands = new List<string> { "0", "1", "x", "y", "z" };
        public static List<string> Operators = new List<string> { "^", "+", "->", "<->" };
        public static List<string> eqImp = new List<string> {"-", ">", "<"};

        private static bool AllowedSymbols(string text)
        {
            foreach (var letter in text)
            {
                if (!(Operators.Contains(letter.ToString()) || Operands.Contains(letter.ToString()) ||
                    eqImp.Contains(letter.ToString()) || letter == '!' || letter == '(' || letter == ')'))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ImplicEquiv(string text)
        {
            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] == '-')
                {
                    if (i < text.Length - 1)
                    {
                        if (text[i + 1] == '>')
                        {
                            i++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                       return false;
                    }
                }
                else if (text[i] == '<')
                {
                    if (i < text.Length - 2)
                    {
                        if (text[i + 1] == '-' && text[i + 2] == '>')
                        {
                            i += 2;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool ClosedBrackets(string text)
        {
            var brackStack = new Stack<char>();
            foreach (var letter in text)
            {
                if (letter == '(')
                {
                    brackStack.Push('(');
                }
                else if (letter == ')')
                {
                    if (brackStack.Count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        brackStack.Pop();
                    }
                }
            }

            if (brackStack.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool OperandsBetweenOperators(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Operands.Contains(text[i].ToString()))
                {
                    if (i == 0)
                    {
                        if (!(Operators.Contains(text[i + 1].ToString()) || eqImp.Contains(text[i + 1].ToString()) ))
                        {
                            return false;
                        }
                    }
                    else if (i == text.Length - 1)
                    {
                        if (!(Operators.Contains(text[i - 1].ToString()) || eqImp.Contains(text[i - 1].ToString()) || text[i-1] == '!'))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if ((!(Operators.Contains(text[i - 1].ToString()) || eqImp.Contains(text[i - 1].ToString()) || text[i - 1] =='(' || text[i-1] == '!')) ||
                            (!(Operators.Contains(text[i + 1].ToString()) || eqImp.Contains(text[i + 1].ToString()) || text[i + 1] == ')')))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool OperatorsBetweenOperands(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Operators.Contains(text[i].ToString()))
                {
                    if ((i == 0) || (i == (text.Length - 1)))
                    {
                        return false;
                    }
                    if ((!(Operands.Contains(text[i - 1].ToString()) || text[i - 1] == ')' )) ||
                        (!(Operands.Contains(text[i + 1].ToString()) || text[i + 1] == '(' || text[i + 1] == '!')))
                    {
                        return false;
                    }
                }
                if (text[i] == '-')
                {
                    if ((i == 0) || (i >= (text.Length - 2)))
                    {
                        return false;
                    }
                    if ((!(Operands.Contains(text[i - 1].ToString()) || text[i - 1] == ')')) ||
                        (!(Operands.Contains(text[i + 2].ToString()) || text[i + 2] == '(' || text[i + 2] == '!')))
                    {
                        return false;
                    }

                    i++;
                    continue;
                }
                if (text[i] == '<')
                {
                    if ((i == 0) || (i >= (text.Length - 3)))
                    {
                        return false;
                    }
                    if ((!(Operands.Contains(text[i - 1].ToString()) || text[i - 1] == ')')) ||
                        (!(Operands.Contains(text[i + 3].ToString()) || text[i + 3] == '(' || text[i + 3] == '!')))
                    {
                        return false;
                    }

                    i += 2;
                }
            }


            return true;
        }

        public static bool EmptyBrackets(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(' && text[i + 1] == ')')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool OnlyOperatorsInBrackets(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == '!')
                {
                    if (text[i - 1] == '(' && text[i + 1] == ')')
                    {
                        return false;
                    }
                }
                if (Operators.Contains(text[i].ToString()))
                {
                    if (text[i - 1] == '(' && text[i + 1] == ')')
                    {
                        return false;
                    }
                }
                else if (text[i] == '-')
                {
                    if (text[i - 1] == '(' && text[i + 2] == ')')
                    {
                        return false;
                    }

                    i++;
                }
                else if (text[i] == '<')
                {
                    if (text[i - 1] == '(' && text[i + 2] == ')')
                    {
                        return false;
                    }

                    i += 2;
                }
            }

            return true;
        }

        public static bool WrongInversion(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '!')
                {
                    if (i == text.Length - 1)
                    {
                        return false;
                    }
                    else if(text[i+1] != '(' && !Operands.Contains(text[i+1].ToString()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
     
        public static bool TryMe(string text)
        {
            if (!AllowedSymbols(text))
            {
                MessageBox.Show("Использованы запрещенные символы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ImplicEquiv(text))
            {
                MessageBox.Show("Ожидалось -> или <->", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!ClosedBrackets(text))
            {
                MessageBox.Show("Скобки расставлены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!OperandsBetweenOperators(text))
            {
                MessageBox.Show("Операнды расставлены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!OperatorsBetweenOperands(text))
            {
                MessageBox.Show("Операторы расставлены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!EmptyBrackets(text))
            {
                MessageBox.Show("Скобки пусты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!OnlyOperatorsInBrackets(text))
            {
                MessageBox.Show("В скобках присутствует только оператор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!WrongInversion(text))
            {
                MessageBox.Show("Отрицания расставлены неправильно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
