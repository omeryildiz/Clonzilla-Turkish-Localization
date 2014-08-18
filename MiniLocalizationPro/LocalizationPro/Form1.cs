using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalizationPro
{
    public partial class Form1 : Form
    {
        public static int counter;
        public static string[] filelines;
        public static string filename;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string gettext = richTextBox2.Text;
            string output = Regex.Replace(filelines[counter], "\\'.*\\'", "'" + gettext + "'");
            filelines[counter] = output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileTemp = @"C:\Temp\localization_pro_log.txt";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt|All files (*.*)|*.*";
            theDialog.InitialDirectory = @"C:\Users\Ömer\Documents\GitHub\Clonzilla-Turkish-Localization";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                filename = theDialog.FileName;

                filelines = File.ReadAllLines(filename);

                textBox1.Text = filename;
            }
            FileStream fs1;
            
            if (!File.Exists(fileTemp))
            {
                 fs1 = new FileStream(fileTemp, FileMode.OpenOrCreate, FileAccess.Write);
                 StreamWriter writer = new StreamWriter(fs1);
                 writer.Write("0");
                 writer.Close();
            }

            string[] output = File.ReadAllLines(fileTemp);
            if (output[0].ToString() != null)
                counter = Convert.ToInt32(output[0]);
            else
                counter = 0;
            richTextBox1.Text = filelines[counter];        
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (counter < filelines.Length)
            {
                counter++;
                richTextBox1.Text = filelines[counter];
                richTextBox2.Clear();
            }
            else
                MessageBox.Show("Dosyanın sonuna gelindi! İlerleyemezsiniz");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                richTextBox1.Text = filelines[counter];
                richTextBox2.Clear();
            }
            else
                MessageBox.Show("Dosyanın başına gelindi");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(filename, filelines);
            string fileTemp = @"C:\Temp\localization_pro_log.txt";
     
            if (File.Exists(fileTemp))
            {
                File.Delete(fileTemp);
            }
            FileStream fs = File.Create(fileTemp);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(counter.ToString());
            writer.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Görüş ve önerileriniz için:\n nomeryildiz@gmail.com");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


     
    }
}
