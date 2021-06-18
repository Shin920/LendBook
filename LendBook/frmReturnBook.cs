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
    public partial class frmReturnBook : Form
    {
        public frmReturnBook()
        {
            InitializeComponent();
        }

        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LendingDAC dac = new LendingDAC();
            DataTable dt = dac.GetLendAll();
            dac.Dispose();

            DataView dv1 = new DataView(dt);
            dv1.RowFilter = "LendingState = 1";
            dgvLendable.DataSource = dv1; //대여중

            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "LendingState = 0";
            dgvUnLendable.DataSource = dv2; //대여가능
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //유효성체크
            //책번호입력여부 체크
            if (string.IsNullOrWhiteSpace(txtBookID.Text))
            {
                MessageBox.Show("반납할 도서번호를 입력하세요.");
                return;
            }
            //책번호가 유효 체크
            int bookID = int.Parse(txtBookID.Text);

            BookDAC dac = new BookDAC();
            if (! dac.IsValid(bookID))
            {
                MessageBox.Show("유효하지 않은 도서번호입니다.");
                return;
            }

            //처리로직
            LendingDAC db = new LendingDAC();
            db.ReturnBook(bookID);
            LoadData();
        }
    }
}
