using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace FaceRored
{
    public partial class Form3 : Form
    {

        public Button buttSave = null;

        //массивы хранящие данные занесенные в ручном режиме:
        //  Диаметр
        //  0   -   Верхний предел допусков диаметра 
        //  1   -   Верхний предторевожный предел допусков диаметра
        //  2   -   Номинальное значение диаметра
        //  3   -   Нижний предторевожный предельный допусков диаметра
        //  4   -   Нижний предел допусков диаметра
        //  
        //  Овальность
        //  0   -   Верхний предел допусков овальности 
        //  1   -   Верхний предторевожный предел допусков овальности
        //  2   -   Номинальное значение овальности
        //
        //  Прямолинейность
        //  0   -   Верхний предел допусков прямолинейности 
        //  1   -   Верхний предторевожный предел допусков прямолинейности
        //  2   -   Номинальное значение прямолинейности

        //  Диаметр
        string DiameterHighFaultLimitValue;         //  0   -   Верхний предел допусков диаметра 
        //string DiameterHighAlarmLimitValue;         //  1   -   Верхний предторевожный предел допусков диаметра
        //string DiameterNominalVaue;                 //  2   -   Номинальное значение диаметра
        //string DiameterLowAlarmLimitValue;          //  3   -   Нижний предторевожный предельный допусков диаметра
        string DiameterLowFaultLimitValue;          //  4   -   Нижний предел допусков диаметра

        //  Овальность
        string OvalityHighFaultLimitValue;          //  0   -   Верхний предел допусков овальности
        //string OvalityHighAlarmLimitValue;          //  1   -   Верхний предторевожный предел допусков овальности
        //string OvalityNominalVaue;                  //  2   -   Номинальное значение овальности

        //  Прямолинейность
        string StraightnessHighFaultLimitValue;     //  0   -   Верхний предел допусков прямолинейности
        //string StraightnessHighAlarmLimitValue;     //  1   -   Верхний предторевожный предел допусков прямолинейности
        //string StraightnessNominalVaue;             //  2   -   Номинальное значение прямолинейности

        //массив значений диаметра
        string[] arrayValueDiameter = new string[5] { "0", "0", "0", "0", "0" };
        //массив значений овальности
        string[] arrayValueOvality = new string[3] { "0", "0", "0" };
        //массив значений прямолинейности
        string[] arrayValueStraightness = new string[3] { "0", "0", "0" };

       
        //свойства для массивов
        //массив значений диаметра
        public string[] arrayValueDiameterProp
        {
            get 
            {
                return arrayValueDiameter;
            }
        }

        //массив значений овальности
        public string[] arrayValueOvalityProp
        {
            get
            {
                return arrayValueOvality;
            }
        }

        //массив значений прямолинейности
        public string[] arrayValueStraightnessProp
        {
            get
            {
                return arrayValueStraightness;
            }
        }

        Form7 f7;
        public Form3()
        {
            InitializeComponent();
            f7 = new Form7();
        }

        //скрытие формы клавиатуры
        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        //обработка события нажатия на textbox, вызов клавиатуры
        private void textbox_MouseClick(object sender, MouseEventArgs e)
        {
            f7.txtBox = (TextBox)sender;
            f7.ShowDialog();
        }

        //сохранение данных из textBox в соответствующий массив
        private void SaveDataFromTextBox(object sender, MouseEventArgs e)
        {
            buttSave = (Button)sender;
            string numButt = (string)buttSave.Tag;

            if (numButt == "1") // диаметр
            {
                label45.Text = DiameterHighFaultLimitValue = arrayValueDiameter[0] = textBox1.Text;
                //label46.Text = DiameterHighAlarmLimitValue = arrayValueDiameter[1] = textBox2.Text;
                //label47.Text = DiameterNominalVaue = arrayValueDiameter[2] = textBox3.Text;
                //label48.Text = DiameterLowAlarmLimitValue = arrayValueDiameter[3] = textBox4.Text;
                label49.Text = DiameterLowFaultLimitValue = arrayValueDiameter[1] = textBox5.Text;
            }
            if (numButt == "2") // овальность
            {
                label50.Text = arrayValueOvality[0] = OvalityHighFaultLimitValue = textBox8.Text;
                //label51.Text = arrayValueOvality[1] = OvalityHighAlarmLimitValue = textBox7.Text;
                //label52.Text = arrayValueOvality[2] = OvalityNominalVaue = textBox6.Text;
            }
            if (numButt == "3") // прямолинейность
            {
                label53.Text = arrayValueStraightness[0] = StraightnessHighFaultLimitValue = textBox11.Text;
                //label54.Text = arrayValueStraightness[1] = StraightnessHighAlarmLimitValue = textBox10.Text;
                //label55.Text = arrayValueStraightness[2] = StraightnessNominalVaue = textBox9.Text;
            }
            
        }




    }
}
