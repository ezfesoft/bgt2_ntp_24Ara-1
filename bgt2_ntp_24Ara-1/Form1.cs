using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;

namespace bgt2_ntp_24Ara_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "3mkw7KGTqF2yJNn9IWyM78WlzGN9vhCdXIARwuRW",
            BasePath = "https://bgt2-ntpii-24-25-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        private void button1_Click(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Bağlantı Başarılı");
                label1.Visible = true;
            }
        }

        SetResponse istek = null;
        Ogrenci ogr = null;

        private async void button2_Click(object sender, EventArgs e)
        {

            var ogrenci = new Ogrenci
            {
                Id = Convert.ToInt32(textBox1.Text),
                Ad = textBox2.Text,
                Soyad = textBox3.Text,
                Numara = textBox4.Text,
                Sinif = textBox5.Text,
                Sube = textBox6.Text,
                Developer = "slymn"
            };

            istek=await client.SetAsync("Ogrenci/" + ogrenci.Id, ogrenci);
            ogr = istek.ResultAs<Ogrenci>();
                       
            if (ogr.Id != null)
            {
                MessageBox.Show("Ekleme Başarılı");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız");
            }
        }

        List<Ogrenci> ogrenciler = new List<Ogrenci>();
        FirebaseResponse cevap=null;
        private async void button3_Click(object sender, EventArgs e)
        {
            cevap = await client.GetAsync("Ogrenci");
            var sonuc = cevap.Body;
            var data = JsonConvert.DeserializeObject<Dictionary<string, Ogrenci>>(sonuc);

            foreach (var item in data)
            {
                Ogrenci ogr = item.Value;
                ogrenciler.Add(ogr);
                listBox1.Items.Add(item.Value.Id + " " + item.Value.Ad + " " + item.Value.Soyad + " " + item.Value.Numara + " " + item.Value.Sinif + " " + item.Value.Sube);
            }

        }
    }

}
