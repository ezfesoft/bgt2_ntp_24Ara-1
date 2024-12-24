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
    }
}
