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
    public partial class Form8 : Form
    {

        public Form3 fm3 = null;

        public Form8(Form3 f3)
        {
            InitializeComponent();
            fm3 = f3;
        }

        string DiameterCurrent;
        string DiameterMax;
        string DiameterMin;

        string OvalityCurrent;
        string OvalityMax;

        string StraightnessCurrent;
        string StraightnessMax;

        static bool DiameterStatusManual;         // статус, прошла ли палка по диаметру
        static bool OvalityStatusManual;          // статус, прошла ли палка по овальности
        static bool StraightnessStatusManual;     // статус, прошла ли палка по прямолинейности

        static bool DiameterStatusAuto;         
        static bool OvalityStatusAuto;          
        static bool StraightnessStatusAuto; 

        //скрытие и отображение формы
        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;            
        }

        //передача данных между формами Form3(установка пределов вручную) и Form8(визуализация ручного и автоматического измерения) через сво-ва массива
        public void TranslateDataBetweenForms() 
        {
            //диаметр
            textBox7.Text = fm3.arrayValueDiameterProp[0];
            //textBox8.Text = fm3.arrayValueDiameterProp[1];
            //textBox9.Text = fm3.arrayValueDiameterProp[2];
            //textBox10.Text = fm3.arrayValueDiameterProp[3];
            textBox11.Text = fm3.arrayValueDiameterProp[1];
            //овальность
            textBox14.Text = fm3.arrayValueOvalityProp[0];
            //textBox13.Text = fm3.arrayValueOvalityProp[1];
            //textBox12.Text = fm3.arrayValueOvalityProp[2];
            //прямолинейность
            textBox18.Text = fm3.arrayValueStraightnessProp[0];
            //textBox17.Text = fm3.arrayValueStraightnessProp[1];
            //textBox15.Text = fm3.arrayValueStraightnessProp[2];
        }

        public void SetStatusBars(bool DiamStMan, bool OvalStMan, bool StrtStMan, bool DiamStAuto, bool OvalStAuto, bool StrStAuto)
        {
            if (DiamStMan)
            {
                //DiameterStatusManual = true;
                panel1.BackColor = Color.Lime;
            }
            else 
            {
                //DiameterStatusManual = false;
                panel1.BackColor = Color.Red;
            }

            if (OvalStMan)
            {
                //OvalityStatusManual = true;
                panel3.BackColor = Color.Lime;
            }
            else
            {
                //OvalityStatusManual = false;
                panel3.BackColor = Color.Red;
            }

            if (StrtStMan)
            {
                //StraightnessStatusManual = true;
                panel4.BackColor = Color.Lime;
            }
            else
            {
                //StraightnessStatusManual = false;
                panel4.BackColor = Color.Red;
            }

            if (DiamStAuto)
            {
                //DiameterStatusAuto = true;
                panel2.BackColor = Color.Lime;
            }
            else
            {
                //DiameterStatusAuto = false;
                panel2.BackColor = Color.Red;
            }

            if (OvalStAuto)
            {
                //OvalityStatusAuto = true;
                panel5.BackColor = Color.Lime;
            }
            else
            {
                //OvalityStatusAuto = false;
                panel5.BackColor = Color.Red;
            }
            if (StrStAuto)
            {
                //StraightnessStatusAuto = true;
                panel6.BackColor = Color.Lime;
            }
            else
            {
                //StraightnessStatusAuto = false;
                panel6.BackColor = Color.Red;
            }
        }


        //--------------------------------------------------------------------------------------------------------
        //свойства для автоматического измерения
        public string DiameterCurrentProp
        {
            set
            {
                DiameterCurrent = value;
                textBox23.Text = DiameterCurrent;
            }
            get
            {
                return DiameterCurrent;
            }
        }

        public string DiameterMaxProp
        {
            set
            {
                DiameterMax = value;
                textBox6.Text = DiameterMax;
            }
            get
            {
                return DiameterMax;
            }
        }

        public string DiameterMinProp
        {
            set
            {
                DiameterMin = value;
                textBox5.Text = DiameterMin;
            }
            get
            {
                return DiameterMin;
            }
        }

        public string OvalityCurrentProp
        {
            set
            {
                OvalityCurrent = value;
                textBox24.Text = OvalityCurrent;
            }
            get
            {
                return OvalityCurrent;
            }
        }

        public string OvalityMaxProp
        {
            set
            {
                OvalityMax = value;
                textBox4.Text = OvalityMax;
            }
            get
            {
                return OvalityMax;
            }
        }

        public string StraightnessCurrentProp
        {
            set
            {
                StraightnessCurrent = value;
                textBox25.Text = StraightnessCurrent;
            }
            get
            {
                return StraightnessCurrent;
            }
        }

        public string StraightnessMaxProp
        {
            set
            {
                StraightnessMax = value;
                textBox3.Text = StraightnessMax;
            }
            get
            {
                return StraightnessMax;
            }
        }

        //-----------------------------------------------
        //св-ва для получения статуса прутка по диаметру, овальности и прямолинейности
        public bool DiameterStatusManualProp 
        {
            set 
            {
                DiameterStatusManual = value;
            }
            get
            {
                return DiameterStatusManual;
            }
        }

        public bool OvalityStatusManualProp
        {
            set
            {
                OvalityStatusManual = value;
            }
            get
            {
                return OvalityStatusManual;
            }
        }

        public bool StraightnessStatusManualProp
        {
            set
            {
                StraightnessStatusManual = value;
            }
            get
            {
                return StraightnessStatusManual;
            }
        }



        public bool DiameterStatusAutoProp
        {
            set
            {
                DiameterStatusAuto = value;
            }
            get
            {
                return DiameterStatusAuto;
            }
        }

        public bool OvalityStatusAutoProp
        {
            set
            {
                OvalityStatusAuto = value;
            }
            get
            {
                return OvalityStatusAuto;
            }
        }

        public bool StraightnessStatusAutoProp
        {
            set
            {
                StraightnessStatusAuto = value;
            }
            get
            {
                return StraightnessStatusAuto;
            }
        }

    }
}
