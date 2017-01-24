using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace G
{
    public partial class Form1 : Form
    {
        private List<Label> labels = new List<Label>();
        private List<PictureBox> icons = new List<PictureBox>();
        private List<String> gamePaths = new List<string>();
        private List<String> gameNames = new List<string>();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnAnyGameClick(object sender, EventArgs e)
        {
            int id = -1;
            if (sender is Label)
            {
                Label sen = (Label)sender;
                try { id = Convert.ToInt32(Convert.ToString(sen.Name[sen.Name.Length-1])); }
                catch (Exception) { MessageBox.Show("Wystąpił błąd w oprogramowaniu, skontaktuj się z producentem aplikacji.");}
                if (id == 0)
                    id = 10;
                label11.Text = gameNames[id];
                label12.Text = gamePaths[id];
            }
            
            Log.Enabled = true;
            Check_and_Load();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label11.Text = "";
            label12.Text = "";
            Log.Enabled = false;
        }

        private void Check_and_Load()
        {
            for (int i = 0; i < labels.Count; i++ )
            {
                labels[i].Enabled = false;
                labels[i].BackColor = Color.Gray;
                icons[i].Enabled = false;
                icons[i].BackColor = Color.Gray;


            }
            for (int i = 0; i < gamePaths.Count; i++)
            {
                labels[i].Enabled = true;
                labels[i].Text = gameNames[i];
                //icons[i].Image = ??
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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
            Check_and_Load();
        }
    }
}
