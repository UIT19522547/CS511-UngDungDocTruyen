using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading.Tasks;

namespace UngDungDocTruyen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Ẩn đi picturebox chứa ảnh user do chưa đăng nhập, chỉ hiển thị từ đăng nhập. 
            //Sau khi đăng nhập mới hiển thị ảnh user và ẩn button đăng nhập
            //user_image.Visible = false;

            //Load ảnh vào các PictureBox
            home.Load("..//..//homeIcon4.png");
            home.SizeMode = PictureBoxSizeMode.StretchImage;
            user_image.Load("..//..//jn112_grookey_eevee2.jpg");
            user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            but_back_to_my_story.Load("..//..//back2.png");
            but_back_to_my_story.SizeMode = PictureBoxSizeMode.StretchImage;

            panel_write_new.Visible = false;

            //Chỉnh sửa về màu chữ
            {
                type_book.ForeColor = Color.GreenYellow;
                type_book.Dock = DockStyle.Fill;
                type1.ForeColor = Color.YellowGreen;
                type2.ForeColor = Color.YellowGreen;
                type3.ForeColor = Color.YellowGreen;
                type4.ForeColor = Color.YellowGreen;
                type5.ForeColor = Color.YellowGreen;
                type6.ForeColor = Color.YellowGreen;
                type7.ForeColor = Color.YellowGreen;
                type8.ForeColor = Color.YellowGreen;
                type9.ForeColor = Color.YellowGreen;
                write_new.ForeColor= Color.YellowGreen;
                my_story.ForeColor = Color.YellowGreen;
                


            }

            //Thêm truyện vào tablelayoutpanel
            int i = 0;
            for (i = 0; i < 6; i++)
            {
                tableLayoutPanel_story.Controls.Add(new UserControl_Story_on_Home());
            }
            

            string[] lines = {
            "First line", "Second line", "Third line"
            };
            File.AppendAllLines(Path.Combine("E:\\GAME", "WriteFile.txt"), lines);
            Console.WriteLine("OK");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
