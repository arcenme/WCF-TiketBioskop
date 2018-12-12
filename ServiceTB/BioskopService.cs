using System;
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

        public string CreateFilm(Bioskop bioskop)
        {
            string msg = "GAGAl Create Film";
            string query = String.Format("INSERT INTO Film (JudulFilm, Ratting, Aktor, Harga, Poster) VALUES ('{0}','{1}','{2}',{3},'{4}')",
                bioskop.JudulFilm, bioskop.Ratting, bioskop.Aktor, bioskop.Harga, bioskop.Poster);
            SqlCommand com = new SqlCommand(query, con);  //Comand

            try
            {
                con.Open();
                Console.WriteLine(query);
                com.ExecuteNonQuery();
                msg = "SUKSES Create Film";
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL Create Film";
            }
            con.Close();
            return msg;
        }

        public List<Bioskop> GetDataFIlm()
        {
            List<Bioskop> Listbskp = new List<Bioskop>();
            string query = String.Format("SELECT * FROM Film");
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop bio = new Bioskop();
                    bio.IDFilm = reader.GetInt32(0);
                    bio.JudulFilm = reader.GetString(1);
                    bio.Ratting = reader.GetString(2);
                    bio.Aktor = reader.GetString(3);
                    bio.Harga = reader.GetInt32(4);
                    bio.Poster = reader.GetString(5);
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

        public string EditFilm(Bioskop bioskop)
        {
            string msg = "GAGAl";
            string query = String.Format("UPDATE Film set JudulFilm = '{0}', Ratting = '{1}', Aktor = '{2}', Harga = {3}, Poster ='{4}' where IDFilm ={5}",
                bioskop.JudulFilm, bioskop.Ratting, bioskop.Aktor, bioskop.Harga, bioskop.Poster, bioskop.IDFilm);
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


        public string DeleteFilm(Bioskop bioskop)
        {
            string msg = "GAGAl";
            string query = String.Format("DELETE FROM Film WHERE IDFilm='{0}'", bioskop.IDBioskop);
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

        public string CreateKursi(Bioskop bioskop)
        {
            string msg = "GAGAl Create Kursi";
            string query = String.Format("INSERT INTO InputData (Nomor_Kursi, Ketersediaan, IDBioskop, JudulFilm, Tanggal, Jam) Values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                bioskop.Nomor_Kursi, bioskop.Ketersediaan, bioskop.IDBioskop, bioskop.JudulFilm, bioskop.Tanggal, bioskop.Jam);
            SqlCommand com = new SqlCommand(query, con);  //Comand

            try
            {
                con.Open();
                Console.WriteLine(query);
                com.ExecuteNonQuery();
                msg = "SUKSES Create Kursi";
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL Create Kursi";
            }
            con.Close();
            return msg;
        }

        public List<Bioskop> GetIDBioskop()
        {
            List<Bioskop> Listbskp = new List<Bioskop>();
            string query = String.Format("SELECT IDBioskop from Bioskop");
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop bio = new Bioskop();
                    bio.IDBioskop = reader.GetString(0);
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

        public Bioskop GetKursiBioskop(string IDBioskop)
        {
            Bioskop kursiBioskop = new Bioskop();
            string query = String.Format("SELECT Jumlah_Kursi from Bioskop where IDBioskop = '{0}'", IDBioskop);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    kursiBioskop.Jumlah_Kursi = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return kursiBioskop;
        }

        public List<Bioskop> GetJudulByBioskop(string IDBioskop)
        {
            List<Bioskop> JudulByID = new List<Bioskop>();
            string query = String.Format("SELECT DISTINCT JudulFilm from InputData where IDBioskop = '{0}'", IDBioskop);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop jdl = new Bioskop();
                    jdl.JudulFilm = reader.GetString(0);
                    JudulByID.Add(jdl);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return JudulByID;
        }

        public List<Bioskop> GetTanggalBy(string IDBioskop, string JudulFilm)
        {
            List<Bioskop> TanggaByID = new List<Bioskop>();
            string query = String.Format("SELECT DISTINCT Tanggal from InputData where IDBioskop = '{0}' AND JudulFilm = '{1}'", IDBioskop, JudulFilm);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop tanggal = new Bioskop();
                    tanggal.Tanggal = reader.GetString(0);
                    TanggaByID.Add(tanggal);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return TanggaByID;
        }

        public List<Bioskop> GetJamBy(string IDBioskop, string JudulFilm, string Tanggal)
        {
            List<Bioskop> JamBy = new List<Bioskop>();
            string query = String.Format("SELECT DISTINCT Jam from InputData where IDBioskop = '{0}' AND JudulFilm = '{1}' AND Tanggal = '{2}'", IDBioskop, JudulFilm, Tanggal);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop jam = new Bioskop();
                    jam.Jam = reader.GetString(0);
                    JamBy.Add(jam);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return JamBy;
        }

        public List<Bioskop> showKursi(string IDBioskop, string JudulFilm, string Tanggal, string Jam)
        {
            List<Bioskop> kursi = new List<Bioskop>();
            string query = String.Format("SELECT IDBioskop, JudulFilm, Nomor_Kursi, Ketersediaan from InputData where IDBioskop = '{0}' AND JudulFilm = '{1}' AND Tanggal = '{2}' AND Jam = '{3}'", IDBioskop, JudulFilm, Tanggal, Jam);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop data = new Bioskop();
                    data.IDBioskop = reader.GetString(0);
                    data.JudulFilm = reader.GetString(1);
                    data.Nomor_Kursi = reader.GetString(2);
                    data.Ketersediaan = reader.GetString(3);
                    kursi.Add(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return kursi;
        }

        public List<Bioskop> showJadwal(string IDBioskop, string JudulFilm)
        {
            List<Bioskop> Jadwal = new List<Bioskop>();
            string query = String.Format("Select DISTINCT IDBioskop, JudulFilm, Tanggal, Jam FROM InputData where IDBioskop = '{0}' AND JudulFilm = '{1}'", IDBioskop, JudulFilm);
            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Bioskop data = new Bioskop();
                    data.IDBioskop = reader.GetString(0);
                    data.JudulFilm = reader.GetString(1);
                    data.Tanggal = reader.GetString(2);
                    data.Jam = reader.GetString(3);
                    Jadwal.Add(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            con.Close();
            return Jadwal;
        }
    }
}
