using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyWinformAppDemo
{
    public partial class Form1 : Form
    {

        string filename = "";

        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (filename != "")
            {
                using (StreamWriter sr = new StreamWriter(filename))
                {
                    sr.Write(this.textBox1.Text);
                    MessageBox.Show("File saved.");
                }                   
            }
            else
            {
                MessageBox.Show("No file is open.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    filename = openFileDialog1.FileName;
                    this.Text = "SimplePad -- " + filename;
                    textBox1.Text = sr.ReadToEnd();
                }            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr =  saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                using (StreamWriter sr = new StreamWriter(saveFileDialog1.FileName))
                {
                    sr.Write(this.textBox1.Text);
                    filename = saveFileDialog1.FileName;
                    this.Text = "SimplePad -- " + filename;
                }  
            }
        }
    }
}
