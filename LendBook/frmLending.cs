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
    public partial class frmLending : Form
    {
        public frmLending()
        {
            InitializeComponent();
        }

        private void btnLending_Click(object sender, EventArgs e)
        {
            frmNewLending frm = new frmNewLending();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LendingDAC db = new LendingDAC();
                db.LendBook(frm.StudentID, frm.SelectedBookID);
                db.Dispose();

                LoadData();
            }
        }

        private void frmLending_Load(object sender, EventArgs e)
        {
            label1.Text = ((frmMain)this.MdiParent).loginUser.UserName;

            //그리드뷰의 컬럼 항목을 셋팅
            //데이터를 조회해서 바인딩
            LoadData();
        }

        private void LoadData()
        {
            LendingDAC dac = new LendingDAC();
            DataTable dt = dac.GetLendAll();
            dac.Dispose();

            DataView dv1 = new DataView(dt);
            dv1.RowFilter = "LendingState = 0";
            dgvLendable.DataSource = dv1; //대여가능

            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "LendingState = 1";
            dgvUnLendable.DataSource = dv2; //대여중
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmReserve frm = new frmReserve();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LendingDAC db = new LendingDAC();
                bool result = db.ReserveBook(frm.StudentID, frm.BookID);
                if (result)
                    MessageBox.Show("예약이 완료되었습니다.");
                else
                    MessageBox.Show("다시 시도하여 주십시오.");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
