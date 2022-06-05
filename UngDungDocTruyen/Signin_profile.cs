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

namespace UngDungDocTruyen
{
    public partial class profile_page : Form
    {
        string link_to_user_info = "D://DoAn//user_profile_images";
        public profile_page(string current_username,bool my_profile)
        {
            InitializeComponent();
            //nếu my_profile=true/tức là đang ở trang cá nhân của bản thân => ẩn button follow đi
            if (my_profile)
            {
                but_follow.Visible = false;
                danhSáchĐọcToolStripMenuItem.Visible = true;
                đangTheoDõiToolStripMenuItem.Visible = true;
                truyệnCủaTôiToolStripMenuItem.Text = "Truyện của tôi";
            }
            else
            //nếu đang ở trang profile của người khác ẩn danh sách đọc và người đang theo dõi (follower đi), và truyện của tôi => tác phẩm
            {
                but_follow.Visible = true;
                danhSáchĐọcToolStripMenuItem.Visible = false;
                đangTheoDõiToolStripMenuItem.Visible = false;
                truyệnCủaTôiToolStripMenuItem.Text = "Tác phẩm";
            }


            //Load ảnh+cài đặt màu chữ
            {
                //load ảnh mặc định (khi mới đăng ký)
                pic_profile_img.Load("D://DoAn//Image//pika.jpg");
                pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;


                //Load ảnh đại diện + số tác phẩm, số danh sách đọc và số lượt follow (nếu có) 
                //Nếu current_username=="" tức là không có user ở hiện tại
                if (current_username != "")
                {
                    string link_profile_img = link_to_user_info+"//" + current_username + ".jpg";
                    pic_profile_img.Load(link_profile_img);
                    pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;

                    string link_info = link_to_user_info + "//" + current_username + ".txt";
                    string[] info = File.ReadAllLines(link_info);
                    num_story.Text = info[0];
                    num_list.Text = info[1];
                    num_follower.Text = info[2];

                }

                //màu chữ menu
                menuStrip1.ForeColor = Color.White;

                menuStrip1.BackColor = Color.FromArgb(200, Color.Black);

                panel_profile.BackColor = Color.FromArgb(200, Color.Black);

                truyệnCủaTôiToolStripMenuItem.BackColor = Color.Black;
            }
        }
    }
}
