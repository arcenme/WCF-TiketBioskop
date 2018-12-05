using System;
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
    public interface IServiceTB
    {
       

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
