using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungDocTruyen
{
    public partial class Writing : Form
    {
        public Writing()
        {
            InitializeComponent();

            cácChươngToolStripMenuItem.Visible = false;

            //Load ảnh mũi tên quay lại
            but_back_to_my_story.Load("C://Users//thaov//OneDrive//Desktop//DoAn//Image//back2.png");
            but_back_to_my_story.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void load_cover_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                cover_image.Image = Image.FromFile(fileOpen.FileName);
                cover_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            fileOpen.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Nếu checked thì text là Có, bỏ check thì text thành không
            string txt = checkBox1.Text;
            if (txt == "Không")
            {
                checkBox1.Text = "Có";
            }
            else
            {
                checkBox1.Text = "Không";
            }
        }
    }
}
