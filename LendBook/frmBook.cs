using LendBook.DAC;
using LendBook.Util;
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
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvBook);

            CommonUtil.AddGridTextColumn(dgvBook, "도서번호", "bookid", colWidth:80);
            CommonUtil.AddGridTextColumn(dgvBook, "도서명", "bookname", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvBook, "저자", "author", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvBook, "출판사명", "publisher", colWidth: 100);
            CommonUtil.AddGridTextColumn(dgvBook, "대여상태", "lendingstate", colWidth: 80);
            CommonUtil.AddGridTextColumn(dgvBook, "예약학번", "reservstuid", colWidth: 80);

            DataLoad();
        }

        private void DataLoad()
        {
            BookDAC book = new BookDAC();
            dgvBook.DataSource = book.GetAll().DefaultView;
            book.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(((DataView)dgvBook.DataSource).Table);
            int rowIndex;

            if (txtBookID.Text != "")
            {
                dv.Sort = "BookID";
                rowIndex = dv.Find(txtBookID.Text);
                if (rowIndex == -1)
                    MessageBox.Show("존재하지 않는 도서입니다.");
                else
                {
                    dgvBook.ClearSelection();
                    dgvBook.CurrentCell = dgvBook.Rows[rowIndex].Cells[0];
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Book mybk;
            mybk.Bookid = 0; // Convert.ToInt32(txtBookID.Text);
            mybk.BookName = txtBookName.Text;
            mybk.Author = txtAuthor.Text;
            mybk.Publisher = txtPublisher.Text;

            BookDAC book = new BookDAC();
            book.Insert(mybk);
            book.Dispose();

            DataLoad();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookID.Text = dgvBook[0, dgvBook.CurrentRow.Index].Value.ToString();
            txtBookName.Text = dgvBook[1, dgvBook.CurrentRow.Index].Value.ToString();
            txtAuthor.Text = dgvBook[2, dgvBook.CurrentRow.Index].Value.ToString();
            txtPublisher.Text = dgvBook[3, dgvBook.CurrentRow.Index].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book mybk;
            mybk.Bookid = Convert.ToInt32(txtBookID.Text);
            mybk.BookName = txtBookName.Text;
            mybk.Author = txtAuthor.Text;
            mybk.Publisher = txtPublisher.Text;

            BookDAC book = new BookDAC();
            book.Update(mybk);
            book.Dispose();

            DataLoad();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int bookid = Convert.ToInt32(txtBookID.Text);

            BookDAC book = new BookDAC();
            book.Delete(bookid);
            book.Dispose();

            DataLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
