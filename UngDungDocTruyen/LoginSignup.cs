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
    public partial class LoginSignup : Form
    {
        string[] uname_pass;
        string[] uname_arr=new string[100];
        string[] pass_arr=new string[100];
        int uname_count = 0;
        int pass_count = 0;
        public LoginSignup()
        {
            InitializeComponent();
            warning_username.Text = "";
            warning_password.Text = "";
            warning_password_retype.Text = "";
            label2.Text = "Đăng nhập";

            //Lấy usename và pass đã lưu
            uname_pass = File.ReadLines("C://Users//thaov//OneDrive//Desktop//DoAn//username_password_saved.txt").ToArray();
            //Chia username và pass ra 2 array
            int i = 0;
            for (i = 0; i < uname_pass.Length; i++)
            {
                if (i % 2 == 0)
                {
                    uname_arr[uname_count] = uname_pass[i];
                    uname_count += 1;
                }
                else
                {
                    pass_arr[pass_count] = uname_pass[i];
                    pass_count += 1;
                }
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            string uname = username.Text.ToString();
            if (uname.Any(ch => !Char.IsLetterOrDigit(ch))) {
                warning_username.Text = "Tên đăng nhập không chứa ký tự đặc biệt";
            }
            else if (uname.Length < 6)
            {
                warning_username.Text = "Tên đăng nhập phải có từ 6 ký tự trở lên";
            }
            else if (uname_pass.Contains(uname))
            {
                warning_username.Text = "Tên đăng nhập đã được sử dụng" +
                    "";
            }
            else
            {
                warning_username.Text = "";
            }
        }

        private void but_display_pass_Click(object sender, EventArgs e)
        {
            Button x = (Button)sender;
            if (x.Text.ToString() == "Hiện")
            {
                x.Text = "Ẩn";
                password.UseSystemPasswordChar = false;
                password_retype.UseSystemPasswordChar = false;
            }
            else
            {
                x.Text = "Hiện";
                password.UseSystemPasswordChar = false;
                password_retype.UseSystemPasswordChar = false;
            }
        }

        private void password_retype_TextChanged(object sender, EventArgs e)
        {
            string pass = password.Text.ToString();
            string pass_re = password_retype.Text.ToString();
            if (pass != pass_re)
            {
                warning_password_retype.Text = "Mật khẩu nhập lại không trùng khớp";
            }
            else
            {
                warning_password_retype.Text = "";
            }

        }
        

        private void password_TextChanged(object sender, EventArgs e)
        {
            string pass = password.Text.ToString();
            
            if (pass.Length < 6)
            {
                warning_username.Text = "Mật khẩu phải có từ 6 ký tự trở lên";
            }
            else
            {
                warning_username.Text = "";
            }
        }

        private void exitlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toSignUp_Click(object sender, EventArgs e)
        {
            panSignUp.Visible = true;
            label2.Text = "Đăng ký";
        }

        private void toLogin_Click(object sender, EventArgs e)
        {
            panSignUp.Visible = false;
            label2.Text = "Đăng nhập";
        }

        private void login_ok_Click(object sender, EventArgs e)
        {
            if (warning_username.Text.ToString() != "" || warning_password.Text.ToString() != "" || username.Text.ToString() == "" || password.Text.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập lại", "Tên đăng nhập hoặc mật khẩu không hợp lệ", MessageBoxButtons.OK);
            }
            else if (!uname_arr.Contains(username.Text.ToString()))
            {
                MessageBox.Show("Vui lòng nhập lại", "Tên đăng nhập không tồn tại", MessageBoxButtons.OK);
            }
            else
            {
                string uname = username.Text.ToString();
                string pass = password.Text.ToString();
                //Kiểm tra pass có đúng hay không
                int index_ = Array.IndexOf(uname_arr, uname);
                if (pass != pass_arr[index_])
                {
                    MessageBox.Show("Vui lòng nhập lại", "Mật khẩu không chính xác", MessageBoxButtons.OK);
                }
                else
                {
                    this.Hide();
                    
                }
            }
        }

        private void signup_ok_Click(object sender, EventArgs e)
        {

        }
    }
}
