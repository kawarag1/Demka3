using Demka3.Models;
using Demka3.Services;
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

namespace Demka3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();
            ProductTypesBox.ItemsSource = InitializeProductTypes();
        }

        private List<ProductType> InitializeProductTypes()
        {
            var db = Helper.GetContext();
            return db.ProductType.ToList();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = Helper.GetContext();
            Products newProduct = new Products();
            var type = ProductTypesBox.SelectedItem as ProductType;
            newProduct.ProductTypeID = type.ID;
            newProduct.Title = TitleBox.Text;
            newProduct.Article = Convert.ToInt32(ArticleBox.Text);
            newProduct.MinCostForPartner = Convert.ToDecimal(MinCostForPartnerBox.Text);
            newProduct.Wight = Convert.ToDecimal(WightBox.Text);
            db.Products.Add(newProduct);
            db.SaveChanges();
            MessageBox.Show("Успешно!");
            NavigationService.GoBack();
        }
    }
}
