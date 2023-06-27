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
        public SaveCommand SaveCommand { get; set; }

        public ContactViewModel()
        {
            SaveCommand = new SaveCommand(this);
        }
    }
    public class SaveCommand : ContextCommand<ContactViewModel>
    {
        public SaveCommand(ContactViewModel context)
        {
            Context = context;
        }

        public override bool CanExecute(ContactViewModel context, object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(ContactViewModel context, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
