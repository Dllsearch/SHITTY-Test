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
    public partial class UserEditor : Form
    {
        DBworker DBworker = new DBworker();
        string[][] resultsmx;

        public UserEditor()
        {
            InitializeComponent();
            updResultsTable();
        }

        void updResultsTable() // Получаем юзверей
        {
            resultsmx = DBworker.getUsersString();
            dataGridView1.RowCount = resultsmx.Length;
            dataGridView1.AutoGenerateColumns = true;
            for (int row = 0; row < resultsmx.Length; row++) for (int col = 0; col < dataGridView1.ColumnCount; col++) dataGridView1[col, row].Value = resultsmx[row][col].ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("" + dataGridView1.CurrentRow.Cells[5].Value);
            CurrentUserEdit ed = new CurrentUserEdit(DBworker.getUserByID("" + dataGridView1.CurrentRow.Cells[5].Value), false);
            ed.ShowDialog();
            updResultsTable();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            updResultsTable();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            resultsmx = DBworker.getUsersString();
            int row = 0;
            for (int x = 0; x < resultsmx.Length; x++)
            {
                if (
                    (resultsmx[x][0].IndexOf(textBox7.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    && (resultsmx[x][1].IndexOf(textBox5.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    && (resultsmx[x][2].IndexOf(textBox4.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    //&& (resultsmx[x][4].IndexOf(textBox6.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    )
                {
                    dataGridView1.Rows.Add();
                    for (int col = 0; col < dataGridView1.ColumnCount; col++)
                    {
                        dataGridView1[col, row].Value = resultsmx[x][col].ToString();
                    }
                    row++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updResultsTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newU adduser = new newU();
            adduser.ShowDialog();
            updResultsTable();
        }
    }
}
