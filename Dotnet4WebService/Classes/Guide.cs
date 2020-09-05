using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Guide
    {
        SqlConnection con = new SqlConnection();

        public void Initializeconnection()
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

        public void GuideGet(int Guide_ID,out string Plant_Name, out string Guide_Content, out string Video_URL)
        {
            Initializeconnection();
            Plant_Name = "";
            Guide_Content = "";
            Video_URL = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GuideGet", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Guide_ID", Guide_ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Plant_Name = reader["Plant_Name"].ToString();
                    Guide_Content = reader["Guide_Content"].ToString();
                    Video_URL = reader["Video_URL"].ToString();





                }

                con.Close();
                cmd.Dispose();
                con.Dispose();

            }


        }

        public void GuideGetAll(out List<string> Guide_Name,out List<string> Plant_Name)
        {
            Initializeconnection();
            Guide_Name = new List<string>(); ;
            Plant_Name = new List<string>();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GuideGetAll", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Guide_Name.Add(reader["Guide_Name"].ToString());
                    Plant_Name.Add(reader["Plant_Name"].ToString());


                }

                con.Close();
                cmd.Dispose();
                con.Dispose();




            }








        }

        public int GuideGetID(string Guide_Name, string Plant_Name)
        {
            Initializeconnection();
            int x = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GuideGetID", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Guide_Name", Guide_Name);
            cmd.Parameters.AddWithValue("@Plant_Name", Plant_Name);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    x = int.Parse(reader["Guide_ID"].ToString());
                    


                }

                cmd.Dispose();
                con.Close();
                con.Dispose();


            }

            return x;


        }

        public void GuideGetByPlant(string Plant_Name, out List<string> Guide_Name,out List<string> Plant_Names)
        {
            Guide_Name = new List<string>();
            Plant_Names = new List<string>();

            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GuideGetByPlant", con)
            { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Plant_Name", Plant_Name);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Guide_Name.Add(reader["Guide_Name"].ToString());
                    Plant_Names.Add(reader["Plant_Name"].ToString());




                }
                con.Close();
                cmd.Dispose();
                con.Dispose();




            }






          

        }







    }
}
