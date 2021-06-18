using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace LendBook.DAC
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserAuth { get; set; }
        public string IsAdmin { get; set; }
    }

    public class UserDAC :IDisposable
    {
        MySqlConnection conn;

        public UserDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["gudi"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public bool SearchPwd(string id, string name, string email)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select count(*) from usertbl where userid=@id and name=@name and email=@email";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return (cnt > 0);
        }

        public bool UpdatePwd(string id, string newPwd)
        {
            string sql = "update usertbl set pwd=@pwd where userid=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@pwd", newPwd);
            cmd.Parameters.AddWithValue("@id", id);
            int rowAffect = cmd.ExecuteNonQuery();
            return (rowAffect > 0);
        }
    }
}
