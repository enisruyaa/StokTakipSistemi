using StokTakipSistemi.DesignPattern.SingletonPattern;
using StokTakipSistemi.Models.ContextClasses;
using StokTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class Form1 : Form
    {
        MyContext _db;
        public Form1()
        {
            InitializeComponent();
            _db = DBTool.DBInstance;
            UrunleriListele();
            lstUrunler.SelectedIndex = -1;
        }

        public void UrunleriListele()
        {
            lstUrunler.DataSource = _db.Products.ToList();
        }

        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex >= 0)
            {
                Product secilenUrun = (Product)lstUrunler.SelectedItem;
                txtAd.Text = secilenUrun.Name;              
                txtFiyat.Text = secilenUrun.Price.ToString();
                txtStok.Text = secilenUrun.StockQuantity.ToString();
            }
            else
            {
                txtAd.Text = "";
                txtFiyat.Text = "";
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                MessageBox.Show("Lütfen ürün adı ve fiyatını giriniz!");
                return;
            }

            if (!int.TryParse(txtFiyat.Text, out int stok))
            {
                MessageBox.Show("Lütfen Geçerli Bir Stok Sayısı Giriniz");
                return;
            }

            if (!decimal.TryParse(txtFiyat.Text,out decimal fiyat))
            {
                MessageBox.Show("Lütfen Geçerli Bir Fiyat Giriniz");
                return;
            }

            else 
            {

                Product p = new Product()
                {
                    Name = txtAd.Text,
                    Price = fiyat,
                    StockQuantity = stok
                };
                _db.Products.Add(p);
                _db.SaveChanges();
                UrunleriListele();
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lstUrunler.SelectedIndex = -1;
            txtAd.Text = " ";
            txtFiyat.Text = "";
            txtStok.Text = " ";
        }
    }
}
