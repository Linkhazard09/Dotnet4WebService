using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Comment
    {
        SqlConnection con = new SqlConnection();

        private void Initializeconnection()
        {
            SqlConnectionStringBuilder constring = new SqlConnectionStringBuilder();
            constring.DataSource = "DESKTOP-3B1OFSU\\SQLEXPRESS";
            constring.UserID = "mpaladine15";
            constring.Password = "Hello_World1234";
            constring.InitialCatalog = "Plantarium";
            constring.IntegratedSecurity = false;
            SqlConnection con = new SqlConnection(constring.ConnectionString);
            this.con = con;
        }

        public string CommentDelete(int Comment_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CommentDelete", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Comment_ID", Comment_ID);
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            cmd.Dispose();
            return "Comment Deleted!";




        }

        public void CommentGetForForum(int Forum_ID, out List<string> Username, out List<string> Date, out List<string> Time, out List<string> Comment_Content)
        {
            Username = new List<string>();
            Date =  new List<string>();
            Time = new List<string>();
            Comment_Content = new List<string>();


            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CommentGetForForum", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   Username.Add(reader["Username"].ToString());
                     Date.Add(reader["Date"].ToString());
                    Time.Add(reader["Time"].ToString());
                    Comment_Content.Add(reader["Comment_Content"].ToString());

                }

                con.Close();
                con.Dispose();
                cmd.Dispose();

            }
                



        }

        public int CommentGetID(int Account_ID, int Forum_ID, string Time)
        {
            int x = 0;
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CommentGetID", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            cmd.Parameters.AddWithValue("@Time", Time);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = int.Parse(reader["Comment_ID"].ToString());


                }


                con.Close();
                con.Dispose();
                cmd.Dispose();


            }

            return x;



        }

        public string CommentInsert(string Date, string Time, string Comment_Content, int Account_ID, int Forum_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CommentInsert", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Comment_Content", Comment_Content);
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
            cmd.Dispose();

            return "Comment Posted!";







        }

        public string CommentUpdate(int Comment_ID, string Comment_Content)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_CommentUpdate", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Comment_ID", Comment_ID);
            cmd.Parameters.AddWithValue("@Comment_Content", Comment_Content);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Comment Updated!";





        }











    }
}
