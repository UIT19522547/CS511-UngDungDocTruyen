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
    public partial class profile_following : UserControl
    {
        public profile_following(string name_, string username_, string num_story_,string num_follower_)
        {
            InitializeComponent();
            name.Text = name_;
            username.Text = username_;
            num_story.Text = num_story_;
            num_follower.Text = num_follower_;

            //Tải ảnh đại diện
            string path = "D://DoAn//user_profile_images//" + username_ + ".jpg";
            profile_image.Load(path);
            profile_image.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
