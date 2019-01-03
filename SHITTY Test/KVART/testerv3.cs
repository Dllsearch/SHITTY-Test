using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class testerv3 : Form
    {

        Random rand = new Random();

        shitcomp questions = new shitcomp();

        user User = new user();

        string testName;

        // -------------------

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool PostMessage(IntPtr hWnd, uint Msg, uint WParam, uint LParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        internal extern static bool ReleaseCapture();

        const uint WM_SYSCOMMAND = 0x0112;
        const uint DOMOVE = 0xF012;
        const uint DOSIZE = 0xF008;

        // --------------------
        
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_SIZEBOX = 0x40000;

                var cp = base.CreateParams;
                cp.Style |= WS_SIZEBOX;

                return cp;
            }
        }
        

        // --------------------

        int counter = 0;

        bool[][] checks;
        string[] txt;

        string link;

        void preInit(shitcomp questionarium)
        {
            questions = questionarium;
            questions.questions = questionarium.questions.OrderBy(x => rand.Next()).ToArray();
            progressBar1.Maximum = questions.questions.Length - 1;
            checks = new bool[questions.questions.Length][];
            //int cntr4rs = 0;
            for (int n = 0; n < questions.questions.Length; n++)
            {
                checks[n] = new bool[questions.questions[n].trueanswer.Length];
                //if (questions.questions[n].qtype == question.questiontypes.text) cntr4rs++;
            }
            //txt = new string[cntr4rs];
            txt = new string[questions.questions.Length];
            updateForm();
        }

        void questionUpdater()
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            if (questions.questions[counter].qtype == question.questiontypes.radio)
            {
                if (questions.questions[counter].pics) userControl41.Show();
                else userControl11.Show();
            }
            else if (questions.questions[counter].qtype == question.questiontypes.check)
            {
                if (questions.questions[counter].pics) userControl51.Show();
                else userControl21.Show();
            }
            else if (questions.questions[counter].qtype == question.questiontypes.text)
            {
                userControl31.Show();
            }
            questionLoader(questions.questions[counter].qtype);
        }

        void takeAnswers ()
        {
            if (questions.questions[counter].qtype == question.questiontypes.radio)
            {
                checks[counter] = userControl11.whatIsAsk(questions.questions[counter]);
            }
            else if (questions.questions[counter].qtype == question.questiontypes.check)
            {
                checks[counter] = userControl21.whatIsAsk(questions.questions[counter]);
            }
            else if (questions.questions[counter].qtype == question.questiontypes.text)
            {
                txt[counter] = userControl31.whatIsAsk(questions.questions[counter]);
            }
        }

        void questionLoader (question.questiontypes qtype)
        {
            if (qtype == question.questiontypes.radio)
            {
                if (questions.questions[counter].pics) userControl41.loadQuestion(questions.questions[counter]);
                else userControl11.loadQuestion(questions.questions[counter]);
            }
            else if (qtype == question.questiontypes.check)
            {
                if (questions.questions[counter].pics) userControl51.loadQuestion(questions.questions[counter]);
                else userControl21.loadQuestion(questions.questions[counter]);
            }
            else if (qtype == question.questiontypes.text)
            {
                userControl31.loadQuestion(questions.questions[counter]);
            }
        }

        void points ()
        {
            int balls = 0;
            int eballs = 0;
            int mballs = 0;
            for (int n = 0; n < questions.questions.Length; n++)
            {
                int tempcnt = 0;
                int mtempcnt = 0;
                eballs += questions.questionsPoints[n];
                /*
                if (questions.questions[n].trueanswer.Equals(checks[n]))
                { balls++; }
                */
                for (int m = 0; m < questions.questions[n].trueanswer.Length; m++)
                {
                    if (questions.questions[n].qtype != question.questiontypes.text)
                    {
                        if (checks[n][m] == questions.questions[n].trueanswer[m])
                        {
                            tempcnt++;
                        }
                        else if (checks[n][m] == questions.questions[n].trueanswer[m])
                        {
                            mtempcnt++;
                        }
                    }
                    else
                    {
                        if (txt[n].ToLower().Trim(new char[] { ' ' , ',', '.', '!', '?'}) == questions.questions[n].answerstext[m].ToLower().Trim(new char[] { ' ', ',', '.', '!', '?' }))
                        {
                            tempcnt = questions.questions[n].trueanswer.Length;
                            mtempcnt = 0;
                            break;
                        }
                        else 
                        {
                            mtempcnt++;
                        }
                    }
                }
                if (tempcnt == questions.questions[n].trueanswer.Length) balls++;
                else if (mtempcnt > 0) mballs++;
            }
            if ((User.Permissions == user.permtype.cheater || User.Permissions == user.permtype.CAHR ) && balls < (eballs/2))
            {
                if (User.Permissions == user.permtype.cheater)
                {
                    int sballs = (eballs - balls);
                    if (sballs >= (eballs / 2)) balls += (eballs - sballs);
                }
                else if (User.Permissions == user.permtype.CAHR)
                {
                    balls += (eballs / 10);
                }
            }
            MessageBox.Show("Вы набрали " + balls + " из " + eballs 
                //+ "\n Неточных ответов - " + mballs
                , "Итог");
            dbworker dbworker = new dbworker();
            dbworker.addResult(User, balls, testName);
        }

        void updateForm()
        {
            if (counter < questions.questions.Length)
            {
                label1.Text = "Вопрос №" + (1 + counter);
                label2.Text = "Вопросов " + questions.questions.Length + "";
                progressBar1.Value = counter;
                questionUpdater();
            }
            if ((counter<1)||(counter==0))
            {
                button4.Hide();
            }
            if (!(counter<questions.questions.Length))
            {
                button3.Hide();
                points();
            }
        }

        public testerv3(shitcomp shitcomp, user user, string tstName)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            preInit(shitcomp);
            User = user;
            testName = tstName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            counter--;
            updateForm();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (counter<questions.questions.Length)
            {
                takeAnswers();
                counter++;
                updateForm();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            PostMessage(this.Handle, WM_SYSCOMMAND, DOMOVE, 0);
        }
    }
}
