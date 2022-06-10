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
        public Writing(string story_name,string current_user_name,string current_user_username)
        {
            InitializeComponent();

            dataGridView1.Visible = false;
            current_user_name_ = current_user_name;
            current_user_uname_ = current_user_username;
            cácChươngToolStripMenuItem.Visible = false;

            //Load ảnh mũi tên quay lại
            btnBackToMyStory.Load("D://DoAn//Image//back2.png");
            btnBackToMyStory.SizeMode = PictureBoxSizeMode.StretchImage;
            tableLayoutPanel3.BackColor= Color.FromArgb(200, Color.Black);
            panel6.BackColor = Color.FromArgb(200, Color.Black);
            write_new_menu.BackColor = Color.FromArgb(200, Color.Black);
            tTTToolStripMenuItem.BackColor = Color.Black;
            cácChươngToolStripMenuItem.BackColor= Color.FromArgb(200, Color.Black);

            //Nếu story_name="" /rỗng tức là viết truyện mới => k cần làm gì cả
            //Nếu ngược lại là viết tiếp 1 truyện nào đó => load thông tin của truyện vào nơi viết để viết tiếp
            if (story_name != "")
            {
                create_ok.Visible = false;
                cácChươngToolStripMenuItem.Visible = true;
                string story_folder_path = "D://DoAn//Story//" + story_name;
                string story_info_path = story_folder_path + "//0.txt";
                string[] info = File.ReadAllLines(story_info_path, Encoding.UTF8);


                //richTextBox2.LoadFile(story_info_path, RichTextBoxStreamType.PlainText);
                textBox1.Text = info[0];
                textBox1.Text = textBox1.Text;
                label8.Text = info[0];
                textBox2.AutoSize = false;
                textBox2.ScrollBars = ScrollBars.Vertical;
                textBox2.Size = new System.Drawing.Size(470, 95);
                textBox2.Text = info[3];
                textBox3.Text = info[4];
                comboBox1.Text = info[5];
                checkBox1.Text = info[6];
                if (info[6] == "Có")
                {
                    checkBox1.Checked = true;
                }

                string cover_link = story_folder_path + "//" + story_name + ".png";
                cover_image.Load(cover_link);
                cover_image.SizeMode = PictureBoxSizeMode.StretchImage;

                //Load các chương vào datagridview
                DataTable x = new DataTable();
                x.Columns.Add("Bảng mục lục", typeof(string));
                //Lấy tên tất cả các chương trong file 0.txt (ta đã lấy dc tất cả thông tin thành mảng story_info) => giờ chỉ cần lọc ra
                //Tên các chương nếu có sẽ bắt đầu từ index 7
                if (info.Length > 7)
                {
                    int count = 1;
                    int j = 0;
                    for (j = 7; j < info.Length; j++)
                    {
                        string s = info[j];
                        if (s.Length < 4)
                        {
                            x.Rows.Add("Chương " + count.ToString());
                        }
                        else
                        {
                            x.Rows.Add("Chương " + count.ToString() + ": " + s.Substring(3, s.Length - 3));
                        }
                        count += 1;
                    }
                }

                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 14);
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                this.dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                this.dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

                dataGridView1.DataSource = x;
                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 580;
            }

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
            if (txt.ToLower() == "không")
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
            if (textBox1.Text.ToString() == "")
            {
                MessageBox.Show("Tiêu đề trống", "Vui lòng nhập tiêu đề", MessageBoxButtons.OK);
            }
            else if (textBox3.Text.ToString() == "")
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
                string story_path = "D://DoAn//Story//"+ textBox1.Text.ToString();
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

                    //xóa ảnh bìa (cùng tên với ảnh bìa mới/nếu có)
                    string path = story_path + "//" + textBox1.Text.ToString() + ".png";
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    //lưu ảnh bìa mới
                    cover_image.Image.Save(story_path+"//"+textBox1.Text.ToString()+".png");

                    //Nếu mô tả trống, cho nó là 1 hàng trống
                    if (textBox2.Text.ToString() == "")
                    {
                        textBox2.Text = "\n";
                    }

                    //Lưu các thông tin khác
                    string[] info =
                    {
                        textBox1.Text.ToString(),
                        current_user_name_,
                        current_user_uname_,
                        textBox2.Text.ToString(),
                        textBox3.Text.ToString(),
                        comboBox1.Text.ToString(),
                        checkBox1.Text.ToString()
                    };
                    string info_path = story_path + "//0.txt";
                    File.WriteAllLines(info_path, info);
                    //Cộng số lượng tác phẩm của tác giả lên 1
                    path = "D://DoAn//user_profile_images//" + current_user_uname_ + ".txt";
                    string[] y = File.ReadAllLines(path);
                    y[1] = (Int32.Parse(y[1]) + 1).ToString();
                    File.WriteAllLines(path, y);
                    //Thêm tên tác phẩm vào nơi tổng hợp tất cả các tác phẩm của tác giả
                    path = "D://DoAn//user_all_story//" + current_user_uname_ + ".txt";
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(textBox1.Text.ToString());
                    }


                    //Chuyển sang viết truyện (tập 1)

                }

            }
            

        }

        private void but_back_home_Click(object sender, EventArgs e)
        {

        }

        private void cácChươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            cácChươngToolStripMenuItem.BackColor = Color.Black;
            tTTToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
        }

        private void tTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            cácChươngToolStripMenuItem.BackColor = Color.FromArgb(200, Color.Black);
            tTTToolStripMenuItem.BackColor = Color.Black;
        }

        private void btnBackToMyStory_Click(object sender, EventArgs e)
        {

        }
    }
}
