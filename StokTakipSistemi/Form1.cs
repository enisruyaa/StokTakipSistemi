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
            lstUrunler.DrawMode = DrawMode.OwnerDrawFixed;
            lstUrunler.DrawItem += LstUrunler_DrawItem;
        }

        private void LstUrunler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Product product = (Product)lstUrunler.Items[e.Index];
            Color textColor;
            switch (product.StockStatus)
            {
                case "Low":
                    textColor = Color.Red;
                    break;
                case "Medium":
                    textColor = Color.DarkOrange;
                    break;
                default:
                    textColor = Color.Black;
                    break;
            }
            e.DrawBackground();
            using (Brush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(product.ToString(), e.Font, brush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }


        public void UrunleriListele()
        {
            lstUrunler.DataSource = _db.Products.ToList();
            SecimTemizle();
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

        public void SecimTemizle()
        {
            lstUrunler.SelectedIndex = -1;
            txtAd.Text = " ";
            txtFiyat.Text = "";
            txtStok.Text = " ";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Ürünü Seçin");
                return;
            }
            else
            {
                Product secilenUrun = (Product)lstUrunler.SelectedItem;
                _db.Products.Remove(secilenUrun);
                _db.SaveChanges();
                UrunleriListele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz Ürünü Seçiniz");
                return;
            }
            else
            {
                Product secilenUrun = (Product)lstUrunler.SelectedItem;
                string yeniAd = txtAd.Text;
                decimal yeniFiyat = Convert.ToDecimal(txtFiyat.Text);
                int yeniStok = Convert.ToInt32(txtStok.Text);
                if (string.IsNullOrEmpty(yeniAd))
                {
                    MessageBox.Show("Lütfen Güncellemek İstediğiniz Ürün İçin Bilgilerinizi Doldurunuz");
                    return;
                }
                else
                {
                    secilenUrun.Name = yeniAd;
                    secilenUrun.Price = yeniFiyat;
                    secilenUrun.StockQuantity = yeniStok;
                    _db.SaveChanges();
                    UrunleriListele();
                }
            }
        }
    }
}
