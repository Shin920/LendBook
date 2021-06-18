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
    public partial class frmReserve : Form
    {
        public int StudentID
        {
            get { return int.Parse(txtStudentID.Text); }
        }

        public int BookID
        {
            get { return int.Parse(txtBookID.Text); }
        }

        public frmReserve()
        {
            InitializeComponent();
        }

        private void NumCheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효성체크
            //학번, 도서번호 입력여부 체크
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) 
                || string.IsNullOrWhiteSpace(txtBookID.Text))
            {
                MessageBox.Show("예약할 학번과 도서번호를 입력해주세요.");
                return;
            }
            //학번 유효한지 체크
            StudentDAC dac = new StudentDAC();
            if (! dac.IsValid(int.Parse(txtStudentID.Text)))
            {
                MessageBox.Show("학번을 확인해주십시오.");
                return;
            }
            dac.Dispose();

            //도서번호 유효한지 체크
            BookDAC db = new BookDAC();
            if (!db.IsValid(int.Parse(txtBookID.Text)))
            {
                MessageBox.Show("도서번호를 확인해주십시오.");
                return;
            }
            
            //대여중인 상태인지 도서 체크
            if (!db.IsLended(int.Parse(txtBookID.Text)))
            {
                MessageBox.Show("도서를 대여하실 수 있습니다.");
                return;
            }

            //이미 예약상태인지 도서 체크
            if (db.IsReserved(int.Parse(txtBookID.Text)))
            {
                MessageBox.Show("이미 예약된 도서입니다.");
                return;
            }

            //이미 예약상태
            db.Dispose();

            //처리로직
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
