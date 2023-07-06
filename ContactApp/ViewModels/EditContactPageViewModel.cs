using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    class EditContactPageViewModel : ViewModelBase
    {
        private Contact _targetContact;
        public Contact TargetContact
        {
            get => _targetContact;
            set
            {
                _targetContact = value;
                OnPropertyChanged();
            }
        }

    }
}
