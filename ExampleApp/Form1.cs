using System;
using System.Windows.Forms;
using ETH_Identicons;
using System.Diagnostics;
using System.IO;

namespace ExampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //size 8x8 is the standard one, used in Mist etc...
            Identicon identicon = new Identicon(textBox1.Text.Trim(), 8);
            int size = Convert.ToInt32(textBox2.Text);
            pictureBox1.Size = new System.Drawing.Size(size, size);
            pictureBox1.Image = identicon.GetBitmap(size);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Identicon identicon = new Identicon(textBox1.Text.Trim(), 8);
            int size = Convert.ToInt32(textBox2.Text);
            saveFileDialog.Filter = "Icon (*.ico)|*.ico";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    identicon.GetIcon(size).Save(fs);
                    fs.Close();
                    fs.Dispose();
                }
                Process.Start(saveFileDialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Identicon identicon = new Identicon(textBox1.Text.Trim(), 8);
            int size = Convert.ToInt32(textBox2.Text);
            saveFileDialog.Filter = "Bitmap (*.bmp)|*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                identicon.GetBitmap(size).Save(saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }  
        }
    }
}
