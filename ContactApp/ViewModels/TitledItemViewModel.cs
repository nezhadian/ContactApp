using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    public class TitledItemViewModel : CollectionViewModel<TitledItem>,ICloneable
    {
        public TitledItemViewModel()
        {
            ItemsCollection = new ObservableCollection<TitledItem>();
        }

        protected override bool AddCommandCanExecute(object parameter)
        {
            return true;
        }
        protected override void OnAddCommandExecuted(object parameter)
        {
            ItemsCollection.Add(new TitledItem() {Title = "",Value ="" });
        }

        public object Clone()
        {
            return new TitledItemViewModel()
            {
                ItemsCollection = new ObservableCollection<TitledItem>(ItemsCollection)
            };
        }

    }
}
