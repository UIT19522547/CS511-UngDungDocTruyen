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
    public partial class Reading : Form
    {
        public Form RefToHome { get; set; }
        public Reading(string story_name,string author_user_name,string current_user_name)
        {
            InitializeComponent();

            panel6.BackColor = Color.FromArgb(200, Color.Black);
            write_new_menu.BackColor = Color.FromArgb(200, Color.Black);
            tTTToolStripMenuItem.BackColor = Color.Black;
            tableLayoutPanel1.BackColor = Color.FromArgb(200, Color.Black);

            string user_profile_folder_link = "D://DoAn//user_profile_images";
            string story_folder_link = "D://DoAn//Story//" + story_name;
            string story_info_folder_link = story_folder_link + "//0.txt";
            string story_view_like_chapter_link = story_folder_link + "//view_like_chapter_count.txt";


            string[] story_info = File.ReadAllLines(story_info_folder_link);
            string[] story_info2 = File.ReadAllLines(story_view_like_chapter_link);

            au_name.Text = story_info[1];
            au_username.Text = story_info[2];
            num_views.Text = story_info2[0];
            num_likes.Text = story_info2[1];
            num_chapters.Text = story_info2[2];

            string ten_dang_nhap_tac_gia = story_info[2];
            string profile_image_link = user_profile_folder_link + "//" + ten_dang_nhap_tac_gia + ".jpg";
            string story_cover_image_link = story_folder_link + "//" + story_name + ".png";
            cover_image.Load(story_cover_image_link);
            cover_image.SizeMode = PictureBoxSizeMode.StretchImage;
            profile_image.Load(profile_image_link);
            profile_image.SizeMode = PictureBoxSizeMode.StretchImage;

            //load ảnh current user (tài khoản đang đăng nhập)/nếu có
            if (current_user_name != "")
            {
                string current_profile_image_link = user_profile_folder_link + "//" + current_user_name + ".jpg";
                current_user_image.Load(current_profile_image_link);
                current_user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                current_user_image.Load("D://DoAn//user_profile_images//default.jpg");
                current_user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void current_user_image_Click(object sender, EventArgs e)
        {
            contextMenuStrip_profile_image.Show(profile_image, new Point(0, 80));
        }

        private void home_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.RefToHome.WindowState = FormWindowState.Maximized;
            }
            this.RefToHome.Show();
            this.Close();
        }
    }
}
