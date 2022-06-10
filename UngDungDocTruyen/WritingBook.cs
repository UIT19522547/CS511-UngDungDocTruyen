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
    public partial class WritingBook : Form
    {
        string userName;
        string authorName;
        public WritingBook(string currentUserName, string currentAuthor)
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

            tmiBookInfo.ForeColor = Color.GreenYellow;
            tmiAllBook.ForeColor = Color.GreenYellow;
            pnlChapters.Visible = false;

            pnlWrite.Visible = false;
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

                UserControlMyBook newBookControl = new UserControlMyBook(imagePath, book, draftCount, uploadCount, "hom nay", view, like, chapter);
                newBookControl.BookTitleClick += new EventHandler(BookClick);
                newBookControl.ContinueButtonClick += new EventHandler(ContinueClick);
                //newBookControl.DeleteButtonClick += new EventHandler(DeleteClick);

                tlpMyBook.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
                tlpMyBook.Controls.Add(newBookControl, 0, tlpMyBook.RowCount);
                tlpMyBook.RowCount += 1;

            }
            allBooks.Close();

        }

       

        void ShowBookInfoPanel(bool showPanel, string bookTitle = "", bool isContinue = false)
        { 
            if (showPanel)
            {
                currentTitle = bookTitle;
                //dgvChapters.Visible = false;
                if (bookTitle == "")
                {
                    lblBook.Text = "Truyện chưa có tiêu đề";
                    picCoverImage.BackgroundImage = Image.FromFile("D:\\DoAn\\Image\\cover_default.jpg");
                    tbTitle.Clear();
                    tbAuthor.Text = authorName;
                    tbDescription.Clear();
                    tbGenre.Clear();
                    cbbAge.Text = "Độ tuổi độc giả chính";
                    ckbAdult.Checked = false;

                    btnCreateBook.Text= "Tạo truyện";
                    tmiChapters.Visible = false;
                }
                else
                {
                    lblBook.Text = bookTitle;
                    btnCreateBook.Text = "Lưu";
                    string bookPath = "D:\\DoAn\\Story\\" + bookTitle;
                    picCoverImage.BackgroundImage = Image.FromFile(bookPath + "\\" + bookTitle + ".png");
                    string[] bookInfo = File.ReadAllLines(bookPath + "\\0.txt");

                    // load thông tin truyện
                    tbTitle.Text = bookInfo[0];
                    tbAuthor.Text = bookInfo[1];
                    tbDescription.Text = bookInfo[3];
                    tbGenre.Text = bookInfo[4];
                    cbbAge.Text = bookInfo[5];
                    if (bookInfo[6] != "không") ckbAdult.Checked = true;

                    // load các chaptes
                    tmiChapters.Visible = true;
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
                        tmiBookInfo.ForeColor = Color.White;
                        tmiChapters.ForeColor = Color.GreenYellow;
                        pnlChapters.Visible = true;
                    }
                    else
                    {
                        tmiBookInfo.ForeColor = Color.GreenYellow;
                        tmiChapters.ForeColor = Color.White;
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
            UserControlMyBook clickedBook = (UserControlMyBook)sender;
            ShowBookInfoPanel(true, clickedBook.bookTitle);
        }

        protected void ContinueClick(object sender, EventArgs e)
        {
            UserControlMyBook clickedBook = (UserControlMyBook)sender;
            ShowBookInfoPanel(true, clickedBook.bookTitle, true);
        }
       /* protected void DeleteClick(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa truyện?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                UserControlMyBook clickedBook = (UserControlMyBook)sender;
                string deleteBook = clickedBook.bookTitle;
                string userAllBookPath = "D:\\DoAn\\user_all_story\\" + userName + ".txt";
                string userAllBook = File.ReadAllText(userAllBookPath);
                userAllBook = userAllBook.Replace(deleteBook + "\r\n", "");
                File.WriteAllText(userAllBookPath, userAllBook);

                string deleteDir = "D:\\DoAn\\Story\\" + deleteBook;
                picCoverImage.BackgroundImage.Dispose();
                if (Directory.Exists(deleteDir)) Directory.Delete(deleteDir, true);
            }    
            

            LoadAllBookInfo();
        }*/

        private void label1_Click(object sender, EventArgs e)
        {
            
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
            if (btnCreateBook.Text == "Lưu")
            {
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
                    string newTitle = tbTitle.Text;
                    if (newTitle == currentTitle)
                    {
                        string bookPath = "D://DoAn//Story//" + newTitle + "//";
                        string[] bookInfo = File.ReadAllLines(bookPath + "0.txt");
                        bookInfo[0] = newTitle;
                        bookInfo[3] = tbDescription.Text;
                        bookInfo[4] = tbGenre.Text;
                        bookInfo[5] = cbbAge.Text;
                        bookInfo[6] = ckbAdult.Checked ? "Không" : "Có";
                        File.WriteAllLines(bookPath + "0.txt", bookInfo);
                    }
                    //Không có vấn đề => lưu thông tin truyện đã nhập
                    
                }
                return;
            }    


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

        private void tmiBookInfo_Click(object sender, EventArgs e)
        {
            pnlChapters.Visible = false;
            tmiBookInfo.ForeColor = Color.GreenYellow;
            tmiChapters.ForeColor = Color.White;
        }
        private void tmiChapters_Click(object sender, EventArgs e)
        {
            pnlChapters.Visible = true;
            tmiChapters.ForeColor = Color.GreenYellow;
            tmiBookInfo.ForeColor = Color.White;


        }

        private void btnLoadCoverImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg|PNG Files (*.png)| *.png";
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                picCoverImage.Image = Image.FromFile(fileOpen.FileName);
                picCoverImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            fileOpen.Dispose();
        }

        private void dgvChapters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            string bookTitle = tbTitle.Text;
            string chapterTitle = dgvChapters.Rows[row].Cells[0].Value.ToString();
            //int chapterIndex = int.Parse(chapterTitle.Split('.')[0]);
            ShowWritePanel(true, bookTitle, chapterTitle, row+1);

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

            if (!File.Exists(chapterPath)) File.Create(chapterPath).Close();
            File.WriteAllText(chapterPath, String.Empty);
            File.WriteAllText(chapterPath, rtbStory.Text);

            // lưu thông tin truyện trong chapter 0
            string bookInfoPath = bookPath + "\\0.txt";
            string[] bookInfo = File.ReadAllLines(bookInfoPath);
            int chapterIndex = int.Parse(lblChapterIndex.Text);
            if (chapterIndex + 6 < bookInfo.Length) // nếu chapter đã có
            {
                bookInfo[chapterIndex + 6] = tbChapterTitle.Text;
                File.WriteAllLines(bookInfoPath, bookInfo);
            }         
            else // nếu là chapter mới
            {
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

        }

        private void picHideWritePanel_Click(object sender, EventArgs e)
        {
            ShowBookInfoPanel(true, tbTitle.Text, true);
            ShowWritePanel(false);
        }

        
    }
}
