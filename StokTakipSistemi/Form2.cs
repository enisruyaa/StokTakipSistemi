using StokTakipSistemi.DesignPattern.SingletonPattern;
using StokTakipSistemi.Models.ContextClasses;
using StokTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class Form2 : Form
    {
        MyContext _db;
        public Form2()
        {
            InitializeComponent();
            _db = DBTool.DBInstance;
            UrunleriListele();
            SiparisleriListele();
        }

        public void UrunleriListele()
        {
            cmbUrunler.DataSource = _db.Products.ToList();
            cmbUrunler.DisplayMember = "Name";
            cmbUrunler.ValueMember = "ID";
        }

        public void SiparisleriListele()
        {
            lstsSiparisler.DataSource = _db.Orders.ToList();
            lstsSiparisler.DisplayMember = "";
            SecimTemizle();
        }

        public void SecimTemizle()
        {
            lstsSiparisler.SelectedIndex = -1;
            cmbUrunler.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            int UrunId = Convert.ToInt32(cmbUrunler.SelectedValue); // Seçilen Ürünün İD'sini alma        
            Product urun = _db.Products.FirstOrDefault(p => p.ID == UrunId);// Veri Tabanından Ürün Bulmak
            int adet = (int)numAdet.Value; // Numericten seçilen adet
            if (cmbUrunler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen Bir Ürün Seçiniz");
            }
            else if (adet <=0)
            {
                MessageBox.Show("Lütfen Geçerli Bir Adet Giriniz");
            }
            else if (urun == null)
            {
                MessageBox.Show("Secilen Ürün Bulunamadı");
            }
            // Stok Kontrol 
            else if (urun.StockQuantity <= adet)
            {
                MessageBox.Show($" {urun.Name} Ürününden Yeterli Stok Bulunmamaktadır. \r Maximum {urun.StockQuantity} Kadar Sipariş Verebilirsiniz. ");
                return;
            }
            else
            {
                Order siparis = new Order
                {
                    OrderDate = DateTime.Now,
                    TotalAmount = urun.Price,
                    Products = new List<Product>() { urun }
                };
                urun.StockQuantity -= adet; // Stoktan Düşmek
                _db.Orders.Add(siparis);
                _db.SaveChanges();
                lstsSiparisler.Items.Add($"{adet} Adet -> {urun.Name} Siparis Verilmiştir. ");
                SiparisleriListele();
            }
        }
    }
}
