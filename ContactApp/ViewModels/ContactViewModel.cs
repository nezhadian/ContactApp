using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactApp.ViewModels
{
    public class ContactViewModel : FilterCollectionViewModel<Contact>
    {
        public static CustomCommand StaticDeleteSelectedItemCommand { set; get; }

        public ContactViewModel()
        {
            EditSelectedItem = new CustomCommand(OnEditSelectedItemExecuted, EditSelectedItemCanExecute);
            StaticDeleteSelectedItemCommand = DeleteSelectedItemCommand;

            EditPage = new EditContactPageViewModel();
            EditPage.OnEditResault += EditPage_OnEditResault;
        }

        private bool _onlyShowFavorites;
        public bool OnlyShowFavorites
        {
            get => _onlyShowFavorites;
            set
            {
                _onlyShowFavorites = value;
                OnPropertyChanged();
                ReFilter();
            }
        }
        public override bool FilterItems(Contact item)
        {
            if (OnlyShowFavorites)
            {
                return item.IsFavorite && 
                    (item.FirstName.Contains(FilterKeyword, StringComparison.InvariantCultureIgnoreCase) || 
                        item.LastName.Contains(FilterKeyword, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return item.FirstName.Contains(FilterKeyword, StringComparison.InvariantCultureIgnoreCase) ||
                        item.LastName.Contains(FilterKeyword, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        #region Edit
        public static CustomCommand EditSelectedItem { set; get; }
        static EditContactPageViewModel EditPage;
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
            if (resault == EditContactPageViewModel.EditResault.SaveRequested)
            {
                ItemsCollection[ItemsCollection.IndexOf(SelectedItem)] = EditPage.TargetContact;
            }

            MainWindow.Instance.NavigateToHome();
        }
        #endregion

    }
}
