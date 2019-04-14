using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceRored
{
    //большая клавиатура
    public partial class Form6 : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        public Form6()
        {
            InitializeComponent();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("Q");
                checkBox3.Checked = false;
            }
            else 
            {
                SendKeys.Send("q");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("W");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("w");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("E");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("e");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("R");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("r");              
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("T");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("t");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("Y");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("y");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("U");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("u");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("I");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("i");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("O");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("o");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("P");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("p");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("A");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("a");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("S");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("s");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("D");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("d");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("F");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("f");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("G");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("g");
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("H");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("h");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("J");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("j");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("K");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("k");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("L");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("l");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("Z");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("z");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("X");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("x");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("C");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("c");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("V");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("v");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("B");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("b");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("N");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("n");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox3.Checked)
            {
                SendKeys.Send("M");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("m");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("!");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("1");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("@");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("2");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("#");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("3");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("$");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("4");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("%");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("5");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("^");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("6");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("?");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("7");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("*");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("8");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("(");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("9");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send(")");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("0");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("_");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("-");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("+");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("=");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("~");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send(",");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("{");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("[");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("}");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("]");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void button58_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send(":");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send(";");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("''");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("'");
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send("|");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("");
            }
        }

        private void button87_Click(object sender, EventArgs e)
        {
            SendKeys.Send("0");
        }

        private void button80_Click(object sender, EventArgs e)
        {
            SendKeys.Send("1");
        }

        private void button89_Click(object sender, EventArgs e)
        {
            SendKeys.Send("2");
        }

        private void button88_Click(object sender, EventArgs e)
        {
            SendKeys.Send("3");
        }

        private void button83_Click(object sender, EventArgs e)
        {
            SendKeys.Send("4");
        }

        private void button82_Click(object sender, EventArgs e)
        {
            SendKeys.Send("5");
        }

        private void button81_Click(object sender, EventArgs e)
        {
            SendKeys.Send("6");
        }

        private void button73_Click(object sender, EventArgs e)
        {
            SendKeys.Send("7");
        }

        private void button72_Click(object sender, EventArgs e)
        {
            SendKeys.Send("8");
        }

        private void button84_Click(object sender, EventArgs e)
        {
            SendKeys.Send("9");
        }

        private void button78_Click(object sender, EventArgs e)
        {
            SendKeys.Send("/");
        }

        private void button77_Click(object sender, EventArgs e)
        {
            SendKeys.Send("*");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }

        private void button63_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

        private void button62_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F1}");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F2}");
        }

        private void button54_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F3}");
        }

        private void button40_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void button71_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F5}");
        }

        private void button70_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F6}");
        }

        private void button69_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F7}");
        }

        private void button68_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F8}");
        }

        private void button67_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F9}");
        }

        private void button76_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F10}");
        }

        private void button75_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F11}");
        }

        private void button74_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F12}");
        }

        private void button86_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                SendKeys.Send(".");
                checkBox3.Checked = false;
            }
            else
            {
                SendKeys.Send("{DELETE}");
            }
        }




    }
}
