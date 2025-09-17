using Demka3.Models;
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
    /// Логика взаимодействия для CountMaterials.xaml
    /// </summary>
    public partial class CountMaterials : Page
    {
        public CountMaterials(Products product)
        {
            InitializeComponent();
        }


        public List<Materials> MaterialsCount(int TypeProductID, int MaterialTypeID, int NumberOfProducts, decimal CountOnStorage, )
        {
            return null;
        }
    }
}
