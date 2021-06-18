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
    public struct Book
    {
        public int Bookid;
        public string BookName;
        public string Author;
        public string Publisher;
    }

    public class BookDAC : IDisposable
    {
        private MySqlConnection conn;

        public BookDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetAll()
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            string sql = $@"SELECT BookID, BookName, Author, Publisher,  
                    case when IFNULL(LendingState, 0) = 0 then '대여가능'
			            else '대여중' end LendingState, 
	                ReservStuID 
                FROM BOOK 
                WHERE Deleted=0";

            da.SelectCommand = new MySqlCommand(sql, conn);
            da.Fill(ds, "Book");

            return ds.Tables["Book"];
        }

        public void Insert(Book bk)
        {
            string sql = $@"INSERT INTO book(BookName, Author, Publisher) 
                            VALUES (@BookName, @Author, @Publisher)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BookName", bk.BookName);
            cmd.Parameters.AddWithValue("@Author", bk.Author);
            cmd.Parameters.AddWithValue("@Publisher", bk.Publisher);

            cmd.ExecuteNonQuery();
        }

        public int Update(Book bk)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE book SET BookName=@BookName,Author=@Author,Publisher=@Publisher WHERE BookID=@BookID";

            cmd.Parameters.AddWithValue("@BookName", bk.BookName);
            cmd.Parameters.AddWithValue("@Author", bk.Author);
            cmd.Parameters.AddWithValue("@Publisher", bk.Publisher);
            cmd.Parameters.AddWithValue("@BookID", bk.Bookid);

            return cmd.ExecuteNonQuery();
        }

        public int Delete(int bkID)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = $"UPDATE book SET deleted=1 WHERE BookID=@BookID";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@BookID", bkID);

            return cmd.ExecuteNonQuery();
        }

        //도서번호가 유효하면 true
        public bool IsValid(int bookID)
        {
            string sql = "SELECT count(*) FROM book where Deleted = 0 and bookid = @bookID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookID", bookID);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            return (cnt > 0);
        }

        //대여중이면 true
        public bool IsLended(int bookID)
        {
            string sql = "SELECT ifnull(LendingState, 0) LendingState FROM book where Deleted = 0 and bookid=@bookID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookID", bookID);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            return (cnt > 0);
        }

        //예약중이면 true
        public bool IsReserved(int bookID)
        {
            string sql = "SELECT ifnull(ReservStuID, 0) ReservStuID FROM book where Deleted = 0 and bookid=@bookID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookID", bookID);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            return (cnt > 0);
        }

        //예약학번을 리턴 (예약이 없는 경우는 0)
        public int GetReserveStuID(int bookID)
        {
            string sql = "SELECT ifnull(ReservStuID, 0) ReservStuID FROM book where Deleted = 0 and bookid=@bookID";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookID", bookID);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        //도서번호에 해당하는 도서정보를 반환
        public Book GetBookInfo(int bookID)
        {
            string sql = "select BookID, BookName, Author, Publisher from book where bookid = @bookid";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@bookid", bookID);
            MySqlDataReader reader = cmd.ExecuteReader();

            Book bk = new Book();            
            if (reader.Read())
            {                
                bk.Bookid = Convert.ToInt32(reader["BookID"]);
                bk.BookName = reader["BookName"].ToString();
                bk.Author = reader["Author"].ToString();
                bk.Publisher = reader["Publisher"].ToString();                
            }
            return bk;
        }
    }
}
