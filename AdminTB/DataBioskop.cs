using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AdminTB
{
    [DataContract]
    public class DataBioskop
    {
        [DataMember]
        public int IDFilm { get; set; }

        [DataMember]
        public int IDB { get; set; }

        [DataMember]
        public string IDBioskop { get; set; }

        [DataMember]
        public string NamaBioskop { get; set; }

        [DataMember]
        public string AlamatBioskop { get; set; }

        [DataMember]
        public string JudulFilm { get; set; }

        [DataMember]
        public string Aktor { get; set; }

        [DataMember]
        public string Ratting { get; set; }

        [DataMember]
        public string Ringkasan { get; set; }

        [DataMember]
        public string Tanggal { get; set; }

        [DataMember]
        public string Jam { get; set; }

        [DataMember]
        public string Nomor_Kursi { get; set; }

        [DataMember]
        public int Harga { get; set; }

        [DataMember]
        public int Jumlah_Kursi { get; set; }

        [DataMember]
        public string Ketersediaan { get; set; }

        [DataMember]
        public string Poster { get; set; }
    }
}
