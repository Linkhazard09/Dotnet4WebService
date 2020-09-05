using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Feedback
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

        public string FeedbackDelete(int Feedback_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_FeedbackDelete", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Feedback_ID", Feedback_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Feedback deleted!";



        }

        public void FeedbackGet(int Feedback_ID, out string Date, out string Time, out string Feedback_Content, out int Rating)
        {
            con.Open();
            Initializeconnection();
            Date = "";
            Time = "";
            Feedback_Content = "";
            Rating = 1;
            SqlCommand cmd = new SqlCommand("sp_FeedbackGet", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Feedback_ID", Feedback_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Date = reader["Date"].ToString();
                    Time = reader["Time"].ToString();
                    Feedback_Content = reader["Feedback_Content"].ToString();
                    Rating = int.Parse(reader["Rating"].ToString());
                }

                con.Close();
                cmd.Dispose();
                con.Dispose();



            }






        }

        public int FeedbackGetID(int Account_ID, int Guide_ID)
        {
            int x = 0;
            Initializeconnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("sp_FeedbackGetID", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            cmd.Parameters.AddWithValue("@Guide_ID", Guide_ID);
             using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    x = int.Parse(reader["Feedback_ID"].ToString());




                }

                con.Close();
                cmd.Dispose();
                con.Dispose();
            }

            return x;




        }

        public string FeedbackInsert(string Date, string Time, string Feedback_Content, int Account_ID, int Guide_ID, int Rating)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_FeedbackInsert", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Date",Date);
            cmd.Parameters.AddWithValue("@Time",Time);
            cmd.Parameters.AddWithValue("@Feedback_Content",Feedback_Content);
            cmd.Parameters.AddWithValue("@Account_ID",Account_ID);
            cmd.Parameters.AddWithValue("@Guide_ID",Guide_ID);
            cmd.Parameters.AddWithValue("@Rating",Rating);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Feedback added!";

        }

        public string FeedbackUpdate(int Feedback_ID, string Feedback_Content, int Rating)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_FeedbackUpdate", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Feedback_ID",Feedback_ID);
            cmd.Parameters.AddWithValue("@Feedback_Content",Feedback_Content);
            cmd.Parameters.AddWithValue("@Rating",Rating);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Feedback Updated!";



        }

        public void FeedbackGetAll(int Guide_ID,out List<string> Username, out List<string> Date, out List<string> Time, out List<string> Feedback_Content, out List<string> Rating)
        {
            Username = new List<string>();
            Date = new List<string>();
            Time = new List<string>();
            Feedback_Content = new List<string>();
            Rating = new List<string>();
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_FeedbackGetAll", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Guide_ID", Guide_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Username.Add(reader["Username"].ToString());
                    Date.Add(reader["Date"].ToString());
                    Time.Add(reader["Time"].ToString());
                    Feedback_Content.Add(reader["Feedback_Content"].ToString());
                    Rating.Add(reader["Rating"].ToString());



                }

                cmd.Dispose();
                con.Close();
                con.Dispose();


            }



        }






    }
}
