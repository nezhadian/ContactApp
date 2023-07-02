using AdonisUI.Controls;
using ContactApp.Pages;
using ContactApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        public Page CurrentPage
        {
            get { return (Page)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(Page), typeof(MainWindow), new PropertyMetadata());

        public MainWindow()
        {
            CurrentPage = new HomePage();

            DataContext = this;
            InitializeComponent();
        }

        public static void NavigateToPage(Page page)
        {
            var instance = (MainWindow)Application.Current.MainWindow;
            instance.CurrentPage = page;
        }
    }
}
