using System;
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
    public partial class UserControl_MyBook : UserControl
    {
        public event EventHandler TitleClick ;
        public event EventHandler ContinueClick;
        public event EventHandler DeleteClick;
        public UserControl_MyBook(string imagePath, string bookTitle, int draftCount, int uploadCount, string lastUpdate, int view, int like, int chapter)
        {
            InitializeComponent();

            picBookImage.Image = GetCopyImage(imagePath);
            lblBookTitle.Text = bookTitle;
            lblUploadCount.Text = uploadCount.ToString() + " chương đã đăng";
            lblDraftCount.Text = draftCount.ToString() + " bản thảo";
            lblLastUpdate.Text = lastUpdate;
            lblView.Text = view.ToString();
            lblLike.Text = like.ToString();
            lblChapter.Text = chapter.ToString();
        }

        public string bookTitle
        {
            get
            {
                return lblBookTitle.Text;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (this.ContinueClick != null)
                this.ContinueClick(this, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteClick != null)
                this.DeleteClick(this, e);
        }

        private void lblBookTitle_Click(object sender, EventArgs e)
        {
            if (this.TitleClick != null)
                this.TitleClick(this, e);
        }

        private Image GetCopyImage(string path)
        {
            Image img = Image.FromFile(path);
            Bitmap bm = new Bitmap(img);
            img.Dispose();
            return bm;
            
        }
    }
}
