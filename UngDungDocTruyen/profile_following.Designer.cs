namespace UngDungDocTruyen
{
    partial class profile_following
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
            this.profile_image = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_story = new System.Windows.Forms.Label();
            this.num_follower = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profile_image)).BeginInit();
            this.SuspendLayout();
            // 
            // profile_image
            // 
            this.profile_image.Location = new System.Drawing.Point(24, 23);
            this.profile_image.Name = "profile_image";
            this.profile_image.Size = new System.Drawing.Size(121, 115);
            this.profile_image.TabIndex = 0;
            this.profile_image.TabStop = false;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Black;
            this.name.Location = new System.Drawing.Point(151, 23);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(235, 31);
            this.name.TabIndex = 1;
            this.name.Text = "label1";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tác phẩm:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Người theo dõi:";
            // 
            // num_story
            // 
            this.num_story.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_story.Location = new System.Drawing.Point(296, 65);
            this.num_story.Name = "num_story";
            this.num_story.Size = new System.Drawing.Size(108, 31);
            this.num_story.TabIndex = 4;
            this.num_story.Text = "0";
            // 
            // num_follower
            // 
            this.num_follower.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_follower.Location = new System.Drawing.Point(296, 107);
            this.num_follower.Name = "num_follower";
            this.num_follower.Size = new System.Drawing.Size(108, 31);
            this.num_follower.TabIndex = 5;
            this.num_follower.Text = "0";
            // 
            // profile_following
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.num_follower);
            this.Controls.Add(this.num_story);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.profile_image);
            this.Name = "profile_following";
            this.Size = new System.Drawing.Size(407, 164);
            ((System.ComponentModel.ISupportInitialize)(this.profile_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox profile_image;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label num_story;
        private System.Windows.Forms.Label num_follower;
    }
}
