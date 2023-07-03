using ContactApp.Models;
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

namespace ContactApp.Pages
{
    /// <summary>
    /// Interaction logic for EditContactItemPage.xaml
    /// </summary>
    public partial class EditContactItemPage : Page
    {
        private Contact _targetContact;
        public Contact TargetContact
        {
            get => _targetContact;
            set {

                DataContext = value;
                _targetContact = value;
            }
        }

        public EditContactItemPage()
        {
            InitializeComponent();
        }
        public EditContactItemPage(Contact contact):this()
        {
            TargetContact = contact;
        }

        private void AddNewEmail_Click(object sender, RoutedEventArgs e)
        {
            AddTitledItemToCollection(TargetContact.EmailsCollection, new TitledItem() { Title = "Title", Value = "@gmail.com" });
        }

        private void AddNewNumber_Click(object sender, RoutedEventArgs e)
        {
            AddTitledItemToCollection(TargetContact.NumbersCollection, new TitledItem() { Title = "Title", Value = "+98" });
        }

        public void AddTitledItemToCollection(ICollection<TitledItem> collection,TitledItem item)
        {
            if (collection is null)
                return;

            collection.Add(item);
        }
    }
}
