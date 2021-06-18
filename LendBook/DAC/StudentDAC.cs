using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;

namespace LendBook.DAC
{
    public struct Student
    {
        public int ID;
        public string Name;
        public string Dept;

        public Student(int stuID, string stuName, string stuDept)
        {
            ID = stuID;
            Name = stuName;
            Dept = stuDept;
        }
    }

    public class StudentDAC : IDisposable
    {
        MySqlConnection conn;

        public StudentDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public string Insert(Student stu)
        {
            try
            {
                string sql = "insert into student (StudentID, StudentName, Department) values (@StudentID, @StudentName, @Department)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", stu.ID);
                cmd.Parameters.AddWithValue("@StudentName", stu.Name);
                cmd.Parameters.AddWithValue("@Department", stu.Dept);

                int iAffectRows = cmd.ExecuteNonQuery();

                return (iAffectRows > 0) ? "" : "적용된 행 없음";
            }
            catch(Exception err)
            {
                //Debug.WriteLine(err.Message);
                return err.Message;
            }
        }

        public string Update(Student stu)
        {
            try
            {
                string sql = "update student set StudentName = @StudentName, Department = @Department where StudentID = @StudentID ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", stu.ID);
                cmd.Parameters.AddWithValue("@StudentName", stu.Name);
                cmd.Parameters.AddWithValue("@Department", stu.Dept);

                int iAffectRows = cmd.ExecuteNonQuery();

                return (iAffectRows > 0) ? "" : "적용된 행 없음";
            }
            catch (Exception err)
            {
                //Debug.WriteLine(err.Message);
                return err.Message;
            }
        }

        public string Delete(int stuID)
        {
            try
            {
                string sql = "update student set Deleted = 1 where StudentID = @StudentID";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", stuID);

                int iAffectRows = cmd.ExecuteNonQuery();

                return (iAffectRows > 0) ? "" : "적용된 행 없음";
            }
            catch (Exception err)
            {
                //Debug.WriteLine(err.Message);
                return err.Message;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();

                string sql = "select StudentID, StudentName, Department from student where Deleted = 0";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(dt);

                return dt;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool IsValid(int stuID)
        {
            string sql = "select count(*) from student where deleted=0 and StudentID = @stuID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@stuID", stuID);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            return(cnt > 0);
        }
    }
}
