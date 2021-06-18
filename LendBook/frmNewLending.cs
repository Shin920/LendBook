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
    public partial class frmNewLending : Form
    {
        public int StudentID { get { return int.Parse(txtStudentID.Text); } }

        public int[] SelectedBookID 
        { 
            get
            {
                int[] bookIDs = new int[lstLendBook.Items.Count];
                for(int i=0; i<lstLendBook.Items.Count; i++)
                {
                    string[] arr = lstLendBook.Items[i].ToString().Split('/');
                    bookIDs[i] = int.Parse(arr[0].Trim());
                }

                return bookIDs;
            }
        }

        public frmNewLending()
        {
            InitializeComponent();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //유효성체크
            BookDAC db = new BookDAC();
            int bookID = int.Parse(txtBookID.Text);
            int studentID = int.Parse(txtStudentID.Text);

            //1. 입력한 도서번호가 유효한 도서번호인지 체크
            if (!db.IsValid(bookID))
            {
                MessageBox.Show("도서가 존재하지 않습니다.");
                db.Dispose();
                return;
            }
            //2. 대여중인 도서인지 체크
            if (db.IsLended(bookID))
            {
                MessageBox.Show("대여중인 도서입니다.");
                db.Dispose();
                return;
            }

            //3. 예약한 학번이 입력한 학번인지 체크
            if (db.IsReserved(bookID))
            {
                if (db.GetReserveStuID(bookID) != studentID)
                {
                    MessageBox.Show("이미 예약된 도서입니다.");
                    db.Dispose();
                    return;
                }
            }

            //처리로직
            Book bk = db.GetBookInfo(bookID);
            db.Dispose();

            //리스트박스에 추가
            lstLendBook.Items.Add($"{bk.Bookid} / {bk.BookName} / {bk.Author} / {bk.Publisher}");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효성체크
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
                MessageBox.Show("학번을 입력하세요.");
            else if (lstLendBook.Items.Count < 1)
                MessageBox.Show("도서를 추가해주세요.");
            else
            {
                StudentDAC stuDB = new StudentDAC();
                if (!stuDB.IsValid(StudentID))
                {
                    MessageBox.Show("존재하지 않는 학생입니다.");
                    stuDB.Dispose();
                    return;
                }
                stuDB.Dispose();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
