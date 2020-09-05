using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Account
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

        public string AccountInsert(string Username,string Password, string Role, int Person_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountInsert", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Role", Role);
            cmd.Parameters.AddWithValue("@Person_ID", Person_ID);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            con.Dispose();

            return "Account added successfully!";
                





        }

        public string AccountDelete(int Account_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountDelete", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Account deleted successfully!";




        }

        public int AccountGetID(string Username)
        {
            Initializeconnection();
            int x = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountGetID", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", Username);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    x = int.Parse(reader["Account_ID"].ToString());
                }

                con.Close();
                cmd.Dispose();
                con.Dispose();

            }

            return x;




        }

        public void AccountGetInfo(int Account_ID,out string Username, out string Password, out string Role, out int Person_ID, out int Spam_Counter)
        {
            Initializeconnection();
            Username = "";
            Password = "";
            Role = "";
            Person_ID = 1;
            Spam_Counter = 0;

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountGetInfo", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    Role = reader["Role"].ToString();
                    Person_ID = int.Parse(reader["Person_ID"].ToString());
                    Spam_Counter = int.Parse(reader["Spam_Counter"].ToString());
                }

                con.Close();
                cmd.Dispose();
                con.Dispose();
            }



        
        
        
        
        
        
        
        
        }

        public string AccountUpdate(string Username, string Password,string Role,int Account_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountUpdate", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Username",Username);
            cmd.Parameters.AddWithValue("@Password",Password);
            cmd.Parameters.AddWithValue("@Role",Role);
            cmd.Parameters.AddWithValue("@Account_ID",Account_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
            return "Account Updated!";
                
        }

        public string AccountUpdateSpamCounter(int Account_ID, int Spam_Counter)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountUpdateSpamCounter", con);
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            cmd.Parameters.AddWithValue("@Spam_Counter", Spam_Counter);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

            return "Spam Counter Updated!";



        }

       public int AccountGetSpamCounter(int Account_ID)
        {
            int x = 0;
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AccountGetSpamCounter", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Account_ID", Account_ID);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = int.Parse(reader["Spam_Counter"].ToString());


                }
                con.Close();
                cmd.Dispose();
                con.Dispose();




            }

            return x;




        }











    }
}
