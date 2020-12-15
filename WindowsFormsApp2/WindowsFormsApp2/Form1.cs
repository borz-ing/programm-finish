using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        readonly string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        FileStream file; 
        float[] array;
        int range;

        float[,] array2;
        int a, b;

        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            range = int.Parse(textBox1.Text);
            array = new float[range];


            for(int i = 0; i < range; i++)
            {
                array[i] = r.Next(100);
                textBox2.Text += array[i] + " ";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            array = null;
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox3.Text);
            b = int.Parse(textBox4.Text);
           file= new FileStream(mydocs + @"\Array2.txt", FileMode.OpenOrCreate);

            array2 = new float[a, b];

            for(int i = 0; i<a; i++)
            {

                string tempString = "";
               
                for (int j = 0; j < b; j++)
                {
                    array2[i, j] = r.Next(100);
                    tempString += $"[{array2[i, j]}] ";
                }
                tempString += "\n";
                byte[] tempBytes = Encoding.Default.GetBytes(tempString);
                file.Write(tempBytes, 0, tempBytes.Length);
            }
            file.Close();
            Process.Start(mydocs + @"\Array2.txt");

        }
    }
}
