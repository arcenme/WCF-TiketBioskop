﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace ServiceTB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class BioskopService : IBioskopService
    {
        //sambungkan dengan SQL Database
        SqlConnection con = new SqlConnection(@"Data Source=GRIZZLY\ARISUSENO;Initial Catalog=CoEgg;User ID=sa;Password=vaticanCame0s");

        public string CreateBioskop(Bioskop bioskop)
        {
            string msg = "GAGAl Create Bioskop";
            string query = String.Format("INSERT INTO Bioskop (IDBioskop, NamaBioskop, AlamatBioskop, Jumlah_Kursi) VALUES ('{0}','{1}','{2}',{3})", bioskop.IDBioskop, bioskop.NamaBioskop, bioskop.AlamatBioskop, bioskop.Jumlah_Kursi);
            SqlCommand com = new SqlCommand(query, con);  //Comand

            try
            {
                con.Open();
                Console.WriteLine(query);
                com.ExecuteNonQuery();
                msg = "SUKSES Create Bioskkop";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL Create Bioskop";
            }
            con.Close();
            return msg;
        }

        public List<Bioskop> GetDataBioskop()
        {
            List<Bioskop> Listbskp = new List<Bioskop>();
            string query = String.Format("SELECT * FROM Bioskop");
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop bio = new Bioskop();
                    bio.IDB = reader.GetInt32(0);
                    bio.IDBioskop = reader.GetString(1);
                    bio.NamaBioskop = reader.GetString(2);
                    bio.AlamatBioskop = reader.GetString(3);
                    bio.Jumlah_Kursi = reader.GetInt32(4);
                    Listbskp.Add(bio);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return Listbskp;
        }

        public string EditBioskop(Bioskop bioskop)
        {
            string msg = "GAGAl";
            string query = String.Format("UPDATE Bioskop SET IDBioskop = '{0}', NamaBioskop = '{1}', AlamatBioskop = '{2}', Jumlah_Kursi = {3} WHERE IDBioskop = '{0}'",
                bioskop.IDBioskop, bioskop.NamaBioskop, bioskop.AlamatBioskop, bioskop.Jumlah_Kursi);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                Console.WriteLine(query);
                com.ExecuteNonQuery();
                msg = "SUKSES";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }
            con.Close();
            return msg;
        }

        public string DeleteBioskop(Bioskop bioskop)
        {
            string msg = "GAGAl";
            string query = String.Format("DELETE FROM Bioskop WHERE IDB={0}", bioskop.IDBioskop);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                Console.WriteLine(query);
                com.ExecuteNonQuery();
                msg = "SUKSES";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }
            con.Close();
            return msg;
        }
    }
}
