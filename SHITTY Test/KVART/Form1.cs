using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class Form1 : Form
    {
        string test;
        string studen;
        int questions;
        public Form1()
        {
            InitializeComponent();
            studen = "Test OFFline User";
            test = "TST.shittytest";
            textBox1.Text = studen;
            textBox2.Text = test;
            //label1.Text = studen+", \nвам предлагается пройти тест \n\""+test+"\",\nответив на "+questions+" вопросов.";
        }

        private int mansNoHot ()
        {
            OpenFileDialog bucket = new OpenFileDialog();
            //bucket.InitialDirectory = @"C:\";
            bucket.Filter = "Class dump (*.dat)|*.dat|" + "Test class (*.shittytestv3)|*.shittytestv3|" + "Test files (*.shittytestv2)|*.shittytestv2|" + "Test files (*.shittytest)|*.shittytest|" + "All Files (*.*)|*.*";
            //bucket.FileName = "test.shittytest";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Choose TEST";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                test = bucket.FileName;
                textBox2.Text = test;
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] patharr; 
            string[] tnarr; 
            patharr = test.Split('\\');
            string yuy = patharr.Last();
            tnarr = yuy.Split('.');
            if ((tnarr.Last() == "shittytest") || (tnarr.Last() == "shittytestv2"))
            {
                FileStream MainFile = new FileStream(test, FileMode.Open, FileAccess.Read);
                StreamReader file = new StreamReader(MainFile, Encoding.GetEncoding(1251));
                questions = Convert.ToInt32(file.ReadLine());
                file.Close();
                studen = textBox1.Text;
                MessageBox.Show("Проблемы с доступом к подпрограммам");
                Form2 form = new Form2(questions, test, studen, checkBox1.Checked, checkBox2.Checked);
                this.Hide();
                form.ShowDialog();
            }
            /*
            else if ((tnarr.Last() == "dat") || (tnarr.Last() == "shittytestv3"))
            {
                Form4 form = new Form4(test);
                this.Hide();
                form.ShowDialog();
            }
            */
            Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mansNoHot();
        }
        /*
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.ShowDialog();
            Show();
        }
        */
    }
}
