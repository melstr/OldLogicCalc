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
    public partial class Instruction : Form
    {
        private Button Temp;
        public Instruction(Button b)
        {
            InitializeComponent();
            Temp = b;
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Instruction_Load(object sender, EventArgs e)
        {

        }

        private void Instruction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Temp.Enabled = true;
        }
    }
}
