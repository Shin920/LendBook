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

namespace LendBook
{
    public partial class frmMain : Form
    {
        public User loginUser;

        public frmMain()
        {
            InitializeComponent();
        }

        private void 학생관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent frm = new frmStudent();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show(this);
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBook frm = new frmBook();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 대여관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLending frm = new frmLending();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 반납관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook frm = new frmReturnBook();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loginUser = frm.LoginUserInfo;
                label1.Text = $"{loginUser.UserName}님, 환영합니다.";
                if (loginUser.IsAdmin == "Y")
                {
                    menuStrip1.Visible = true;
                    menuStrip2.Visible = false;
                }
                else
                {
                    menuStrip1.Visible = false;
                    menuStrip2.Visible = true;
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
