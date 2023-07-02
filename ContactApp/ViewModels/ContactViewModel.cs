using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.ViewModels
{
    public class ContactViewModel : CollectionViewModel<Contact>
    {
        public static CustomCommand SaveCommand { set; get; }
        public ContactViewModel()
        {
            SaveCommand = new CustomCommand(OnSaveExecuted, SaveCanExecute);
        }

        private bool SaveCanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        private void OnSaveExecuted(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
