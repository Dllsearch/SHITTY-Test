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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        public void loadQuestion(question question) // Выводит текст вопроса, и изображение при наличии
        {
            label1.Text = question.questiontext;
            if (question.questionpic != null) label1.Image = question.questionpic;
        }

        public string whatIsAsk(question question) // Атвет
        {
            return textBox1.Text;
        }
    }
}
