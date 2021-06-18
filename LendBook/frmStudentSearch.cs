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
    public partial class frmStudentSearch : Form
    {
        public int StudentID 
        {
            get { return int.Parse(txtStudentID.Text); }
        }

        public frmStudentSearch()
        {
            InitializeComponent();
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1.PerformClick();
            else if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text.Length != 6)
            {
                MessageBox.Show("검색하실 학번은 6자리로 입력하세요.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
