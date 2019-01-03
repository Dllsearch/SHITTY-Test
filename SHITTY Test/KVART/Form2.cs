using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Linq;
using SHITTYTEST;

namespace SHITTYTEST
{
    public partial class Form2 : Form
    {

        int questions; //вопросов
        string[] askaq; // Текст вопроса
        int[] answers; // Ответы
        string[][] qus; //Текст ответов
        int ansttl; //количество указаннных правилььных ответов?
        string[] trueanswers; //Верные ответы
        int radio = 0, check = 1, text = 2; //enum заменитель :3
        int[] qtypes; //типы вопросов (enum не нужен - eнн)

        string[] patharr; //для разбивки пути на куски
        string[] tnarr; //отделить имя и расширение
        bool writetype; // Галка записи текста ответа
        bool checkTest; // Галка проверки теста
        string test; // ПУТь
        int i=0; // Кунтер
        string studen; //Имя Имярекович
        string[] answ; //ответы
        int tru; //Кол-во верных ответов Имя Имярековича

        public Form2(int oquestions, string otest, string studenb, bool wtype, bool chktst)
        {
            InitializeComponent();
            questions = oquestions;
            test = otest;
            patharr = test.Split('\\');
            string yuy = patharr.Last();
            tnarr = yuy.Split('.');
            studen = studenb;
            writetype = wtype;
            checkTest = chktst;
            answ = new string[questions];
            /*
            for (int opa=0; opa < questions; opa++)
            {
                answ[opa] = "X";
            }
            */
            askaq = new string[questions];
            wakeUpNeo();
            testParser(test);
            answersVisibler(answers[i], qtypes[i]);
            toolStripProgressBar1.Maximum = questions;
            toolStripStatusLabel1.Text = "Вопрос " + (1 + i) + "/" + questions;
            label1.Text = askaq[i];
        }
        
