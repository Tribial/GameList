using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G
{
    public partial class putName : Form
    {
        public string name;

        public putName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Name" || textBox1.Text.Length == 0 || textBox1.Text.Contains(' '))
            {
                MessageBox.Show("This name is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                name = textBox1.Text;
                this.Close();
            }
        }
    }
}
