using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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

        void updTestList()
        {
            listBox1.Items.Clear();
            Tests = dbworker.getTests();
            Tests.OrderBy(x => x.Name);
            listBox1.Items.AddRange(Tests.Select(x => x.Name).ToArray());
        }

        void updResultsTable()
        {
            //listView1.Items.Add()
            resultsmx = dbworker.getResultsString();
            dataGridView1.RowCount = resultsmx.Length;
            //listView1.Items.Clear();
            //ListViewItem[] item = new ListViewItem[resultsmx.Length];
            for (int x = 0; x < resultsmx.Length; x++)
            {
                //listView1.Columns.Add()
                //listView1.Items.Add(resultsmx[x][0]);
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
            dataGridView1.AutoGenerateColumns = true;
            for (int row = 0; row < resultsmx.Length; row++) for (int col = 0; col < dataGridView1.ColumnCount; col++) dataGridView1[col, row].Value = resultsmx[row][col].ToString();
            //listBox1.Items.AddRange(animal.Select(x => x.name).ToArray());
        }

        void updateForm()
        {
            permVis();
            updTestList();
            updResultsTable();
        }

        void permVis()
        {
            if (User.Permissions == user.permtype.studen || User.Permissions == user.permtype.cheater)
            {
                button2.Hide();
                button4.Hide();
                button5.Hide();
                button8.Hide();
                button10.Hide();
                textBox1.Hide();
                textBox2.Hide();
                label1.Hide();
                label3.Hide();
                checkBox1.Hide();
                textBox4.Text = User.Group;
                textBox4.Enabled = false;
                textBox5.Text = User.Name;
                textBox5.Enabled = false;
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

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox3.Text != "") && (textBox3.Text != null))
            {
                listBox1.Items.Clear();
                Tests = dbworker.findTests(textBox3.Text);
                Tests.OrderBy(x => x.Name);
                listBox1.Items.AddRange(Tests.Select(x => x.Name).ToArray());
            }
            else updTestList();
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
        
        private void button4_Click(object sender, EventArgs e)
        {
            mansNoHot();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Editor form = new Editor();
            this.Hide();
            form.ShowDialog();
            Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            resultsmx = dbworker.getResultsString();
            int row = 0;
            for (int x = 0; x < resultsmx.Length; x++)
            {
                if (
                    (resultsmx[x][0].IndexOf(textBox5.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    && (resultsmx[x][1].IndexOf(textBox4.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    && (resultsmx[x][2].IndexOf(textBox7.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    && (resultsmx[x][4].IndexOf(textBox6.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    )
                {
                    dataGridView1.Rows.Add();
                    for (int col = 0; col < dataGridView1.ColumnCount; col++)
                    {
                        if ((col != 3) && radioButton1.Checked)
                        {
                            dataGridView1[col, row].Value = resultsmx[x][col].ToString();
                        }
                        else if ((col == 3) && radioButton2.Checked)
                        {
                            bool np = false;
                            int eballs = 0;
                            shitcomp tst = tts(resultsmx[x][2]);
                            if (tst == null)
                            {
                                np = true;
                                goto L1;
                            }
                            for (int n = 0; n < tst.questions.Length; n++)
                            {
                                eballs += tst.questionsPoints[n];
                            }
                            double otn = Convert.ToDouble(resultsmx[x][col].ToString()) / eballs * 100;
                            dataGridView1[col, row].Value = (otn / 20).ToString();
                        L1:
                            if (np)
                            {
                                dataGridView1[col, row].Value = "ТЕСТ НЕ НАЙДЕН";
                            }
                        }
                    }
                    row++;
                }
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        /*
private void listView1_ItemActivate(object sender, EventArgs e)
{
int i = listView1.SelectedIndices[0];
string s = listView1.Items[i].Text;
listBox2.Items.Clear();
listBox2.Items.AddRange(resultsmx[i]);
}
*/
    }
}
