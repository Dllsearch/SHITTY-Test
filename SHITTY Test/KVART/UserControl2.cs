using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class UserControl2 : UserControl
    {

        CheckBox[] checkBoxes;

        public UserControl2()
        {
            InitializeComponent();
            CheckBox[] check = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8 };
            checkBoxes = check;
        }

        public void loadQuestion(question question)
        {
            label1.Text = question.questiontext;
            for (int n=0;n<8;n++)
            {
                checkBoxes[n].Checked = false;
                checkBoxes[n].Hide();
            }
            for (int n = 0; n < question.answerstext.Length; n++)
            {
                checkBoxes[n].Text = question.answerstext[n];
                checkBoxes[n].Show();
            }
        }

        public bool[] whatIsAsk(question question)
        {
            bool[] nah = new bool[question.trueanswer.Length];
            for (int n = 0;n < nah.Length; n++)
            {
                nah[n] = checkBoxes[n].Checked;
            }
            return nah;
        }
    }
}
