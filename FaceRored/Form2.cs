using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace FaceRored
{
    public partial class Form2 : Form
    {
        //Функция получение результатов данных за день
        del_read_res_file fun_read_res_file = null;


        public Form2(del_read_res_file fun_read_res_file)
        {
            InitializeComponent();
            this.fun_read_res_file = fun_read_res_file;
        }

        //кнопка скрытия формы
        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void Open_Statistics(object sender, EventArgs e)
        {
            DataTable dt;
            DataGridViewColumn column = null;


            //Получение результатов данных за день
            dt = fun_read_res_file(dateTimePicker1.Value);

            dataGridView1.DataSource = null;
            if (dt == null)
                return;

            dataGridView1.DataSource = dt;
            column = dataGridView1.Columns[0];
            column.DefaultCellStyle.Format = "dd.MM.yyyy HH.mm.sss";
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            for (int i_stroka = 0; i_stroka < dataGridView1.Rows.Count -1; i_stroka++)
            {
                for (int j_stolb = 0; j_stolb < dataGridView1.ColumnCount -1; j_stolb++)
                {
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "Плох.")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.Red;
                    }
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "Хор.")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.Lime;
                    }
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "Да")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.Red;
                    }
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "Нет")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.Lime;
                    }
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "АВТОМ.")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.DeepSkyBlue;
                    }
                    if ((dataGridView1.Rows[i_stroka].Cells[j_stolb]).Value.ToString() == "РУЧНОЙ")
                    {
                        dataGridView1.Rows[i_stroka].Cells[j_stolb].Style.BackColor = Color.LimeGreen;
                    }
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
        }

        private void SaveTable(DataGridView table) 
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Statistics.xlsx";
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = excelapp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet workSheet = workBook.ActiveSheet;

            for (int i = 1; i < table.RowCount + 1; i++)
            {
                for (int j = 1; j < table.ColumnCount + 1; j++)
                {
                    workSheet.Rows[i].Columns[j] = table.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            excelapp.AlertBeforeOverwriting = false;
            workBook.SaveAs(path);
            excelapp.Quit();
        }
    }
}
