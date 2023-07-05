using ContactApp.Models;
using ContactApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactApp.ViewModels
{
    public class ContactViewModel : CollectionViewModel<Contact>
    {
        public static CustomCommand StaticDeleteSelectedItemCommand { set; get; }
        public static CustomCommand SaveCommand { set; get; }
        public static CustomCommand EditSelectedItem { set; get; }
        static EditContactItemPage EditPage;

        public ContactViewModel()
        {
            SaveCommand = new CustomCommand(OnSaveExecuted, SaveCanExecute);
            EditSelectedItem = new CustomCommand(OnEditSelectedItemExecuted, EditSelectedItemCanExecute);
            StaticDeleteSelectedItemCommand = DeleteSelectedItemCommand;

            EditPage = new EditContactItemPage();
        }

        private bool EditSelectedItemCanExecute(object parameter)
        {
            return SelectedItem != null;
        }
        private void OnEditSelectedItemExecuted(object parameter)
        {
            EditPage.TargetContact = SelectedItem;
            MainWindow.NavigateToPage(EditPage);
        }

        private bool SaveCanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        private void OnSaveExecuted(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
