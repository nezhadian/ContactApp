using ContactApp.ViewModels;
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
    public class Contact : ModelsBase,ICloneable
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

        public TitledItemViewModel EmailsViewModel { get; set; } = new TitledItemViewModel();
        public TitledItemViewModel NumbersViewModel { get; set; } = new TitledItemViewModel();

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

        public Contact()
        {
            Random r = new Random();
            ProfilePicture = new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
        }

        public object Clone()
        {
            return new Contact()
            {
                FirstName = FirstName,
                LastName = LastName,
                EmailsViewModel = (TitledItemViewModel)EmailsViewModel.Clone(),
                NumbersViewModel = (TitledItemViewModel)NumbersViewModel.Clone(),
                IsFavorite = IsFavorite,
                ProfilePicture = ProfilePicture
            };
        }
    }
}
