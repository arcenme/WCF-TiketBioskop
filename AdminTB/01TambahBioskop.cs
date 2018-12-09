using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using Newtonsoft.Json;

namespace AdminTB
{
    public partial class _01TambahBioskop : Form
    {
        string BaseAddress = "http://localhost:8080/";
        string _IDB, _IDFilm;
        public _01TambahBioskop()
        {
            InitializeComponent();
        }
         
        private void _01TambahBioskop_Load(object sender, EventArgs e)
        {
           
            panelBioskop.Visible = true;
            panelDataBioskop.Visible = false;
            
        }

        private void TambahBioskop_Click(object sender, EventArgs e)
        {

        }

        private void EditBioskop_Click(object sender, EventArgs e)
        {
            try
            {
                
                panelBioskop.Visible = false;
                panelDataBioskop.Visible = true;
                
                //Get Data
                var listbskp = listViewBioskop.SelectedItems[0];
                string IDBioskop = listbskp.SubItems[1].Text;
                string NamaBioskop = listbskp.SubItems[2].Text;
                string AlamatBisokop = listbskp.SubItems[3].Text;
                string Jumlah_Kursi = listbskp.SubItems[4].Text;
                _IDB = listbskp.SubItems[0].Text;

                panelDataBioskop.Visible = false;
                panelEditBioskop.Visible = true;

                EditIDBskp.AppendText(IDBioskop);
                EditNamaBskp.AppendText(NamaBioskop);
                EditAlamatBskp.AppendText(AlamatBisokop);
                EditKapasitasBskp.AppendText(Jumlah_Kursi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chose Data", "Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HapusBioskop_Click(object sender, EventArgs e)
        {
            try
            {
                var listbskp = listViewBioskop.SelectedItems[0];
                string IDBioskop = listbskp.SubItems[0].Text;

                DataBioskop DBBskp = new DataBioskop();
                DBBskp.IDBioskop = IDBioskop;

                var dataPut = JsonConvert.SerializeObject(DBBskp);
                var Json = new WebClient();
                Json.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                string response = Json.UploadString(BaseAddress + "Bioskop/Delete", "DELETE", dataPut);
                Console.WriteLine(response);
                MessageBox.Show("Sukses", "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kembaliBioskop_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void KonfirmasiBioskop_Click(object sender, EventArgs e)
        {
            try
            {
                DataBioskop DBBskp = new DataBioskop();
                DBBskp.IDBioskop = textBoxIDBioskop.Text;
                DBBskp.NamaBioskop = textBoxNamaBioskop.Text;
                DBBskp.AlamatBioskop = textBoxAlamatBioskop.Text;
                DBBskp.Jumlah_Kursi = Int32.Parse(CmBoxKapasitas.Text);

                //Not Null
                if (!DBBskp.IDBioskop.Equals("") || DBBskp.NamaBioskop.Equals("") || DBBskp.AlamatBioskop.Equals("") || DBBskp.Jumlah_Kursi.Equals(""))
                {
                    var dataBioskop = JsonConvert.SerializeObject(DBBskp);
                    var JsonBioskop = new WebClient();
                    JsonBioskop.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    string responseBioskop = JsonBioskop.UploadString(BaseAddress + "Bioskop", dataBioskop);
                    Console.WriteLine(responseBioskop);

                    MessageBox.Show("Sukses", "Create Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxIDBioskop.Text = "";
                    textBoxNamaBioskop.Text = "";
                    textBoxAlamatBioskop.Text = "";
                    CmBoxKapasitas.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert Data", "Create Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BatalBioskop_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LihatDataBioskop_Click(object sender, EventArgs e)
        {
            try
            {
                panelBioskop.Visible = false;
                panelDataBioskop.Visible = true;
                panelEditBioskop.Visible = false;

                listViewBioskop.Items.Clear();
                var json = new WebClient().DownloadString(BaseAddress + "Bioskop");
                var data = JsonConvert.DeserializeObject<List<DataBioskop>>(json);
                foreach (var bskp in data)
                {
                    ListViewItem dataBioskop = new ListViewItem(Convert.ToString(bskp.IDB));
                    dataBioskop.SubItems.Add(bskp.IDBioskop);
                    dataBioskop.SubItems.Add(bskp.NamaBioskop);
                    dataBioskop.SubItems.Add(bskp.AlamatBioskop);
                    dataBioskop.SubItems.Add(Convert.ToString(bskp.Jumlah_Kursi));
                    listViewBioskop.Items.Add(dataBioskop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KonfirmasiEditBskp_Click(object sender, EventArgs e)
        {
            try
            {
                DataBioskop DBBskp = new DataBioskop();
                DBBskp.IDBioskop = EditIDBskp.Text;
                DBBskp.NamaBioskop = EditNamaBskp.Text;
                DBBskp.AlamatBioskop = EditAlamatBskp.Text;
                DBBskp.Jumlah_Kursi = Int32.Parse(EditKapasitasBskp.Text);
                var dataPut = JsonConvert.SerializeObject(DBBskp);
                var Json = new WebClient();
                Json.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                string response = Json.UploadString(BaseAddress + "Bioskop/Edit", "PUT", dataPut);
                Console.WriteLine(response);
                MessageBox.Show("Sukses", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BatalFilm_Click(object sender, EventArgs e)
        {

        }

        private void KonfirmasiFilm_Click(object sender, EventArgs e)
        {
            try
            {
                DataBioskop DBFilm = new DataBioskop();
                DBFilm.JudulFilm = textBoxJudulFilm.Text;
                DBFilm.Ratting = textBoxRatting.Text;
                DBFilm.Aktor = textBoxAktor.Text;
                DBFilm.Harga = Int32.Parse(textBoxHarga.Text);
                DBFilm.Poster = TxtBoxPoster.Text;
                if (!DBFilm.JudulFilm.Equals("") || DBFilm.Ratting.Equals("") || DBFilm.Aktor.Equals("") || DBFilm.Harga.Equals("") || DBFilm.Poster.Equals(""))
                {
                    var dataFilm = JsonConvert.SerializeObject(DBFilm);
                    var JsonFilm = new WebClient();
                    JsonFilm.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                    string responseKursi = JsonFilm.UploadString(BaseAddress + "Film", dataFilm);
                    Console.WriteLine(responseKursi);

                    MessageBox.Show("Sukses", "Create Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxJudulFilm.Text = "";
                    textBoxRatting.Text = "";
                    textBoxAktor.Text = "";
                    textBoxHarga.Text = "";
                    TxtBoxPoster.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert Data", "Create Film", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Film", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TambahFilm_Click(object sender, EventArgs e)
        {
            panelBioskop.Visible = false;
            panelDataBioskop.Visible = false;
            panelDataFilm.Visible = false;
            panelEditBioskop.Visible = false;
            panelEditFilm.Visible = false;
            panelFilm.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var listFilm = listViewFilm.SelectedItems[0];
                _IDFilm = listFilm.SubItems[0].Text;

                DataBioskop DBBskp = new DataBioskop();
                DBBskp.IDBioskop = _IDFilm;

                var dataPut = JsonConvert.SerializeObject(DBBskp);
                var Json = new WebClient();
                Json.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                string response = Json.UploadString(BaseAddress + "Film/Delete", "DELETE", dataPut);
                Console.WriteLine(response);
                MessageBox.Show("Sukses", "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hapus Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelBioskop.Visible = false;
            panelDataBioskop.Visible = false;
            panelDataFilm.Visible = true;
            panelEditBioskop.Visible = false;
            panelEditFilm.Visible = false;
            panelFilm.Visible = false;
            try
            {
                //Get Data
                var listFilm = listViewFilm.SelectedItems[0];
                string judulfilm = listFilm.SubItems[1].Text;
                string ratting = listFilm.SubItems[2].Text;
                string aktor = listFilm.SubItems[3].Text;
                string harga = listFilm.SubItems[4].Text;
                string poster = listFilm.SubItems[5].Text;
                _IDFilm = listFilm.SubItems[0].Text;

                panelDataFilm.Visible = false;
                panelEditFilm.Visible = true;

                textBoxEditJdlFlm.AppendText(judulfilm);
                textBoxEditRatting.AppendText(ratting);
                textBoxEditAktor.AppendText(aktor);
                textBoxEdittHarga.AppendText(harga);
                TxtBoxEditPoster.AppendText(poster);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chose Data", "Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LihatDataFilm_Click(object sender, EventArgs e)
        {
            try
            {
                panelBioskop.Visible = false;
                panelFilm.Visible = false;
                panelDataBioskop.Visible = false;
                panelDataFilm.Visible = true;
                listViewFilm.Items.Clear();

                var json = new WebClient().DownloadString(BaseAddress + "Film");
                var data = JsonConvert.DeserializeObject<List<DataBioskop>>(json);
                foreach (var film in data)
                {
                    ListViewItem dataFilm = new ListViewItem(Convert.ToString(film.IDFilm));
                    dataFilm.SubItems.Add(film.JudulFilm);
                    dataFilm.SubItems.Add(film.Ratting);
                    dataFilm.SubItems.Add(film.Aktor);
                    dataFilm.SubItems.Add(Convert.ToString(film.Harga));
                    dataFilm.SubItems.Add(film.Poster);
                    listViewFilm.Items.Add(dataFilm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Show Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void buttonInput_Click(object sender, EventArgs e)
        {
            try
            {
                panelBioskop.Visible = false;
                panelDataBioskop.Visible = false;
                panelDataFilm.Visible = false;
                panelEditBioskop.Visible = false;
                panelEditFilm.Visible = false;
                panelFilm.Visible = false;
                panelJadwal.Visible = false;
                panelKursi.Visible = false;
                panelSign.Visible = true;

                var jsonID = new WebClient().DownloadString(BaseAddress + "Bioskop/IDBioskop");
                var dataID = JsonConvert.DeserializeObject<List<DataBioskop>>(jsonID);
                comboBoxIDBioskop.Items.Clear();
                foreach (var bskp in dataID)
                {
                    comboBoxIDBioskop.Items.Add(bskp.IDBioskop);
                }

                var json = new WebClient().DownloadString(BaseAddress + "Film");
                var data = JsonConvert.DeserializeObject<List<DataBioskop>>(json);
                comboBoxJudulFilm.Items.Clear();
                foreach (var film in data)
                {
                    comboBoxJudulFilm.Items.Add(film.JudulFilm);
                }

                comboBoxJam.Items.Clear();
                for (int x = 1; x <= 24; x++)
                {
                    comboBoxJam.Items.Add(x);
                }

                comboBoxMenit.Items.Clear();
                for (int x = 1; x <= 60; x++)
                {
                    comboBoxMenit.Items.Add(x);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                _IDB = comboBoxIDBioskop.Text;
                int jumlahKursi;
                string jam = comboBoxJam.Text;
                string menit = comboBoxMenit.Text;
                string waktu = jam + ":" + menit;

                var json = new WebClient().DownloadString(BaseAddress + "Bioskop/IDBioskop=" + _IDB);
                DataBioskop bskp = JsonConvert.DeserializeObject<DataBioskop>(json);
                jumlahKursi = bskp.Jumlah_Kursi;

                DataBioskop DBInput = new DataBioskop();

                DBInput.Ketersediaan = "Y";
                DBInput.IDBioskop = _IDB;
                DBInput.JudulFilm = comboBoxJudulFilm.Text;
                DBInput.Tanggal = DateBulan.Text;
                DBInput.Jam = waktu;

                string huruf = "";
                string[] kursi109 = new string[109];
                string[] kursi188 = new string[188];
                int count;

                //Not Null
                if (!DBInput.IDBioskop.Equals("") || DBInput.JudulFilm.Equals("") || DBInput.Tanggal.Equals("") || DBInput.Jam.Equals(""))
                {
                    if (jumlahKursi == 109)
                    {
                        count = 0;
                        for (char c = 'A'; c <= 'J'; c++)
                        {
                            switch (c)
                            {
                                case 'A':
                                    huruf = "A";
                                    break;
                                case 'B':
                                    huruf = "B";
                                    break;
                                case 'C':
                                    huruf = "C";
                                    break;
                                case 'D':
                                    huruf = "D";
                                    break;
                                case 'E':
                                    huruf = "E";
                                    break;
                                case 'F':
                                    huruf = "F";
                                    break;
                                case 'G':
                                    huruf = "G";
                                    break;
                                case 'H':
                                    huruf = "H";
                                    break;
                                case 'I':
                                    huruf = "I";
                                    break;
                                case 'J':
                                    huruf = "J";
                                    break;
                            }

                            for (int i = 1; i <= 12; i++)
                            {
                                if (c == 'I' || c == 'O') { break; }
                                kursi109[count] = Convert.ToString(huruf + i);
                                count++;
                                if (c == 'A' && i == 12)
                                {
                                    kursi109[count] = Convert.ToString(huruf + (i + 1));
                                    count++;
                                }
                            }
                        }

                        for (int x = 0; x < kursi109.Length; x++)
                        {
                            DBInput.Nomor_Kursi = kursi109[x];
                            var data = JsonConvert.SerializeObject(DBInput);
                            var Json = new WebClient();
                            Json.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                            string response = Json.UploadString(BaseAddress + "Inputdata", data);
                            Console.WriteLine(response);
                        }
                    }
                    else if (jumlahKursi == 188)
                    {
                        count = 0;
                        bool cek = true;
                        for (char c = 'A'; c <= 'K'; c++)
                        {
                            switch (c)
                            {
                                case 'A':
                                    huruf = "A";
                                    break;
                                case 'B':
                                    huruf = "B";
                                    break;
                                case 'C':
                                    huruf = "C";
                                    break;
                                case 'D':
                                    huruf = "D";
                                    break;
                                case 'E':
                                    huruf = "E";
                                    break;
                                case 'F':
                                    huruf = "F";
                                    break;
                                case 'G':
                                    huruf = "G";
                                    break;
                                case 'H':
                                    huruf = "H";
                                    break;
                                case 'I':
                                    huruf = "I";
                                    break;
                                case 'J':
                                    huruf = "J";
                                    break;
                                case 'K':
                                    huruf = "K";
                                    break;
                            }
                            for (int i = 1; i <= 22; i++)
                            {
                                if (c == 'I' || c == 'O') { break; }
                                if (i == 12)
                                {
                                    if (c == 'A' && i == 12)
                                    {
                                        kursi188[count] = (huruf + i);
                                        count++;
                                        kursi188[count] = (huruf + (i + 1));
                                        count++;
                                    }
                                    i = 14;
                                }
                                if (i == 1 || i == 2)
                                {
                                    if ((c == 'A' && cek == true) || (c == 'B' && cek == true) || (c == 'C' && cek == true))
                                    {
                                        kursi188[count] = ("A1");
                                        count++;
                                        kursi188[count] = ("B1");
                                        count++;
                                        kursi188[count] = ("C1");
                                        count++;
                                        kursi188[count] = ("A2");
                                        count++;
                                        kursi188[count] = ("B2");
                                        count++;
                                        kursi188[count] = ("C2");
                                        count++;
                                        cek = false;
                                    }
                                    i = 3;
                                }
                                kursi188[count] = (huruf + i);
                                count++;
                            }
                        }
                        for (int x = 0; x < kursi188.Length; x++)
                        {
                            DBInput.Nomor_Kursi = kursi188[x];
                            var data = JsonConvert.SerializeObject(DBInput);
                            var Json = new WebClient();
                            Json.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                            string response = Json.UploadString(BaseAddress + "Inputdata", data);
                            Console.WriteLine(response);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Insert Data", "Create Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Sukses", "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void buttonCekKursi_Click(object sender, EventArgs e)
        {
            panelBioskop.Visible = false;
            panelDataBioskop.Visible = false;
            panelDataFilm.Visible = false;
            panelEditBioskop.Visible = false;
            panelEditFilm.Visible = false;
            panelFilm.Visible = false;
            panelJadwal.Visible = false;
            panelKursi.Visible = true;
            panelSign.Visible = false;
        }

        private void buttonCekJadwal_Click(object sender, EventArgs e)
        {
            panelBioskop.Visible = false;
            panelDataBioskop.Visible = false;
            panelDataFilm.Visible = false;
            panelEditBioskop.Visible = false;
            panelEditFilm.Visible = false;
            panelFilm.Visible = false;
            panelJadwal.Visible = true;
            panelKursi.Visible = false;
            panelSign.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
