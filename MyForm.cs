using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ListviewItemToComboBox.MyForm;

namespace ListviewItemToComboBox
{
    public partial class MyForm : Form
    {
        
        public MyForm()
        {
            InitializeComponent();

        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            ListViewHazirla();
            List<Kisi> kisiler = Doldur();

            ListViewDoldur(kisiler);
            ComboBoxDoldur(kisiler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Şu an boş
        }
        #region Kisi Struct
        // Kişi struct sınıfı yaratıldı.
        public struct Kisi
        {
            private int no;
            private string ad;
            private string soyad;
            public void DegerleriGir(int _no, string _ad, string _soyad)
            {
                no = _no;
                ad = _ad;
                soyad = _soyad;
            }
            public int No
            {
                get { return no;}
            }
            public string Ad
            {
                get { return ad; }
            }
            public string Soyad
            {
                get { return soyad; }
            }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", No.ToString(), Ad, Soyad);
            }
        }
        #endregion
        #region Kişiler Listesi Hazırlanıyor
        // Kişiler List objesi hazırlanıyor.
        private List<Kisi> Doldur()    
        {    
    
            List<Kisi> kisiler = new List<Kisi>();

            Kisi kisi1 = new Kisi();
            kisi1.DegerleriGir(1, "Zeki", "Gülen");
            kisiler.Add(kisi1);    
    
            Kisi kisi2 = new Kisi();
            kisi2.DegerleriGir(2, "Mina", "Turgut");    
            kisiler.Add(kisi2);    
    
            Kisi kisi3 = new Kisi();
            kisi3.DegerleriGir(3, "Alihan", "Bayraktar");    
            kisiler.Add(kisi3);    
    
            Kisi kisi4 = new Kisi();
            kisi4.DegerleriGir(4, "Adil", "Özçaycı");    
            kisiler.Add(kisi4);    
    
            Kisi kisi5 = new Kisi();
            kisi5.DegerleriGir(5, "Serdar", "Gürleyen");    
            kisiler.Add(kisi5);

            return kisiler;    
        }
        #endregion
        #region List View Hazırla
        private void ListViewHazirla()
        {
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("No", 50);
            listView1.Columns.Add("Adı, Soyadı", 200);
        }
        private void ListViewDoldur(List<Kisi> kisiler)
        {
            //ListView üzerindeki bilgiler 
            listView1.Items.Clear();

            foreach(Kisi s in kisiler)
            {
                ListViewItem kisi = new ListViewItem();
                kisi.Text = s.No.ToString();
                ListViewItem.ListViewSubItem kisiSubItem = new ListViewItem.ListViewSubItem();
                kisiSubItem.Text = string.Format("{0} {1}", s.Ad, s.Soyad);
                kisi.SubItems.Add(kisiSubItem);

                listView1.Items.Add(kisi);
            }
        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (listView1.SelectedItems.Count > 0)
            {
                comboBox1.SelectedIndex = listView1.SelectedItems[0].Index;
            }
            
        }

        private void ComboBoxDoldur(List<Kisi> kisiler)
        {
            // ComboBox üzerine itemların yerleştirilmesi..
            comboBox1.Items.Clear();
            for(int i=0;i<kisiler.Count;i++)
                comboBox1.Items.Insert(i, string.Format("{0} {1}", kisiler[i].Ad, kisiler[i].Soyad));            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.SelectedItems.Clear();
            listView1.Items[comboBox1.SelectedIndex].Selected = true;
            listView1.TabStop = true;
            
        }
    }
}
