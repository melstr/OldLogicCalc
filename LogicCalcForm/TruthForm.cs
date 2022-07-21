using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicCalcForm
{
    public partial class TruthForm : Form
    {
        public TruthForm(Stack<string> revPolStack, List<string> usedLettersList)
        {
            InitializeComponent();
            var operandsValues = new List<string>();

            for (int i = 0; i < usedLettersList.Count; i++)
            {
                operandsValues.Add("0");
            }

            dataGridView1.ColumnCount = usedLettersList.Count + 1;

            for (int i = 0; i < usedLettersList.Count; i++)
            {
                dataGridView1.Columns[i].Name = usedLettersList[i];
            }

            dataGridView1.Columns[usedLettersList.Count].Name = "F()";
      
            makeTruthTable(operandsValues, revPolStack, usedLettersList);
        }
    

        private void TruthForm_Load(object sender, EventArgs e)
        {

        }

         public void makeTruthTable(List<string> opValues, Stack<string> revPolStack, List<string> usedLettersList, int index = 0)
          {
              for (int i = 0; i < 2; i++)
              {
                  opValues[index] = i.ToString();
                  if (index < opValues.Count - 1)
                  {
                      makeTruthTable(opValues, revPolStack, usedLettersList, index + 1);
                  }
                  else if (index == opValues.Count - 1)
                  {
                      var row = new string[opValues.Count + 1];

                      for (int j = 0; j < opValues.Count; j++)
                      {
                          row[j] = opValues[j];
                      }
                      Stack<string> reverseStack = new Stack<string>();
                      foreach (var token in revPolStack)
                      {
                          var sign = token;
                          if (usedLettersList.Contains(token))
                          {
                              sign = opValues[usedLettersList.IndexOf(sign)];
                          }
                          reverseStack.Push(sign);
                      }
                      row[opValues.Count] = ResultFromPol.Result(reverseStack);
                      var temp = ResultFromPol.Result(reverseStack);
                      dataGridView1.Rows.Add(row);
                  }
              }
          }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

