using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ContactApp.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        public ContactViewModel ContactViewModel { set; get; }

        public HomePageViewModel()
        {
            ContactViewModel = new ContactViewModel();
        }
    }
}
