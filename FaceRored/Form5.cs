using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRored
{
    public partial class Form5 : Form
    {

        //Form1 fm1 = null;

        public Form5(Form1 f1)
        {            
            InitializeComponent();
            //fm1 = f1;
            //LinkStatus(fm1.LinkToPLCprop, fm1.LinkToAnybusProp, fm1.LinkToServiceProp);
        }

        //скрытие формы
        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        //установка статусов связи
        public void LinkStatus(bool Com_Port_Zumb, bool Communication_Zumb, bool Data_Zumb, 
                               bool Com_Port_Anybus, bool Communication_anybus, bool Data_Anybus, bool PLC_anybus)
        {
            if (Com_Port_Zumb)
            {
                panel6.BackColor = Color.Lime;
            }
            else 
            {
                panel6.BackColor = Color.Red;
            }

            if (Communication_Zumb)
            {
                panel4.BackColor = Color.Lime;
            }
            else
            {
                panel4.BackColor = Color.Red;
            }

            if (Data_Zumb)
            {
                panel3.BackColor = Color.Lime;
            }
            else
            {
                panel3.BackColor = Color.Red;
            }

            if (Com_Port_Anybus)
            {
                panel9.BackColor = Color.Lime;
            }
            else
            {
                panel9.BackColor = Color.Red;
            }

            if (Communication_anybus)
            {
                panel8.BackColor = Color.Lime;
            }
            else
            {
                panel8.BackColor = Color.Red;
            }

            if (Data_Anybus)
            {
                panel7.BackColor = Color.Lime;
            }
            else
            {
                panel7.BackColor = Color.Red;
            }

            if (PLC_anybus)
            {
                panel10.BackColor = Color.Lime;
            }
            else
            {
                panel10.BackColor = Color.Red;
            }
        }

    }
}
