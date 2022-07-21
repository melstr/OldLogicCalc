using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LogicCalcForm.PolandReverseConvert;
using static LogicCalcForm.ResultFromPol;
using static LogicCalcForm.Exception;


namespace LogicCalcForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var operandsWo10 = new List<string> {"x", "y", "z"};
            Text = textBox1.Text;
            Text = Text.Replace(" ", string.Empty);
            while(Text.Contains("!!"))
            { 
                Text = Text.Replace("!!", "!");
            }

            var usedOperandsList = new List<string>();

            foreach (var token in operandsWo10)
            {
                if (Text.Contains(token))
                {
                    usedOperandsList.Add(token);
                }
            }

            var noErrors = Exception.TryMe(Text);
            if (noErrors)
            {
                label3.Text = string.Empty;
                PolandReverseConvert polRev = new PolandReverseConvert(Text);

                Stack<string> reverseStack = new Stack<string>();
                foreach (var token in polRev.GetRevPol())
                {
                    reverseStack.Push(token);
                }
                label1.Text = string.Empty;
                foreach (var token in reverseStack)
                {
                    label1.Text += token;
                }


                if (usedOperandsList.Count > 0)
                {
                    TruthForm formT = new TruthForm(polRev.GetRevPol(), usedOperandsList);
                    formT.ShowDialog();
                }
                else
                {
                    var temp = ResultFromPol.Result(reverseStack);
                    label3.Text = "F( ) = ";
                    label3.Text += temp;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Instruction formTemp = new Instruction(button1);
            formTemp.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
