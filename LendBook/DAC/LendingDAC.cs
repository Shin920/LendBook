using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace LendBook.DAC
{
    public class LendingDAC : IDisposable
    {
        MySqlConnection conn;

        public LendingDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public void LendBook(int stuID, int[] bookIDs)
        {
            //Lending insert 1건
            //LendingItem insert 여러건
            //Book update 여러건
            //트랜잭션 : 여러개의 커맨드를 하나의 단위로 묶어서 처리
            //   Commit() => 마지막에 한번만 실행. try구문의 제일 마지막에서 실행
            //   RollBack() => catch구문에서 실행. 지금까지 실행되었던것 모두 취소

            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into lending (LendDate, StudentID) values (now(), @StudentID);select last_insert_id();";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentID", stuID);
                cmd.Transaction = trans;
                int newLendingID = Convert.ToInt32(cmd.ExecuteScalar());

                string sql = "insert into lendingitem (LendingID, BookItem, BookID) values(@LendingID, @BookItem, @BookID)";
                cmd.Parameters.Add("@LendingID", MySqlDbType.Int32);
                cmd.Parameters.Add("@BookItem", MySqlDbType.Int32);
                cmd.Parameters.Add("@BookID", MySqlDbType.Int32);

                cmd.CommandText = sql;

                string uSql = "update book set LendingState = 1 where BookID = @BookID";
                MySqlCommand u_cmd = new MySqlCommand(uSql, conn);
                u_cmd.Transaction = trans;
                u_cmd.Parameters.Add("@BookID", MySqlDbType.Int32);

                string ur_Sql = "update book set ReservStuID = 0 where BookID = @BookID and ReservStuID = @StudentID";
                MySqlCommand ur_cmd = new MySqlCommand(ur_Sql, conn);
                ur_cmd.Transaction = trans;
                ur_cmd.Parameters.Add("@BookID", MySqlDbType.Int32);
                ur_cmd.Parameters.Add("@StudentID", MySqlDbType.Int32);

                for (int i=0; i<bookIDs.Length; i++)
                {                       
                    cmd.Parameters["@LendingID"].Value = newLendingID;
                    cmd.Parameters["@BookItem"].Value = i+1;
                    cmd.Parameters["@BookID"].Value = bookIDs[i];
                    cmd.ExecuteNonQuery();

                    u_cmd.Parameters["@BookID"].Value = bookIDs[i];
                    u_cmd.ExecuteNonQuery();

                    ur_cmd.Parameters["@BookID"].Value = bookIDs[i];
                    ur_cmd.Parameters["@StudentID"].Value = stuID;
                    ur_cmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch(Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }

        public DataTable GetLendAll()
        {
            DataTable dt = new DataTable();

            string sql = @"select b.BookID, BookName, Author, Publisher, 
       ifnull(LendingState, 0) LendingState, 
       ifnull(StudentID, 0) StudentID, 
       ifnull(ReservStuID, 0) ReservStuID
from book b left outer join (select bookID, max(lendingID) lendingID
from lendingitem
group by bookID) t on b.BookID = t.BookID
    left outer join lending l on t.LendingID = l.LendingID
where Deleted = 0";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }

        public void ReturnBook(int bookID)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                //Book 테이블 update 1번
                string sql = "update Book set LendingState=0 where BookID=@bookID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                //LendingItem 테이블 update 1번
                cmd.CommandText = "update lendingitem set ReturnDate = now() where BookID=@bookID and ReturnDate is null";
                cmd.ExecuteNonQuery();

                trans.Commit();
            }
            catch(Exception err)
            {
                trans.Rollback();
                throw err;                
            }
        }

        public bool ReserveBook(int stuid, int bookid)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "update book set ReservStuID = @studentID where BookID = @bookID";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@studentID", stuid);
            cmd.Parameters.AddWithValue("@bookID", bookid);

            int iCnt = cmd.ExecuteNonQuery();

            return (iCnt > 0);
        }
    }
}
