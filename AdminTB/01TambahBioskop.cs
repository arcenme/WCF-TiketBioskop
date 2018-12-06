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
        string _IDB;
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

        }

        private void TambahFilm_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void LihatDataFilm_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
