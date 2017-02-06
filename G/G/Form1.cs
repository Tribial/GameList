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
        private int currentId;
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
                currentId = id - 1;
                label11.Text = gameNames[currentId];
                label12.Text = gamePaths[currentId];
            }
            
            Lging.Enabled = true;
            Delete.Enabled = true;
            Check_and_Load();
            label_MouseHover(sender, e);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label11.Text = "";
            label12.Text = "";
            Lging.Enabled = false;
            Delete.Enabled = false;
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
            catch (Exception) { MessageBox.Show("Wystąpił błąd w oprogramowaniu, skontaktuj się z producentem aplikacji."); }

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
            currentId = -1;
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
            OpenFileDialog searchGame = new OpenFileDialog();
            bool clone=false;
            string currentName;
            searchGame.ShowDialog();
            foreach (var a in gamePaths)
            {
                if (a == searchGame.FileName)
                    clone = true;
            }
            if (!clone)
            {//21
                if (searchGame.SafeFileName.Length > 21)
                {
                    MessageBox.Show(searchGame.SafeFileName + "\n is to long, it has to have less than 22 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    putName pt = new putName();
                    pt.ShowDialog();
                    gameNames.Add(pt.name);
                    currentName = pt.name;
                }

                else if (MessageBox.Show("This game will be displayed with this name: " + searchGame.SafeFileName + "\nWould you like to change it?", "Add game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    putName pt = new putName();
                    pt.ShowDialog();
                    gameNames.Add(pt.name);
                    currentName = pt.name;
                }

                else
                {
                    gameNames.Add(searchGame.SafeFileName);
                    currentName = searchGame.SafeFileName;
                }
                gamePaths.Add(searchGame.FileName);
                

                using (StreamWriter sw = new StreamWriter("games", true))
                {
                    sw.WriteLine(searchGame.FileName + "#" + currentName);
                }
                File.Create(Directory.GetCurrentDirectory() + "\\Game Logs\\" + currentName + "-logFile.txt");
            }
            else
            {
                MessageBox.Show("File:\n   " + searchGame.FileName + "\n   " + searchGame.SafeFileName +"\nIs already on your game list.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Check_and_Load();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                labels[gamePaths.Count - 1].Text = "Empty";
                gamePaths.Remove(gamePaths[currentId]);
                gameNames.Remove(gameNames[currentId]);
                if (MessageBox.Show("Do you want to delete all related log files?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\Game Logs\\" + gameNames[currentId] + "-logFile.txt"))
                        File.Delete(Directory.GetCurrentDirectory() + "\\Game Logs\\" + gameNames[currentId] + "-logFile.txt");
                }
                Check_and_Load();
            }
            catch (Exception) { MessageBox.Show("Wystąpił błąd w oprogramowaniu, skontaktuj się z producentem aplikacji."); }
            Form1_Click(sender, e);
            
            using (StreamWriter sw = new StreamWriter("games"))
            {
                for (int i = 0; i < gamePaths.Count; i++)
                {
                    sw.WriteLine(gamePaths[i] + "#" + gameNames[i]);
                }
            }
        }

        private void Log_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory()+"\\Game Logs\\" +gameNames[currentId] + "-logFile.txt", true))
            {
                Log logIn = new Log();
                logIn.ShowDialog();
                if (logIn.ok)
                    Log(logIn.msg, sw);
            }
        }
        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  {0}", logMessage);
            w.WriteLine("  :");
            w.WriteLine("-------------------------------");
        }
    }
}
