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
using Chernovik.UI.Pages;
using Chernovik.Utilities;


namespace Chernovik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Осуществление перехода на страницу материалов
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MaterialLV());
            Transition.MainFrame = MainFrame;
        }

        /// <summary>
        /// Код видимости кнопки назад на главной форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(Transition.MainFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                BackBtn.Visibility= Visibility.Visible;
            }
        }

        /// <summary>
        /// Код кнопки назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Transition.MainFrame.GoBack();
        }
    }
}
