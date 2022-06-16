using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungDocTruyen
{
    public partial class Writing : Form
    {
        string userName;
        string authorName;
        public Writing(string currentAuthor, string currentUserName)
        {
            InitializeComponent();
            userName = currentUserName;
            authorName = currentAuthor;

            LoadAllBookInfo();
            dgvChapters.Columns.Add("Chapters", "Các chương");
            dgvChapters.Columns.Add("Status", "Tình trạng");
            dgvChapters.Columns["Chapters"].Width = 300;
            dgvChapters.Columns["Status"].Width = 150;

            tlpMyBook.RowCount = 0;
            tlpMyBook.RowStyles.Clear();
            pnlBookInfo.Visible = false;

            tsmiBookInfo.ForeColor = Color.GreenYellow;
            tấtCảTruyệnToolStripMenuItem.ForeColor = Color.GreenYellow;
            pnlChapters.Visible = false;

            pnlWrite.Visible = false;


            //load ảnh current user (tài khoản đang đăng nhập)/nếu có
            if (currentUserName != "")
            {
                string profileImagePath = "D://DoAn//user_profile_images//" + currentUserName + ".jpg"; 
                current_user_image.Image = GetCopyImage(profileImagePath);
                current_user_image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        void LoadAllBookInfo()
        {
            tlpMyBook.Controls.Clear();
            tlpMyBook.RowStyles.Clear();
            tlpMyBook.RowCount = 0;

            string allBooksPath = "D:\\DoAn\\user_all_story\\" + userName + ".txt";
            StreamReader allBooks = new StreamReader(allBooksPath);

            string book;
            while((book = allBooks.ReadLine()) != null)
            {
                string bookPath = "D:\\DoAn\\Story\\" + book + "\\";
                StreamReader countInfo = new StreamReader(bookPath + "view_like_chapter_count.txt");

                string[] stringSeparators = new string[] { "\r\n" };
                string[] counts = countInfo.ReadToEnd().Split(stringSeparators, StringSplitOptions.None);
                int view = int.Parse(counts[0]), like = int.Parse(counts[1]), chapter = int.Parse(counts[2]);
                countInfo.Close();


                StreamReader uploadInfo = new StreamReader(bookPath + "upload_status.txt");
                string[] uploads = uploadInfo.ReadToEnd().Split(stringSeparators, StringSplitOptions.None);
                uploadInfo.Close();

                int draftCount = 0, uploadCount = 0;
                foreach (string upload in uploads)
                {
                    if (upload == "true") uploadCount += 1;
                    else if (upload == "false") draftCount += 1;
                }
                string imagePath = bookPath + book + ".png";

                string update = "";
                if (File.Exists(bookPath + "\\last_update.txt"))
                {
                    string[] updateInfo = File.ReadAllLines(bookPath + "\\last_update.txt");
                    update = updateInfo[0];
                }
                else
                {
                    File.Create(bookPath + "\\last_update.txt").Close();
                    StreamWriter sr = new StreamWriter(bookPath + "\\last_update.txt");
                    update = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                    sr.WriteLine(update);
                    sr.Close();
                }    
                

                UserControl_MyBook newBookControl = new UserControl_MyBook(imagePath, book, draftCount, uploadCount, update, view, like, chapter);
                newBookControl.TitleClick += new EventHandler(BookClick);
                newBookControl.ContinueClick += new EventHandler(ContinueClick);
                newBookControl.DeleteClick += new EventHandler(DeleteClick);

                tlpMyBook.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
                tlpMyBook.Controls.Add(newBookControl, 0, tlpMyBook.RowCount);
                tlpMyBook.RowCount += 1;

            }
            allBooks.Close();

        }

        private Image GetCopyImage(string path)
        {
            Image img = Image.FromFile(path);
            Bitmap bm = new Bitmap(img);
            img.Dispose();
            return bm;
        }

        void ShowBookInfoPanel(bool showPanel, string bookTitle = "", bool isContinue = false)
        { 
            if (showPanel)
            {              
                if (bookTitle == "")
                {
                    lblBook.Text = "Truyện chưa có tiêu đề";
                    btnCreateBook.Text = "Tạo truyện";

                    picCoverImage.BackgroundImage = GetCopyImage("D:\\DoAn\\Image\\cover_default.jpg");
                    
                    tbTitle.Clear(); tbTitle.ReadOnly = false;
                    tbAuthor.Text = authorName;
                    tbDescription.Clear();
                    tbGenre.Clear();
                    cbbAge.Text = "Độ tuổi độc giả chính";
                    ckbAdult.Checked = false;

                    tsmiBookInfo.Visible = true;
                    tsmiBookInfo.ForeColor = Color.YellowGreen;
                    tsmiChapters.Visible = false;
                    pnlChapters.Visible = false;
                }
                else
                {
                    lblBook.Text = bookTitle; currentTitle = bookTitle;
                    btnCreateBook.Text = "Lưu";

                    string bookPath = "D:\\DoAn\\Story\\" + bookTitle;
                    picCoverImage.BackgroundImage = GetCopyImage(bookPath + "\\" + bookTitle + ".png");


                    // load thông tin truyện
                    string[] bookInfo = File.ReadAllLines(bookPath + "\\0.txt");
                    tbTitle.Text = bookInfo[0]; //tbTitle.ReadOnly = true;
                    tbAuthor.Text = bookInfo[1];
                    tbDescription.Text = bookInfo[3];
                    tbGenre.Text = bookInfo[4];
                    cbbAge.Text = bookInfo[5];
                    if (bookInfo[6] == "Không") ckbAdult.Checked = true;
                    else ckbAdult.Checked = false;

                    // load các chaptes
                    tsmiChapters.Visible = true;
                    string[] status = File.ReadAllLines(bookPath + "\\upload_status.txt");
                    for (int i = 0; i < status.Length; i++)
                        if (status[i] == "true") status[i] = "đã đăng tải";
                        else status[i] = "bản thảo";

                    string[] chapters = new string[bookInfo.Length - 7];
                    for (int i = 0; i < chapters.Length; i++)
                        chapters[i] = bookInfo[i + 7];

                    dgvChapters.Rows.Clear();
                    for (int i = 0; i < chapters.Length; i++)
                        dgvChapters.Rows.Add(chapters[i], status[i]);

                    if (isContinue)
                    {
                        tsmiBookInfo.ForeColor = Color.White;
                        tsmiChapters.ForeColor = Color.GreenYellow;
                        pnlChapters.Visible = true;
                    }
                    else
                    {
                        tsmiBookInfo.ForeColor = Color.GreenYellow;
                        tsmiChapters.ForeColor = Color.White;
                        pnlChapters.Visible = false;
                    }
                }
                pnlBookInfo.Visible = true;
            }
            else
                pnlBookInfo.Visible = false;   
        }

        void ShowWritePanel(bool showPanel, string bookTitle = "", string chapterTitle = "", int chapterIndex = 0)
        {
            if (showPanel)
            {
                lblBookName.Text = bookTitle;
                string bookPath = "D:\\DoAn\\Story\\" + bookTitle;
                if (chapterTitle == "")
                {                
                    int chapterCount = int.Parse(File.ReadAllLines(bookPath + "\\view_like_chapter_count.txt")[2]);
                    lblChapterIndex.Text = (chapterCount + 1).ToString();
                    lblChapterName.Text = "Chưa có tiêu đề chương " + (chapterCount + 1).ToString();
                    tbChapterTitle.Text = "Chưa có tiêu đề chương " + (chapterCount + 1).ToString();
                    rtbStory.Text = "Viết truyện ở đây...";
                    rtbStory.Select();
                }
                else
                {         
                    lblChapterName.Text = chapterTitle;
                    tbChapterTitle.Text = chapterTitle;
                    string chapterPath = bookPath + "\\" + chapterIndex.ToString() + ".txt";
                    lblChapterIndex.Text = chapterIndex.ToString();
                    rtbStory.Text = File.ReadAllText(chapterPath);
                }
                ShowBookInfoPanel(false);  
                pnlWrite.Visible = true;
            }
            else pnlWrite.Visible = false;
        }

        protected void BookClick(object sender, EventArgs e)
        {
            UserControl_MyBook clickedBook = (UserControl_MyBook)sender;
            ShowBookInfoPanel(true, clickedBook.bookTitle);
        }

        protected void ContinueClick(object sender, EventArgs e)
        {
            UserControl_MyBook clickedBook = (UserControl_MyBook)sender;
            ShowBookInfoPanel(true, clickedBook.bookTitle, true);
        }
       
        protected void DeleteClick(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa truyện?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                UserControl_MyBook clickedBook = (UserControl_MyBook)sender;
                string deleteBook = clickedBook.bookTitle;
                string userAllBookPath = "D://DoAn//user_all_story//" + userName + ".txt";
                string userAllBook = File.ReadAllText(userAllBookPath);
                userAllBook = userAllBook.Replace(deleteBook + "\r\n", "");
                File.WriteAllText(userAllBookPath, userAllBook);

                string deleteDir = "D://DoAn//Story//" + deleteBook;
                picCoverImage.BackgroundImage.Dispose();
                if (Directory.Exists(deleteDir)) Directory.Delete(deleteDir, true);

                string path1 = "D://DoAn//user_profile_images//" + userName + ".txt";
                string[] y = File.ReadAllLines(path1);
                //y[1] = (Int32.Parse(y[1]) + 1).ToString();
                string path2 = "D://DoAn//user_all_story//" + userName + ".txt";
                y[1] = File.ReadAllLines(path2).Length.ToString();
                File.WriteAllLines(path1, y);
            }    
            

            LoadAllBookInfo();
        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            ShowBookInfoPanel(true, "");          
        }

        private void btnBackToMyBook_Click(object sender, EventArgs e)
        {
            LoadAllBookInfo();
            ShowBookInfoPanel(false);
        }

        string currentTitle = "";
        private void btnCreateBook_Click(object sender, EventArgs e)
        {
            //Lưu các thông tin trang bìa đã nhập
            //Điều kiện: tiêu đề, thể loại, độ tuổi độc giả không trống
            if (tbTitle.Text.ToString() == "")
            {
                MessageBox.Show("Tiêu đề trống", "Vui lòng nhập tiêu đề", MessageBoxButtons.OK);
            }
            else if (tbAuthor.Text.ToString() == "")
            {
                MessageBox.Show("Tên tác giả trống", "Vui lòng nhập tên tác giả", MessageBoxButtons.OK);
            }
            else if (tbGenre.Text.ToString() == "")
            {
                MessageBox.Show("Thể loại trống", "Vui lòng chọn thể loại", MessageBoxButtons.OK);
            }
            else if (cbbAge.Text == "Độ tuổi độc giả chính")
            {
                MessageBox.Show("Độ tuổi trống", "Vui lòng chọn độ tuổi độc giả", MessageBoxButtons.OK);
            }
            else
            {
                // Nếu thuyện đã tạo rồi
                if (btnCreateBook.Text == "Lưu")
                {
                    // Nếu đổi tên truyện
                    if (currentTitle != tbTitle.Text)
                    {
                            
                        string oldBookPath = "D://DoAn//Story//" + currentTitle;
                        string newBookPath = "D://DoAn//Story//" + tbTitle.Text;
                        if (Directory.Exists(newBookPath))
                        {
                            MessageBox.Show("Tiêu đề đã tồn tại", "Vui lòng nhập tiêu đề khác cho truyện", MessageBoxButtons.OK);
                        }
                        else
                        {
                            // chuyển qua thư mục truyện mới
                            Directory.CreateDirectory("D://DoAn//Story//" + tbTitle.Text);
                            string[] bookFiles = Directory.GetFiles(oldBookPath);
                            foreach (string file in bookFiles)
                            {
                                string fileName = new FileInfo(file).Name;
                                File.Move(oldBookPath + "//" + fileName, newBookPath + "//" + fileName);
                            }

                            // xóa thư mục truyện cũ
                            if (Directory.Exists(oldBookPath)) Directory.Delete(oldBookPath, true);
                        }

                        // đổi tên truyện cũ thành mới trong thông tin truyện của user
                        string userStoriesPath = "D://DoAn//user_all_story//" + userName + ".txt";
                        string[] userStoriesInfo = File.ReadAllLines(userStoriesPath);
                        for (int i=0; i< userStoriesInfo.Length; i++)
                        {
                            if (userStoriesInfo[i] == currentTitle)
                                userStoriesInfo[i] = tbTitle.Text;
                        }
                        File.WriteAllLines(userStoriesPath, userStoriesInfo);
                        
                    }    

                    // lưu cac thông tin trên bìa truyện xuống file 0.txt
                    string bookPath = "D://DoAn//Story//" + tbTitle.Text;
                    string[] bookInfo = File.ReadAllLines(bookPath + "//0.txt");

                    bookInfo[0] = tbTitle.Text;
                    bookInfo[3] = tbDescription.Text;
                    bookInfo[4] = tbGenre.Text;
                    bookInfo[5] = cbbAge.Text;
                    bookInfo[6] = ckbAdult.Checked ? "Không" : "Có";
                    File.WriteAllLines(bookPath + "//0.txt", bookInfo);

                    // lưu thời gian cập nhật truyện mới nhất
                    if (!File.Exists(bookPath + "//last_update.txt"))
                        File.Create(bookPath + "//last_update.txt").Close();
                    StreamWriter sr = new StreamWriter(bookPath + "//last_update.txt");
                    sr.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                    sr.Close();
               

                    //xóa ảnh bìa (cùng tên với ảnh bìa mới/nếu có) và lưu ảnh bìa mới
                    string path = bookPath + "//" + tbTitle.Text.ToString() + ".png";
                    if (File.Exists(path)) File.Delete(path);
                    picCoverImage.BackgroundImage.Save(bookPath + "//" + tbTitle.Text.ToString() + ".png");

                    lblBook.Text = tbTitle.Text;
                    MessageBox.Show("Bạn đã lưu thông tin bìa truyện thành công", "Thông báo", MessageBoxButtons.OK);
                }    
                else
                {
                    //Không có vấn đề => lưu thông tin truyện đã nhập
                    string storyPath = "D://DoAn//Story//" + tbTitle.Text.ToString();
                    //Tạo folder truyện
                    if (Directory.Exists(storyPath))
                    {
                        MessageBox.Show("Tiêu đề đã tồn tại", "Vui lòng nhập tiêu đề", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(storyPath);
                        string[] x = { "0", "0", "0" };
                        File.WriteAllLines(storyPath + "//view_like_chapter_count.txt", x);

                        File.Create(storyPath + "//upload_status.txt").Close();

                        //xóa ảnh bìa (cùng tên với ảnh bìa mới/nếu có) và lưu ảnh bìa mới
                        string path = storyPath + "//" + tbTitle.Text.ToString() + ".png";
                        if (File.Exists(path)) File.Delete(path);
                        picCoverImage.BackgroundImage.Save(storyPath + "//" + tbTitle.Text.ToString() + ".png");

                        //Nếu mô tả trống, cho nó là 1 hàng trống
                        //if (tbDescription.Text.ToString() == "") tbDescription.Text = "\n";


                        //Lưu các thông tin khác
                        string[] info =
                        {
                            tbTitle.Text,
                            tbAuthor.Text,
                            userName,
                            tbDescription.Text,
                            tbGenre.Text,
                            cbbAge.Text,
                            ckbAdult.Text
                        };

                        string infoPath = storyPath + "//0.txt";
                        File.WriteAllLines(infoPath, info);

                        //Thêm tên tác phẩm vào nơi tổng hợp tất cả các tác phẩm của tác giả
                        path = "D://DoAn//user_all_story//" + userName + ".txt";
                        string[] all_story = File.ReadAllLines(path);
                        string[] new_story = { tbTitle.Text };
                        File.WriteAllLines(path, new_story);
                        File.AppendAllLines(path, all_story);

                        //Cộng số lượng tác phẩm của tác giả lên 1
                        string path1 = "D://DoAn//user_profile_images//" + userName + ".txt";
                        string[] y = File.ReadAllLines(path1);
                        //y[1] = (Int32.Parse(y[1]) + 1).ToString();
                        string path2 = "D://DoAn//user_all_story//" + userName + ".txt";
                        y[1] = File.ReadAllLines(path2).Length.ToString();
                        File.WriteAllLines(path1, y);


                        //Chuyển sang viết truyện (tập 1)
                        ShowBookInfoPanel(false);
                        ShowWritePanel(true, tbTitle.Text, "");
                    }    

                }

            }
        }

        private void tsmiBookInfo_Click(object sender, EventArgs e)
        {
            pnlChapters.Visible = false;
            tsmiBookInfo.ForeColor = Color.GreenYellow;
            tsmiChapters.ForeColor = Color.White;
        }
        private void tsmiChapters_Click(object sender, EventArgs e)
        {
            pnlChapters.Visible = true;
            tsmiChapters.ForeColor = Color.GreenYellow;
            tsmiBookInfo.ForeColor = Color.White;


        }

        private void btnLoadCoverImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                picCoverImage.BackgroundImage = GetCopyImage(fileOpen.FileName);
                //picCoverImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            fileOpen.Dispose();
        }


        private void dgvChapters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            string bookTitle = tbTitle.Text;
            string chapterTitle = dgvChapters.Rows[row].Cells[0].Value.ToString();
            //int chapterIndex = int.Parse(chapterTitle.Split('.')[0]);
            ShowWritePanel(true, bookTitle, chapterTitle, row + 1);
        }
        private void btnNewChapter_Click(object sender, EventArgs e)
        {
            string bookTitle = tbTitle.Text;
            string bookPath = "D:\\DoAn\\Story\\" + bookTitle;

            //string[] viewLikeChapterCount = File.ReadAllLines(bookPath + "\\view_like_chapter_count.txt");
            //int newChapterIndex = int.Parse(viewLikeChapterCount[2]) + 1;
            //viewLikeChapterCount[2] = newChapterIndex.ToString();
            //File.WriteAllLines(bookPath + "\\view_like_chapter_count.txt", viewLikeChapterCount);

            ShowWritePanel(true, bookTitle, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookPath = "D:\\DoAn\\Story\\" + lblBookName.Text;
            string chapterPath = bookPath + "\\" + lblChapterIndex.Text + ".txt";

            // lưu thông tin truyện trong chapter 0
            string bookInfoPath = bookPath + "\\0.txt";
            string[] bookInfo = File.ReadAllLines(bookInfoPath);
            int chapterIndex = int.Parse(lblChapterIndex.Text);
            if (chapterIndex <= bookInfo.Length - 7) // nếu chapter đã có
            {
                bookInfo[chapterIndex + 7 -1] = tbChapterTitle.Text;
                File.WriteAllLines(bookInfoPath, bookInfo);

                File.WriteAllText(chapterPath, String.Empty);
                File.WriteAllText(chapterPath, rtbStory.Text);
            }         
            else // nếu là chapter mới
            {
                if (!File.Exists(chapterPath)) File.Create(chapterPath).Close();
                File.WriteAllText(chapterPath, String.Empty);
                File.WriteAllText(chapterPath, rtbStory.Text);

                using (StreamWriter sr = new StreamWriter(bookInfoPath, true))
                {
                    sr.WriteLine(tbChapterTitle.Text);
                    sr.Close();
                }

                // thêm trạng thái upload là bản thảo
                string uploadStatusPath = bookPath + "\\upload_status.txt";
                using (StreamWriter sr = new StreamWriter(uploadStatusPath, true))
                {
                    sr.WriteLine("false");
                    sr.Close();
                }

                // tăng lượng chapter lên 1
                string[] viewLikeChapterCount = File.ReadAllLines(bookPath + "\\view_like_chapter_count.txt");
                int newChapterIndex = int.Parse(viewLikeChapterCount[2]) + 1;
                viewLikeChapterCount[2] = newChapterIndex.ToString();
                File.WriteAllLines(bookPath + "\\view_like_chapter_count.txt", viewLikeChapterCount);
            }

            // lưu thời gian cập nhật truyện mới nhất
            if (!File.Exists(bookPath + "//last_update.txt"))
                File.Create(bookPath + "//last_update.txt").Close();
            using (StreamWriter sr = new StreamWriter(bookPath + "//last_update.txt"))
            {
                sr.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                sr.Close();
            }
            lblChapterName.Text = tbChapterTitle.Text;
            MessageBox.Show("Bạn đã lưu chương thành công.", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string bookPath = "D:\\DoAn\\Story\\" + lblBookName.Text;
            string uploadPath = bookPath + "\\upload_status.txt";

            string[] uploadInfo = File.ReadAllLines(uploadPath);
            int chapterIndex = int.Parse(lblChapterIndex.Text);


            if (chapterIndex - 1 < uploadInfo.Length)
            {
                uploadInfo[chapterIndex - 1] = "true";
                MessageBox.Show("Bạn đã đăng tải chương thành công.", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Bạn phải lưu bản thảo rồi mới đăng tải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            File.WriteAllLines(uploadPath, uploadInfo);

            // lưu thời gian cập nhật truyện mới nhất
            if (!File.Exists(bookPath + "//last_update.txt"))
                File.Create(bookPath + "//last_update.txt").Close();
            using (StreamWriter sr = new StreamWriter(bookPath + "//last_update.txt"))
            {
                sr.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"));
                sr.Close();
            }

        }

        private void picHideWritePanel_Click(object sender, EventArgs e)
        {
            ShowBookInfoPanel(true, tbTitle.Text, true);
            ShowWritePanel(false);
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteChapter_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvChapters.CurrentCell.RowIndex;
            if (rowIndex < 0) return;
            string chapterName = dgvChapters.Rows[rowIndex].Cells[0].Value.ToString();

            string bookInfoPath = "D:\\DoAn\\Story\\" + tbTitle.Text + "\\0.txt";
            string[] bookInfo = File.ReadAllLines(bookInfoPath);
            File.WriteAllText(bookInfoPath, String.Empty);

            StreamWriter sr = new StreamWriter(bookInfoPath, true);
            int chapterIndex = 0, lastChapterIndex = bookInfo.Length - 7;
            for (int i = 0; i < bookInfo.Length; i++)
            {
                if (bookInfo[i] != chapterName)
                {
                    sr.WriteLine(bookInfo[i]);
                }
                else chapterIndex = i - 6;
            }
            sr.Close();
            if (chapterIndex <= 0) return; // nếu không có chương nào bị xóa thì kết thúc          

            // xóa trạng thái upload của chương cần xóa
            string uploadInfoPath = "D:\\DoAn\\Story\\" + tbTitle.Text + "\\upload_status.txt";
            string[] uploadInfo = File.ReadAllLines(uploadInfoPath);

            File.WriteAllText(uploadInfoPath, String.Empty);
            sr = new StreamWriter(uploadInfoPath, true);
            for(int i=0; i< uploadInfo.Length; i++)
                if (i != chapterIndex - 1)
                    sr.WriteLine(uploadInfo[i]);
            sr.Close();

            string bookPath = "D:\\DoAn\\Story\\" + tbTitle.Text + "\\";

            if (File.Exists(bookPath + chapterIndex.ToString() + ".txt")) File.Delete(bookPath + chapterIndex.ToString() + ".txt");
            for (int i =chapterIndex +1; i<= lastChapterIndex; i++)
            {
                File.Move(bookPath + i.ToString() + ".txt", bookPath + (i - 1).ToString() + ".txt");
            }

            ShowBookInfoPanel(true, tbTitle.Text, true);

            // giảm số lượng chương của truyện xuống 1
            string[] viewLikeChapterCount = File.ReadAllLines(bookPath + "\\view_like_chapter_count.txt");
            int newChapterIndex = int.Parse(viewLikeChapterCount[2]) - 1;
            viewLikeChapterCount[2] = newChapterIndex.ToString();
            File.WriteAllLines(bookPath + "\\view_like_chapter_count.txt", viewLikeChapterCount);

        }
    }
}
