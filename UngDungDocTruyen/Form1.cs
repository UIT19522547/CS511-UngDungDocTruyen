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
using static UngDungDocTruyen.LoginSignup;
using static UngDungDocTruyen.Reading;
//using System.Threading.Tasks;

namespace UngDungDocTruyen
{
    public partial class Form1 : Form
    {
        string link_story_folder = "D://DoAn//Story";
        bool already_login = false;
        string current_user_user_name = "";
        string current_field = "Tác phẩm";
        int[] index = Enumerable.Range(0, 14).ToArray();

        public Form1(string current_user_uname)
        {
            InitializeComponent();

            tableLayoutPanel2.Visible = false;
            menuStrip1.BackColor = Color.FromArgb(200, Color.Black);
            menuStrip1.ForeColor = Color.White;
            tácPhẩmToolStripMenuItem.BackColor = Color.Black;
            //Ẩn đi picturebox chứa ảnh user do chưa đăng nhập, chỉ hiển thị từ đăng nhập. 
            //Sau khi đăng nhập mới hiển thị ảnh user và ẩn button đăng nhập
            //user_image.Visible = false;

            //Load ảnh vào các PictureBox
            home.Load("D://DoAn//Image//homeIcon4.png");
            home.SizeMode = PictureBoxSizeMode.StretchImage;
            Image im = GetCopyImage("D://DoAn//Image//pika.jpg");
            profile_image.Image = im;
            profile_image.SizeMode = PictureBoxSizeMode.StretchImage;
            

            //panel_write_new.Visible = false;

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
                tableLayoutPanel1.BackColor= Color.FromArgb(200, Color.Black);
                contextMenuStrip_profile_image.ForeColor = Color.YellowGreen;
                



            }

            //Xáo index để truyện xuất hiện random không giống nhau
            Random random = new Random();
            index = index.OrderBy(x => random.Next()).ToArray();
            //Lấy tên các folder con trong đường dẫn
            string[] story = Directory.GetDirectories(link_story_folder);
            //Thêm truyện vào tablelayoutpanel
            int i = 0;
            for (i = 0; i < 9; i++)
            {
                int ind = index[i];
                //Link đến folder chứa tập truyện, thông tin của truyện, ảnh bìa...
                string link_folder_truyen = story[ind];
                string link_infor_truyen = link_folder_truyen + "//" + "0.txt";
                Console.WriteLine(link_infor_truyen);
                string[] infor_truyen= File.ReadLines(link_infor_truyen).ToArray();
                //dòng đầu tiên trong file là tên truyện 
                string ten_truyen = story[ind].Remove(0, link_story_folder.Length+1);
                //dòng 2 là tên đăng nhập của tác giả (username)
                string ten_dang_nhap_tac_gia = infor_truyen[2];
                //dòng thứ 3 là tóm tắt truyện
                string sum = infor_truyen[3];

                string link_view_like_chapter_file = link_folder_truyen + "//" + "view_like_chapter_count.txt";
                string[] count = File.ReadLines(link_view_like_chapter_file).ToArray();
                string view_count = count[0];
                string like_count = count[1];
                string chapter_count = count[2];

                

                //link ảnh bìa
                string link_anh_bia = story[ind] + "//" + ten_truyen + ".png";

                var x = new UserControl_Story_on_Home(ten_truyen, ten_dang_nhap_tac_gia, view_count, like_count, chapter_count,sum,link_anh_bia);

                //đặt tên cho user control chứa truyện là tên truyện
                x.Name = ten_truyen;

                //add event function click vào truyện
                x.Click += story_click;

                //Đổi cusor của control
                x.Cursor = System.Windows.Forms.Cursors.Hand;

                //add truyện
                tableLayoutPanel_story.Controls.Add(x);

                
            }

            //Thêm event khi bấm vào thểm loại
            foreach (ToolStripMenuItem toolItem in type_book.Items)
            {
                foreach (ToolStripMenuItem children in toolItem.DropDownItems)
                {
                    children.Click += filter_type;
                }
            }

            //Nếu đã đăng nhập 
            if (current_user_uname != "")
            {
                already_login = true;
                current_user_user_name = current_user_uname;
                string profile_img_path = "D://DoAn//user_profile_images//" + current_user_user_name + ".jpg";
                im = GetCopyImage(profile_img_path);
                profile_image.Image = im;
                profile_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }


            //Thêm những người mà bạn đang theo dõi vào (following)
            //Lấy tên các folder con trong đường dẫn
            string following_path = "D://DoAn//user_all_story";

            string[] info = Directory.GetFiles(following_path);
            //Thêm info của những người đang following vào tablelayoutpanel
            i = 0;

