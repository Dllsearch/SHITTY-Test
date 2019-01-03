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
    public partial class UserControl5 : UserControl
    {
        
        CheckBox[] checkBoxes;
        PictureBox[] pictureBoxes;

        public UserControl5()
        {
            InitializeComponent();
            CheckBox[] check = { checkBox1, checkBox2, checkBox3, checkBox4};
            PictureBox[] pcs = { pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            checkBoxes = check;
            pictureBoxes = pcs;
        }

        public void loadQuestion(question question)
        {
            label1.Text = question.questiontext;
            if (question.questionpic != null) pictureBox1.Image = question.questionpic;
            for (int n = 0; n < 4; n++)
            {
                checkBoxes[n].Checked = false;
                checkBoxes[n].Hide();
            }
            for (int n = 0; n < question.answerstext.Length; n++)
            {
                checkBoxes[n].Text = question.answerstext[n];
                if (question.answerspic[n] != null) 
                {                                     
                    pictureBoxes[n].Image = question.answerspic[n];
                }
                checkBoxes[n].Show();
            }
        }

        public bool[] whatIsAsk(question question)
        {
            bool[] nah = new bool[question.trueanswer.Length];
            for (int n = 0; n < nah.Length; n++)
            {
                nah[n] = checkBoxes[n].Checked;
            }
            return nah;
        }
    }
}
