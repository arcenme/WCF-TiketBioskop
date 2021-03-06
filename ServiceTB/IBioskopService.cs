﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;


namespace ServiceTB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBioskopService
    {
        //Ambil data bioskop
        [OperationContract]
        [WebGet(
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "Bioskop")]
        List<Bioskop> GetDataBioskop();

        //Membuat data bioskop
        [OperationContract]
        [WebInvoke(Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "Bioskop")]
        string CreateBioskop(Bioskop bioskop);

        //Edit data bioskop
        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "Bioskop/Edit")]
        string EditBioskop(Bioskop bioskop);

        //Hapus data bioskop
        [OperationContract]
        [WebInvoke(Method = "DELETE",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "Bioskop/Delete")]
        string DeleteBioskop(Bioskop bioskop);


        //Membuat data Film
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Film")]
        string CreateFilm(Bioskop bioskop);

        //Mengambil data Film
        [OperationContract]
        [WebGet(
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "Film")]
        List<Bioskop> GetDataFIlm();

        //Mengedit data Film
        [OperationContract]
        [WebInvoke(Method = "PUT",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           UriTemplate = "Film/Edit")]
        string EditFilm(Bioskop bioskop);

        //Menghapus data Film
        [OperationContract]
        [WebInvoke(Method = "DELETE",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          UriTemplate = "Film/Delete")]
        string DeleteFilm(Bioskop bioskop);

        //Membuat data jumlah Kursi
        [OperationContract]
        [WebInvoke(Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "Inputdata")]
        string CreateKursi(Bioskop bioskop);

        //Input Data
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Bioskop/IDBioskop")]
        List<Bioskop> GetIDBioskop();

        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Bioskop/IDBioskop={IDBioskop}")]
        Bioskop GetKursiBioskop(string IDBioskop);

        //Cek kursi
        //Get Judul by IDBisokop
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Kursi/IDBioskop={IDBioskop}")]
        List<Bioskop> GetJudulByBioskop(string IDBioskop);

        //Get Tanggal by
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Kursi/IDBioskop={IDBioskop}JudulFilm={JudulFilm}")]
        List<Bioskop> GetTanggalBy(string IDBioskop, string JudulFilm);

        //Get Jam by
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Kursi/IDBioskop={IDBioskop}JudulFilm={JudulFilm}Tanggal={Tanggal}")]
        List<Bioskop> GetJamBy(string IDBioskop, string JudulFilm, string Tanggal);

        //Show data kursi
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Kursi/IDBioskop={IDBioskop}JudulFilm={JudulFilm}Tanggal={Tanggal}Jam={Jam}")]
        List<Bioskop> showKursi(string IDBioskop, string JudulFilm, string Tanggal, string Jam);

        //Show data Jadwal
        [OperationContract]
        [WebGet(
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "Jadwal/IDBioskop={IDBioskop}JudulFilm={JudulFilm}")]
        List<Bioskop> showJadwal(string IDBioskop, string JudulFilm);

    }

    [DataContract]
    public class Bioskop
    {
        private string _IDBioskop, _NamaBioskop, _AlamatBioskop, _Nomor_Kursi, _Ketersediaan, _JudulFilm, _Ratting, _Aktor, _Tanggal, _Jam, _Poster, _Email, _Nama, _Password;
        private int _Jumlah_Kursi, _Harga, _IDFilm, _IDB;

        //Order, mengurutkan data yang dikirim
        [DataMember(Order = 0)]
        public string IDBioskop
        {
            get
            {
                return _IDBioskop;
            }

            set
            {
                _IDBioskop = value;
            }
        }


        [DataMember(Order = 1)]
        public string NamaBioskop
        {
            get
            {
                return _NamaBioskop;
            }

            set
            {
                _NamaBioskop = value;
            }
        }

        [DataMember(Order = 2)]
        public string AlamatBioskop
        {
            get
            {
                return _AlamatBioskop;
            }

            set
            {
                _AlamatBioskop = value;
            }
        }


        [DataMember(Order = 3)]
        public int Jumlah_Kursi
        {
            get
            {
                return _Jumlah_Kursi;
            }

            set
            {
                _Jumlah_Kursi = value;
            }
        }

        [DataMember(Order = 4)]
        public string Nomor_Kursi
        {
            get
            {
                return _Nomor_Kursi;
            }

            set
            {
                _Nomor_Kursi = value;
            }
        }


        [DataMember(Order = 5)]
        public string Ketersediaan
        {
            get
            {
                return _Ketersediaan;
            }

            set
            {
                _Ketersediaan = value;
            }
        }

        [DataMember(Order = 6)]
        public string JudulFilm
        {
            get
            {
                return _JudulFilm;
            }

            set
            {
                _JudulFilm = value;
            }
        }

        [DataMember(Order = 7)]
        public string Ratting
        {
            get
            {
                return _Ratting;
            }

            set
            {
                _Ratting = value;
            }
        }

        [DataMember(Order = 8)]
        public string Aktor
        {
            get
            {
                return _Aktor;
            }

            set
            {
                _Aktor = value;
            }
        }

        [DataMember(Order = 9)]
        public int Harga
        {
            get
            {
                return _Harga;
            }

            set
            {
                _Harga = value;
            }
        }


        [DataMember(Order = 10)]
        public int IDFilm
        {
            get
            {
                return _IDFilm;
            }

            set
            {
                _IDFilm = value;
            }
        }

        [DataMember(Order = 11)]
        public int IDB
        {
            get
            {
                return _IDB;
            }

            set
            {
                _IDB = value;
            }
        }

        [DataMember(Order = 12)]
        public string Tanggal
        {
            get
            {
                return _Tanggal;
            }

            set
            {
                _Tanggal = value;
            }
        }

        [DataMember(Order = 13)]
        public string Jam
        {
            get
            {
                return _Jam;
            }

            set
            {
                _Jam = value;
            }
        }

        [DataMember(Order = 14)]
        public string Poster
        {
            get
            {
                return _Poster;
            }

            set
            {
                _Poster = value;
            }
        }

        [DataMember(Order = 15)]
        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        [DataMember(Order = 16)]
        public string Nama
        {
            get
            {
                return _Nama;
            }

            set
            {
                _Nama = value;
            }
        }

        [DataMember(Order = 17)]
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }
    }
}
