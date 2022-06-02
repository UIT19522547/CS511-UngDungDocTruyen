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
    public partial class Signin_profile : Form
    {
        public Signin_profile()
        {
            InitializeComponent();


            //Load ảnh+cài đặt màu chữ
            {
                //load ảnh mặc định (khi mới đăng ký)
                pic_profile_img.Load("C://Users//thaov//OneDrive//Desktop//DoAn//Image//pika.jpg");
                pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;
                //màu chữ menu
                menuStrip1.ForeColor = Color.White;

                menuStrip1.BackColor = Color.FromArgb(200, Color.Black);

                panel_profile.BackColor = Color.FromArgb(200, Color.Black);

                truyệnCủaTôiToolStripMenuItem.BackColor = Color.Black;
            }
        }
    }
}
