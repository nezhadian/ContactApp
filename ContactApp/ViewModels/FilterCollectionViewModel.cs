using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ContactApp.ViewModels
{
    public abstract class FilterCollectionViewModel<T> : CollectionViewModel<T>
    {
        public override ObservableCollection<T> ItemsCollection
        {
            get => base.ItemsCollection;
            set
            {
                if (value is null)
                    return;

                base.ItemsCollection = value;
                FilteredCollectionView = CollectionViewSource.GetDefaultView(ItemsCollection);
                FilteredCollectionView.Filter = (i) => FilterItems((T)i);
                ItemsCollection.CollectionChanged += (s,e) => ReFilter();
            }
        }

        public ICollectionView FilteredCollectionView { protected set; get; }

        private string _filterKeyword;
        public string FilterKeyword
        {
            get => _filterKeyword ?? string.Empty;
            set
            {
                _filterKeyword = value;
                OnPropertyChanged();
                ReFilter();
            }
        }

        public abstract bool FilterItems(T item);

        public void ReFilter()
        {
            FilteredCollectionView?.Refresh();
        }


    }
}
