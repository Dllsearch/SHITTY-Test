using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SHITTYTEST;

namespace SHITTYTEST
{
    // Редактор тестов
    public partial class Editor : Form
    {
        int[] qstep;
        int qvalue;
        RadioButton[] radioButtons;
        CheckBox[] checkBoxes;
        TextBox[] textBoxes;
        Button[] answersImageButtons;
        Button[] answersWhatIsImageButtons;

        shitcomp compared = new shitcomp();

        void initNEO() // Просто забивает элементы формы в массив, ибо так удобнее
        {
            RadioButton[] radioButtonss =
                {
                radioButton4,
                radioButton5,
                radioButton6,
                radioButton7,
                radioButton8,
                radioButton9,
                radioButton10,
                radioButton11
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
            TextBox[] textBoxx =
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8
            };
            textBoxes = textBoxx;
            Button[] imgBtnss =
            {
                button9,
                button10,
                button11,
                button12,
                button13,
                button14,
                button15,
                button16,
            };
            answersImageButtons = imgBtnss;
            Button[] img2Btnss =
            {
                button21,
                button22,
                button23,
                button24,
                button25,
                button26,
                button27,
                button28,
            };
            answersWhatIsImageButtons = img2Btnss;
        }

        void initEditor(int dudes) // ТИп инициализирует
        {
            compared.afterInit(dudes);
            for (int wat=0;wat < dudes; wat++)
            {
                compared.questions[wat] = new question();
            }
            qvalue = dudes;
            qstep = new int[dudes];
            for (int qq = 0; qq < dudes; qq++)
            {
                qstep[qq] = 2;
            }
            if (true) updateForm();
        }

        void updateForm()// Обновляет форму исходя из стадии вопроса
        {
            toolStripStatusLabel1.Text = "ВОПРОС №" + (1 + compared.tamedCounter) + ", ЭТАП " + qstep[compared.tamedCounter];
            hideAll();
            numericUpDown1.Value = compared.questions.Length;
            switch (qstep[compared.tamedCounter])
            {
                case 2:
                    show2();
                    break;
                case 3:
                    show3();
                    break;
                case 4:
                    show4();
                    break;
                case 5:
                    show5();
                    break;
                default:
                    MessageBox.Show("An error occured. Question step can't be less than 2 at that step");
                    break;
            }
        }

        void hideAll() // Забыть всё
        {
            for (int op = 0; op < 8; op++)
            {
                radioButtons[op].Checked = false;
                checkBoxes[op].Checked = false;
                textBoxes[op].Text = "";
            }
            groupBox5.Hide();
            groupBox4.Hide();
            groupBox3.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            toolStripStatusLabel1.Visible = false;
            label4.Hide();
            label6.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button7.Hide();
            button8.Hide();
            button19.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            radioButton5.Hide();
            radioButton6.Hide();
            radioButton7.Hide();
            radioButton8.Hide();
            radioButton9.Hide();
            radioButton10.Hide();
            radioButton11.Hide();
            checkBox1.Hide();
            checkBox2.Hide();
            checkBox3.Hide();
            checkBox4.Hide();
            checkBox5.Hide();
            checkBox6.Hide();
            checkBox7.Hide();
            checkBox8.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox7.Hide();
            textBox8.Hide();
            textBox9.Hide();
            numericUpDown2.Hide();
        }

        void show2()
        {
            // Этап 2
            groupBox3.Show();
            label4.Show();
            numericUpDown2.Show();
            if (compared.questions[compared.tamedCounter].answerstext != null)
            {
                numericUpDown2.Value = compared.questions[compared.tamedCounter].answerstext.Length;
            }
            button8.Show();
        }
        void show3()
        {
            show2();
            // Этап 3
            groupBox2.Show();
            textBox9.Show();
            textBox9.Text = compared.questions[compared.tamedCounter].questiontext;
            button3.Show();
            toolStripStatusLabel1.Visible = true;
            button19.Show();
        }
        void show4()
        {
            show3();
            // Этап 4
            groupBox4.Show();
            label6.Show();
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Show();
            if (compared.questions[compared.tamedCounter].qtype == question.questiontypes.radio)
            {
                radioButton1.Checked = true;
            }
            else if (compared.questions[compared.tamedCounter].qtype == question.questiontypes.check)
            {
                radioButton2.Checked = true;
            }
            else if (compared.questions[compared.tamedCounter].qtype == question.questiontypes.text)
            {
                radioButton3.Checked = true;
            }
            button2.Show();
        }

