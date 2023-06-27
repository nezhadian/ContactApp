using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ContactApp.Models
{
    public class Contact : ModelsBase
    {
        #region Private Fields
        private string _firstName;
        private string _lastName;
        private ObservableCollection<TitledItem> _emailsCollection;
        private ObservableCollection<TitledItem> _numbersCollection;
        private bool _isFavorite;
        private Brush _profilePicture;
        #endregion

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TitledItem> EmailsCollection
        {
            get => _emailsCollection;
            set
            {
                if (value == null)
                    return;

                if (_emailsCollection != null)
                    _emailsCollection.CollectionChanged -= OnEmailsCollectionChanged;

                value.CollectionChanged += OnEmailsCollectionChanged;
                OnEmailsCollectionChanged(null, null);

                _emailsCollection = value;
                OnPropertyChanged();

            }
        }
        public ObservableCollection<TitledItem> NumbersCollection
        {
            get => _numbersCollection;
            set
            {
                if (value == null)
                    return;

                if (_numbersCollection != null)
                    _numbersCollection.CollectionChanged -= OnNumbersCollectionChanged;

                _numbersCollection = value;

                OnPropertyChanged();
                value.CollectionChanged += OnNumbersCollectionChanged;
                OnNumbersCollectionChanged(null, null);
            }
        }

        public bool IsEmailsEmpty
        {
            get => EmailsCollection == null || EmailsCollection.Count == 0;
        }
        public bool IsNumbersEmpty
        {
            get => NumbersCollection == null || NumbersCollection.Count == 0;
        }

        private void OnEmailsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEmailsEmpty));
        }
        private void OnNumbersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsNumbersEmpty));

        }


        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                _isFavorite = value;
                OnPropertyChanged();
            }
        }

        public Brush ProfilePicture
        {
            get => _profilePicture;
            set
            {
                _profilePicture = value;
                OnPropertyChanged();
            }
        }
    }
}
