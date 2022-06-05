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
    public partial class Writing : Form
    {
        public Form RefToHome { get; set; }
        string current_user_name_;
        string current_user_uname_;
        public Writing(string current_user_name,string current_user_username)
        {
            InitializeComponent();

            current_user_name_ = current_user_name;
            current_user_uname_ = current_user_username;
            cácChươngToolStripMenuItem.Visible = false;

            //Load ảnh mũi tên quay lại
            but_back_home.Load("D://DoAn//Image//back2.png");
            but_back_home.SizeMode = PictureBoxSizeMode.StretchImage;
            tableLayoutPanel3.BackColor= Color.FromArgb(200, Color.Black);
            panel6.BackColor = Color.FromArgb(200, Color.Black);
            write_new_menu.BackColor = Color.FromArgb(200, Color.Black);

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

        private void create_ok_Click(object sender, EventArgs e)
        {
            //Lưu các thông tin trang bìa đã nhập
            //Điều kiện: tiêu đề, thể loại, độ tuổi độc giả không trống
            if (richTextBox1.Text.ToString() == "")
            {
                MessageBox.Show("Tiêu đề trống", "Vui lòng nhập tiêu đề", MessageBoxButtons.OK);
            }
            else if (comboBox.Text.ToString() == "Thể loại chính")
            {
                MessageBox.Show("Thể loại trống", "Vui lòng chọn thể loại", MessageBoxButtons.OK);
            }
            else if(comboBox1.Text== "Độ tuổi độc giả chính")
            {
                MessageBox.Show("Độ tuổi trống", "Vui lòng chọn độ tuổi độc giả", MessageBoxButtons.OK);
            }
            else
            {
                //Không có vấn đề => lưu thông tin truyện đã nhập
                string story_path = "D://DoAn//Story//"+ richTextBox1.Text.ToString();
                //Tạo folder truyện
                if (Directory.Exists(story_path))
                {
                    MessageBox.Show("Tiêu đề đã tồn tại", "Vui lòng nhập tiêu đề", MessageBoxButtons.OK);
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(story_path);
                    //tạo file view_like_chapter_count
                    string[] x = { "0", "0", "1" };
                    //Số tập là 1 vì khi tạo truyện thành công => tự động tạo bản thảo của tập 1
                    File.WriteAllLines(story_path + "//view_like_chapter_count.txt", x);

                    //lưu ảnh bìa
                    cover_image.Image.Save(story_path+"//"+richTextBox1.Text.ToString()+".jpg");

                    //Nếu mô tả trống, cho nó là 1 hàng trống
                    if (richTextBox2.Text.ToString() == "")
                    {
                        richTextBox2.Text = "\n";
                    }

                    //Lưu các thông tin khác
                    string[] info =
                    {
                        richTextBox1.Text.ToString(),
                        current_user_name_,
                        current_user_uname_,
                        richTextBox2.Text.ToString(),
                        comboBox.Text.ToString(),
                        comboBox1.Text.ToString(),
                        checkBox1.Text.ToString()
                    };
                    string info_path = story_path + "//0.txt";
                    File.WriteAllLines(info_path, info);

                    //Chuyển sang viết truyện (tập 1)

                }

            }

        }

        private void but_back_home_Click(object sender, EventArgs e)
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