        void showx()
        {
            if (compared.questions[compared.tamedCounter].pics == true)
            {
                radioButton12.Checked = true;
            }
            else if (compared.questions[compared.tamedCounter].pics == false)
            {
                radioButton13.Checked = true;
            }
            if (compared.questions[compared.tamedCounter].questionpic != null)
            {
                pictureBox1.Image = compared.questions[compared.tamedCounter].questionpic;
            }
            else if (compared.questions[compared.tamedCounter].questionpic == null)
            {
                pictureBox1.Image = null;
            }
        }

        void show5()
        {
            show4();
            showx();
            // Этап 5
            groupBox1.Show();
            button9.Show();
            button10.Show();
            button11.Show();
            button12.Show();
            button13.Show();
            button14.Show();
            button15.Show();
            button16.Show();
            if (compared.questions[compared.tamedCounter].qtype == question.questiontypes.radio)
            {
                for (int op=0; op < compared.questions[compared.tamedCounter].answerstext.Length; op++)
                {
                    radioButtons[op].Show();
                    radioButtons[op].Checked = compared.questions[compared.tamedCounter].trueanswer[op];
                }
            }
            else if (compared.questions[compared.tamedCounter].qtype == question.questiontypes.check)
            {
                for (int op = 0; op < compared.questions[compared.tamedCounter].answerstext.Length; op++)
                {
                    checkBoxes[op].Show();
                    checkBoxes[op].Checked = compared.questions[compared.tamedCounter].trueanswer[op];
                }
            }
            for (int op = 0; op < compared.questions[compared.tamedCounter].answerstext.Length; op++)
            {
                textBoxes[op].Show();
                textBoxes[op].Text = compared.questions[compared.tamedCounter].answerstext[op];
            }
            // ---
            if (compared.tamedCounter > 0) button4.Show();
            if (compared.tamedCounter < (compared.questions.Length-1)) button5.Show();
            button7.Show();
            groupBox5.Show();
        }

        public Editor() // Инициализация (да ладна)
        {
            InitializeComponent();
            initNEO();
            hideAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initEditor(decimal.ToInt32(numericUpDown1.Value));
            updateForm();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            compared.questions[compared.tamedCounter].initialDude(decimal.ToInt32(numericUpDown2.Value));
            qstep[compared.tamedCounter] = 3;
            updateForm();
        }

