using AdonisUI.Controls;
using ContactApp.ViewModels;
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

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        public ContactViewModel ContactViewModel { get; set; }
        public MainWindow()
        {
            ContactViewModel = new ContactViewModel();
            ContactViewModel.ItemsCollection = new System.Collections.ObjectModel.ObservableCollection<Models.Contact>()
            {
                new Models.Contact(){FirstName = "Yasin",LastName="EbrahimNezhadian", IsFavorite=true, ProfilePicture = new SolidColorBrush(Colors.Red) },
                new Models.Contact(){FirstName = "Nimar",LastName="Ahmadi", IsFavorite=false, ProfilePicture = new SolidColorBrush(Colors.Green) },
                new Models.Contact(){FirstName = "Matin",LastName="Jahmadi", IsFavorite=true, ProfilePicture = new SolidColorBrush(Colors.Goldenrod) },
                new Models.Contact(){FirstName = "Ahmed",LastName="Sahmadi", IsFavorite=false, ProfilePicture = new SolidColorBrush(Colors.Silver) },
            };

            DataContext = this;
            InitializeComponent();
        }
    }
}
