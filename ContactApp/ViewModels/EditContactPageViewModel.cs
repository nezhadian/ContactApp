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

        public enum EditResault
        {
            Canceled, SaveRequested
        }
        public delegate void EditResaultEventHandler(object sender,EditResault resault);
        public event EditResaultEventHandler OnEditResault;

        public CustomCommand SendEditResaultCommand { set; get; }

        public EditContactPageViewModel()
        {
            SendEditResaultCommand = new CustomCommand(OnEditResaultSended);
        }

        private void OnEditResaultSended(object parameter)
        {
            if (parameter is string resault)
                OnEditResault?.Invoke(this, (EditResault)Enum.Parse(typeof(EditResault), resault));
            
        }
    }
}
