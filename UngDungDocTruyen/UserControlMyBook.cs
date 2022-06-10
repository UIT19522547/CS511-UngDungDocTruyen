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
    public partial class UserControlMyBook : UserControl
    {
        public event EventHandler BookTitleClick;
        public event EventHandler ContinueButtonClick;
        //public event EventHandler DeleteButtonClick;
        public UserControlMyBook(string imagePath, string bookTitle, int draftCount, int uploadCount, string lastUpdate, int view, int like, int chapter)
        {
            InitializeComponent();

            picBookImage.Image = Image.FromFile(imagePath);
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
           if (this.ContinueButtonClick != null)
                this.ContinueButtonClick(this, e);
        }

        /*private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteButtonClick != null)
                this.DeleteButtonClick(this, e);
        }*/

        private void lblBookTitle_Click(object sender, EventArgs e)
        {
            if (this.BookTitleClick != null)
                this.BookTitleClick(this, e);
        }

        
    }
}
