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
    // Окно выбора для OFF
    public partial class offline : Form
    {

        string test;
        string studen;
        int questions;

        public offline()
        {
            InitializeComponent();
        }

        private int mansNoHot()
        {
            OpenFileDialog bucket = new OpenFileDialog();
            //bucket.InitialDirectory = @"C:\";
            bucket.Filter = "Test class (*.shittytestv3)|*.shittytestv3|" + "Test files (*.shittytestv2)|*.shittytestv2|" + "Test files (*.shittytest)|*.shittytest|" + "All Files (*.*)|*.*";
            //bucket.FileName = "test.shittytest";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Открытие теста";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                test = bucket.FileName;
                textBox2.Text = test;
            }
            return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mansNoHot();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] patharr; //для разбивки пути на куски
            string[] tnarr; //отделить имя и расширение
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
                testerv1 form = new testerv1(questions, test, studen, checkBox1.Checked, checkBox2.Checked);
                this.Hide();
                form.ShowDialog();
            }
            else if ((tnarr.Last() == "dat") || (tnarr.Last() == "shittytestv3"))
            {
                Form4 form = new Form4(test);
                this.Hide();
                form.ShowDialog();
            }
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Editor form = new Editor();
            this.Hide();
            form.ShowDialog();
            Show();
        }
    }
}
