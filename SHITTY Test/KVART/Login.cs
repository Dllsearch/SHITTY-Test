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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbworker dbworker = new dbworker();
            user user = dbworker.login(textBox1.Text, maskedTextBox1.Text);
            if (user != null)
            {
                MessageBox.Show("ПРАВА: " + user.Permissions);
                if (user.Permissions == user.permtype.admin)
                {
                    TestDesk form = new TestDesk(user);
                    Hide();
                    form.ShowDialog();
                    Close();
                }
                else if (user.Permissions == user.permtype.teacher)
                {
                    TestDesk form = new TestDesk(user);
                    Hide();
                    form.ShowDialog();
                    Close();
                }
                else if (user.Permissions == user.permtype.studen)
                {
                    TestDesk form = new TestDesk(user);
                    Hide();
                    form.ShowDialog();
                    Close();
                }
                else if (user.Permissions == user.permtype.cheater)
                {
                    TestDesk form = new TestDesk(user);
                    Hide();
                    form.ShowDialog();
                    Close();
                }
                else if (user.Permissions == user.permtype.CAHR)
                {
                    TestDesk form = new TestDesk(user);
                    Hide();
                    form.ShowDialog();
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
