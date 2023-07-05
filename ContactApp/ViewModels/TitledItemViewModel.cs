using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    public class TitledItemViewModel : CollectionViewModel<TitledItem>
    {
        public TitledItemViewModel()
        {
            ItemsCollection = new ObservableCollection<TitledItem>();
        }

    }
}
