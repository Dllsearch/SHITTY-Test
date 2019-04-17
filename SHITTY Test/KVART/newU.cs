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
    public partial class newU : Form
    {
        public newU()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBworker DBworker = new DBworker();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("ВСЕ ПОЛЯ ОБЯЗАТЕЛЬНЫ К ЗАПОЛЕНИЮ");
            }
            else
            {
                DBworker.addUser(textBox2.Text, textBox1.Text, maskedTextBox1.Text, textBox3.Text, (user.permtype) comboBox1.SelectedIndex);
                MessageBox.Show("Регистрация успешна!");
                Close();
            }
        }
    }
}
