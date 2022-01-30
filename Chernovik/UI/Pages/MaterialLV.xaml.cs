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
using Chernovik.Entities;
using Chernovik.Utilities;

namespace Chernovik.UI.Pages
{
    /// <summary>
    /// Interaction logic for MaterialLV.xaml
    /// </summary>
    public partial class MaterialLV : Page
    {
        public MaterialLV()
        {
            InitializeComponent();
            var types = Transition.DataContext.MaterialType.ToList();
            types.Insert(0,new MaterialType { Title = "Все типы"});
            TypesCBox.ItemsSource = types;
            TypesCBox.SelectedIndex = 0;
            SortCBox.SelectedIndex = 0;
            ViewMaterial.ItemsSource = Transition.DataContext.Material.ToList();
            //SortingProduct();
        }

        private void SortingProduct()
        {
            var itemUpdate = Transition.DataContext.Material.ToList();

            if (TypesCBox.SelectedIndex > 0)
                itemUpdate = itemUpdate
                    .Where(p => p.MaterialTypeID == (TypesCBox.SelectedItem as MaterialType).ID)
                    .ToList();

            if (SearchTBox.Text != "Введите для поиска")
                itemUpdate = itemUpdate
                    .Where(p => p.Title.ToLower().Contains(SearchTBox.Text.ToLower())
                    || p.Description.ToLower().Contains(SearchTBox.Text.ToLower()))
                    .ToList();

            switch (SortCBox.SelectedIndex)
            {
                case 1:
                    {
                        if (!(bool)DecreasingCheck.IsChecked)
                            itemUpdate = itemUpdate.OrderBy(p => p.Title).ToList();
                        else
                            itemUpdate = itemUpdate.OrderByDescending(p => p.Title).ToList();
                        break;
                    }
                case 2:
                    {
                        if (!(bool)DecreasingCheck.IsChecked)
                            itemUpdate = itemUpdate.OrderBy(p => p.CountInStock).ToList();
                        else
                            itemUpdate = itemUpdate.OrderByDescending(p => p.CountInStock).ToList();
                        break;
                    }
                case 3:
                    {
                        if (!(bool)DecreasingCheck.IsChecked)
                            itemUpdate = itemUpdate.OrderBy(p => p.Cost).ToList();
                        else
                            itemUpdate = itemUpdate.OrderByDescending(p => p.Cost).ToList();
                        break;
                    }
            }

            CountOutElBlock.Text = $"Количество элементов: {itemUpdate.Count} из {Transition.DataContext.Material.ToList().Count}";

            

            ViewMaterial.ItemsSource = itemUpdate;
        }

        private void SearchTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTBox.Text != "Введите текст для поиска" && SearchTBox.Text != null)
            {
                SortingProduct();
            }
        }

        private void SearchTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTBox.Text = null;
        }

        private void TypesCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortingProduct();
        }

        private void ViewMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortingProduct();
        }

        private void ViewMaterial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SortCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortingProduct();
        }

        private void DecreasingCheck_Checked(object sender, RoutedEventArgs e)
        {
            SortingProduct();
        }

        private void DecreasingCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            SortingProduct();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateMinCountBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTBox.Text == null)
                SearchTBox.Text = "Введите текст для поиска";
        }
    }
}
