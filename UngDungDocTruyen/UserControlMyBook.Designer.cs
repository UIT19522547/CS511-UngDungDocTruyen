
namespace UngDungDocTruyen
{
    partial class UserControlMyBook
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMyBook));
            this.picBookImage = new System.Windows.Forms.PictureBox();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblDraftCount = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.panel_view_like_chapters = new System.Windows.Forms.Panel();
            this.lblChapter = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblLike = new System.Windows.Forms.Label();
            this.lblUploadCount = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lbl0 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBookImage)).BeginInit();
            this.panel_view_like_chapters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // picBookImage
            // 
            this.picBookImage.Location = new System.Drawing.Point(15, 10);
            this.picBookImage.Name = "picBookImage";
            this.picBookImage.Size = new System.Drawing.Size(134, 155);
            this.picBookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBookImage.TabIndex = 0;
            this.picBookImage.TabStop = false;
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblBookTitle.Location = new System.Drawing.Point(155, 10);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(278, 29);
            this.lblBookTitle.TabIndex = 1;
            this.lblBookTitle.Text = "Truyện chưa có tiêu đề";
            this.lblBookTitle.Click += new System.EventHandler(this.lblBookTitle_Click);
            // 
            // lblDraftCount
            // 
            this.lblDraftCount.AutoSize = true;
            this.lblDraftCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraftCount.ForeColor = System.Drawing.Color.White;
            this.lblDraftCount.Location = new System.Drawing.Point(156, 67);
            this.lblDraftCount.Name = "lblDraftCount";
            this.lblDraftCount.Size = new System.Drawing.Size(104, 25);
            this.lblDraftCount.TabIndex = 2;
            this.lblDraftCount.Text = "0 bản thảo";
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.BackColor = System.Drawing.Color.YellowGreen;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(707, 57);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(218, 42);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Tiếp tục viết";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // panel_view_like_chapters
            // 
            this.panel_view_like_chapters.Controls.Add(this.lblChapter);
            this.panel_view_like_chapters.Controls.Add(this.lblView);
            this.panel_view_like_chapters.Controls.Add(this.pictureBox2);
            this.panel_view_like_chapters.Controls.Add(this.pictureBox4);
            this.panel_view_like_chapters.Controls.Add(this.pictureBox3);
            this.panel_view_like_chapters.Controls.Add(this.lblLike);
            this.panel_view_like_chapters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_view_like_chapters.ForeColor = System.Drawing.Color.White;
            this.panel_view_like_chapters.Location = new System.Drawing.Point(160, 120);
            this.panel_view_like_chapters.Name = "panel_view_like_chapters";
            this.panel_view_like_chapters.Size = new System.Drawing.Size(330, 45);
            this.panel_view_like_chapters.TabIndex = 4;
            // 
            // lblChapter
            // 
            this.lblChapter.AutoSize = true;
            this.lblChapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChapter.Location = new System.Drawing.Point(283, 10);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(23, 25);
            this.lblChapter.TabIndex = 8;
            this.lblChapter.Text = "0";
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(34, 10);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(23, 25);
            this.lblView.TabIndex = 1;
            this.lblView.Text = "0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(251, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 29);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(123, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 25);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lblLike
            // 
            this.lblLike.AutoSize = true;
            this.lblLike.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLike.Location = new System.Drawing.Point(158, 10);
            this.lblLike.Name = "lblLike";
            this.lblLike.Size = new System.Drawing.Size(23, 25);
            this.lblLike.TabIndex = 3;
            this.lblLike.Text = "0";
            // 
            // lblUploadCount
            // 
            this.lblUploadCount.AutoSize = true;
            this.lblUploadCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadCount.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblUploadCount.Location = new System.Drawing.Point(156, 42);
            this.lblUploadCount.Name = "lblUploadCount";
            this.lblUploadCount.Size = new System.Drawing.Size(185, 25);
            this.lblUploadCount.TabIndex = 5;
            this.lblUploadCount.Text = "0 chương đã đăng";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.ForeColor = System.Drawing.Color.White;
            this.lblLastUpdate.Location = new System.Drawing.Point(328, 92);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(85, 25);
            this.lblLastUpdate.TabIndex = 7;
            this.lblLastUpdate.Text = "thời gian";
            // 
            // lbl0
            // 
            this.lbl0.AutoSize = true;
            this.lbl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl0.ForeColor = System.Drawing.Color.White;
            this.lbl0.Location = new System.Drawing.Point(158, 92);
            this.lbl0.Name = "lbl0";
            this.lbl0.Size = new System.Drawing.Size(170, 25);
            this.lbl0.TabIndex = 6;
            this.lbl0.Text = "Cập nhật lần cuối:";
            // 
            // UserControlMyBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.lbl0);
            this.Controls.Add(this.lblUploadCount);
            this.Controls.Add(this.panel_view_like_chapters);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.lblDraftCount);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.picBookImage);
            this.Name = "UserControlMyBook";
            this.Size = new System.Drawing.Size(1032, 176);
            ((System.ComponentModel.ISupportInitialize)(this.picBookImage)).EndInit();
            this.panel_view_like_chapters.ResumeLayout(false);
            this.panel_view_like_chapters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBookImage;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblDraftCount;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel panel_view_like_chapters;
        private System.Windows.Forms.Label lblLike;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUploadCount;
        private System.Windows.Forms.Label lblChapter;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lbl0;
    }
}
