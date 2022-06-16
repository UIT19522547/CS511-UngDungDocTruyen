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
using static UngDungDocTruyen.FormHome;


namespace UngDungDocTruyen
{
    public partial class LoginSignup : Form
    {
        string[] uname_pass;
        string[] uname_arr=new string[100];
        string[] pass_arr=new string[100];
        string uname_pass_path = "D://DoAn//username_password_saved.txt";
        int uname_count = 0;
        int pass_count = 0;
        string uname;
        public LoginSignup()
        {
            InitializeComponent();
            warning_username.Text = "";
            warning_password.Text = "";
            warning_password_retype.Text = "";
            label2.Text = "Đăng nhập";
            panSignUp.Visible = false;

            uname = username.Text.ToString();
            //Lấy usename và pass đã lưu
            uname_pass = File.ReadLines(uname_pass_path).ToArray();
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
            else if (uname_arr.Contains(uname) && label2.Text.ToString()=="Đăng ký")
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
                warning_password.Text = "Mật khẩu phải có từ 6 ký tự trở lên";
            }
            else
            {
                warning_password.Text = "";
            }
        }

        private void exitlogin_Click(object sender, EventArgs e)
        {
            //nếu bấm tắt cửa sổ đăng nhập nhưng không đăng nhập tức là trạng thái đăng nhập là false.
            //mở file current_user_name.txt để cập nhật trạng thái
            string file_name = "D://DoAn//current_user_name.txt";
            string[] x = { "false"};
            File.WriteAllLines(file_name, x);
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
                    //Đăng nhập thành công
                    save_current_username();
                    this.Hide();
                    
                }
            }
        }

        private void signup_ok_Click(object sender, EventArgs e)
        {
            if (warning_username.Text.ToString() != "" || warning_password.Text.ToString() != "" || username.Text.ToString() == "" || password.Text.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập lại", "Tên đăng nhập hoặc mật khẩu không hợp lệ", MessageBoxButtons.OK);
            }
            else
            {
                string uname = username.Text.ToString();
                string pass = password.Text.ToString();
                
                //Đang ký thành công
                //Lưu tài khoản vào file chưa tài khoản và mật khẩu
                string path2 = "D://DoAn//username_password_saved.txt";
                using (StreamWriter writer = new StreamWriter(path2, true))
                {
                    writer.WriteLine(uname);
                    writer.WriteLine(pass);
                }
                //tạo mới các file cần thiết của 1 tài khoản
                //tạo ảnh đại diện default (copy ảnh default và đổi tên thành tên tài khoản
                string default_img_src = "D://DoAn//user_profile_images//default.jpg";
                string img_des = "D://DoAn//user_profile_images//"+uname+".jpg";
                System.IO.File.Copy(default_img_src, img_des);
                //tạo file chứa số lượng tác phẩm, số lượng danh sách đọc và số lượng follower (+ tên của các follower)
                string path = "D://DoAn//user_profile_images//" + uname + ".txt";
                //tên tài khoản khi mới tạo sẽ có default=username
                string[] x = { uname,"0", "0", "0" ,"0"};
                File.WriteAllLines(path, x);
                //tạo file chứa tên tất cả tác phẩm của tài khoản (đây là tài khoản đăng ký mới nên file sẽ rỗng)
                path = "D://DoAn//user_all_story//" + uname + ".txt";
                string[] y = {};
                File.WriteAllLines(path, y);


                //Đồng thời đăng nhập vào tài khoản đang đăng ký hiện tại
                save_current_username();
                this.Hide();
            }
        }

        //save username hiện tại đã đăng nhập vào file current_user_name.txt
        //và thanh đổi tình trạng đăng nhập (có/không) vào file current_user_name.txt
        public void save_current_username()
        {
            string file_name = "D://DoAn//current_user_name.txt";
            string[] x = {"true",username.Text.ToString()};
            File.WriteAllLines(file_name, x);


        }

        private void LoginSignup_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