        private void button6_Click(object sender, EventArgs e) //Конвертит старый говноформат
        {
            MessageBox.Show("В РАЗРАБООТКЕ");
            //
            OpenFileDialog bucket = new OpenFileDialog();
            //bucket.InitialDirectory = @"C:\";
            bucket.Filter = "Test files (*.shittytestv2)|*.shittytestv2|" + "Test files (*.shittytest)|*.shittytest|" + "All Files (*.*)|*.*";
            //bucket.FileName = "test.shittytest";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Открытие теста";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                FileStream MainFile = new FileStream(bucket.FileName, FileMode.Open, FileAccess.Read);
                StreamReader file = new StreamReader(MainFile, Encoding.GetEncoding(1251));
                int questions = Convert.ToInt32(file.ReadLine());
                int[] answers = new int[questions];
                for (int t = 0; t < questions; t++)
                {
                    answers[t] = Convert.ToInt32(file.ReadLine());
                }
                int[] qtypes = new int[questions];
                for (int a = 0; a < questions; a++)
                {
                    qtypes[a] = Convert.ToInt32(file.ReadLine());
                }
                string[] questiontexts = new string[questions];
                for (int quq = 0; quq < questions; quq++)
                {
                    questiontexts[quq] = file.ReadLine();
                }
                string[][] answerstext = new string[questions][];
                for (int tt = 0; tt < questions; tt++)
                {
                    answerstext[tt] = new string[answers[tt]];
                }
                for (int qs = 0; qs < questions; qs++)
                {
                    for (int aw = 0; aw < answers[qs]; aw++)
                    {
                        answerstext[qs][aw] = file.ReadLine();
                    }
                }
                initEditor(questions);
                if (true)
                {
                    for (int n = 0; n < questions; n++)
                    {
                        compared.questions[n].initialDude(answers[n]);
                        compared.questions[n].qtype = (question.questiontypes)qtypes[n];
                        compared.questions[n].questiontext = questiontexts[n];
                        compared.questions[n].answerstext = answerstext[n];
                    }
                }

                //
                for (int n = 0; n < questions; n++)
                {
                    qstep[n] = 5;
                }
                //

                string[] patharr = bucket.FileName.Split('\\');
                string[] tnarr = patharr.Last().Split('.');
                if (tnarr.Last() == "shittytestv2")
                {
                    int ansttl = Convert.ToInt32(file.ReadLine());
                    string[] trueanswersstring = new string[ansttl];
                    for (int tr = 0; tr < ansttl; tr++)
                    {
                        trueanswersstring[tr] = file.ReadLine();
                        if (compared.questions[tr].qtype == question.questiontypes.radio)
                        {
                            compared.questions[tr].trueanswer[Convert.ToInt32(trueanswersstring[tr])] = true;
                        }
                        if (compared.questions[tr].qtype == question.questiontypes.check)
                        {
                            string[] splitedanswers = trueanswersstring[tr].Split(',');
                            int[] convertedanswers = new int[trueanswersstring.Length];
                            for (int n = 0; n < splitedanswers.Length; n++)
                            {
                                if (splitedanswers[n]!="") convertedanswers[n] = Convert.ToInt32(splitedanswers[n]);
                            }
                            for (int n=0;n<answers[tr];n++)
                            {
                                for (int m = 0; m < answers[tr]; m++)
                                {
                                    if (convertedanswers[n] == m)
                                    {
                                        compared.questions[tr].trueanswer[m] = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (tnarr.Last() == "shittytestv2man") //а это вообще...
                {
                    int ansttl = Convert.ToInt32(file.ReadLine());
                    string[] trueanswersstring = new string[ansttl];
                    for (int tr = 0; tr < ansttl; tr++)
                    {
                        trueanswersstring[tr] = file.ReadLine();
                        if (compared.questions[tr].qtype == question.questiontypes.radio)
                        {
                            compared.questions[tr].trueanswer[Convert.ToInt32(trueanswersstring[tr])-1] = true;
                        }
                        if (compared.questions[tr].qtype == question.questiontypes.check)
                        {
                            string[] splitedanswers = trueanswersstring[tr].Split(',');
                            int[] convertedanswers = new int[trueanswersstring.Length];
                            for (int n = 0; n < splitedanswers.Length; n++)
                            {
                                if (splitedanswers[n] != "") convertedanswers[n] = Convert.ToInt32(splitedanswers[n]);
                            }
                            for (int n = 0; n < answers[tr]; n++)
                            {
                                for (int m = 0; m < answers[tr]; m++)
                                {
                                    if (convertedanswers[n] == m)
                                    {
                                        compared.questions[tr].trueanswer[m] = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                file.Close();
                updateForm();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            answWrite();
            if ( compared.tamedCounter < (compared.questions.Length-1))
            {
                compared.tamedCounter++;
            }
            else
            {
                button5.Hide();
            }
            updateForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (compared.tamedCounter > 0)
            {
                compared.tamedCounter--;
            }
            else
            {
                button4.Hide();
            }
            updateForm();
        }

        private void Form3_Load(object sender, EventArgs e) //Удолить рука не поднимается
        {

        }

        private void button2_Click(object sender, EventArgs e) // Тип вопроса
        {
            if (radioButton1.Checked) compared.questions[compared.tamedCounter].qtype = question.questiontypes.radio;
            if (radioButton2.Checked) compared.questions[compared.tamedCounter].qtype = question.questiontypes.check;
            if (radioButton3.Checked) compared.questions[compared.tamedCounter].qtype = question.questiontypes.text;
            qstep[compared.tamedCounter] = 5;
            updateForm();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) //Не помню этого
        {

        }

        private void button3_Click(object sender, EventArgs e)// ВОПРОС ЗНАТОКАМ
        {
            compared.questions[compared.tamedCounter].questiontext = textBox9.Text;
            qstep[compared.tamedCounter] = 4;
            updateForm();
        }

        void answWrite () // Епифанцев записывает ответы...
        {
            for (int yay = 0; yay < compared.questions[compared.tamedCounter].answerstext.Length; yay++)
            {
                compared.questions[compared.tamedCounter].answerstext[yay] = textBoxes[yay].Text;
            }
            if (compared.questions[compared.tamedCounter].qtype != question.questiontypes.text)
            {
                for (int kek = 0; kek < compared.questions[compared.tamedCounter].answerstext.Length; kek++)
                {
                    compared.questions[compared.tamedCounter].trueanswer[kek] = false;
                }
                for (int kek = 0; kek < compared.questions[compared.tamedCounter].answerstext.Length; kek++)
                {
                    if (radioButtons[kek].Checked || checkBoxes[kek].Checked)
                    {
                        compared.questions[compared.tamedCounter].trueanswer[kek] = true;
                    }
                }
            }
            else
            {
                for (int kek = 0; kek < compared.questions[compared.tamedCounter].answerstext.Length; kek++)
                {
                    compared.questions[compared.tamedCounter].trueanswer[kek] = true;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e) // Сказать братишке, чтоб записал
        {
            answWrite();
        }

        void writeAndExit(string path) // Запиши тест в файл, и иди чисти вилкой г***о
        {
            FileStream MainFile = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter file = new StreamWriter(MainFile, Encoding.GetEncoding(1251));
            int questionsAtAll = compared.questions.Length;
            //вопросов
            MessageBox.Show("" + questionsAtAll);
            file.WriteLine(questionsAtAll);
            //ответов
            for (int meem = 0; meem < questionsAtAll; meem++)
            {
                file.WriteLine(compared.questions[meem].answerstext.Length);
            }
            //тип
            for (int meem = 0; meem < questionsAtAll; meem++)
            {
                if (compared.questions[meem].qtype == question.questiontypes.radio)
                {
                    file.WriteLine(0);
                }
                if (compared.questions[meem].qtype == question.questiontypes.check)
                {
                    file.WriteLine(1);
                }
                if (compared.questions[meem].qtype == question.questiontypes.text)
                {
                    file.WriteLine(2);
                }
            }
            //текст
            for (int meem = 0; meem < questionsAtAll; meem++)
            {
                file.WriteLine(compared.questions[meem].questiontext);
            }
            //текст ответов
            for (int meem = 0; meem < questionsAtAll; meem++)
            {
                for (int WeeW=0; WeeW < compared.questions[meem].answerstext.Length; WeeW++)
                {
                    file.WriteLine(compared.questions[meem].answerstext[WeeW]);
                }
            }
            //ответ(ы)
            file.WriteLine(questionsAtAll);
            for (int meem = 0; meem < questionsAtAll; meem++)
            {
                if (compared.questions[meem].qtype == question.questiontypes.radio)
                {
                    for (int n = 0; (n < compared.questions[meem].trueanswer.Length); n++)
                    {
                        if (compared.questions[meem].trueanswer[n] == true)
                        {
                            file.WriteLine(n);
                            break;
                        }
                    }
                }
                else if (compared.questions[meem].qtype == question.questiontypes.check)
                {
                    for (int n = 0;n < compared.questions[meem].answerstext.Length; n++)
                    {
                        if (compared.questions[meem].trueanswer[n] == true)
                        {
                            MessageBox.Show("Q" + meem + " A" + n + " is" + "true");
                            file.Write(n+",");
                        }
                        else
                        {
                            MessageBox.Show("Q" + meem + " A" + n + " is" + "false");
                        }
                    }
                    file.WriteLine("");
                }
                else if (compared.questions[meem].qtype == question.questiontypes.text)
                {
                    file.WriteLine(compared.questions[meem].answerstext[0]);
                }
                else MessageBox.Show("ERROR AT Q" + meem + ", qtype isnt ok");
            }
            file.Close();
            Close();
        }

        private void button7_Click(object sender, EventArgs e) // В1/2 Сейв
        {
            if (MessageBox.Show("При сохранении в чиатемом формате, медиа-контент не сохраняется! \n  Вы уверены в том, то хотите продолжить?", "ВНИМАНИЕ", MessageBoxButtons.OKCancel) != DialogResult.Cancel)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Test files (*.shittytest)|*.shittytest|" + "Test files (*.shittytestv2)|*.shittytestv2|" + "All Files (*.*)|*.*";
                //save.CheckFileExists = true;
                //save.CheckPathExists = false;
                save.Title = "Сохранение теста";
                DialogResult yep = save.ShowDialog();
                if (yep == DialogResult.OK)
                {
                    writeAndExit(save.FileName);
                }
                // TO DO - DO IT! 
                // ------------------------ JUST DO IT!!!
                // MAKE YOUR DREAMS COME T R U E!!!
                // DO IT!!!
            }
        }

        private void button18_Click(object sender, EventArgs e) // Открыть тест
        {
            OpenFileDialog bucket = new OpenFileDialog();
            bucket.Filter = "Test files (*.shittytestv3)|*.shittytestv3|" + "class data (*.dat)|*.dat|" + "All Files (*.*)|*.*";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Открытие бинарника теста";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                using (Stream input = File.OpenRead(bucket.FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    compared = (shitcomp)formatter.Deserialize(input);
                }
                qstep = compared.tamedCounterArray;
                numericUpDown1.Value = 1+compared.tamedCounter;
                updateForm();
            }
        }

        private void button19_Click(object sender, EventArgs e) // Схоронить тест
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Test files (*.shittytestv3)|*.shittytestv3|" + "All Files (*.*)|*.*";
            //save.CheckFileExists = true;
            //save.CheckPathExists = false;
            save.Title = "Сохранение теста в бинарном формате";
            DialogResult yep = save.ShowDialog();
            if (yep == DialogResult.OK)
            {
                using (Stream output = File.Create(save.FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    compared.tamedCounterArray = qstep;
                    formatter.Serialize(output, compared);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e) // Если нужны картинки...
        {
            if ((radioButton12.Checked) || (compared.questions[compared.tamedCounter].qtype != question.questiontypes.text))
            {
                for (int x = 0; x < answersImageButtons.Length; x++)
                {
                    answersImageButtons[x].Enabled = true;
                    answersWhatIsImageButtons[x].Enabled = true;
                    compared.questions[compared.tamedCounter].pics = true;
                }
            }
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e) // если картинки не нужны
        {

            if ((radioButton13.Checked) || (compared.questions[compared.tamedCounter].qtype == question.questiontypes.text))
            {
                for (int x = 0; x < answersImageButtons.Length; x++)
                {
                    answersImageButtons[x].Enabled = false;
                    answersWhatIsImageButtons[x].Enabled = false;
                    compared.questions[compared.tamedCounter].pics = false;
                }
            }
        }

        private void button20_Click(object sender, EventArgs e) //открываем картиночки :)
        {
            OpenFileDialog bucket = new OpenFileDialog();
            bucket.Filter = "ЕБУЧИЕ ШАКАЛЫ (*.jpg)|*.jpg|" + "ЕБУЧИЕ ШАКАЛЫ (*.jp*g)|*.jp*g|" + "BMP (*.bmp)|*.bmp|" + "GIF (*.gif)|*.gif|" + "All Files (*.*)|*.*";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Выбор изображения";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                compared.questions[compared.tamedCounter].questionpic = Image.FromFile(bucket.FileName);
            }
            pictureBox1.Image = compared.questions[compared.tamedCounter].questionpic;
        }

        void setQPic (int answerN) // тож картиночки
        {

            OpenFileDialog bucket = new OpenFileDialog();
            bucket.Filter = "ЕБУЧИЕ ШАКАЛЫ (*.jpg)|*.jpg|" + "ЕБУЧИЕ ШАКАЛЫ (*.jp*g)|*.jp*g|" + "BMP (*.bmp)|*.bmp|" + "GIF (*.gif)|*.gif|" + "All Files (*.*)|*.*";
            bucket.CheckFileExists = true;
            bucket.CheckPathExists = false;
            bucket.Title = "Выбор изображения";
            DialogResult yep = bucket.ShowDialog();
            if (yep == DialogResult.OK)
            {
                compared.questions[compared.tamedCounter].answerspic[answerN] = Image.FromFile(bucket.FileName);
            }
        }

        // Задаем картиночки ответам
        private void button9_Click(object sender, EventArgs e)
        {
            setQPic(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setQPic(1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setQPic(2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setQPic(3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setQPic(4);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setQPic(5);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setQPic(6);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            setQPic(7);
        }

        void callPic (int answerN) // Пасматрет картинку
        {
            PicView form = new PicView(compared.questions[compared.tamedCounter].answerspic[answerN]);
            form.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            callPic(0);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            callPic(1);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            callPic(2);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            callPic(3);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            callPic(4);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            callPic(5);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            callPic(6);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            callPic(7);
        }
        // Без комментариев...
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
