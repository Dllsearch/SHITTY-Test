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
    public partial class UserControl4 : UserControl
    {

        RadioButton[] radioButtons;
        PictureBox[] pictureBoxes;

        public UserControl4()
        {
            InitializeComponent();
            RadioButton[] radioButton = { radioButton1, radioButton2, radioButton3, radioButton4 };
            PictureBox[] pcs = { pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            radioButtons = radioButton;
            pictureBoxes = pcs;
        }

        public void loadQuestion(question question)
        {
            label1.Text = question.questiontext;
            if (question.questionpic != null) pictureBox1.Image = question.questionpic;
            for (int n = 0; n < 4; n++)
            {
                radioButtons[n].Checked = false;
                radioButtons[n].Hide();
            }
            for (int n = 0; n < question.answerstext.Length; n++)
            {
                radioButtons[n].Text = question.answerstext[n];
                if (question.answerspic[n] != null)
                {
                    pictureBoxes[n].Image = question.answerspic[n];
                }
                radioButtons[n].Show();
            }
        }

        public bool[] whatIsAsk(question question)
        {
            bool[] nah = new bool[question.trueanswer.Length];
            for (int n = 0; n < nah.Length; n++)
            {
                nah[n] = radioButtons[n].Checked;
            }
            return nah;
        }
    }
}
