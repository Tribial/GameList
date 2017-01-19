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
    public partial class Form1 : Form
    {
        private List<Label> labels = new List<Label>();
        private List<PictureBox> icons = new List<PictureBox>();
        public Form1()
        {
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            icons.Add(pictureBox1);
            icons.Add(pictureBox2);
            icons.Add(pictureBox3);
            icons.Add(pictureBox4);
            icons.Add(pictureBox5);
            icons.Add(pictureBox6);
            icons.Add(pictureBox7);
            icons.Add(pictureBox8);
            icons.Add(pictureBox9);
            icons.Add(pictureBox10);
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
            
        }
        private void OnAnyGameClick(object sender, EventArgs e)
        {
            int id = 1;
            if (sender is Label)
            {
                Label sen = (Label)sender;
                label11.Text = sen.Name;
            }
            else if (sender is PictureBox)
            {
                PictureBox sen = (PictureBox)sender;
                label11.Text = icons.IndexOf(sen).ToString();

            }
            //label11.Text = id.ToString();
            Log.Enabled = true;
        }
    }
}
