using ContactApp.Models;
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
        public static CustomCommand EditSelectedItem { set; get; }
        static EditContactPageViewModel EditPage;

        public ContactViewModel()
        {
            EditSelectedItem = new CustomCommand(OnEditSelectedItemExecuted, EditSelectedItemCanExecute);
            StaticDeleteSelectedItemCommand = DeleteSelectedItemCommand;

            EditPage = new EditContactPageViewModel();
            EditPage.OnEditResault += EditPage_OnEditResault;
        }

        private bool EditSelectedItemCanExecute(object parameter)
        {
            return SelectedItem != null;
        }
        private void OnEditSelectedItemExecuted(object parameter)
        {
            EditPage.TargetContact = SelectedItem;
            MainWindow.Instance.NavigateToPage(EditPage);
        }
        private void EditPage_OnEditResault(object sender, EditContactPageViewModel.EditResault resault)
        {
            if(resault == EditContactPageViewModel.EditResault.SaveRequested)
            {
                ItemsCollection[ItemsCollection.IndexOf(SelectedItem)] = EditPage.TargetContact;
            }

            MainWindow.Instance.NavigateToHome();
        }

    }
}
