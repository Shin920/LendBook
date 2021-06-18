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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            //한번만 발생되는 이벤트 (컨트롤의 초기 설정)
            CommonUtil.SetInitGridView(dgvStudent);
            CommonUtil.AddGridTextColumn(dgvStudent, "학번", "StudentID", colWidth: 150);
            CommonUtil.AddGridTextColumn(dgvStudent, "학생명", "StudentName", colWidth: 200);
            CommonUtil.AddGridTextColumn(dgvStudent, "학과", "Department", colWidth: 300);

            LoadData();
        }

        private void LoadData()
        {
            StudentDAC dac = new StudentDAC();
            dgvStudent.DataSource = dac.GetAll();
            dgvStudent.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStudentInsUp frm = new frmStudentInsUp(OpenMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Student stu = frm.StudentInfo;
                StudentDAC dac = new StudentDAC();
                string result = dac.Insert(stu);
                dac.Dispose();

                if (result.Length < 1)
                {
                    MessageBox.Show("추가되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //선택된 학생정보
            Student stu;
            stu.ID = Convert.ToInt32(dgvStudent[0, dgvStudent.CurrentRow.Index].Value);
            stu.Name = dgvStudent[1, dgvStudent.CurrentRow.Index].Value.ToString();
            stu.Dept = dgvStudent[2, dgvStudent.CurrentRow.Index].Value.ToString();

            frmStudentInsUp frm = new frmStudentInsUp(OpenMode.Update);
            frm.StudentInfo = stu;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                StudentDAC dac = new StudentDAC();
                string result = dac.Update(frm.StudentInfo);
                dac.Dispose();

                if (result.Length < 1)
                {
                    MessageBox.Show("수정되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //선택된 학생을 삭제할건지 확인
            string name = dgvStudent[1, dgvStudent.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show($"{name} 학생정보를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int stuID = (int)dgvStudent[0, dgvStudent.CurrentRow.Index].Value;

                StudentDAC dac = new StudentDAC();
                string result = dac.Delete(stuID);
                dac.Dispose();

                if (result.Length < 1)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmStudentSearch frm = new frmStudentSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int stuID = frm.StudentID;

                //1. DataTable Select()
                //DataTable dt = (DataTable)dgvStudent.DataSource;
                //DataRow[] rows = dt.Select("StudentId=" + stuID);
                //if (rows.Length == 0)
                //{
                //    MessageBox.Show("검색된 학생이 없습니다.");
                //}
                //else
                //{
                //    MessageBox.Show(rows[0][1].ToString());
                //}

                //2. DataView Find()
                //DataTable dt = (DataTable)dgvStudent.DataSource;
                //DataView dv = dt.DefaultView;
                //dv.Sort = "StudentID";
                //int rowIdx = dv.Find(stuID); //찾는 값으로 먼저 Sort를 먼저 해놓고 Find()
                //if (rowIdx < 0)
                //{
                //    MessageBox.Show("검색된 학생이 없습니다.");
                //}
                //else
                //{
                //    dgvStudent.ClearSelection(); //선택된 row를 선택안하도록
                //    dgvStudent.CurrentCell = dgvStudent.Rows[rowIdx].Cells[0];
                //    //dgvStudent.Rows[rowIdx].Selected = true;
                //}

                //3. 현재 상태의 데이터그리드뷰에서 검색
                bool bFlag = false;
                for(int i=0; i<dgvStudent.Rows.Count; i++)
                {
                    if ((int)dgvStudent[0, i].Value == stuID)
                    {
                        dgvStudent.ClearSelection();
                        dgvStudent.CurrentCell = dgvStudent.Rows[i].Cells[0];
                        bFlag = true;
                        break;
                    }
                }

                if (!bFlag)
                {
                    MessageBox.Show("검색된 학생이 없습니다.");
                }
            }
        }
    }
}
