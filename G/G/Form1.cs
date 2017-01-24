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
                label11.Text = gameNames[id-1];
                label12.Text = gamePaths[id-1];
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
                labels[i].BackColor = Color.FromArgb(30,30,30);
                icons[i].Enabled = false;
                icons[i].BackColor = Color.FromArgb(30, 30, 30);
            }

            for (int i = 0; i < gamePaths.Count; i++)
            {
                labels[i].Enabled = true;
                labels[i].BackColor = Color.Black;
                labels[i].Text = gameNames[i];
                
                //icons[i].Image = ??
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("games"))
                {
                    string[] path_name;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        path_name = line.Split('#');
                        gamePaths.Add(path_name[0]);
                        gameNames.Add(path_name[1]);
                    }
                }
            }
            catch (Exception){}
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

        private void label_MouseHover(object sender, EventArgs e)
        {
            int id = -1;
            Label sen = (Label)sender;
            try { id = Convert.ToInt32(Convert.ToString(sen.Name[sen.Name.Length - 1])); }
            catch (Exception) { MessageBox.Show("Wystąpił błąd w oprogramowaniu, skontaktuj się z producentem aplikacji."); }
            if (id == 0)
                id = 10;
            labels[id-1].BackColor = Color.Gray;
            
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            int id = -1;
            Label sen = (Label)sender;
            try { id = Convert.ToInt32(Convert.ToString(sen.Name[sen.Name.Length - 1])); }
            catch (Exception) { MessageBox.Show("Wystąpił błąd w oprogramowaniu, skontaktuj się z producentem aplikacji."); }
            if (id == 0)
                id = 10;
            labels[id - 1].BackColor = Color.Transparent;
            labels[id - 1].ForeColor = Color.White;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog lol = new OpenFileDialog();
            bool clone=false;
            lol.ShowDialog();
            foreach (var a in gamePaths)
            {
                if (a == lol.FileName)
                    clone = true;
            }
            if (!clone)
            {
                gamePaths.Add(lol.FileName);
                gameNames.Add(lol.SafeFileName);

                using (StreamWriter sw = new StreamWriter("games", true))
                {
                    sw.WriteLine(lol.FileName + "#" + lol.SafeFileName);
                }
            }
            else
            {
                MessageBox.Show("File:\n   " + lol.FileName + "\n   " + lol.SafeFileName +"\nIs already on your game list.");
            }
            Check_and_Load();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
