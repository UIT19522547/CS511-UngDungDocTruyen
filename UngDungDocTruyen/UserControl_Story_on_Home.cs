using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungDocTruyen
{
    public partial class UserControl_Story_on_Home : UserControl
    {
        public Form RefToHome { get; set; }
        public UserControl_Story_on_Home(string ten_truyen,string ten_dang_nhap_tac_gia,string view_count,string like_count,string num_of_chapters, string sum,string link_anh_bia)
        {
            InitializeComponent();
            story_name.Text = ten_truyen;
            author_username.Text = ten_dang_nhap_tac_gia;
            num_views.Text = view_count;
            num_likes.Text = like_count;
            num_chapters.Text = num_of_chapters;
            story_summary.Text = sum;
            pictureBox1.Load(link_anh_bia);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public string story_name_
        {
            get { return story_name.Text; }
            set { story_name.Text = value; }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            InvokeOnClick(this, new EventArgs());
        }
    }
}
