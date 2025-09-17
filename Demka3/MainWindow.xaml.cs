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
using Demka3.Pages;

namespace Demka3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new CheckProducts());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.GoBack();
        }

        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.Content is CheckProducts)
            {
                BackBtn.Visibility = Visibility.Hidden;
                AddProductBtn.Visibility = Visibility.Visible;
                CountMaterialsBtn.Visibility = Visibility.Visible;
                Title.Text = "Просмотр продуктов";
            }
            else if (FrmMain.Content is ChangeProduct)
            {
                BackBtn.Visibility = Visibility.Visible;
                AddProductBtn.Visibility = Visibility.Hidden;
                CountMaterialsBtn.Visibility = Visibility.Hidden;
                Title.Text = "Редактирование продукта";
            }
            else if (FrmMain.Content is AddProduct)
            {
                BackBtn.Visibility = Visibility.Visible;
                AddProductBtn.Visibility = Visibility.Hidden;
                CountMaterialsBtn.Visibility = Visibility.Hidden;
                Title.Text = "Добавление продукта";
            }
            else if (FrmMain.Content is CountMaterials)
            {
                BackBtn.Visibility = Visibility.Visible;
                AddProductBtn.Visibility = Visibility.Hidden;
                CountMaterialsBtn.Visibility = Visibility.Hidden;
                Title.Text = "Расчёт количества материала";
            }
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            FrmMain.Navigate(new AddProduct());
        }

        private void CountMaterialsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FrmMain.Content is CheckProducts page)
            {
                if (page.LVProducts.SelectedItem == null)
                {
                    MessageBox.Show("Для начала выберите продукт, который вы хотите произвести");
                    return;
                }
                else
                {
                    var product = page.LVProducts.SelectedItem as Products;
                    FrmMain.Navigate(new CountMaterials(product));
                }
            }
        }
    }
}
