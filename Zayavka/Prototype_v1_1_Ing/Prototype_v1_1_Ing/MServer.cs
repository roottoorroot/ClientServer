using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Prototype_v1_1_Ing
{
    public partial class MServer : Form
    {
        public IPAddress add = IPAddress.None;
        public string _ip;
        
        
        public MServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(textBox1.Text, out add))
            {
                MessageBox.Show("Ошибка!\r Не верный IP...");
                textBox1.Text = "";
            }
            else
            {
                try
                {
                    _ip = add.ToString();


                    StreamWriter config = new StreamWriter(@"C:\log\configClient.txt", false);
                    config.WriteLine(_ip);
                    config.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                MessageBox.Show("IP сервера изменен...");
            }
        }

        public IPAddress ReturnAdIp()
        {
            return add;
        }
    }
}
    