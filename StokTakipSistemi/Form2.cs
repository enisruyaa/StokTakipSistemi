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
            cmbUrunler.DrawMode = DrawMode.OwnerDrawFixed;
            cmbUrunler.DrawItem += cmbUrunler_DrawItem;

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

            Order order = new Order
            {
                OrderDate = DateTime.Now
            };
            _db.Orders.Add(order);
            _db.SaveChanges();

            OrderDetail detail = new OrderDetail
            {
                OrderID = order.ID,
                ProductID = urun.ID,
                Quantity = adet,
                UnitPrice = urun.Price
            };

            _db.OrderDetails.Add(detail);
            urun.StockQuantity -= adet;
            _db.SaveChanges();
            lstsSiparisler.DataSource = null;
            lstsSiparisler.Items.Add($"{adet} Adet  {urun.Name} Ürünü Sipariş Edilmiştir. ");
            SiparisleriListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstsSiparisler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Ürünü Seçiniz");
                return;
            }

            Order siparis = (Order)lstsSiparisler.SelectedItem;
            _db.Orders.Remove(siparis);
            _db.SaveChanges();
            SiparisleriListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstsSiparisler.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Güncellemek İstediğiniz Siparişi Seçiniz.");
                return;
            }


            Order siparis = (Order)lstsSiparisler.SelectedItem;

            siparis.OrderDetails.First().ProductID = ((Product)cmbUrunler.SelectedItem).ID;
            siparis.OrderDetails.First().Quantity = (int)numAdet.Value;

            _db.SaveChanges();
            SiparisleriListele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cmbUrunler.SelectedIndex = -1;
            numAdet.Value = 0;
            lstsSiparisler.ClearSelected();
            SiparisleriListele();
        }

        private void cmbUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrunler.SelectedItem is Product urun)
            {
                lblStok.Text = $"Stok : {urun.StockQuantity}";
                lblStok.Visible = true;
            }
            else
            {
                lblStok.Visible = false;
            }
        }

        private void cmbUrunler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Product product = (Product)cmbUrunler.Items[e.Index];
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
    }
}
