using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbworker dbworker = new dbworker();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("ВСЕ ПОЛЯ ОБЯЗАТЕЛЬНЫ К ЗАПОЛЕНИЮ");
            }
            else
            {
                dbworker.newUser(textBox2.Text, textBox1.Text, maskedTextBox1.Text, textBox3.Text, maskedTextBox2.Text);
                MessageBox.Show("Регистрация успешна!");
                Close();
            }

        }
    }
}
