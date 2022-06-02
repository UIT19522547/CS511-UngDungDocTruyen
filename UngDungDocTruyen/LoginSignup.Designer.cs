namespace UngDungDocTruyen
{
    partial class LoginSignup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.toSignUp = new System.Windows.Forms.Label();
            this.exitlogin = new System.Windows.Forms.Button();
            this.panSignUp = new System.Windows.Forms.Panel();
            this.warning_password_retype = new System.Windows.Forms.Label();
            this.toLogin = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.signup_ok = new System.Windows.Forms.Button();
            this.password_retype = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.warning_username = new System.Windows.Forms.Label();
            this.warning_password = new System.Windows.Forms.Label();
            this.but_display_pass = new System.Windows.Forms.Button();
            this.panSignUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "B-BOOK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(41, 228);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(327, 41);
            this.username.TabIndex = 3;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(41, 359);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(327, 41);
            this.password.TabIndex = 5;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // login_ok
            // 
            this.login_ok.BackColor = System.Drawing.Color.Black;
            this.login_ok.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_ok.ForeColor = System.Drawing.Color.White;
            this.login_ok.Location = new System.Drawing.Point(111, 435);
            this.login_ok.Name = "login_ok";
            this.login_ok.Size = new System.Drawing.Size(158, 54);
            this.login_ok.TabIndex = 6;
            this.login_ok.Text = "Đăng nhập";
            this.login_ok.UseVisualStyleBackColor = false;
            this.login_ok.Click += new System.EventHandler(this.login_ok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 617);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Chưa có tài khoản?";
            // 
            // toSignUp
            // 
            this.toSignUp.AutoSize = true;
            this.toSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toSignUp.Location = new System.Drawing.Point(229, 617);
            this.toSignUp.Name = "toSignUp";
            this.toSignUp.Size = new System.Drawing.Size(67, 20);
            this.toSignUp.TabIndex = 8;
            this.toSignUp.Text = "Đăng ký";
            this.toSignUp.Click += new System.EventHandler(this.toSignUp_Click);
            // 
            // exitlogin
            // 
            this.exitlogin.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitlogin.Location = new System.Drawing.Point(338, 2);
            this.exitlogin.Name = "exitlogin";
            this.exitlogin.Size = new System.Drawing.Size(49, 49);
            this.exitlogin.TabIndex = 9;
            this.exitlogin.Text = "X";
            this.exitlogin.UseVisualStyleBackColor = true;
            this.exitlogin.Click += new System.EventHandler(this.exitlogin_Click);
            // 
            // panSignUp
            // 
            this.panSignUp.Controls.Add(this.warning_password_retype);
            this.panSignUp.Controls.Add(this.toLogin);
            this.panSignUp.Controls.Add(this.label9);
            this.panSignUp.Controls.Add(this.signup_ok);
            this.panSignUp.Controls.Add(this.password_retype);
            this.panSignUp.Controls.Add(this.label7);
            this.panSignUp.Location = new System.Drawing.Point(23, 426);
            this.panSignUp.Name = "panSignUp";
            this.panSignUp.Size = new System.Drawing.Size(364, 267);
            this.panSignUp.TabIndex = 10;
            this.panSignUp.Visible = false;
            // 
            // warning_password_retype
            // 
            this.warning_password_retype.AutoSize = true;
            this.warning_password_retype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_password_retype.ForeColor = System.Drawing.Color.Red;
            this.warning_password_retype.Location = new System.Drawing.Point(14, 117);
            this.warning_password_retype.Name = "warning_password_retype";
            this.warning_password_retype.Size = new System.Drawing.Size(136, 20);
            this.warning_password_retype.TabIndex = 13;
            this.warning_password_retype.Text = "Cần 6 ký tự trở lên";
            // 
            // toLogin
            // 
            this.toLogin.AutoSize = true;
            this.toLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLogin.Location = new System.Drawing.Point(166, 222);
            this.toLogin.Name = "toLogin";
            this.toLogin.Size = new System.Drawing.Size(88, 20);
            this.toLogin.TabIndex = 10;
            this.toLogin.Text = "Đăng nhập";
            this.toLogin.Click += new System.EventHandler(this.toLogin_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Đã có tài khoản?";
            // 
            // signup_ok
            // 
            this.signup_ok.BackColor = System.Drawing.Color.Black;
            this.signup_ok.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_ok.ForeColor = System.Drawing.Color.White;
            this.signup_ok.Location = new System.Drawing.Point(88, 159);
            this.signup_ok.Name = "signup_ok";
            this.signup_ok.Size = new System.Drawing.Size(158, 54);
            this.signup_ok.TabIndex = 8;
            this.signup_ok.Text = "Đăng ký";
            this.signup_ok.UseVisualStyleBackColor = false;
            this.signup_ok.Click += new System.EventHandler(this.signup_ok_Click);
            // 
            // password_retype
            // 
            this.password_retype.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_retype.Location = new System.Drawing.Point(18, 73);
            this.password_retype.Name = "password_retype";
            this.password_retype.Size = new System.Drawing.Size(327, 41);
            this.password_retype.TabIndex = 7;
            this.password_retype.UseSystemPasswordChar = true;
            this.password_retype.TextChanged += new System.EventHandler(this.password_retype_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 35);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nhập lại mật khẩu:";
            // 
            // warning_username
            // 
            this.warning_username.AutoSize = true;
            this.warning_username.BackColor = System.Drawing.Color.White;
            this.warning_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_username.ForeColor = System.Drawing.Color.Red;
            this.warning_username.Location = new System.Drawing.Point(37, 272);
            this.warning_username.Name = "warning_username";
            this.warning_username.Size = new System.Drawing.Size(136, 20);
            this.warning_username.TabIndex = 11;
            this.warning_username.Text = "Cần 6 ký tự trở lên";
            // 
            // warning_password
            // 
            this.warning_password.AutoSize = true;
            this.warning_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_password.ForeColor = System.Drawing.Color.Red;
            this.warning_password.Location = new System.Drawing.Point(37, 403);
            this.warning_password.Name = "warning_password";
            this.warning_password.Size = new System.Drawing.Size(136, 20);
            this.warning_password.TabIndex = 12;
            this.warning_password.Text = "Cần 6 ký tự trở lên";
            // 
            // but_display_pass
            // 
            this.but_display_pass.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_display_pass.Location = new System.Drawing.Point(294, 359);
            this.but_display_pass.Name = "but_display_pass";
            this.but_display_pass.Size = new System.Drawing.Size(74, 40);
            this.but_display_pass.TabIndex = 13;
            this.but_display_pass.Text = "Hiện";
            this.but_display_pass.UseVisualStyleBackColor = true;
            this.but_display_pass.Click += new System.EventHandler(this.but_display_pass_Click);
            // 
            // LoginSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(399, 705);
            this.Controls.Add(this.but_display_pass);
            this.Controls.Add(this.warning_password);
            this.Controls.Add(this.warning_username);
            this.Controls.Add(this.panSignUp);
            this.Controls.Add(this.exitlogin);
            this.Controls.Add(this.toSignUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.login_ok);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginSignup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginSignup";
            this.panSignUp.ResumeLayout(false);
            this.panSignUp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button login_ok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label toSignUp;
        private System.Windows.Forms.Button exitlogin;
        private System.Windows.Forms.Panel panSignUp;
        private System.Windows.Forms.TextBox password_retype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label toLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button signup_ok;
        private System.Windows.Forms.Label warning_username;
        private System.Windows.Forms.Label warning_password;
        private System.Windows.Forms.Button but_display_pass;
        private System.Windows.Forms.Label warning_password_retype;
    }
}