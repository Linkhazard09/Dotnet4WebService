using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet4WebService.Classes
{
    class Photo
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

        public void InsertPhoto(byte [] Image, int Forum_ID )
        {
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_InsertPhoto", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Photo", Image);
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();




        }

        public void GetPhoto(out byte[] Image,int Forum_ID)
        {
            Image = null;
            Initializeconnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetPhoto", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Forum_ID", Forum_ID);


            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Image = ObjectToByteArray(reader["Photo"]);



            }


           


        }

       private byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }










    }
}
