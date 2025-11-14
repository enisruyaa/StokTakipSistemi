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
            lstsSiparisler.DataSource =
     _db.Orders
        .Include("OrderDetails.Product")
        .ToList();
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
            if (cmbUrunler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
                return;
            }

            int urunId = Convert.ToInt32(cmbUrunler.SelectedValue);
            int adet = (int)numAdet.Value;

            Product urun = _db.Products.FirstOrDefault(x => x.ID == urunId);

            if (adet <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir adet giriniz.");
                return;
            }

            if (urun == null)
            {
                MessageBox.Show("Seçilen ürün bulunamadı.");
                return;
            }

            if (urun.StockQuantity < adet)
            {
                MessageBox.Show($"Stok yetersiz! Maksimum {urun.StockQuantity} adet sipariş verebilirsiniz.");
                return;
            }

            // 1) Order oluştur
            Order order = new Order
            {
                OrderDate = DateTime.Now
            };
            _db.Orders.Add(order);
            _db.SaveChanges(); // ID almak için

            // 2) OrderDetail oluştur
            OrderDetail detail = new OrderDetail
            {
                OrderID = order.ID,
                ProductID = urun.ID,
                Quantity = adet,
                UnitPrice = urun.Price
            };

            _db.OrderDetails.Add(detail);

            // 3) Stok düş
            urun.StockQuantity -= adet;

            // 4) Kayıt
            _db.SaveChanges();

            // 5) Listbox'a yazdır
            lstsSiparisler.DataSource = null;
            lstsSiparisler.Items.Add($"{adet} Adet  {urun.Name} Ürünü Sipariş Edilmiştir. ");
        }

    }
}
