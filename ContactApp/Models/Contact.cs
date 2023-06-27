using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ContactApp.Models
{
    class Contact : ModelsBase
    {
        #region Private Fields
        private string _firstName;
        private string _lastName;
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

        public ObservableCollection<TitledItem> EmailsCollection { get; set; }
        public ObservableCollection<TitledItem> NumbersCollection { get; set; }

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
