using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;

namespace FaceRored
{
    //Класс главной Формы
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class Form1 : Form, ServiceReferenceRobert.I_WCF_ContractCallback
    {
        Form8 ManualMeasurementMode;// = new Form8();
        Form5 device;// = new Form5();
        Form4 Faults = new Form4();
        Form3 Limits = new Form3();
        Form2 Statistics;// = new Form2(GetResData);

        SynchronizationContext form_Context;
        ServiceReferenceRobert.I_WCF_ContractClient i_wcf_cc = null;
        InstanceContext ic = null;


        //переменные: ***************************************************************************************************************************

        static bool DiameterLimit;
        static bool OvalityLimit;
        static bool StraightnessLimit;

        static bool ComPortZumb;                 // связь с COM-PORT Zumbach
        static bool CommunicationZumb;           // связь с Zumbach
        static bool DataZumb;                    // наличие данных с Zumbach

        static bool ComPortAnybus;               // связь с COM-PORT Anybus
        static bool CommunicationAnybus;         // связь с anybus
        static bool DataAnybus;                  // наличие данных с anybus
        static bool PlcAnybus;                   // связь с PLC

        //static int CountBars;                    // общий подсчёт прутков
        //static int CountBadBars;                 // подсчёт плохих прутков
        //static int CountGoodBars;                // подсчёт хороших прутков

        bool ModeOfOperation;               // режим работы (автоматическое или ручное измерение)

        bool HighStraightness;              // верхний предел допусков прямолинейности
        bool HighAlarmStraightness;         // верхний предтревожный предел допусков прямолинейности

        bool HighAlarmToleranceDiameter;    // верхний предторевожный предел допусков диаметра
        bool LowAlarmToleranceDiameter;     // нижний предторевожный предел допусков диаметра
        bool NormalDiameter;                // если всё нормально с диаметром
        bool HighLimitDiameter;             // флаг верхнего предела, если измеренный диаметр больше заданной границы
        bool LowLimitDiameter;              // флаг нижнего предела, если измеренный диаметр меньше заданной границы

        bool NormalOvality;                 // если всё нормально с овальностью
        bool HighLimitOvality;              // флаг верхнего предела допуска овальности
        bool HighAlarmToleranceOvality;     // верхний предторевожный предел допусков овальности

        double MaxDiameter;                 // максимальный диаметр 
        double MinDiameter;                 // минимальный диаметр
        double CurrDiameter;                // текущий диаметр

        double MaxDimCurrOval;              // максимальный измеренный диаметр  для овальности 
        double MinDimCurrOval;              // минимальный  измеренный диаметр  для овальности 
        double Ovality;                     // значение овальности

        double StrCurr = 1;                     // текущая прямолинейность
        double StrMax = 1;                      // максимальная прямолинейность

        int CountWellBars;                  // кол-во палок без дефектов
        int CountDefectsBars;               // кол-во палок с дефектами
        int MeltingNum;                     // номер плавки
        int NumberBar;                      // номер палки 

        // свойства переменных:
        //св-во связь с COM-PORT Zumbach
        public bool ComPortZumbprop { set { ComPortZumb = value; } get { return ComPortZumb; } }

        //св-во связь с Zumbach
        public bool CommunicationZumbProp { set { CommunicationZumb = value; } get { return CommunicationZumb; } }

        //св-во наличие данных с Zumbach
        public bool LinkToServiceProp { set { DataZumb = value; } get { return DataZumb; } }

        //св-во связь с COM-PORT Anybus
        public bool ComPortAnybusProp { set { ComPortAnybus = value; } get { return ComPortAnybus; } }

        //св-во связь с anybus
        public bool CommunicationAnybusProp { set { CommunicationAnybus = value; } get { return CommunicationAnybus; } }

        //св-во наличие данных с anybus
        public bool DataAnybusProp { set { DataAnybus = value; } get { return DataAnybus; } }

        //св-во связь с PLC
        public bool PlcAnybusProp { set { PlcAnybus = value; } get { return PlcAnybus; } }


        //-----------------------------------------

        //св-во режима работы
        public bool ModeOfOperationProp { set { ModeOfOperation = value; } get { return ModeOfOperation; } }

        // св-во верхнего предела допусков прямолинейности
        public bool HighStraightnessProp { set { HighStraightness = value; } get { return HighStraightness; } }

        // св-во верхнего предтревожного предела допусков прямолинейности
        public bool HighAlarmStraightnessProp { set { HighAlarmStraightness = value; } get { return HighAlarmStraightness; } }

        // св-во верхнего предторевожного предела допусков диаметра
        public bool HighAlarmToleranceDiameterProp { set { HighAlarmToleranceDiameter = value; } get { return HighAlarmToleranceDiameter; } }

        // св-во нижнего предторевожного предела допусков диаметра
        public bool LowAlarmToleranceDiameterProp { set { LowAlarmToleranceDiameter = value; } get { return LowAlarmToleranceDiameter; } }

        // св-во, нормальности диаметра
        public bool NormalDiameterProp { set { NormalDiameter = value; } get { return NormalDiameter; } }

        //св-во максимального диаметра
        public bool HighLimitDiameterProp { set { HighLimitDiameter = value; } get { return HighLimitDiameter; } }

        //св-во минимального диаметра
        public bool LowLimitDiameterProp { set { LowLimitDiameter = value; } get { return LowLimitDiameter; } }

        // св-во нормальности овальности
        public bool NormalOvalityProp { set { NormalOvality = value; } get { return NormalOvality; } }

        // св-во верхнего предела допуска овальности
        public bool HighLimitOvalityProp { set { HighLimitOvality = value; } get { return HighLimitOvality; } }

        // св-во верхнего предторевожного предела допуска овальности
        public bool HighAlarmToleranceOvalityProp { set { HighAlarmToleranceOvality = true; } get { return HighAlarmToleranceOvality; } }

        // св-во максимального диаметра
        public double MaxDiameterProp { set { MaxDiameter = value; } get { return MaxDiameter; } }

        // св-во минимального диаметра
        public double MinDiameterProp { set { MinDiameter = value; } get { return MinDiameter; } }

        // св-во текущего измеренного диаметра
        public double CurrDiameterProp { set { CurrDiameter = value; } get { return CurrDiameter; } }

        // св-во максимального диаметра для овальности, хотя один хер одно и тоже
        public double MaxDimCurrOvalProp { set { MaxDimCurrOval = value; } get { return MaxDimCurrOval; } }
        
        // св-во минимального диаметра для овальности, хотя один хер одно и тоже
        public double MinDimCurrOvalProp { set { MinDimCurrOval = value; } get { return MinDimCurrOval; } }

        // св-во овальности
        public double OvalityProp { set { Ovality = value; } get { return Ovality; } }

        // св-во текущей измеренной прямолинейности
        public double StrCurrProp { set { StrCurr = value; } get { return StrCurr; } }

        // св-во максимальной прямолинейности
        public double StrMaxProp { set { StrMax = value; } get { return StrMax; } }


        //**************************************************************************************************************************************

        public Form1()
        {
            InitializeComponent();
            form_Context = SynchronizationContext.Current;
            ic = new InstanceContext(this);
            try 
            {
                if (i_wcf_cc == null)
                {
                i_wcf_cc = new ServiceReferenceRobert.I_WCF_ContractClient(ic);
                //Подключиться
                i_wcf_cc.Connect();
                }
            } catch(Exception e) 
            {
                MessageBox.Show("Нет связи с сервисом");
            }

            device = new Form5(this);
            ManualMeasurementMode = new Form8(Limits);
            Statistics = new Form2(GetResData);
        }

        //Вызов окон****************************************************************************************************************************

        //вызов окна статистики
        private void button1_Click(object sender, EventArgs e)
        {
            Statistics.ShowDialog();
        }

        //вызов окна установки пределов
        private void button4_Click(object sender, EventArgs e)
        {
            Limits.ShowDialog();
        }

        //вызов окна ошибок
        private void button2_Click(object sender, EventArgs e)
        {
            Faults.ShowDialog();
        }

        // выход из программы
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (i_wcf_cc != null)
                {
                    i_wcf_cc.Disconnect();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Нет связи с сервисом");
            }
            Close();
        }

