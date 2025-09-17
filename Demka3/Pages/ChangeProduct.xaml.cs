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
    /// Логика взаимодействия для ChangeProduct.xaml
    /// </summary>
    public partial class ChangeProduct : Page
    {
        public static Products product_;
        public ChangeProduct(Products product)
        {
            InitializeComponent();
            product_ = product;
            TitleBox.Text = product.Title;
            ArticleBox.Text = Convert.ToString(product.Article);
            MinCostForPartnerBox.Text = Convert.ToString(product.MinCostForPartner);
            WightBox.Text = Convert.ToString(product.Wight);

            ProductTypesBox.ItemsSource = InitializeProductTypes();
            ProductTypesBox.SelectedIndex = product.ProductTypeID;
        }

        private void ChangeProductBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = Helper.GetContext();
            product_.Title = TitleBox.Text;
            product_.Article = Convert.ToInt32(ArticleBox.Text);
            product_.MinCostForPartner = Convert.ToDecimal(MinCostForPartnerBox.Text);
            product_.Wight = Convert.ToDecimal(WightBox.Text);
            var type = ProductTypesBox.SelectedItem as ProductType;
            product_.ProductTypeID = type.ID;
            db.SaveChanges();
            MessageBox.Show("Успешно!");
            NavigationService.GoBack();

        }

        private List<ProductType> InitializeProductTypes()
        {
            var db = Helper.GetContext();
            return db.ProductType.ToList();
        }
    }
}
