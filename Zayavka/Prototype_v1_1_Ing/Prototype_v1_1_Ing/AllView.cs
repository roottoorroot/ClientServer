using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_v1_1_Ing
{
    public partial class AllView : Form
    {
        public AllView()
        {
            InitializeComponent();
            InitTable();
            DataGridVseZayavki(@"C:\log\closeLog.txt");
        }

        public void InitTable()
        {
            dataGridView1.Columns.Add("A0", "№");
            dataGridView1.Columns.Add("A1", "Время открытия");
            dataGridView1.Columns.Add("A2", "Время Закрытия");
            dataGridView1.Columns.Add("A3", "Инженер");
            dataGridView1.Columns.Add("A4", "Отделение");
            dataGridView1.Columns.Add("A5", "Оборудование");
            dataGridView1.Columns.Add("A6", "Состояние");
            dataGridView1.Columns.Add("A7", "Id");
            dataGridView1.Columns.Add("A8", "...");

            dataGridView1.Columns[0].Width = 10;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 167;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 20;
            dataGridView1.Columns[8].Width = 10;
            
        }

        public void DataGridVseZayavki(string patch)
        {
            string filelog = "";
            int count = 0;

           
            dataGridView1.RowCount = 1;


            try
            {
                StreamReader reader = File.OpenText(patch);
                filelog = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка в InitText: \r" + e.ToString());
            }

            for (int i = 0; i < filelog.Length; i++)
            {
                if (filelog[i] == '*') count++;
            }



            string[] less = filelog.Split('*');
            for (int i = 0; i < less.Length; i++)
            {
                less[i] = less[i].Replace("\r\n", string.Empty);

            }

            string[][] ls = new string[less.Length][];
            for (int i = 0; i < less.Length; i++)
            {
                ls[i] = less[i].Split('|');
            }

          
            dataGridView1.Columns[0].Width = 10;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 174;
            dataGridView1.Columns[7].Width = 10;
            dataGridView1.Columns[8].Width = 10;
            for (int i = 0; i < count + 1; i++)
            {
                dataGridView1.Rows.Add();
            }



            for (int i = 0; i < ls.Length; i++)
            {
                for (int j = 0; j < ls[i].Length; j++)
                {
                    //string cell = dgr[i][j];
                    dataGridView1.Rows[i].Cells[j].Value = ls[i][j];
                    // xlWorkSheet.Range[i,j].Select();
                }
            }

            label7.Text = Convert.ToString(dataGridView1.Rows.Count - 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridVseZayavki(@"C:\log\closeLog.txt");
        }
    }
}
