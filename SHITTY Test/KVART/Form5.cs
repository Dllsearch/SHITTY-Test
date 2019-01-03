using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHITTYTEST
{
    public partial class Form5 : Form
    {
        public Form5(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
        }
    }
}
