using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    public class CollectionViewModel<T> : ViewModelBase
    {
        public ObservableCollection<T> ItemsCollection { get; set; }

        private T _selItem;
        public T SelectedItem
        {
            get => _selItem;
            set
            {
                _selItem = value;
                OnPropertyChanged();
                DeleteSelectedItemCommand.RaiseCanExecuteChanged();
            }
        }

        public CustomCommand DeleteSelectedItemCommand { set; get; }
        public CustomCommand AddItemCommand { set; get; }

        public CollectionViewModel()
        {
            DeleteSelectedItemCommand = new CustomCommand(OnDeleteCommandExecuted,DeleteCommandCanExecute);
            AddItemCommand = new CustomCommand(OnAddCommandExecuted, AddCommandCanExecute);
        }

        protected virtual bool AddCommandCanExecute(object parameter)
        {
            return parameter != null && parameter is T;
        }
        protected virtual void OnAddCommandExecuted(object parameter)
        {
            ItemsCollection.Add((T)parameter);
        }

        protected virtual bool DeleteCommandCanExecute(object parameter)
        {
            return SelectedItem != null;
        }
        protected virtual void OnDeleteCommandExecuted(object parameter)
        {
            ItemsCollection.Remove(SelectedItem);
        }
    }
}
