using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Demka3.Models;
using Demka3.Services;

namespace Demka3.Pages
{
    /// <summary>
    /// Логика взаимодействия для CheckProducts.xaml
    /// </summary>
    public partial class CheckProducts : Page
    {
        public ListView LVCheck => LVProducts;
        public CheckProducts()
        {
            InitializeComponent();
            LVProducts.ItemsSource = GetProducts();
        }


        public List<Products> GetProducts()
        {
            var db = Helper.GetContext();
            List<Materials> materials = db.Materials.ToList();
            List<ProductsMaterial> pm = db.ProductsMaterial.ToList();
            var products = db.Products.ToList();
            foreach(var product in products)
            {
                //для расчёта стоимости нужно умножить количество материала продукта на цену материала
                ProductsMaterial material = pm.Where(p => p.ProductID == product.ID).FirstOrDefault();
                product.FinalCost = material.Materials.Cost * material.MaterialCount;
            }
            return products;
        }

        private void LVProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ChangeProduct(LVProducts.SelectedItem as Products));
            LVProducts.ItemsSource = GetProducts();
        }
    }
}
