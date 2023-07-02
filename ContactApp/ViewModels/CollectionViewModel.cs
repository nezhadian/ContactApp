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
    public class CollectionViewModel<T> : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implamentation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

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

        public static CustomCommand DeleteSelectedItemCommand { set; get; }
        public static CustomCommand AddItemCommand { set; get; }

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
