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
    public partial class UserControl1 : UserControl
    {

        RadioButton[] radioButtons;

        public UserControl1()
        {
            InitializeComponent();
            RadioButton[] radioButton = { radioButton1, radioButton2 , radioButton3, radioButton4, radioButton5, radioButton6, radioButton7, radioButton8 };
            radioButtons = radioButton;
        }

        public void loadQuestion(question question)
        {
            label1.Text = question.questiontext;
            for(int n=0;n<8;n++)
            {
                radioButtons[n].Checked = false;
                radioButtons[n].Hide();
            }
            for (int n=0; n<question.answerstext.Length; n++)
            {
                radioButtons[n].Text = question.answerstext[n];
                radioButtons[n].Show(); 
            }
        }

        public bool[] whatIsAsk (question question)
        {
            bool[] nah = new bool [question.trueanswer.Length];
            for (int n=0; n<nah.Length; n++)
            {
                nah[n] = radioButtons[n].Checked;
            }
            return nah;
        }
    }
}
