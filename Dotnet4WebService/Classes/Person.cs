using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Dotnet4WebService
{
    class Person
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

        public string InsertPerson(string LastName, string GivenName, string MiddleName, int SuffixID, string EmailAddress)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PersonInsert", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Last_Name",LastName);
            cmd.Parameters.AddWithValue("@Given_Name",GivenName);
            cmd.Parameters.AddWithValue("@Middle_Name",MiddleName);
            cmd.Parameters.AddWithValue("@Suffix_ID",SuffixID);
            cmd.Parameters.AddWithValue("@Email_Address",EmailAddress);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            return "Person Added Successfully!";



        }

        public void PersonGet(int Person_ID,out string Last_Name, out string Given_Name, out string Middle_Name, out string Suffix_Name, out string Email_Address )
        {
            Initializeconnection();
            con.Open();
            Last_Name = "";
            Given_Name = "";
            Middle_Name = "";
            Suffix_Name = "";
            Email_Address = "";
            SqlCommand cmd = new SqlCommand("sp_PersonGet", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Person_ID",Person_ID);
             using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Last_Name = reader["Last_Name"].ToString();
                    Given_Name = reader["Given_Name"].ToString();
                    Middle_Name = reader["Middle_Name"].ToString();
                    Suffix_Name = reader["Suffix_Name"].ToString();
                    Email_Address = reader["Email_Address"].ToString();
                }

                con.Close();
                cmd.Dispose();
                con.Dispose();

            }


            




        }

        public int PersonGetID(string Email_Address)
        {
            Initializeconnection();
            con.Open();
            int PID = 0;
            SqlCommand cmd = new SqlCommand("sp_PersonGetID", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Email_Address", Email_Address);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    PID = int.Parse(reader["Person_ID"].ToString());
                }

                con.Close();
                cmd.Dispose();
                con.Dispose();

            }

            return PID;



        }

        public string PersonDelete(int Person_ID)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PersonDelete",con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Person_ID", Person_ID);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            con.Dispose();
            return "Personal Information Deleted Successfully!";
        
        
        
        
        
        
        }

        public string PersonUpdate(int Person_ID, string Last_Name, string Given_Name, string Middle_Name, int Suffix_ID, string Email_Address)
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_PersonUpdate", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Person_ID",Person_ID);
            cmd.Parameters.AddWithValue("@Last_Name",Last_Name);
            cmd.Parameters.AddWithValue("@Given_Name",Given_Name);
            cmd.Parameters.AddWithValue("@Middle_Name",Middle_Name);
            cmd.Parameters.AddWithValue("@Suffix_ID",Suffix_ID);
            cmd.Parameters.AddWithValue("@Email_Address",Email_Address);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();


            con.Dispose();
            return "Personal information updated!";










        }


        public string SuffixGet(int Suffix_ID)
        {
            Initializeconnection();
            string x = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_SuffixGet", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Suffix_ID", Suffix_ID);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = reader["Suffix_Name"].ToString();
                }

                cmd.Dispose();
                con.Close();
                con.Dispose();
            }

            return x;


        }

        public int SuffixGetID(string Suffix_Name)
        {
            Initializeconnection();
            con.Open();
            int x = 0;
            SqlCommand cmd = new SqlCommand("sp_SuffixGetID", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Suffix_Name", Suffix_Name);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = int.Parse(reader["Suffix_ID"].ToString());





                }
                cmd.Dispose();
                con.Close();
                con.Dispose();



            }
            return x;


        }









    }
}