        //вызов окна диагностики устройства
        private void button5_Click(object sender, EventArgs e)
        {
            device.LinkStatus(ComPortZumb, CommunicationZumb, DataZumb, ComPortAnybus, CommunicationAnybus, DataAnybus, PlcAnybus);
            device.ShowDialog();
        }

        //кнопка перехода в ручной режим задания параметров измерения
        private void button6_Click(object sender, EventArgs e)
        {
            ManualMeasurementMode.TranslateDataBetweenForms();
            ManualMeasurementMode.ShowDialog();
        }

        //**************************************************************************************************************************************

        //***************************************************************************************************************************************************************

        //методы отрисовки (уже не для тестов)

        // отрисовка диаметров, заданных(статические окружности) и полученного(динамическая окружность)
        private void DrawVisualCircle()
        {
            int width, height;           //ширина и длина pictureBox1

            width = pictureBox1.Width;      // в width записываем ширину pictureBox1
            height = pictureBox1.Height;    // в height записываем длину pictureBox1

            Bitmap bmp = new Bitmap(width, height);
            Graphics graphDiam = Graphics.FromImage(bmp);
            graphDiam.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;   //сглаживание линий, кругов и прицела
            Pen penDiam = new Pen(Color.Silver, 3);
            penDiam.DashStyle = DashStyle.Dash;
            graphDiam.DrawLine(penDiam, height / 2, 0, height / 2, height);  //прицел
            graphDiam.DrawLine(penDiam, 0, width / 2, width, width / 2);     //прицел
            int xPx; // переменная для радиуса измеренной палки в пикселяхъ
            //рисуем большую окружность
            penDiam = new Pen(Color.Black, 3);
            graphDiam.DrawEllipse(penDiam, 25, 25, width - 50, height - 50);    // максимальный диаметр, 25,25 координаты отступа от левого верхнего угла picturebox
            //рисуем малую окружность
            graphDiam.DrawEllipse(penDiam, 70, 70, width / 2, height / 2);      // минимальный диаметр   70,70 координаты отступа от левого верхнего угла picturebox
            //рисуем измеренное значение в масштабе относительно макс и мин
            penDiam = new Pen(Color.Green, 3);
            // рисуем статический круг, если измеренный диаметр вышел за пределы максимального

            if (/*ManualMeasurementMode.DiameterStatusManualProp == false ||*/ DiameterLimit == false)
            {
                //panel1.BackColor = Color.Red;
                penDiam = new Pen(Color.Red, 4);
                //graphDiam.DrawEllipse(penDiam, 5, 5, width - 10, height - 10);
                graphDiam.DrawRectangle(penDiam, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }
            /*
            // рисуем статический круг, если измеренный диаметр вышел за пределы минимального
            if (LowLimitDiameter)
            {
                //panel1.BackColor = Color.Red;
                penDiam = new Pen(Color.Red, 4);
                graphDiam.DrawEllipse(penDiam, 105, 105, width - 210, height - 210);
                //graphDiam.DrawRectangle(penDiam, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }
             * */
            // рисуем динамически изменяющиеся окружности. 
            //Цвет зависит от того, приходит ли предупреждающий бит о приближении к заданной максимальной/минимальной границе или нет
            /*
            if (HighAlarmToleranceDiameter || LowAlarmToleranceDiameter)
            {
                //panel1.BackColor = Color.Yellow;
                penDiam = new Pen(Color.Yellow, 4);
                xPx = 70 + ((int)CurrDiameter - (int)MinDiameter) * (115 - 70) / ((int)MaxDiameter - (int)MinDiameter); // 115 и 70 радиусы внешней и внутренней статических окружности соответственно в пикселях
                //xPx = (int)(70 + (CurrDiameter - MinDiameter) * (115 - 70) / (MaxDiameter - MinDiameter)); // 115 и 70 радиусы внешней и внутренней статических окружности соответственно в пикселях
                graphDiam.DrawEllipse(penDiam, (width - xPx * 2) / 2, (width - xPx * 2) / 2, xPx * 2, xPx * 2);
                graphDiam.DrawRectangle(penDiam, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            } 
             * */
            //else
            //{
                //отрисовка полученного диаметра, если все в огне
                //try
                //{
                    //panel1.BackColor = Color.Lime;
                    xPx = (int)(70 + (CurrDiameter - MinDiameter) * (115 - 70) / (MaxDiameter - MinDiameter)); // 115 и 70 радиусы внешней и внутренней статических окружности соответственно в пикселях
                    //xPx = 70 + ((int)CurrDiameter - (int)MinDiameter) * 45 / ((int)MaxDiameter - (int)MinDiameter); //70 + (currDim - minDim) * (115 - 70) / (maxDim - minDim);
                    penDiam = new Pen(Color.Green, 4);
                    graphDiam.DrawEllipse(penDiam, (width - xPx * 2) / 2, (width - xPx * 2) / 2, xPx * 2, xPx * 2);
                //}
                //catch (DivideByZeroException ex) { } 
            //}
            pictureBox1.Image = bmp;
        }

        // отрисовка овальности относительно диаметра
        private void DrawVisualOvality()
        {
            int width, height;         //ширина и длина pictureBox1
            double x;                  //координата x pictureBox4
            double wEl;                //ширина эллипса
            width = pictureBox4.Width;
            height = pictureBox4.Height;

            Bitmap bmp = new Bitmap(width, height);
            Graphics graphOvality = Graphics.FromImage(bmp);
            graphOvality.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;   //сглаживание линий, кругов и прицела
            Pen penOvality = new Pen(Color.Silver, 3);
            penOvality.DashStyle = DashStyle.Dash;
            graphOvality.DrawLine(penOvality, height / 2, 0, height / 2, height);            //прицел
            graphOvality.DrawLine(penOvality, 0, width / 2, width, width / 2);               //прицел

            //узнаём значение овальности в процентах
            x = 25 + (width / 2 - 25) * Ovality;
            wEl = 230 - 230 * Ovality;
            //отрисовка окружности
            penOvality = new Pen(Color.Black, 3);
            graphOvality.DrawEllipse(penOvality, 25, 25, width - 50, height - 50);           // максимальный диаметр, 25,25 координаты отступа от левого верхнего угла picturebox
            //отрисовка эллипса
            if (OvalityLimit == false) // если достигнут предел овальности
            {
                penOvality = new Pen(Color.Red, 4);
                graphOvality.DrawEllipse(penOvality, (int)x, 25, (int)wEl, height - 50);
                graphOvality.DrawRectangle(penOvality, 5, 5, 270, 270);                      //отрисовка предупреждающего прямоугольника
            }
            if (HighAlarmToleranceOvality) // если достигнут предтревожный предел овальности
            {
                penOvality = new Pen(Color.Yellow, 4);
                graphOvality.DrawEllipse(penOvality, (int)x, 25, (int)wEl, height - 50);
                graphOvality.DrawRectangle(penOvality, 5, 5, 270, 270);                      //отрисовка предупреждающего прямоугольника
            }
            else //отрисовка овальности, если всё в огне
            {
                //panel2.BackColor = Color.Lime;
                penOvality = new Pen(Color.Green, 4);
                graphOvality.DrawEllipse(penOvality, (int)x, 25, (int)wEl, height - 50);               
            }
            pictureBox4.Image = bmp;
        }

        // отрисовка прямолинейности палки 1
        private void DrawVisualStraight()
        {
            int width;
            int height;
            width = pictureBox2.Width;
            height = pictureBox2.Height;
            double deltaH;      // высота отрисовки дуги
            //double y2 = 140;
            //double y3 = 140;
            double y2 = -20;
            double y3 = -20;
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics graphStraightness = Graphics.FromImage(bmp);
            Pen penStraightness = new Pen(Color.Silver, 3);
            penStraightness.DashStyle = DashStyle.Dash;
            graphStraightness.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //сглаживание линии
            graphStraightness.DrawLine(penStraightness, 0, 140, 320, 140);                      // отрисовка оси

            deltaH = StrCurr / StrMax;
 
            if (HighAlarmStraightness) // если придёт бит о предтревожном пределе
            {
                penStraightness = new Pen(Color.Yellow, 5);
                graphStraightness.DrawRectangle(penStraightness, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }
            if (StraightnessLimit == false) // если придёт бит о достижении предела
            {
                penStraightness = new Pen(Color.Red, 5);
                graphStraightness.DrawRectangle(penStraightness, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }

            penStraightness = new Pen(Color.Blue, 10);

            y3 = y2 = y2 - (y2 * deltaH) + 140;

            System.Drawing.Point p1 = new System.Drawing.Point(50, 140);          // 50 140
            System.Drawing.Point p2 = new System.Drawing.Point(120, (int)y2);     // 120 140
            System.Drawing.Point p3 = new System.Drawing.Point(180, (int)y3);     // 180 140
            System.Drawing.Point p4 = new System.Drawing.Point(250, 140);         // 250 140

            List<System.Drawing.Point> p = new List<System.Drawing.Point> { p1, p2, p3, p4 };
            graphStraightness.DrawBezier(penStraightness, p1, p2, p3, p4);
            /*
            foreach (System.Drawing.Point point in p)
            {
                graphStraightness.DrawRectangle(penStraightness, point.X - 1, point.Y - 1, 2, 2);
            }
            */
            //DrawVisualStraight_2();
            pictureBox2.Image = bmp;
        }

        // отрисовка прямолинейности палки 2
        /*
        private void DrawVisualStraight_2()
        {
            double MoveAxis; // смещение по оси
            double deltaPx = 0; // смещение в пикселях
            int width;
            int height;
            width = pictureBox3.Width;
            height = pictureBox3.Height;

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics graphStraightness2 = Graphics.FromImage(bmp);
            graphStraightness2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //сглаживание линии
            Pen penStraightness2 = new Pen(Color.Black, 3);

            graphStraightness2.DrawEllipse(penStraightness2, 25, 25, width - 50, height - 50); // отрисовка простой окружности

            penStraightness2 = new Pen(Color.Red, 3);
            graphStraightness2.DrawLine(penStraightness2, height / 2, 0, height / 2, height);  //прицел
            graphStraightness2.DrawLine(penStraightness2, 0, width / 2, width, width / 2);     //прицел

            MoveAxis = StrCurr / StrMax;
            deltaPx = 280 - 280 * MoveAxis;

            penStraightness2 = new Pen(Color.Blue, 5);
            if (HighAlarmStraightness) // если придёт бит о предтревожном пределе
            {
                penStraightness2 = new Pen(Color.Yellow, 5);
                graphStraightness2.DrawRectangle(penStraightness2, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }
            if (HighStraightness) // если придёт бит о достижении предела
            {
                penStraightness2 = new Pen(Color.Red, 5);
                graphStraightness2.DrawRectangle(penStraightness2, 5, 5, 270, 270);   //отрисовка предупреждающего прямоугольника
            }

            penStraightness2 = new Pen(Color.Blue, 5);
            graphStraightness2.DrawLine(penStraightness2, width / 4, (height / 2) - (int)deltaPx, width - width / 4, (height / 2) - (int)deltaPx);    //прицел смещающийся
            graphStraightness2.DrawLine(penStraightness2, width / 2, height / 4 - (int)deltaPx, width / 2, (height - height / 4) - (int)deltaPx);     //прицел смещающийся

            pictureBox3.Image = bmp;
        }
        */
        //***************************************************************************************************************************************************************

        //метод передаёт на форму данные в textboxЫ, 
        //о текущем диаметре, овальности, прямолинейности, 
        //номер плавки, номер палки, общее кол-во палок, 
        //кол-во годных, кол-во дефектных
        private void TransmitDataToAForm()
        {
            textBox1.Text = CurrDiameter.ToString();        //  текущий измеренный диаметр
            textBox7.Text = MeltingNum.ToString();          //  номер плавки
            textBox8.Text = NumberBar.ToString();           //  номер палки
        }


       //Реализация I_WCF_ContractCallback
        //Передача завершённого измерения клиента
        public void Set_Client_Measure_Complete(ServiceReferenceRobert.Data_WCF_Result wcf_measure)
        {
            form_Context.Post(View_Measure_Complete, wcf_measure);
        }

        //Реализация I_WCF_ContractCallback
        //Передача завершённого измерения в автомате
        public void Set_Auto_Measure_Complete(ServiceReferenceRobert.Data_WCF_Result wcf_measure)
        {
            form_Context.Post(View_Auto_Measure_Complete, wcf_measure);
        }

        //-----------------------------------------------------------------------------------------
        //Функция для вызова в контексте формы
        void View_Auto_Measure_Complete(object o)
        {
            ServiceReferenceRobert.Data_WCF_Result wcf_measure;

            if (o == null)
                return;
            wcf_measure = (ServiceReferenceRobert.Data_WCF_Result)o;

            if (wcf_measure != null)
            {
                //Если есть ссылка на материал
                if (wcf_measure.data_wcf_material != null)
                {
                    //textBox54.Text = wcf_measure.data_wcf_material.number_job.ToString();
                    //textBox53.Text = wcf_measure.data_wcf_material.number_program.ToString();
                    //textBox52.Text = wcf_measure.data_wcf_material.number_semiproduct.ToString();
                }

                //Если есть ссылка на установленные пределы
                if (wcf_measure.data_wcf_limits != null)
                {
                    textBox2.Text = wcf_measure.data_wcf_limits.diameter_max.ToString();
                    textBox3.Text = wcf_measure.data_wcf_limits.diameter_min.ToString();
                    textBox16.Text = wcf_measure.data_wcf_limits.ovality_max.ToString();
                    textBox17.Text = wcf_measure.data_wcf_limits.straightness_max.ToString();
                //    wcf_measure.data_wcf_material.number_job
                }
                //Если есть ссылка на подсчитанные данные
                if (wcf_measure.data_wcf_calculate_measure != null)
                {
                    MaxDiameter = wcf_measure.data_wcf_calculate_measure.diameter_max * 1000;
                    MinDiameter = wcf_measure.data_wcf_calculate_measure.diameter_min * 1000;
                    Ovality = wcf_measure.data_wcf_calculate_measure.ovality_max * 0.25;
                    StrCurr = wcf_measure.data_wcf_calculate_measure.straightness_max + 1;
                    // для отображения графиков в автомате
                    //Недостаточно данных для измерения
                    if (wcf_measure.data_wcf_calculate_measure.is_bad_measure)
                    {

                    }
                    else
                    {

                    }
                    //Диаметр
                    if (wcf_measure.data_wcf_calculate_measure.is_good_diameter)
                    {
                        textBox25.BackColor = Color.Lime;
                        textBox24.BackColor = Color.Lime;
                        DiameterLimit = true;
                    }
                    else
                    {
                        textBox25.BackColor = Color.Red;
                        textBox24.BackColor = Color.Red;
                        DiameterLimit = false;
                    }
                    //Овальность
                    if (wcf_measure.data_wcf_calculate_measure.is_good_ovality)
                    {
                        textBox23.BackColor = Color.Lime;
                        OvalityLimit = true;
                    }

                    else
                    {
                        textBox23.BackColor = Color.Red;
                        OvalityLimit = false;
                    }

                    //Прямолинейность
                    if (wcf_measure.data_wcf_calculate_measure.is_good_straightness)
                    {
                        textBox22.BackColor = Color.Lime;
                        StraightnessLimit = true;
                    }

                    else
                    {
                        textBox22.BackColor = Color.Red;
                        StraightnessLimit = false;
                    }
                }
            }
            //отрисовка диаметра при автоматическом режиме
            DrawVisualCircle();
            //Отрисовка овальности при автоматическом режиме
            DrawVisualOvality();
            //Отрисовка прямолинейности 1, при автоматическом режиме
            DrawVisualStraight();
            textBox19.Text = "ИЗМЕРЕНО";
            textBox19.BackColor = Color.Lime;
        }



        //-----------------------------------------------------------------------------------------
        //Функция для вызова в контексте формы
        void View_Measure_Complete(object o)
        {

            ServiceReferenceRobert.Data_WCF_Result wcf_measure;

            if (o == null)
                return;
            wcf_measure = (ServiceReferenceRobert.Data_WCF_Result)o;

            if (wcf_measure != null)
            {
                //Если есть ссылка на установленные пределы
                if (wcf_measure.data_wcf_limits != null)
                {

                }
                //Если есть ссылка на подсчитанные данные
                if (wcf_measure.data_wcf_calculate_measure != null)
                {
                    textBox13.Text = wcf_measure.data_wcf_calculate_measure.diameter_max.ToString();
                    textBox14.Text = wcf_measure.data_wcf_calculate_measure.diameter_min.ToString();
                    textBox15.Text = wcf_measure.data_wcf_calculate_measure.ovality_max.ToString();
                    textBox21.Text = wcf_measure.data_wcf_calculate_measure.straightness_max.ToString();
                    textBox18.Text = "ИЗМЕРЕНО";
                    textBox18.BackColor = Color.Lime;
                    //Недостаточно данных для измерения
                    if (wcf_measure.data_wcf_calculate_measure.is_bad_measure)
                    {
                        panel4.BackColor = Color.Red;
                    }
                    else
                    {

                    }
                    //Диаметр
                    if (wcf_measure.data_wcf_calculate_measure.is_good_diameter)
                    {
                        textBox13.BackColor = Color.Lime;
                        textBox14.BackColor = Color.Lime;
                        DiameterLimit = true;
                    }
                    else
                    {
                        textBox13.BackColor = Color.Red;
                        textBox14.BackColor = Color.Red;
                        DiameterLimit = false;
                    }
                    //Овальность                  
                    if (wcf_measure.data_wcf_calculate_measure.is_good_ovality)
                    {
                        textBox15.BackColor = Color.Lime;
                        OvalityLimit = true;
                    }
                    else
                    {
                        textBox15.BackColor = Color.Red;
                        OvalityLimit = false;
                    }
                    //Прямолинейность
                    if (wcf_measure.data_wcf_calculate_measure.is_good_straightness)
                    {
                        textBox21.BackColor = Color.Lime;
                        StraightnessLimit = true;
                    }
                        
                    else
                    {
                        textBox21.BackColor = Color.Red;
                        StraightnessLimit = false;
                    }
                }
            }
        }



        //Реализация I_WCF_ContractCallback
        //Передача текущего измерения клиента и автоматического измерения
        public void Set_Client_State_And_Measure(ServiceReferenceRobert.Sum_WCF_Data sum_wcf_data)
        {
            form_Context.Post(View_State_And_Measure, sum_wcf_data);       
        }

        //-----------------------------------------------------------------------------------------
        //Функция для вызова в контексте формы

        void View_State_And_Measure(object o)
        {
            ServiceReferenceRobert.Sum_WCF_Data sum_wcf_data;
            ServiceReferenceRobert.Data_WCF_Result wcf_measure_client = null;
            ServiceReferenceRobert.Data_WCF_Result wcf_measure_auto = null;
            ServiceReferenceRobert.State_Communication_Zumbach scz = null;
            ServiceReferenceRobert.State_Communication_Anybus sca = null;

            if (o == null)
                return;

            sum_wcf_data = (ServiceReferenceRobert.Sum_WCF_Data)o;

            wcf_measure_client = sum_wcf_data.wcf_measure_client;
            wcf_measure_auto = sum_wcf_data.wcf_measure_auto;
            scz = sum_wcf_data.scz;
            sca = sum_wcf_data.sca;

            //----------------------------------------------
            //Есть ссылка на связь с Zumbach
            if (scz != null)
            {
                //Порт
                if (scz.is_open_port)
                {
                    ComPortZumb = true;
                    panel15.BackColor = Color.Lime;
                }
                else
                {
                    ComPortZumb = false;
                    panel15.BackColor = Color.Red;
                }
                //Связь
                if (scz.is_exists_communication)
                {
                    CommunicationZumb = true;
                    panel14.BackColor = Color.Lime;
                }
                else
                {
                    CommunicationZumb = false;
                    panel14.BackColor = Color.Red;
                }
                //Данные
                if (scz.is_good_data)
                {
                    DataZumb = true;
                    panel13.BackColor = Color.Lime;
                }
                else
                {
                    DataZumb = false;
                    panel13.BackColor = Color.Red;
                }
            }

        //----------------------------------------------
        //Есть ссылка на связь с Anybus

            if (sca != null)
            {
                //Порт
                if (sca.is_open_port)
                {
                    ComPortAnybus = true;
                    panel6.BackColor = Color.Lime;
                }
                else
                {
                    ComPortAnybus = false;
                    panel6.BackColor = Color.Red;
                }
                //Связь
                if (sca.is_exists_communication)
                    CommunicationAnybus = true;
                else
                    CommunicationAnybus = false;
                //Данные
                if (sca.is_good_data)
                    DataAnybus = true;
                else
                    DataAnybus = false;
                //PLC
                if (sca.is_alive_plc)
                    PlcAnybus = true;
                else
                    PlcAnybus = false;   
            }

        //----------------------------------------------
        //Клиенские измерения
            if (wcf_measure_client != null)
            {
                //Если есть ссылка на текущие измерения
                if (wcf_measure_client.data_wcf_measure != null)
                {
                    textBox1.Text = wcf_measure_client.data_wcf_measure.diameter.ToString();
                    CurrDiameter = wcf_measure_client.data_wcf_measure.diameter * 1000;
                    //textBox2.Text = wcf_measure_client.data_wcf_measure.deviation.ToString();
                }
                //Если есть ссылка на установленные пределы
                if (wcf_measure_client.data_wcf_limits != null)
                {
                    //textBox5.Text = wcf_measure_client.data_wcf_limits.diameter_max.ToString();
                    //textBox6.Text = wcf_measure_client.data_wcf_limits.diameter_min.ToString();
                    //textBox8.Text = wcf_measure_client.data_wcf_limits.ovality_max.ToString();
                    //textBox10.Text = wcf_measure_client.data_wcf_limits.straightness_max.ToString();
                }
                //Если есть ссылка на подсчитанные данные
                if (wcf_measure_client.data_wcf_calculate_measure != null)
                {
                    //textBox1.Text = wcf_measure_client.data_wcf_calculate_measure.count_measure_diameter.ToString();
                    //textBox16.Text = wcf_measure_client.data_wcf_calculate_measure.count_measure_deviation.ToString();
                    ////textBox16.Text = wcf_measure_client.data_wcf_calculate_measure.diameter_max.ToString();
                    ////textBox19.Text = wcf_measure_client.data_wcf_calculate_measure.diameter_min.ToString();
                    ////textBox17.Text = wcf_measure_client.data_wcf_calculate_measure.ovality_max.ToString();
                    ////textBox18.Text = wcf_measure_client.data_wcf_calculate_measure.straightness_max.ToString();
                    MaxDiameter = wcf_measure_client.data_wcf_calculate_measure.diameter_max * 1000;
                    MinDiameter = wcf_measure_client.data_wcf_calculate_measure.diameter_min * 1000;
                    Ovality = wcf_measure_client.data_wcf_calculate_measure.ovality_max * 0.25;
                    StrMax = wcf_measure_client.data_wcf_calculate_measure.straightness_max + 1;
                    textBox18.Text = "ИЗМЕРЯЕМ";
                    textBox18.BackColor = Color.Lime;
                    //Недостаточно данных для измерения
                    if (wcf_measure_client.data_wcf_calculate_measure.is_bad_measure)
                    {
                        //textBox15.BackColor = Color.Red;
                        //textBox16.BackColor = Color.Red;
                        textBox18.Text = "Нет данных";
                        textBox18.BackColor = Color.Red;
                    }
                    else
                    {
                        //textBox15.BackColor = Color.Green;
                        //textBox16.BackColor = Color.Green;
                    }
                    //Диаметр
                    if (wcf_measure_client.data_wcf_calculate_measure.is_good_diameter)
                    {
                        //panel1.BackColor = Color.Lime;
                        //HighLimitDiameter = false;
                        ManualMeasurementMode.DiameterStatusManualProp = true;
                    }
                    else
                    {
                        //panel1.BackColor = Color.Red;
                        //HighLimitDiameter = true;
                        ManualMeasurementMode.DiameterStatusManualProp = false;
                    }
                    //Овальность
                    if (wcf_measure_client.data_wcf_calculate_measure.is_good_ovality)
                    {
                        //panel2.BackColor = Color.Lime;
                        ManualMeasurementMode.OvalityStatusManualProp = true;
                    }
                    else
                    {
                        //panel2.BackColor = Color.Red;
                        ManualMeasurementMode.OvalityStatusManualProp = false;
                    }
                    //Прямолинейность
                    if (wcf_measure_client.data_wcf_calculate_measure.is_good_straightness)
                    {
                        //panel3.BackColor = Color.Lime;
                        ManualMeasurementMode.StraightnessStatusManualProp = true;
                    }
                    else
                    {
                        //panel3.BackColor = Color.Red;
                        ManualMeasurementMode.StraightnessStatusManualProp = false;
                    }
                }
            }
            //----------------------------------------------
            //Автоматические измерения
            if (wcf_measure_auto != null)
            {
                
                //Если есть ссылка на текущие измерения
                if (wcf_measure_auto.data_wcf_measure != null)
                {
                    ManualMeasurementMode.DiameterCurrentProp = wcf_measure_auto.data_wcf_measure.diameter.ToString();
                    //textBox41.Text = wcf_measure_auto.data_wcf_measure.deviation.ToString();
                }
                //Если есть ссылка на материал
                if (wcf_measure_auto.data_wcf_material != null)
                {
                    textBox7.Text = wcf_measure_auto.data_wcf_material.number_job.ToString();
                    textBox20.Text = wcf_measure_auto.data_wcf_material.number_program.ToString();
                    textBox8.Text = wcf_measure_auto.data_wcf_material.number_semiproduct.ToString();
                }

                //Если есть ссылка на установленные пределы
                if (wcf_measure_auto.data_wcf_limits != null)
                {
                    textBox2.Text = wcf_measure_auto.data_wcf_limits.diameter_max.ToString();
                    textBox3.Text = wcf_measure_auto.data_wcf_limits.diameter_min.ToString();
                    textBox16.Text = wcf_measure_auto.data_wcf_limits.ovality_max.ToString();
                    textBox17.Text = wcf_measure_auto.data_wcf_limits.straightness_max.ToString();
                }
                //Если есть ссылка на подсчитанные данные
                if (wcf_measure_auto.data_wcf_calculate_measure != null)
                {
                    //textBox28.Text = wcf_measure_auto.data_wcf_calculate_measure.count_measure_diameter.ToString();
                    //textBox27.Text = wcf_measure_auto.data_wcf_calculate_measure.count_measure_deviation.ToString();
                    textBox25.Text = wcf_measure_auto.data_wcf_calculate_measure.diameter_max.ToString();
                    textBox24.Text = wcf_measure_auto.data_wcf_calculate_measure.diameter_min.ToString();
                    textBox23.Text = wcf_measure_auto.data_wcf_calculate_measure.ovality_max.ToString();
                    textBox22.Text = wcf_measure_auto.data_wcf_calculate_measure.straightness_max.ToString();

                    MaxDiameter = wcf_measure_auto.data_wcf_calculate_measure.diameter_max * 1000;
                    MinDiameter = wcf_measure_auto.data_wcf_calculate_measure.diameter_min * 1000;
                    Ovality = wcf_measure_auto.data_wcf_calculate_measure.ovality_max * 0.25;
                    StrCurr = wcf_measure_auto.data_wcf_calculate_measure.straightness_max + 1;
                    textBox19.Text = "ИЗМЕРЯЕМ";
                    textBox19.BackColor = Color.Lime;
                    //Недостаточно данных для измерения
                    if (wcf_measure_auto.data_wcf_calculate_measure.is_bad_measure)
                    {
                        //textBox28.BackColor = Color.Red;
                        //textBox27.BackColor = Color.Red;
                        textBox19.BackColor = Color.Red;
                        textBox19.Text = "Нет данных";
                    }
                    else
                    {
                        //textBox28.BackColor = Color.Green;
                        //textBox27.BackColor = Color.Green;
                    }
                    //Диаметр
                    if (wcf_measure_auto.data_wcf_calculate_measure.is_good_diameter)
                    {
                        //panel9.BackColor = Color.Lime;
                        //textBox38.BackColor = Color.Green;
                        ManualMeasurementMode.DiameterStatusAutoProp = true;
                    }
                    else
                    {
                        //panel9.BackColor = Color.Red;
                        //textBox38.BackColor = Color.Red;
                        ManualMeasurementMode.DiameterStatusAutoProp = false;
                    }
                    //Овальность         
                    if (wcf_measure_auto.data_wcf_calculate_measure.is_good_ovality)
                    {
                        //textBox39.BackColor = Color.Green;
                        //panel8.BackColor = Color.Lime;
                        ManualMeasurementMode.OvalityStatusAutoProp = true;
                    }
                    else
                    {
                        //panel8.BackColor = Color.Red;
                        ManualMeasurementMode.OvalityStatusAutoProp = false;
                    }
                    //Прямолинейность
                    if (wcf_measure_auto.data_wcf_calculate_measure.is_good_straightness)
                    {
                        //panel7.BackColor = Color.Lime;
                        //textBox40.BackColor = Color.Green;
                        ManualMeasurementMode.StraightnessStatusAutoProp = true;
                    }
                    else
                    {
                        //textBox40.BackColor = Color.Red;
                        //panel7.BackColor = Color.Red;
                        ManualMeasurementMode.StraightnessStatusAutoProp = false;
                    }
                }
            //отрисовка диаметра
            DrawVisualCircle();
            //Отрисовка овальности
            DrawVisualOvality();
            //Отрисовка прямолинейности 1
            DrawVisualStraight();


            }

            //вызов метода со статусами для отображения цвета лампочек :)
            ManualMeasurementMode.SetStatusBars(ManualMeasurementMode.DiameterStatusManualProp, 
                                                ManualMeasurementMode.OvalityStatusManualProp, 
                                                ManualMeasurementMode.StraightnessStatusManualProp, 
                                                ManualMeasurementMode.DiameterStatusAutoProp, 
                                                ManualMeasurementMode.OvalityStatusAutoProp, 
                                                ManualMeasurementMode.StraightnessStatusAutoProp);

            //методы потом закоменнтить или удалить кроме panel5.backcolor = color.red;
            //вызов метода отображения установленных пределов
            setLimitMeasure();
            //отрисовка диаметра
            DrawVisualCircle();
            //Отрисовка овальности
            DrawVisualOvality();
            //Отрисовка прямолинейности 1
            DrawVisualStraight();
            //разблокировка кнопки
            button7.Enabled = true;
        }


        //-----------------------------------------------------------------------------------------
        //Начать измерять//удалить потом этот метод, т.к. есть Start_Measure_button()
        private void Start_Measure()
        {
            if (i_wcf_cc != null)
                //Начать измерения
                i_wcf_cc.StartMeasure();
        }
        //----------------------------------------------------------------------------------------

        //Установить пределы для измерений
        private void setLimitMeasure()
        {
            ServiceReferenceRobert.Data_WCF_Limits temp_wcf_limits = new ServiceReferenceRobert.Data_WCF_Limits();

            textBox9.Text = Limits.arrayValueDiameterProp[0];   // установленный максимальный диаметр
            textBox10.Text = Limits.arrayValueDiameterProp[1];   // установленный минимальный диаметр
            textBox11.Text = Limits.arrayValueOvalityProp[0];   // установленная максимальная овальность
            textBox12.Text = Limits.arrayValueStraightnessProp[0];   // установленная максимальная прямолинейность

            //Заполняем пределы
            temp_wcf_limits.diameter_max = Convert.ToSingle(textBox9.Text);
            temp_wcf_limits.diameter_min = Convert.ToSingle(textBox10.Text);
            temp_wcf_limits.ovality_max = Convert.ToSingle(textBox11.Text);
            temp_wcf_limits.straightness_max = Convert.ToSingle(textBox12.Text);

            //Устанавливаем серверу
            //Установка пределов
            i_wcf_cc.Set_Limits(temp_wcf_limits);
        }

        //-----------------------------------------------------------------------------------------
        //Начать измерять
        private void Start_Measure_button(object sender, EventArgs e)
        {
            if (i_wcf_cc != null)
            {
                //вызов метода отображения установленных пределов
                setLimitMeasure();
                //Начать измерения
                i_wcf_cc.StartMeasure();
                //panel5.BackColor = Color.Lime;
                //отрисовка диаметра
                DrawVisualCircle();
                //Отрисовка овальности
                DrawVisualOvality();
                //Отрисовка прямолинейности 1
                DrawVisualStraight();
                //блокировка кнопки после нажатия
                button7.Enabled = false;
            }   
        }

        //-----------------------------------------------------------------------------------------
        //Показать результаты за день
        DataTable GetResData(DateTime dt_res)
        {
            DataTable dt;
            //Чтение файла результатов в таблицу
            dt = i_wcf_cc.ReadResFile(dt_res);
            return dt;
        }
    }

        //----------------------------------------------------------------------------------
        //Делегат
        public delegate DataTable del_read_res_file(DateTime dt_res);


        //----------------------------------------------------------------------------------
        class Sum_Data
        {
            public ServiceReferenceRobert.Data_WCF_Result wcf_measure_client = null;
            public ServiceReferenceRobert.Data_WCF_Result wcf_measure_auto = null;
            public ServiceReferenceRobert.State_Communication_Zumbach scz = null;
            public ServiceReferenceRobert.State_Communication_Anybus sca = null;
            public ServiceReferenceRobert.Data_WCF_Result wcf_measure = null;
        }
    
}

