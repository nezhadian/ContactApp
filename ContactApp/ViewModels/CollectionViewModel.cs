using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactApp.ViewModels
{
    public interface ICollectionViewModel
    {
        public bool AddItemCanExecute(object parameters);
        public void AddItemExecute(object paramters);

        public bool DeleteSelectedItemCanExecute(object parameters);
        public void DeleteSelectedItemExecute(object paramters);
    }
    public class CollectionViewModel<T> : ICollectionViewModel,INotifyPropertyChanged
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
            }
        }

        public AddItemCommand AddItemCommand { get; set; }
        public DeleteSelectedItemCommand DeleteSelectedItemCommand { set; get; }

        public CollectionViewModel()
        {
            AddItemCommand = new AddItemCommand(this);
            DeleteSelectedItemCommand = new DeleteSelectedItemCommand(this);
        }

        public bool AddItemCanExecute(object parameters)
        {
            throw new NotImplementedException();
        }
        public void AddItemExecute(object paramters)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSelectedItemCanExecute(object parameters)
        {
            throw new NotImplementedException();
        }
        public void DeleteSelectedItemExecute(object paramters)
        {
            throw new NotImplementedException();
        }

    }

    public class DeleteSelectedItemCommand : ICommand
    {
        ICollectionViewModel collectionVM;
        public DeleteSelectedItemCommand(ICollectionViewModel collectionVM)
        {
            this.collectionVM = collectionVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return collectionVM.DeleteSelectedItemCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            collectionVM.DeleteSelectedItemExecute(parameter);
        }
    }
    public class AddItemCommand : ICommand
    {
        ICollectionViewModel collectionVM;
        public AddItemCommand(ICollectionViewModel collectionVM)
        {
            this.collectionVM = collectionVM;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return collectionVM.AddItemCanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            collectionVM.AddItemExecute(parameter);
        }
    }
}
