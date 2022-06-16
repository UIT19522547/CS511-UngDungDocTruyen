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
        string current_user_uname, au_uname,current_story_name;
        public Reading(string story_name,string author_user_name,string current_user_name)
        {
            InitializeComponent();

            dgvBookmark.Columns.Add("Chapter", "Tên chương");
            dgvBookmark.Columns.Add("Time", "Thời gian");
            dgvBookmark.Columns["Chapter"].Width = 250;
            dgvBookmark.Columns["Time"].Width = 175;
            pnlBookmark.Visible = false;

            pnlReading.Visible = false;
            current_user_uname = current_user_name;
            au_uname = author_user_name;
            dataGridView1.Visible = false;
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

            current_story_name = story_info[0];
            au_name.Text = story_info[1];
            au_username.Text = story_info[2];
            num_views.Text = story_info2[0];
            num_likes.Text = story_info2[1];
            num_chapters.Text = story_info2[2];
            lblTitle.Text = story_info[0];
            sum.Text = story_info[3];
            genre.Text = story_info[4];
            rating.Text = story_info[5];
            yeu_to_truong_thanh.Text = story_info[6];

            // số chương đã upload
            string[] uploadStatus = File.ReadAllLines(story_folder_link + "//upload_status.txt");
            int uploadCount = 0;
            foreach (string status in uploadStatus)
            {
                if (status == "true")
                {
                    uploadCount += 1;
                }
            }
            num_chapters.Text = uploadCount.ToString();



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
                Image im = GetCopyImage(current_profile_image_link);
                current_user_image.Image = im;
                current_user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Image im = GetCopyImage("D://DoAn//user_profile_images//default.jpg");
                current_user_image.Image = im;
                current_user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }


            //Thêm event handle
            trangCáNhânToolStripMenuItem.Click += trangCáNhânToolStripMenuItem_Click;
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;

            //
            //Load các chương vào datagridview
            DataTable x = new DataTable();
            x.Columns.Add("Bảng mục lục", typeof(string));
            //Lấy tên tất cả các chương trong file 0.txt (ta đã lấy dc tất cả thông tin thành mảng story_info) => giờ chỉ cần lọc ra
            //Tên các chương nếu có sẽ bắt đầu từ index 7
            if (story_info.Length > 7)
            {
                int count = 1;
                int j = 0;
                for (j = 7; j < story_info.Length; j++)
                {
                    string s = story_info[j];
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
            dataGridView1.CellClick += click_chapter;

        }

        private void click_chapter(Object sender, DataGridViewCellEventArgs e)
        {
            int ind = dataGridView1.CurrentCell.RowIndex;
            string path = "D://DoAn//Story//" + current_story_name + "//view_like_chapter_count.txt";
            string[] x = File.ReadAllLines(path);
            //Tăng số lượt đọc lên 1
            x[0] = (Int32.Parse(x[0]) + 1).ToString();
            File.WriteAllLines(path, x);

            //chuyển sang trang đọc chapter

        }

        private void current_user_image_Click(object sender, EventArgs e)
        {
            contextMenuStrip_profile_image.Show(current_user_image, new Point(0, 80));
        }

        private void home_Click(object sender, EventArgs e)
        {
            var x = new FormHome(current_user_uname);
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void cácChươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            cácChươngToolStripMenuItem.BackColor = Color.Black;
            tTTToolStripMenuItem.BackColor = Color.Transparent;
        }

        private void tTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            cácChươngToolStripMenuItem.BackColor = Color.Black;
            tTTToolStripMenuItem.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string chapter = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string i = "1";
            if (chapter.Length < 9)
            {
                i = chapter.Substring(7, 1);
            }
            else
            {
                i = chapter.Substring(7, 2);
            }
            //Chuyển sang trang đọc chương truyện cụ thể


        }

        private void au_name_Click(object sender, EventArgs e)
        {
            var x = new profile_page(current_user_uname, au_uname, (current_user_uname == au_uname));
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void trangCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chuyển đến form trang cá nhân
            string path = "D://DoAn//user_profile_images//" + current_user_uname + ".txt";
            string current_user_name = File.ReadAllLines(path)[0];
            var x = new profile_page(current_user_uname, current_user_uname, true);
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = new FormHome("");
            if (this.WindowState == FormWindowState.Maximized)
            {
                x.WindowState = FormWindowState.Maximized;
            }
            x.Show();
            this.Close();
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        //panel đọc truyện
        string[] chapterStories;
        private void btnRead_Click(object sender, EventArgs e)
        {
            string bookTitle = lblTitle.Text;
            string bookPath = "D:\\DoAn\\Story\\" + bookTitle + "\\";

            //tăng lượt view của truyện lên 1
            string[] viewLikeChapterInfo = File.ReadAllLines(bookPath + "view_like_chapter_count.txt");
            viewLikeChapterInfo[0] = (int.Parse(viewLikeChapterInfo[0]) + 1).ToString();
            File.WriteAllLines(bookPath + "view_like_chapter_count.txt", viewLikeChapterInfo);


            // load thông tin truyện vào panel

            lblBookName.Text = bookTitle;
            string[] bookInfo = File.ReadAllLines(bookPath + "0.txt");
            cbbChapters.Items.Clear();
            string[] uploadStatus = File.ReadAllLines(bookPath + "upload_status.txt");

            if (bookInfo.Length > 7)
            {
                cbbChapters.Text = bookInfo[7];
            }
            else return;

            pnlReading.Visible = true;

            int k = 0, uploadCount = 0;
            for (int i = 0; i < uploadStatus.Length; i++)
            {
                if (uploadStatus[i] == "true" && i + 7 < bookInfo.Length)
                    cbbChapters.Items.Add(bookInfo[i + 7]);
                k++; uploadCount++;
            }

            chapterStories = new string[uploadCount];
            k = 0;
            for (int i = 0; i < uploadStatus.Length; i++)
            {
                if (uploadStatus[i] == "true" && k < chapterStories.Length)
                {
                    chapterStories[k] = File.ReadAllText(bookPath + (i + 1).ToString() + ".txt");
                    k++;
                }
            }

            LoadBookData(lblTitle.Text, 0);
        }
        void LoadBookData(string bookTitle, int chapterIndex)
        {
            lblChapterName.Text = cbbChapters.Text;
            if (chapterIndex >=0 && chapterIndex < chapterStories.Length)
                rtbStory.Text = chapterStories[chapterIndex];
            else
                rtbStory.Text = chapterStories[0];

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // load lượt view của truyện
            string bookTitle = lblTitle.Text;
            string bookPath = "D:\\DoAn\\Story\\" + bookTitle + "\\";
            string[] viewLikeChapterInfo = File.ReadAllLines(bookPath + "view_like_chapter_count.txt");
            num_views.Text = viewLikeChapterInfo[0];

            pnlReading.Visible = false;
            cbbChapters.Text = String.Empty;
        }

        private void cbbChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int chapterIndex = cbbChapters.SelectedIndex;
            LoadBookData(lblTitle.Text, chapterIndex);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (cbbChapters.SelectedIndex <= 0) return;
            cbbChapters.SelectedIndex -= 1;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbbChapters.SelectedIndex >= cbbChapters.Items.Count - 1) return;
            cbbChapters.SelectedIndex += 1;
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            if (current_user_uname == "") return;
            string bookmarkPath = "D:\\DoAn\\bookmark\\" + current_user_uname;
            if (!Directory.Exists(bookmarkPath)) Directory.CreateDirectory(bookmarkPath);
            string markedChaptersPath = bookmarkPath + "\\" + lblBookName.Text + ".txt";
            if (!File.Exists(markedChaptersPath)) File.Create(markedChaptersPath).Close();

            string currentChapter = cbbChapters.Text;
            string[] markedChapetersInfo = File.ReadAllLines(markedChaptersPath);
            for (int i=0; i<markedChapetersInfo.Length; i++)
            {
                string markedChapter = markedChapetersInfo[i].Split(',')[0];
                if (markedChapter == currentChapter)
                {
                    markedChapetersInfo[i] = "-";
                    break;
                }  
            }

            File.WriteAllText(markedChaptersPath, String.Empty);
            StreamWriter sr = new StreamWriter(markedChaptersPath, true);
            foreach(string line in markedChapetersInfo)
            {
                if (line != "-")
                    sr.WriteLine(line);              
            }
            sr.WriteLine(currentChapter + "," + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
            sr.Close();

            LoadBookmark();
        }        

        private void btnBookmark_Click(object sender, EventArgs e)
        {
            if (pnlBookmark.Visible) pnlBookmark.Visible = false;
            else
            {
                if (current_user_uname != "")
                {
                    LoadBookmark();
                }               
                pnlBookmark.Visible = true;
            }

        }      

        void LoadBookmark()
        {
            string bookmarkPath = "D:\\DoAn\\bookmark\\" + current_user_uname;
            if (!Directory.Exists(bookmarkPath)) Directory.CreateDirectory(bookmarkPath);
            string markedChaptersPath = bookmarkPath + "\\" + lblBookName.Text + ".txt";
            if (!File.Exists(markedChaptersPath)) File.Create(markedChaptersPath).Close();

            string[] markedChapetersInfo = File.ReadAllLines(markedChaptersPath);
            dgvBookmark.Rows.Clear();
            for (int i = markedChapetersInfo.Length - 1; i >= 0; i--)
            {
                string[] row = markedChapetersInfo[i].Split(',');
                dgvBookmark.Rows.Add(row[0], row[1]);
            }
        }

        private void Reading_Load(object sender, EventArgs e)
        {

        }

        private void btnContinueRead_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvBookmark.CurrentCell.RowIndex;
            if (rowIndex < 0) return;

            string chapterName = dgvBookmark.Rows[rowIndex].Cells[0].Value.ToString();
            lblChapterName.Text = chapterName;
            cbbChapters.Text = chapterName;
            LoadBookData(lblBookName.Text, cbbChapters.Items.IndexOf(chapterName));
        }

        private void btnDeleteBookmark_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvBookmark.CurrentCell.RowIndex;
            if (rowIndex < 0) return;

            string chapterName = dgvBookmark.Rows[rowIndex].Cells[0].Value.ToString();

            string bookmarkPath = "D:\\DoAn\\bookmark\\" + current_user_uname;
            if (!Directory.Exists(bookmarkPath)) Directory.CreateDirectory(bookmarkPath);
            string markedChaptersPath = bookmarkPath + "\\" + lblBookName.Text + ".txt";
            if (!File.Exists(markedChaptersPath)) File.Create(markedChaptersPath).Close();

            string[] markedChapetersInfo = File.ReadAllLines(markedChaptersPath);
            File.WriteAllText(markedChaptersPath, String.Empty);
            StreamWriter sr = new StreamWriter(markedChaptersPath, true);
            foreach (string line in markedChapetersInfo)
            {
                if (line.Split(',')[0] != chapterName)
                    sr.WriteLine(line);
            }
            sr.Close();
            LoadBookmark();
        }

    }
}
