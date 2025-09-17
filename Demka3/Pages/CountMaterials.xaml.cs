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
    public class ModelForCountMaterials
    {
        public string Title { get; set; }
        public int Counter { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для CountMaterials.xaml
    /// </summary>
    public partial class CountMaterials : Page
    {
        public static Products product_;
        public static List<ModelForCountMaterials> materials = new List<ModelForCountMaterials>();
        public CountMaterials(Products product)
        {
            InitializeComponent();
            product_ = product;
        }


        public void MaterialsCount(int TypeProductID, int MaterialTypeID, int NumberOfProducts, decimal CountOnStorage, decimal BreakPercent, decimal ProductTypeKef, Deemka3Entities db)
        {
            ModelForCountMaterials material = new ModelForCountMaterials();
            var material_ = db.Materials.Where(x => x.MaterialType_ID == MaterialTypeID).FirstOrDefault();
            material.Title = material_.Title;
            int MaterialsForOneProduct = Convert.ToInt32(Math.Ceiling(((BreakPercent * ProductTypeKef) + BreakPercent) * NumberOfProducts));

            material.Counter = MaterialsForOneProduct;
            materials.Add(material);
        }

        private void CountBtn_Click(object sender, RoutedEventArgs e)
        {
            var db = Helper.GetContext();
            var material = db.ProductsMaterial.Where(x => x.ProductID == product_.ID).ToList();
            foreach (var item in material)
            {
                MaterialsCount(product_.ProductTypeID, item.Materials.MaterialType_ID, Convert.ToInt32(CountBox.Text), item.Materials.Remains, item.Materials.MaterialsType.BreakPercent, product_.ProductType.ProductTypeCoef, db);
            }
            LVMaterials.ItemsSource = materials;
        }
    }
}