            for (i = 0; i < info.Length; i++)
            {
                string following_uname = Path.GetFileName(info[i]);
                following_uname = following_uname.Substring(0, following_uname.Length - 4);

                string info2_path = "D://DoAn//user_profile_images//" + following_uname+".txt";
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

        private void filter_type(object sender, EventArgs e)
        {
            tableLayoutPanel_story.RowStyles.Clear();
            tableLayoutPanel_story.Controls.Clear();

            ToolStripMenuItem toolItem = (ToolStripMenuItem)sender;
            string type_have_to_filter = toolItem.Text.ToString();
            Console.WriteLine("AAA" + type_have_to_filter);

            string[] story = Directory.GetDirectories(link_story_folder);
            int i = 0;
            string path;
            for (i = 0; i < story.Length; i++)
            {
                path = story[i]+"//0.txt";
                string[] x = File.ReadAllLines(path);
                string type = x[4];
                string ten_truyen = story[i].Remove(0, link_story_folder.Length + 1);
                //Nếu tên truyện chứa chuỗi tìm kiếm nhập vào thì add truyện vào tablelayoutpanel 
                if (type.ToLower().Contains(type_have_to_filter.ToLower()))
                {


                    //Link đến folder chứa tập truyện, thông tin của truyện, ảnh bìa...
                    string link_folder_truyen = story[i];
                    string link_infor_truyen = link_folder_truyen + "//" + "0.txt";
                    Console.WriteLine(link_infor_truyen);
                    string[] infor_truyen = File.ReadLines(link_infor_truyen).ToArray();
                    //dòng 2 là tên đăng nhập của tác giả (username)
                    string ten_dang_nhap_tac_gia = infor_truyen[2];
                    //dòng thứ 3 là tóm tắt truyện
                    string sum = infor_truyen[3];

                    string link_view_like_chapter_file = link_folder_truyen + "//" + "view_like_chapter_count.txt";
                    string[] count = File.ReadLines(link_view_like_chapter_file).ToArray();
                    string view_count = count[0];
                    string like_count = count[1];
                    string chapter_count = count[2];



                    //link ảnh bìa
                    string link_anh_bia = story[i] + "//" + ten_truyen + ".png";

                    var y = new UserControl_Story_on_Home(ten_truyen, ten_dang_nhap_tac_gia, view_count, like_count, chapter_count, sum, link_anh_bia);

                    //đặt tên cho user control chứa truyện là tên truyện
                    y.Name = ten_truyen;

                    //add event function click vào truyện
                    y.Click += story_click;

                    //Đổi cusor của control
                    y.Cursor = System.Windows.Forms.Cursors.Hand;

                    //add truyện
                    tableLayoutPanel_story.Controls.Add(y);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void load_cover_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                //cover_image.Image = Image.FromFile(fileOpen.FileName);
            }
            fileOpen.Dispose();
        }

        private void write_new_Click(object sender, EventArgs e)
        {
            string path = "D://DoAn//user_profile_images//" + current_user_user_name + ".txt";

            if (already_login)
            {
                string current_user_name = File.ReadAllLines(path)[0];
                Writing x = new Writing("", current_user_name, current_user_user_name);
                if (this.WindowState == FormWindowState.Maximized)
                {
                    x.WindowState = FormWindowState.Maximized;
                }
                this.Hide();
                x.Show();
            }
            

        }

        string current_user_name_link = "D://DoAn//current_user_name.txt";
        bool login_close = true;

        
        private void login_button_Click(object sender, EventArgs e)
        {
            login_close = false;
            var x = new LoginSignup();
            x.ShowDialog();

            string[] info = File.ReadAllLines(current_user_name_link);
            if (info[0] == "true")
            {
                already_login = true;
                current_user_user_name = info[1];
                login_button.Visible = false;
                //Nếu đã login thì load ảnh từ folder user profile image lên (ảnh đại diện)
                string link_anh_dai_dien = "D://DoAn//user_profile_images//" + current_user_user_name + ".jpg";
                Image im = GetCopyImage(link_anh_dai_dien);
                profile_image.Image = im;
                profile_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        

        private void my_story_Click(object sender, EventArgs e)
        {
            if (already_login)
            {
                var x = new profile_page(current_user_user_name,current_user_user_name,true);
                if (this.WindowState == FormWindowState.Maximized)
                {
                    x.WindowState = FormWindowState.Maximized;
                }
                x.Show();
            }
        }

        private void user_image_Click(object sender, EventArgs e)
        {
            this.Hide();
            var x = new profile_page(current_user_user_name, current_user_user_name, true);
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
        }

        private void profile_image_Click(object sender, EventArgs e)
        {
            contextMenuStrip_profile_image.Show(profile_image,new Point(0,80));
        }

        private void trangCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chuyển đến form trang cá nhân
            //profile_image.Image.Dispose();
            profile_image.BackgroundImage.Dispose();
            profile_image.Image = null;
            profile_image.BackgroundImage = null;
            var x = new profile_page(current_user_user_name, current_user_user_name, true);
            x.RefToHome = this;
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Hide();
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
            Reading y = new Reading(ten_truyen,ten_dang_nhap_tac_gia,current_user_user_name);
            y.RefToHome = this;
            if (this.WindowState == FormWindowState.Maximized)
            {
                y.WindowState = FormWindowState.Maximized;
            }
            y.Show();
            this.Hide();
        }

        private void reset_home()
        {
            tableLayoutPanel_story.RowStyles.Clear();
            tableLayoutPanel_story.Controls.Clear();
            //Lấy tên các folder con trong đường dẫn
            string[] story = Directory.GetDirectories(link_story_folder);
            //Thêm truyện vào tablelayoutpanel
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                //Link đến folder chứa tập truyện, thông tin của truyện, ảnh bìa...
                string link_folder_truyen = story[i];
                string link_infor_truyen = link_folder_truyen + "//" + "0.txt";
                Console.WriteLine(link_infor_truyen);
                string[] infor_truyen = File.ReadLines(link_infor_truyen).ToArray();
                //dòng đầu tiên trong file là tên truyện 
                string ten_truyen = story[i].Remove(0, link_story_folder.Length + 1);
                //dòng 2 là tên đăng nhập của tác giả (username)
                string ten_dang_nhap_tac_gia = infor_truyen[2];
                //dòng thứ 3 là tóm tắt truyện
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
                tableLayoutPanel_story.Controls.Add(x);


            }

        }

        private void search_story(object sender, KeyEventArgs e)
        {
            //Chỉ mới có chức năng search theo tên truyện
            if (e.KeyCode == Keys.Enter)
            {
                string have_to_search = textBox1.Text.ToString();
                if (current_field=="Tác phẩm")
                {
                    tableLayoutPanel_story.RowStyles.Clear();
                    tableLayoutPanel_story.Controls.Clear();
                    int i = 0;
                    //Lấy tên các folder con trong đường dẫn (tên truyện)
                    string[] story = Directory.GetDirectories(link_story_folder);
                    int num_of_stories = story.Length;
                    for (i = 0; i < num_of_stories; i++)
                    {
                        //dòng đầu tiên trong file là tên truyện 
                        string ten_truyen = story[i].Remove(0, link_story_folder.Length + 1);
                        //Nếu tên truyện chứa chuỗi tìm kiếm nhập vào thì add truyện vào tablelayoutpanel 
                        if (ten_truyen.ToLower().Contains(have_to_search.ToLower()))
                        {


                        //Link đến folder chứa tập truyện, thông tin của truyện, ảnh bìa...
                        string link_folder_truyen = story[i];
                        string link_infor_truyen = link_folder_truyen + "//" + "0.txt";
                        Console.WriteLine(link_infor_truyen);
                        string[] infor_truyen = File.ReadLines(link_infor_truyen).ToArray();
                        //dòng 2 là tên đăng nhập của tác giả (username)
                        string ten_dang_nhap_tac_gia = infor_truyen[2];
                        //dòng thứ 3 là tóm tắt truyện
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
                        tableLayoutPanel_story.Controls.Add(x);
                        }


                    }
                }

                else if(current_field == "Tác giả")
                {
                    //Thêm những người mà bạn đang theo dõi vào (following)
                    //Lấy tên các folder con trong đường dẫn
                    string following_path = "D://DoAn//user_all_story";

                    string[] info = Directory.GetFiles(following_path);
                    //Thêm info của những người đang following vào tablelayoutpanel
                    tableLayoutPanel2.RowStyles.Clear();
                    tableLayoutPanel2.Controls.Clear();
                    int i = 0;

                    for (i = 0; i < info.Length; i++)
                    {
                        string following_uname = Path.GetFileName(info[i]);
                        following_uname = following_uname.Substring(0, following_uname.Length - 4);
                        string info2_path = "D://DoAn//user_profile_images//" + following_uname + ".txt";
                        string[] info2 = File.ReadAllLines(info2_path);
                        string following_name = info2[0];

                        if (following_uname.ToLower().Contains(have_to_search.ToLower()) || following_name.ToLower().Contains(have_to_search.ToLower()))
                        {
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
                }

                else if(current_field=="Danh sách đọc")
                {

                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login_button.Visible = true;
            already_login = false;
            current_user_user_name = "";
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        
        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_field = "Tác giả";
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel_story.Visible = false;
            tácPhẩmToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            danhSáchĐọcToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            tácGiảToolStripMenuItem.BackColor = Color.Black;
            
            
        }

        private void following_click(object sender, EventArgs e)
        {
            profile_following y = (profile_following)sender;
            //click vào 1 user khác thì reset trang và bỏ thông tin của user đã click vào
            bool ismyprofile = (current_user_user_name == y.Name.ToString());
            profile_page x = new profile_page(current_user_user_name, y.Name.ToString(), ismyprofile);
            x.Show();
            this.Hide();
        }

        private void tácPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_field = "Tác phẩm";
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel_story.Visible = true;
            tácPhẩmToolStripMenuItem.BackColor = Color.Black;
            danhSáchĐọcToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            tácGiảToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
        }

        private void danhSáchĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current_field = "Danh sách đọc";
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel_story.Visible = false;
            tácPhẩmToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            danhSáchĐọcToolStripMenuItem.BackColor = Color.Black;
            tácGiảToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
        }
    }
}
