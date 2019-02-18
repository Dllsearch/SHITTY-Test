using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class TestDesk : Form
    {
        dbworker dbworker = new dbworker();
        string[][] resultsmx;
        List<Test> Tests = new List<Test>();
        List<results> results = new List<results>();
        shitcomp shi = new shitcomp();
        user User = new user();
        string link;

        public TestDesk(user u)
        {
            InitializeComponent();
            User = u;
            updateForm();
        }

        private shitcomp tts(string s)
        {

            //Test sh = dbworker.getTest(s);
            shitcomp tt = dbworker.getTest(s);
            //shitcomp tt = new shitcomp { Name = sh.Name, User = sh.User, isInitialised = sh.isInitialised, questions = sh.questions, questionsAmount = sh.questionsAmount, questionsPoints = sh.questionsPoints };

            return tt;
        }

        void updateForm()
        {
            listBox1.Items.Clear();
            Tests = dbworker.getTests();
            Tests.OrderBy(x => x.Name);
            permVis();
            listBox1.Items.AddRange(Tests.Select(x => x.Name).ToArray());
            //listView1.Items.Add()
            resultsmx = dbworker.getResultsString();
            listView1.Items.Clear();
            //ListViewItem[] item = new ListViewItem[resultsmx.Length];
            for (int x = 0; x < resultsmx.Length; x++)
            {
                //listView1.Columns.Add()
                listView1.Items.Add(resultsmx[x][0]);
                //item[x] = new ListViewItem();
                /*
                item[x].SubItems.Add(resultsmx[x][0]);
                item[x].SubItems.Add(resultsmx[x][1]);
                item[x].SubItems.Add(resultsmx[x][2]);
                item[x].SubItems.Add(resultsmx[x][3]);
                item[x].SubItems.Add(resultsmx[x][4]);
                listView1.Items.Add(item[x]);
                */
            }
            //listBox1.Items.AddRange(animal.Select(x => x.name).ToArray());
        }

        void permVis ()
        {
            if (User.Permissions == user.permtype.studen || User.Permissions == user.permtype.cheater)
            {
                button2.Hide();
                button4.Hide();
                button5.Hide();
                textBox1.Hide();
                textBox2.Hide();
                label1.Hide();
                label3.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateForm();
        }

        private void mansNoHot()
        {
            OpenFileDialog bucket = new OpenFileDialog();
            //bucket.InitialDirectory = @"C:\";
            bucket.Filter = "shitcomp class (*.shittytestv3)|*.shittytestv3|" + "All Files (*.*)|*.*";
            //bucket.FileName = "test.shittytest";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Открытие теста";
            DialogResult yep = bucket.ShowDialog();
            string test;
            if (yep == DialogResult.OK)
            {
                test = bucket.FileName;
                link = test;
                using (Stream input = File.OpenRead(link))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    shi = (shitcomp)formatter.Deserialize(input);
                }
                textBox2.Text = link;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.Text != "" && link != null && link != "")
            {
                dbworker.newTest(textBox1.Text, User.Username, link);
               
            }
            else MessageBox.Show("Введите ВСЕ данные корректно!");
            updateForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mansNoHot();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = listBox1.GetItemText(listBox1.SelectedItem);
            if (s != null && s != "")
            {
                dbworker.delTest(s);
                updateForm();
            }
            else
            {
                MessageBox.Show("Выберите существующий тест из списка!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = listBox1.GetItemText(listBox1.SelectedItem);
            if (s != null && s != "")
            {
                shitcomp tst = tts(s);
                string tstn = dbworker.checkTest(s).Name;
                testerv3 form = new testerv3(tst, User, tstn);
                Hide();
                form.ShowDialog();
                Show();
            }
            else MessageBox.Show("Выберите существующий тест из списка!");
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            string s = listView1.Items[i].Text;
            listBox2.Items.Clear();
            listBox2.Items.AddRange(resultsmx[i]);
        }
    }
}
