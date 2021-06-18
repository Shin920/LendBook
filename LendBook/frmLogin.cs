using LendBook.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace LendBook
{
    public partial class frmLogin : Form
    {
        public User LoginUserInfo { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlSearch.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUser frm = new frmUser();
            frm.Show();
            //this.Close();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root" && textBox2.Text == "1234")
            {

                //db쿼리 실행. 
                User loginUser = new User();
                loginUser.UserID = "root";
                loginUser.UserName = "홍길동";
                loginUser.UserAuth = "관리자";
                loginUser.IsAdmin = "Y";

                this.LoginUserInfo = loginUser;

                this.DialogResult = DialogResult.OK;
                this.Close();
                //사용자의 권한에 따라서 시작폼을 결정
                //frmMain main = new frmMain();
                //main.WindowState = FormWindowState.Maximized;
                //this.Hide();
                //main.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //유효성체크
            //아이디, 이름, 이메일 입력을 했는지 체크
            if (string.IsNullOrWhiteSpace(txtUserID_S.Text)
                || string.IsNullOrWhiteSpace(txtUserName_S.Text)
                || string.IsNullOrWhiteSpace(txtUserEmail_S.Text))
            {
                MessageBox.Show("회원정보를 입력해주세요.");
                return;
            }
            //처리로직
            //1.DB에서 입력한 정보에 해당되는 회원이 있는지 체크
            UserDAC dac = new UserDAC();
            bool result = dac.SearchPwd(txtUserID_S.Text.Trim(), txtUserName_S.Text.Trim(), txtUserEmail_S.Text.Trim());
            if (! result)
            {
                MessageBox.Show("등록된 회원정보가 없습니다.");
                return;
            }

            //2.비밀번호 신규생성
            string newPwd = CreatePassword();

            //3.신규생성된 비밀번호를 회원정보에 update 시켜놓는다.
            result = dac.UpdatePwd(txtUserID_S.Text.Trim(), newPwd);
            dac.Dispose();
            if (!result)
            {
                MessageBox.Show("다시 시도하여 주십시오.");
                return;
            }

            //4.신규생성된 비밀번호를 메일로 발송
            result = SendMail(txtUserName_S.Text, txtUserEmail_S.Text, newPwd);
            if (result)
            {
                MessageBox.Show("초기화된 비밀번호를 Email로 발송하였습니다.");
            }
            else
            {
                MessageBox.Show("메일 발송 중 오류가 발생했습니다.");
            }
        }

        private bool SendMail(string name, string email, string newPwd)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false; //시스템에 설정된 인증 정보를 사용하지 않는다.
                client.EnableSsl = true; //SSL을 사용한다.
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("gmail계정", "gmail암호");

                MailAddress mailTo = new MailAddress(email);
                MailAddress mailFrom = new MailAddress("gmail계정");

                MailMessage message = new MailMessage(mailFrom, mailTo);

                message.Subject = $"{name}님의 비밀번호 초기화 안내 메일입니다.";
                message.Body = $"{name}님의 비밀번호는 {newPwd}으로 초기화 되었습니다.\n 로그인해주십시오.";

                message.SubjectEncoding = Encoding.UTF8;
                message.BodyEncoding = Encoding.UTF8;

                client.Send(message);

                return true;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        private string CreatePassword()
        {
            //신규비밀번호 = 난수8자리(영문대문자 + 숫자)
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<8; i++)
            {
                int temp = rnd.Next(0, 36); //숫자(0~9), 영문자 (10~25)
                if (temp < 10)
                    sb.Append(temp);
                else
                    sb.Append((char)(temp + 55));
            }
            return sb.ToString();
        }
    }
}
