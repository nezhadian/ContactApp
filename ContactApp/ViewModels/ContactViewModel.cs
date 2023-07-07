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

        protected override bool AddCommandCanExecute(object parameter)
        {
            return true;
        }
        protected override void OnAddCommandExecuted(object parameter)
        {
            string text = parameter.ToString();
            int splitIndex = text.IndexOf(' ');
            string firstName = text[..splitIndex];
            string lastName = text[splitIndex..];
            Contact newContact = new Contact()
            {
                FirstName = firstName,
                LastName = lastName
            };

            OpenEditingPageFor(newContact);
        }

        #region Filtering
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
        #endregion

        #region Edit
        public static CustomCommand EditSelectedItem { set; get; }
        static EditContactPageViewModel EditPage;
        private bool EditSelectedItemCanExecute(object parameter)
        {
            return SelectedItem != null;
        }
        private void OnEditSelectedItemExecuted(object parameter)
        {
            OpenEditingPageFor(SelectedItem);
        }
        private void EditPage_OnEditResault(object sender, EditContactPageViewModel.EditResault resault)
        {
            if (resault == EditContactPageViewModel.EditResault.SaveRequested)
            {
                int selItemIndex = ItemsCollection.IndexOf(SelectedItem);
                if(selItemIndex == -1)
                {
                    ItemsCollection.Add(EditPage.TargetContact);
                }
                else
                {
                    ItemsCollection[selItemIndex] = EditPage.TargetContact;
                }
            }

            MainWindow.Instance.NavigateToHome();
        }

        private void OpenEditingPageFor(Contact contact)
        {
            EditPage.Edit(contact);
            MainWindow.Instance.NavigateToPage(EditPage);
        }

        #endregion

    }
}
