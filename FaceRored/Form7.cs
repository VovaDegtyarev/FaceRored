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
    //маленькая, числовая клавиатура
    public partial class Form7 : Form
    {

        public TextBox txtBox = null;
        public Button butt = null;

        public Form7()
        {
            InitializeComponent();
        }
        
        //скрытие клавиатуры и проверка, не стоит ли в конце введенного значения точка
        private void button85_Click(object sender, EventArgs e)
        {
            if (txtBox.Text != "")
            {
                if (txtBox.Text[txtBox.TextLength - 1] == ',')
                {
                    txtBox.Text = txtBox.Text + "0";
                }
            }
            FlagPoint = true;
            Visible = false;
            minus = false;
        }

        //метод для точки в textbox (проверка на нажатие на кнопку точки ".")
        bool FlagPoint = true;
        private void button26_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < txtBox.TextLength; i++)
            {
                if (txtBox.Text[i] == ',')
                    FlagPoint = false;
            }
            if (txtBox.TextLength != 0)
            {
                if (FlagPoint)
                {
                    txtBox.Text = txtBox.Text + ",";
                    FlagPoint = false;
                }
            }
        }
        
        //метод удаление одного символа в textbox и проверка точки (кнопка <-)
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBox.TextLength > 0)
            {
                if (txtBox.Text[txtBox.TextLength-1] == ',')
                {
                    FlagPoint = true;
                }
            txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1);            
            }            
        }

        //удаление всей строки в textbox (кнопка С)
        private void button1_Click(object sender, EventArgs e)
        {
            txtBox.Clear();
            FlagPoint = true;
            minus = false;
        }

        //запись в textbox символов от 0 до 9, в зависимости от значения тега
        private void buttonClick(object sender, MouseEventArgs e)
        {
            butt = (Button)sender;
            txtBox.Text = txtBox.Text + butt.Tag;
        }

        //знак минус
        bool minus = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (!minus)
                txtBox.Text = "-";
            else
                minus = false;
            minus = true;
            FlagPoint = true;
        }


    }
}
