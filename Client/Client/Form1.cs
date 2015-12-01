using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        IPAddress ipAddres;
        public string putchLog = @"D:\Project\Client\Base\log.txt";
        public string putchInjeners = @"D:\Project\Client\Config\injener.txt";
        public string putchInOtdel = @"D:\Project\Client\Config\otdel.txt";
        public int nowOutZayavki = 0;
        public string[] all_Ingeners;


        public Form1()
        {
            InitializeComponent();
            InitComponent();
            InitializeListOFIngeners(comboBox1, 3, putchInjeners);
            InitializeListOFIngeners(comboBox2, 1, putchInOtdel);
        }

        public void InitComponent()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            label1.Text = "Инженер";
            label2.Text = "Оборудование";
            label3.Text = "Полное описание";
            label4.Text = "Отделение";
            label5.Text = "На данный момент:";
            label7.Text = "Общее кол-во обращений: ";
            label8.Text = Convert.ToString(KolZayavokAllTime());
            label6.Text = Convert.ToString(nowOutZayavki);
            button1.Text = "Отмена";
            button2.Text = "";
            button3.Text = "";

           
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddres = ipHostInfo.AddressList[0];
            


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string ansverClient = "";
            TcpClient client = new TcpClient(comboBox1.Text, comboBox2.Text, textBox1.Text, richTextBox1.Text, ipAddres);
            
            try
            {
                client.StartClient();
                ansverClient = client.ansver;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка в модуле отправки сообщения: " + ex.ToString());
            }


            if (ansverClient != "Ok")
            {
                MessageBox.Show("Произошла внутрення системная ошибка! \r Просьба обратиться к системному \r Администратору");
                return;
            }
            else
            {
                client.WriteInLogFile(comboBox1.Text, comboBox2.Text, textBox1.Text, richTextBox1.Text);
                nowOutZayavki++;
                InitComponent();
                MessageBox.Show(" Ответ сервера:... " + ansverClient +  "\r Заявка отправлена \r Можете закрыть программу");
                
               
            }
        }
        private int KolZayavokAllTime()
        {
            int all = 0;
            string filelog = "";
            try
            {
                StreamReader reader = File.OpenText(putchLog);
                filelog = reader.ReadToEnd();
                reader.Close();
                string[] tmpLine = filelog.Split('*');

                for (int i = 0; i < tmpLine.Length; i++)
                {
                    all++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в модуле записи в файл, возможно файл лога отсутствует" + ex.ToString());
            }
            return all - 1;
        }
        public void InitializeListOFIngeners(ComboBox cmb, int countt, string putch)
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
        private void button1_Click(object sender, EventArgs e)
        {
            InitComponent();
        }
    }
}
