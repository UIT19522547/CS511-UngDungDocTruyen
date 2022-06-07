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
        public Form RefToHome { get; set; }
        string link_to_user_info = "D://DoAn//user_profile_images";
        string current_user_uname;
        string current_profile_uname;
        bool isMyProfile = false;
        public profile_page(string current_user_username,string username_of_profile,bool my_profile)
        {
            InitializeComponent();

            panel_setting.Visible = false;
            tableLayoutPanel2.Visible = false;
            truyệnCủaTôiToolStripMenuItem.BackColor = Color.Black;
            current_user_uname = current_user_username;
            current_profile_uname = username_of_profile;
            //Cập nhật tên
            string path = "D://DoAn//user_profile_images//" + username_of_profile + ".txt";
            label7.Text = File.ReadAllLines(path)[0];
            label4.Text = username_of_profile;
            //load ảnh đại diện của tài khoản đang đăng nhập (nếu có) 
            if (current_user_username == "")
            {
                pic_current_uname.Visible = false;

            }
            else if (my_profile)
            {
                string path_ = "D://DoAn//Image//setting.png";
                Image im = GetCopyImage(path_);
                pic_current_uname.Image = im;
                pic_current_uname.SizeMode = PictureBoxSizeMode.StretchImage;
                isMyProfile = true;
            }
            else
            {
                string path_ = "D://DoAn//user_profile_images//" + current_user_uname + ".jpg";
                Image im = GetCopyImage(path_);
                pic_current_uname.Image = im;
                pic_current_uname.SizeMode = PictureBoxSizeMode.StretchImage;

            }

            //Xem tài khoản đang đăng nhập có đang theo dõi profile đó không
            if (!my_profile)
            {
                int j = 0;
                string path2= "D://DoAn//user_profile_images//" + current_user_username + ".txt";
                string[] data = File.ReadAllLines(path2);
                for (j = 5; j < data.Length; j++)
                {
                    if (data[j] == username_of_profile)
                    {
                        but_follow.Text = "Đang theo dõi";
                        break;
                    }
                }
            }


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
                //pic_profile_img.Load("D://DoAn//Image//pika.jpg");
                //pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;


                //Load ảnh đại diện + số tác phẩm, số danh sách đọc và số lượt follow (nếu có) 
                //Nếu current_username=="" tức là không có user ở hiện tại
                if (username_of_profile != "")
                {
                    string link_profile_img = link_to_user_info+"//" + username_of_profile + ".jpg";
                    Image im = GetCopyImage(link_profile_img);
                    pic_profile_img.Image = im;
                    pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;
                    im = GetCopyImage(link_profile_img);
                    profile_image2.Image = im;
                    profile_image2.SizeMode = PictureBoxSizeMode.StretchImage;

                    string link_info = link_to_user_info + "//" + username_of_profile + ".txt";
                    string[] infox = File.ReadAllLines(link_info);
                    num_story.Text = infox[1];
                    num_list.Text = infox[2];
                    num_follower.Text = infox[3];

                }

                //màu chữ menu
                menuStrip1.ForeColor = Color.White;

                menuStrip1.BackColor = Color.FromArgb(200, Color.Black);

                panel_profile.BackColor = Color.FromArgb(200, Color.Black);

                truyệnCủaTôiToolStripMenuItem.BackColor = Color.Black;
            }

            //add truyện của tác giả vào tablelayoutpanel
            string link_story_folder = "D://DoAn//Story";
            string[] story = Directory.GetDirectories(link_story_folder);
            //Thêm truyện vào tablelayoutpanel
            int i = 0;
            for (i = 0; i < story.Length; i++)
            {
                //Link đến folder chứa tập truyện, thông tin của truyện, ảnh bìa...
                string link_folder_truyen = story[i];
                string link_infor_truyen = link_folder_truyen + "//" + "0.txt";
                Console.WriteLine(link_infor_truyen);
                string[] infor_truyen = File.ReadLines(link_infor_truyen).ToArray();
                //dòng đầu tiên trong file là tên truyện 
                string ten_truyen = story[i].Remove(0, link_story_folder.Length + 1);
                //dòng 3 là tên đăng nhập của tác giả (username)
                string ten_dang_nhap_tac_gia = infor_truyen[2];

                //Nếu cùng username với profile đang xem => truyện của người đó => hiển thị

                if (ten_dang_nhap_tac_gia == current_profile_uname)
                {


                    //dòng thứ 4 là tóm tắt truyện
                    string sum = infor_truyen[3];

                    string link_view_like_chapter_file = link_folder_truyen + "//" + "view_like_chapter_count.txt";
                    string[] count = File.ReadLines(link_view_like_chapter_file).ToArray();
                    string view_count = count[0];
                    string like_count = count[1];
                    string chapter_count = count[2];



                    //link ảnh bìa
                    string link_anh_bia = story[i] + "//" + ten_truyen + ".png";

                    var x = new UserControl_Story_on_Home(ten_truyen, ten_dang_nhap_tac_gia, view_count, like_count, chapter_count, sum, link_anh_bia);

                    //đặt tên cho user control chứa truyện là tên truyện
                    x.Name = ten_truyen;

                    //add event function click vào truyện
                    x.Click += story_click;

                    //Đổi cusor của control
                    x.Cursor = System.Windows.Forms.Cursors.Hand;

                    //add truyện
                    tableLayoutPanel1.Controls.Add(x);

                }


            }


            //Thêm những người mà bạn đang theo dõi vào (following)
            //Lấy tên các folder con trong đường dẫn
            string following_path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";

            string[] info = File.ReadAllLines(following_path);
            //Lấy ra số lượng người đang following
            int following = Int32.Parse(info[4]);
            //Thêm info của những người đang following vào tablelayoutpanel
            i = 5;
            
            for (i = 5; i < info.Length; i++)
            {
                string following_uname = info[i];

                string info2_path = "D://DoAn//user_profile_images//" + following_uname + ".txt";
                string[] info2 = File.ReadAllLines(info2_path);
                string following_name = info2[0];
                string story_count = info2[1];
                string follower_count = info2[3];
                string profile_img_path = "D://DoAn//user_profile_images//" + following_uname + ".jpg";


                var x = new profile_following(following_name, following_uname, story_count, follower_count);

                //đặt tên cho user control chứa truyện là tên truyện
                x.Name = following_uname;

                //add event function click vào truyện
                x.Click += new EventHandler(following_click);

                //Đổi cusor của control
                x.Cursor = System.Windows.Forms.Cursors.Hand;

                x.BackColor = Color.FromArgb(200, Color.Black);

                //add profile tóm tắt của người hiện đang theo dõi
                tableLayoutPanel2.Controls.Add(x);


            }
            
            
        }

        private void following_click(object sender, EventArgs e)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            profile_following y = (profile_following)sender;
            //click vào 1 user khác thì reset trang và bỏ thông tin của user đã click vào
            bool ismyprofile = (current_user_uname == y.Name.ToString());
            profile_page x = new profile_page(current_user_uname, y.Name.ToString(), ismyprofile);
            x.Show();
            this.Close();
        }

        private void story_click(object sender, EventArgs e)
        {
            UserControl_Story_on_Home x = (UserControl_Story_on_Home)sender;
            //sẽ click vào 1 user_control
            //Lấy tên truyện từ user control (là tên của user control đó)
            string ten_truyen = x.Name;
            //Lấy author user name trong file thông tin về truyện
            string link_to_story_info_file = "D://DoAn//Story//" + ten_truyen + "//0.txt";
            string[] story_info = File.ReadAllLines(link_to_story_info_file);
            string ten_dang_nhap_tac_gia = story_info[2];

            if (current_profile_uname != current_user_uname)
            {
                Reading y = new Reading(ten_truyen, ten_dang_nhap_tac_gia, current_user_uname);
                //y.RefToHome = this;
                if (this.WindowState == FormWindowState.Maximized)
                {
                    y.WindowState = FormWindowState.Maximized;
                }
                y.Show();
                this.Close();
                
            }
            else
            {
                Writing y = new Writing(story_info[0],story_info[1], current_user_uname);
                if (this.WindowState == FormWindowState.Maximized)
                {
                    y.WindowState = FormWindowState.Maximized;
                }
                y.Show();
                this.Close();
            }
            
        }

        private void but_follow_Click(object sender, EventArgs e)
        {
            if(but_follow.Text.ToString()=="Theo dõi")
            {
                but_follow.Text = "Đang theo dõi";
                //thêm username của user này vào tài khoản hiện tại
                string path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";
                string[] x = File.ReadAllLines(path);
                //Cộng số lượng người mà user này đang follow lên 1
                int following = Int32.Parse(x[4]);
                following += 1;
                x[4] = following.ToString();
                File.WriteAllLines(path, x);
                //Thêm username vào
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(current_profile_uname);
                }


                //Cộng số lượng follower cho người được follow
                path = "D://DoAn//user_profile_images//" + current_profile_uname + ".txt";
                x = File.ReadAllLines(path);
                int follower = Int32.Parse(x[3]);
                follower += 1;
                x[3] = follower.ToString();
                File.WriteAllLines(path, x);
            }
            else
            {
                but_follow.Text = "Theo dõi";
                //xóa username của user này vào tài khoản hiện tại
                string path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";
                string[] x = File.ReadAllLines(path);
                //Cộng số lượng người đang follow lên 1
                int following = Int32.Parse(x[4]);
                following -= 1;
                x[4] = following.ToString();

                //xóa username dó khỏi tên những người đang following
                x = x.Where(val => val != current_profile_uname).ToArray();

                File.WriteAllLines(path, x);


                //Trừ số lượng follower cho người được unfollow
                path = "D://DoAn//user_profile_images//" + current_profile_uname + ".txt";
                x = File.ReadAllLines(path);
                int follower = Int32.Parse(x[3]);
                follower -= 1;
                x[3] = follower.ToString();
                File.WriteAllLines(path, x);
            }
        }

        private void đangTheoDõiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = true;
            đangTheoDõiToolStripMenuItem.BackColor = Color.Black;
            truyệnCủaTôiToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            danhSáchĐọcToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
        }

        private void truyệnCủaTôiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            đangTheoDõiToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            truyệnCủaTôiToolStripMenuItem.BackColor = Color.Black;
            danhSáchĐọcToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
        }

        private void danhSáchĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            đangTheoDõiToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            truyệnCủaTôiToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            danhSáchĐọcToolStripMenuItem.BackColor = Color.Black;
        }

        private void pic_current_uname_Click(object sender, EventArgs e)
        {
            if (isMyProfile)
            {
                string uname_pass_path = "D://DoAn//username_password_saved.txt";
                string[] uname_pass = File.ReadLines(uname_pass_path).ToArray();
                int ind= Array.IndexOf(uname_pass, label4.Text.ToString());

                textBox1.Text = label7.Text.ToString();
                textBox_change_uname.Text= label4.Text.ToString();
                textBox_change_pass.Text = uname_pass[ind + 1];
                warning_name.Text = "";
                warning_pass.Text = "";
                warning_username.Text = "";
                panel_setting.Visible = true;
            }
            else
            {
                contextMenuStrip_profile_image.Show(pic_current_uname, new Point(0, 80));
            }
            
        }

        private void trangCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chuyển đến form trang cá nhân
            string path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";
            string current_user_name = File.ReadAllLines(path)[0];
            var x = new profile_page(current_user_name, current_user_uname, true);
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = new Form1("");
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void pic_back_home_Click(object sender, EventArgs e)
        {
            var x = new Form1(current_user_uname);
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string uname = textBox1.Text.ToString();
            if (uname.Length < 6)
            {
                warning_name.Text = "Tên đăng nhập phải có từ 6 ký tự trở lên";
            }
            else
            {
                warning_name.Text = "";
            }
            
        }

        private void textBox_change_uname_TextChanged(object sender, EventArgs e)
        {
            string uname_pass_path = "D://DoAn//username_password_saved.txt";
            string[] uname_pass = File.ReadLines(uname_pass_path).ToArray();
            string[] uname_arr = new string[100];
            string[] pass_arr = new string[100];
            int uname_count = 0;
            int pass_count = 0;
            //Chia username và pass ra 2 array
            int i = 0;
            for (i = 0; i < uname_pass.Length; i++)
            {
                if (i % 2 == 0)
                {
                    uname_arr[uname_count] = uname_pass[i];
                    uname_count += 1;
                }
                else
                {
                    pass_arr[pass_count] = uname_pass[i];
                    pass_count += 1;
                }
            }



            string uname = textBox_change_uname.Text.ToString();
            string current_uname = label4.Text.ToString(); 
            if (uname.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                warning_username.Text = "Tên đăng nhập không chứa ký tự đặc biệt";
            }
            else if (uname.Length < 6)
            {
                warning_username.Text = "Tên đăng nhập phải có từ 6 ký tự trở lên";
            }
            else if (uname_arr.Contains(uname) && uname!= current_uname)
            {
                warning_username.Text = "Tên đăng nhập đã được sử dụng" +
                    "";
            }
            else
            {
                warning_username.Text = "";
            }
        }

        private void textBox_change_pass_TextChanged(object sender, EventArgs e)
        {
            string pass = textBox_change_pass.Text.ToString();

            if (pass.Length < 6)
            {
                warning_pass.Text = "Mật khẩu phải có từ 6 ký tự trở lên";
            }
            else
            {
                warning_pass.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel_setting.Visible = false;
        }

        private void save_setting_Click(object sender, EventArgs e)
        {
            if (warning_username.Text.ToString() != "" || warning_pass.Text.ToString() != "" || warning_name.Text.ToString()!="")
            {
                MessageBox.Show("Vui lòng nhập lại", "Thông tin không hợp lệ", MessageBoxButtons.OK);
            }
            else
            {
                //Nếu không có điều kiện nào vi phạm => lưu thông tin mới lại
                string new_name = textBox1.Text.ToString();
                string new_uname = textBox_change_uname.Text.ToString();
                string new_pass= textBox_change_pass.Text.ToString();

                string info_path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";
                string[] x = File.ReadAllLines(info_path);
                x[0] = new_name;
                File.WriteAllLines(info_path, x);
                //Đổi tên file (do đã đổi username
                string new_info_path = "D://DoAn//user_profile_images//" + new_uname + ".txt";
                if (info_path != new_info_path)
                {
                    System.IO.Directory.Move(info_path, new_info_path);

                }
                //đổi tên file trong user_all_story
                info_path = "D://DoAn//user_all_story//" + current_user_uname+".txt";
                new_info_path = "D://DoAn//user_all_story//" + new_uname + ".txt";
                if (info_path != new_info_path)
                {
                    System.IO.Directory.Move(info_path, new_info_path);
                }
               
                //đổi username và pass trong file saved
                info_path = "D://DoAn//username_password_saved.txt";
                string[] y = File.ReadAllLines(info_path);
                int ind = Array.IndexOf(y, current_user_uname);
                y[ind] = new_uname;
                y[ind + 1] = new_pass;
                File.WriteAllLines(info_path, y);
                //Đổi name và username bị thay đổi trong tất cả file thông tin truyện của tác giả
                string story_path = "D://DoAn//Story";
                string all_story_name_path = "D://DoAn//user_all_story//" + new_uname + ".txt";
                string[] all_story_name = File.ReadAllLines(all_story_name_path);
                int i = 0;
                for (i = 0; i < all_story_name.Length; i++)
                {
                    info_path = story_path + "//" + all_story_name[i] + "//0.txt";
                    string[] z = File.ReadAllLines(info_path);
                    z[1] = new_name;
                    z[2] = new_uname;
                }

                //save ảnh đại diện mới + cập nhật ảnh đại diện
                string path1 = "D://DoAn//user_profile_images//" + current_user_uname + ".jpg";
                string path2 = "D://DoAn//user_profile_images//" + new_uname + ".jpg";

                File.Delete(path1);
                profile_image2.Image.Save(path2);
                Image im = GetCopyImage(path2);
                pic_profile_img.Image = im;
                pic_profile_img.SizeMode = PictureBoxSizeMode.StretchImage;
                

                //Cập nhật lại thông tin ở trang xem
                label7.Text = new_name;
                label4.Text = new_uname;

                //quay về chế độ xem
                panel_setting.Visible = false;

            }
        }

        private void profile_image2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                profile_image2.Image = Image.FromFile(fileOpen.FileName);
                profile_image2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            fileOpen.Dispose();
        }


        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
    }
}
