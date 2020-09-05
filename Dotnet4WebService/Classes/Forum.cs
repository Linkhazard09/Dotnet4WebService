using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Forum
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

        public string ForumDelete(int Forum_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumDelete")
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return "Forum Deleted!";







        }

        public void ForumGet(int Forum_ID,out string Forum_Content,out string Date,out string Time)
        {
            Forum_Content = "";
            Date = "";
            Time = "";
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumGet", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Forum_Content = reader["Forum_Content"].ToString();
                    Date = reader["Date"].ToString();
                    Time = reader["Time"].ToString();
                }
                con.Close();
                cmd.Dispose();
                con.Dispose();



            }








        }

        public void ForumGetHeader(out List<string> Username, out List<string> Date, out List<string> Headline, out List<string> Time)
        {
            Username = new List<string>();
            Date = new List<string>();
            Headline = new List<string>();
            Time = new List<string>();
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumGetHeader",con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Username.Add(reader["Username"].ToString());
                    Date.Add(reader["Date"].ToString());
                    Time.Add(reader["Time"].ToString());
                    Headline.Add(reader["Headline"].ToString());







                }
                con.Close();
                con.Dispose();
                cmd.Dispose();




            }


            con.Close();
            cmd.Dispose();
            con.Close();







        }

        public int ForumGetID(string Headline, int Account_ID)
        {
            Initializeconnection();
            int x = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumGetID", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Headline", Headline);
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = int.Parse(reader["Forum_ID"].ToString());



                }

                con.Close();
                con.Dispose();
                cmd.Dispose();




            }
            return x;



        }

        public string ForumInsert(string Headline, string Forum_Content, string Date, string Time, int Account_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumInsert", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Headline",Headline);
            cmd.Parameters.AddWithValue("@Forum_Content",Forum_Content);
            cmd.Parameters.AddWithValue("@Date",Date);
            cmd.Parameters.AddWithValue("@Time",Time);
            cmd.Parameters.AddWithValue("@Account_ID",Account_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return "Forum Created!";







        }

        public string ForumUpdate(int Forum_ID, string Headline, string Forum_Content)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_ForumUpdate", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            cmd.Parameters.AddWithValue("@Headline", Headline);
            cmd.Parameters.AddWithValue("@Forum_Content", Forum_Content);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Forum information updated!";


        }





    }
}
