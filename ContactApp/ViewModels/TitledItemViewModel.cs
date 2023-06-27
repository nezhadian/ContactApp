using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    class TitledItemViewModel : CollectionViewModel<TitledItem>
    {

        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        public TitledItemViewModel(ObservableCollection<TitledItem> collection)
        {
            ItemsCollection = collection;
        }

    }
}