        private int testParser(string tsst)
        {
            FileStream MainFile = new FileStream(tsst, FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(MainFile, Encoding.GetEncoding(1251));
            questions = Convert.ToInt32(file.ReadLine());
            answers = new int[questions];
            for (int t = 0; t < questions; t++)
            {
                answers[t] = Convert.ToInt32(file.ReadLine());
            }
            qtypes = new int[questions];
            for (int a = 0; a < questions; a++)
            {
                qtypes[a] = Convert.ToInt32(file.ReadLine());
            }
            string[][] qust = new string[questions][];
            for (int tt = 0; tt < questions; tt++)
            {
                qust[tt] = new string[answers[tt]];
            }
            for (int quq = 0; quq < questions; quq++)
            {
                askaq[quq] = file.ReadLine();
            }
            for (int qs = 0; qs < questions; qs++)
            {
                for (int aw = 0; aw < answers[qs]; aw++)
                {
                    qust[qs][aw] = file.ReadLine();
                }
            }
            if (checkTest && (tnarr.Last() == "shittytestv2"))
            {
                ansttl = Convert.ToInt32(file.ReadLine());
                trueanswers = new string [ansttl];
                for (int tr=0; tr<ansttl;tr++)
                {
                    trueanswers[tr] = file.ReadLine();

                }
            }
            qus = qust;
            file.Close();

            return 0;
        }

        void answersVisibler(int qstamnt, int answtype)
        {
            for (int q=0; q < 8; q++)
            {
                radioButtons[q].Visible = false;
                radioButtons[q].Checked = false;
                checkBoxes[q].Visible = false;
                checkBoxes[q].Checked = false;
            }
            textBox1.Visible = false;
            textBox1.Text = "";

            if (((answtype == radio) || (answtype == check)) && ((qstamnt > 8) || (qstamnt < 1)))
                {
                    MessageBox.Show(this, "В файле обнаружена ошибка:\nВ ВОПРОСЕ УКАЗАНО " + qstamnt + " ОТВЕТОВ\nДля одного вопроса от 1 до 8 ответов.\nВозможны ошибки при отображении ответов.", "ОШИБКА В ФАЙЛЕ ТЕСТА", MessageBoxButtons.OK);
                }
            else if ((answtype < radio) || (answtype > text))
            {
                MessageBox.Show(this, "В файле обнаружена ошибка:\nВ ВОПРОСЕ УКАЗАН " + answtype + " ТИП ОТВЕТОВ\nТипы ответов только 0-2.\nВозможны ошибки при отображении ответов.", "ОШИБКА В ФАЙЛЕ ТЕСТА", MessageBoxButtons.OK);
            }
            else if (answtype == radio)
            {
                for (int q=0; q < qstamnt; q++)
                {
                    radioButtons[q].Visible = true;
                    radioButtons[q].Text = qus[i][q];
                }
            }
            else if (answtype == check)
            {
                for (int q=0; q < qstamnt; q++)
                {
                    checkBoxes[q].Visible = true;
                    checkBoxes[q].Text = qus[i][q];
                }
            }
            else if (answtype == text)
            {
                textBox1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( i<questions && MessageBox.Show(this, "Если вы прекратите сейчас, то ответы буду сохранены в файл.", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                File.WriteAllLines(".\\results\\" + studen + " " + patharr.Last() + ".txt", answ);
                /*
                for (int n = 0; n < (answ.Length); n++)
                {
                    textBox1.AppendText(answ[n]);
                }
                */
                this.Close();
            }
            if (!button1.Visible)
            {
                if (checkTest && (tnarr.Last() == "shittytestv2"))
                {
                    tru = 0;
                    for (int assa=0; assa<ansttl;assa++)
                    {
                        if (answ[assa] == trueanswers[assa]) tru++; 
                    }
                    MessageBox.Show("Вы набрали: "+tru+" баллов из "+ansttl+".");
                }
                File.WriteAllLines(".\\results\\" + studen + " " + tnarr[0] + ".txt", answ);
                /*
                for (int n = 0; n < (answ.Length); n++)
                {
                    textBox1.AppendText(answ[n]);
                }
                */
                this.Close();
            }
        }

        RadioButton[] radioButtons;
        CheckBox[] checkBoxes;

        void wakeUpNeo()
        {
            RadioButton[] radioButtonss =
                {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8
            };
            radioButtons = radioButtonss;
            CheckBox[] checkBoxx =
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5,
                checkBox6,
                checkBox7,
                checkBox8
            };
            checkBoxes = checkBoxx;
        }

        void radioShit()
        {
            int q = 0;
            while (q < answers[i])
            {
                if (radioButtons[q].Checked)
                {
                    writeIt(q);
                    break;
                }
                q++;
            }
        }

        void checkBoxShit()
        {
            int q = 0;
            while (q < answers[i])
            {
                if (checkBoxes[q].Checked) writeIt(q);
                q++;
            }
        }

        void textBoxShit ()
        {
            answ[i] = textBox1.Text;
        }

        void writeIt(int q)
        {
            if (writetype)
            {
                if (qtypes[i] == check)
                {
                    
                    answ[i] += qus[i][q] + "\\";
                }
                else
                {
                    answ[i] = qus[i][q];
                }
            }
            else
            {
                if (qtypes[i] == check)
                {
                    answ[i] += q + ",";
                }
                else
                {
                    answ[i] = ""+q;
                }
            }
        }

        int checkIt()
        {
            if (qtypes[i] == radio) { radioShit(); return radio; }
            else if (qtypes[i] == check) { checkBoxShit(); return check; }
            else if (qtypes[i] == text) { textBoxShit(); return text; }
            else
            {
                MessageBox.Show(this, "Ошибка в файле теста - неизвестный тип ответов на вопрос.\nВозможны ошибки при записи ответов", "ОШИБКА");
                return (-1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i <= questions)
            {
                checkIt();
                //MessageBox.Show(answ[i]);
            }
            i++;
            toolStripProgressBar1.Value = i;
            if (i<(questions))
            {
                toolStripStatusLabel1.Text = "Вопрос " + (1 + i) + "/" + questions;
                label1.Text = askaq[i];
                answersVisibler(answers[i], qtypes[i]);
            }
            else
            {
                button1.Hide();
                //textBox1.AppendText("НеИзВеСтНо");
                MessageBox.Show("Ошибка! \nПодпрограмма для работы с БД недоступна.");
            }
        }
    }
}



        
    

