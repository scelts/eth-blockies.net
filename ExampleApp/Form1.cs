using System;
using System.Windows.Forms;
using ETH_Identicons;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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

        private void button4_Click(object sender, EventArgs e)
        {
            string[] addresses =
            {
                "0x3db4B1Be10b0D39D3A0f2140aEd6Be5b79213453",
                "0x50D857764C66fB7E15eFafeF63a46AF4604D092C",
                "0x55affd5041F689a6D020545c8C97ecEFAD4f6AAe",
                "0x97D159383E6C66c32F89a5f08c105a52D5D5EA2C",
                "0x2512cCAEb46C5A62092056Da7735769A5760aBC6"
            };
            int size = 64;
            int space = 32;
            Bitmap mainImage = new Bitmap(size * 5 + space * 4, size);
            using (Graphics g = Graphics.FromImage(mainImage))
            {
                int pos = 0;
                foreach (var address in addresses)
                {
                    var identicon = new Identicon(address, 8);
                    g.DrawImage(identicon.GetBitmap(size), pos, 0);
                    pos += size + space;
                }
            }
            saveFileDialog.Filter = "Png (*.png)|*.png";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainImage.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Identicon identicon = new Identicon(textBox1.Text.Trim(), 8);
            int size = Convert.ToInt32(textBox2.Text);
            this.Icon = identicon.GetIcon(64);
        }
    }
}
