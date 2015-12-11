using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using prototype_v1_1_Ing;
using System.IO;

namespace Prototype_v1_1_Ing
{
    public partial class Form1 : Form
    {

        public string otvetClient;
        public int _count = 0;
        public string _ip;
        public string putchInOtdel = @"C:\log\otdel.txt";
        public string putchInitSotr = @"C:\log\injener.txt";
        public string[] all_Ingeners;


        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
            initConfig();
            incDefault();
            FormingTable(1);
            //comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            InitializeList(comboBox2, 1, putchInOtdel);
            InitializeList(comboBox1, 1, putchInitSotr);
            comboBox1.SelectedIndex = 0;
        }


        public void FormingTable(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        dataGridView1.Columns.Add("A0", "№");
                        dataGridView1.Columns.Add("A1", "Время открытия");
                        dataGridView1.Columns.Add("A2", "Время Закрытия");
                        dataGridView1.Columns.Add("A3", "Инженер");
                        dataGridView1.Columns.Add("A4", "Отделение");
                        dataGridView1.Columns.Add("A5", "Краткое описание");
                        //dataGridView1.Columns.Add("A6", "Полное описание");
                        dataGridView1.Columns.Add("A6", "Состояние");
                        dataGridView1.Columns[0].Width = 20;
                        dataGridView1.Columns[1].Width = 120;
                        dataGridView1.Columns[2].Width = 120;
                        dataGridView1.Columns[3].Width = 120;
                        dataGridView1.Columns[4].Width = 120;
                        dataGridView1.Columns[5].Width = 167;
                        //dataGridView1.Columns[6].Width = 190;
                        dataGridView1.Columns[6].Width = 80;
                    }
                    break;
                case 2:
                    {
                        //dataGridView2.ColumnCount = 0;
                        //dataGridView2.Columns.Add("A0", "Время открытия");
                        //dataGridView2.Columns.Add("A1", "Время Закрытия");
                        //dataGridView2.Columns.Add("A2", "Инженер");
                        //dataGridView2.Columns.Add("A3", "Отделение");
                        //dataGridView2.Columns.Add("A4", "Краткое описание");
                        //dataGridView2.Columns.Add("A5", "Полное описание");
                        //dataGridView2.Columns.Add("A6", "...");

                        //dataGridView2.Columns[0].Width = 120;
                        //dataGridView2.Columns[1].Width = 120;
                        //dataGridView2.Columns[2].Width = 90;
                        //dataGridView2.Columns[3].Width = 80;
                        //dataGridView2.Columns[4].Width = 150;
                        //dataGridView2.Columns[5].Width = 100;
                    }
                    break;
            }

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;//Кнопка добавления заявки в DataGrid на форме
            button2.Enabled = false;//Кнопка отправки сообщения
            button1.Enabled = true;//Кнопка повторной отправки сообщения

            if ((comboBox1.Text == "") || (comboBox2.Text == "") || (richTextBox1.Text == "") || (richTextBox2.Text == ""))
            {
                if (comboBox1.Text == "") { comboBox1.BackColor = Color.LightCoral; button2.Enabled = true; pictureBox1.Visible = true;}
                if (comboBox2.Text == "") { comboBox2.BackColor = Color.LightCoral; button2.Enabled = true; pictureBox2.Visible = true;}
                if (richTextBox1.Text == "") { richTextBox1.BackColor = Color.LightCoral; button2.Enabled = true; pictureBox3.Visible = true; }
                if (richTextBox2.Text == "") { richTextBox2.BackColor = Color.LightCoral; button2.Enabled = true; pictureBox4.Visible = true; }

                MessageBox.Show("Проверьте заполнение полей выделенных красным цветом", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                
                comboBox1.BackColor = Color.LightGreen;
                comboBox2.BackColor = Color.LightGreen;
                richTextBox1.BackColor = Color.LightGreen;
                richTextBox2.BackColor = Color.LightGreen;


                int i = 0;
                bool iserr = false;

                string lineA = comboBox1.Text;
                string lineB = comboBox2.Text;
                string lineC = richTextBox2.Text;
                string lineD = richTextBox1.Text;
                
                try
                {
                    
                    tcpClient client = new tcpClient(lineA, lineB, lineC, lineD, _ip);
                    client.StartClient();
                    otvetClient = client.ansver;
                }
                catch (Exception ex)
                {
                    i++;
                    richTextBox3.BackColor = Color.Red;
                    richTextBox3.Text = "\r\r\r\r Произошла внутрення систкмная ошибка! \r Просьба обратиться к системному \r Администратору";
                    if (i > 1) richTextBox1.Text = ex.ToString();
                    button2.Enabled = true;
                    iserr = true;
                }

                if (iserr == false)
                {
                    if (otvetClient != "Ok")
                    {
                        richTextBox3.Text = "\r\r\r\r            Повторите отправку. Спасибо.";
                        MessageBox.Show("Произошла системная ошибка. Попробуйте повторить отправку. \r Если ситуация не изменится обратитесь в тех.поддержку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox1.BackColor = Color.White;
                        comboBox2.BackColor = Color.White;
                        richTextBox1.BackColor = Color.White;
                        richTextBox2.BackColor = Color.White;
                        button2.Enabled = true;
                        return;
                    }
                    else
                        richTextBox3.Text = " Ответ сервера:... " + otvetClient + "\r ------------------------------------------------------" + "\r Заявка отправлена" + "\r ------------------------------------------------------" + "\r Можете закрыть программу";
                    MessageBox.Show("Заявка отправлена", "Ок", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    AddDataTabs(lineA, lineB, lineC);
                    _count++;
                    label7.Text = Convert.ToString(_count);
                }
                //button1.Enabled = false;
                //comboBox1.Enabled = false;
                //comboBox2.Enabled = false;
                //textBox1.Enabled = false;


            }




            
        }
        void AddDataTabs(string _linaA, string _lineB, string _lineC)
        {
            Invoke(new Action(() =>
            {
                string datatime = DateTime.Now.ToString();
                //string[] list = str.Split('|');
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[0].Value = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[1].Value = datatime;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[3].Value = _linaA;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Value = _lineB;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[5].Value = _lineC;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[6].Value = "Активная";
                //Coloring allocated cells
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[i];
                    dataGridView1.CurrentCell.Style.BackColor = Color.LightPink;
                    dataGridView1.ClearSelection();
                }


            }));
        }
        private void новаяЗаявкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initConfig();
            button2.Enabled = true;
            groupBox1.Visible = true;
            incDefault();
        }
        private void incDefault()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "Заполните поля, нажмите кнопку отправить.";

            comboBox1.BackColor = Color.White;
            comboBox2.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            richTextBox2.BackColor = Color.White;
            richTextBox3.BackColor = Color.LightBlue;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Вы действительно хотите выйти из програмы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            initConfig();
            button2.Enabled = true;
            incDefault();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void инфоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MServer myServer = new MServer();
            myServer.Show(this);
        }
        public void initConfig()
        {
            string patch;
            try
            {
                StreamReader reader = new StreamReader(@"C:\log\configClient.txt");
                patch = reader.ReadLine();
                reader.Close();
                _ip = patch;
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла ошибка: \r " + e.ToString());
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string putchClose = @"C:\log\closeLog.txt";
            string datatime = DateTime.Now.ToString();
            string new_responce = "";


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    //item = i;
                    //flag = dataGridView1.Rows[i].Selected;
                    //new_responce = SaveinExcell(1, dataGridView1);
                    dataGridView1.Rows[i].Cells[2].Value = datatime;
                    dataGridView1.Rows[i].Cells[6].Value = "Закрыта";
                    for (int z = 0; z < dataGridView1.ColumnCount; z++)
                    {

                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[z];
                        dataGridView1.CurrentCell.Style.BackColor = Color.LightGreen;
                        dataGridView1.ClearSelection();
                        new_responce = new_responce + dataGridView1.Rows[i].Cells[z].Value + "|";
                       
                    }
                }
            }

            LoggInFileClose(putchClose, new_responce);

            
        }
        private void LoggInFileClose(string patch, string received)
        {

            StreamWriter log = new StreamWriter(patch, true);
            string[] less = received.Split('|');
            string tnow = DateTime.Now.ToString();
            log.WriteLine();
            //log.WriteLine(tnow + "|");
            //log.WriteLine(less[0] + "|");
            log.WriteLine(less[0] + "|");
            log.WriteLine(less[1] + "|");
            log.WriteLine(less[2] + "|");
            log.WriteLine(less[3] + "|");
            log.WriteLine(less[4] + "|");
            log.WriteLine(less[5] + "|");
            log.WriteLine(less[6] + "|");
            log.Write("*");
            log.Close();



            //Processing function of the incomming message
            //Removing from the incomming message
            //Adding to table dataGridWiev
            //Adding in logfile
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void просмотрВсехЗаявокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllView formAll = new AllView();
            formAll.Show(this);   
        }
        public void InitializeList(ComboBox cmb, int countt, string putch)
        {
            string tmpIngeners = "";
            int count = 0;

            try
            {
                StreamReader reader = File.OpenText(putch);
                tmpIngeners = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в InitText: \r" + ex.ToString());
            }

            string[] less = tmpIngeners.Split('*');

            for (int i = 0; i < less.Length; i++)
            {
                less[i] = less[i].Replace("\r\n", string.Empty);

            }

            List<string> pre_view = new List<string>();

            for (int i = 0; i < less.Length; i++)
            {
                pre_view.Add(less[i]);
                count++;
            }

            pre_view.RemoveAt(count - 1);//Remote last null element in List

            string[] line = new string[count - 1];//From list after remote last element

            for (int i = 0; i < count - 1; i++)
            {
                line[i] = pre_view[i];
            }




            string[][] big_line = new string[line.Length][];
            for (int i = 0; i < line.Length; i++)
            {
                big_line[i] = line[i].Split('|');
            }


            string[] f_type = new string[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < countt; j++)
                {
                    f_type[i] += big_line[i][j] + " ";
                }
            }


            all_Ingeners = f_type;

            for (int i = 0; i < f_type.Length; i++)
            {
                cmb.Items.Add(all_Ingeners[i] + "\r");
            }

            





            int tmp = 0;
        }
        
    }
}
