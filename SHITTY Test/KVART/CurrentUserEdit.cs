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
    public partial class CurrentUserEdit : Form
    {
        bool cld = false;
        user User;
        DBworker dbworker = new DBworker();

        public CurrentUserEdit(user tUser, bool called)
        {
            cld = called;
            InitializeComponent();
            User = tUser;
            updateForm();
        }

        void updateForm()
        {
            Text += ": " + User.Username;
            textBox1.Text = User.Username;
            textBox2.Text = User.Name;
            textBox3.Text = User.Password;
            textBox4.Text = "" + User.Id;
            int perms = Convert.ToInt32(User.Permissions);
            if (perms < 3) comboBox1.SelectedIndex = perms;
            else if (perms == 3) comboBox1.SelectedIndex = 2;
            else
            {
                comboBox1.SelectedIndex = 4;
                comboBox1.Enabled = false;
            }
            if (cld) comboBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user Nuser = User;
            Nuser.Username = textBox1.Text;
            Nuser.Name = textBox2.Text;
            Nuser.Password = textBox3.Text;
            Nuser.Permissions = (user.permtype) comboBox1.SelectedIndex;
            dbworker.setUser(User.Id, Nuser);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удаление пользователя", "Вы точно хотите удалить пользователя " + User.Username + "из базы данных? ЭТО ДЕЙСТВИЕ НЕЛЬЗЯ ОТМЕНИТЬ!!!", MessageBoxButtons.YesNo) == DialogResult.Yes) dbworker.delUser(User.Id);
            Close();
        }
    }
}
