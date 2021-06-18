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
    public enum OpenMode { Insert, Update }

    public partial class frmStudentInsUp : Form
    {
        public Student StudentInfo 
        {
            get { return new Student(int.Parse(txtStudentID.Text),          
                                     txtStudentName.Text, 
                                     txtDepartment.Text); }
            
            set
            {
                Student stu = value;
                txtStudentID.Text = stu.ID.ToString();
                txtStudentName.Text = stu.Name;
                txtDepartment.Text = stu.Dept;
            }
        }

        public frmStudentInsUp(OpenMode mode)
        {
            InitializeComponent();

            if (mode == OpenMode.Insert)
            {
                this.Text = "학생정보입력";
                txtStudentID.Enabled = true;
            }
            else
            {
                this.Text = "학생정보수정";
                txtStudentID.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //유효성체크
            StringBuilder sb = new StringBuilder();

            if (txtStudentID.Text.Trim().Length != 6)
                sb.AppendLine("- 학번은 6자리로 입력하세요.");
            if (txtStudentName.Text.Trim().Length < 1)
                sb.AppendLine("- 이름을 입력하세요.");
            if (txtDepartment.Text.Trim().Length < 1)
                sb.AppendLine("- 전공을 입력하세요.");

            if (sb.ToString().Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            //처리로직
            this.DialogResult = DialogResult.OK;
            this.Close();            
        }
    }
}
