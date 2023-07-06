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
            var emails = new TitledItemViewModel()
            {
                ItemsCollection = new System.Collections.ObjectModel.ObservableCollection<Models.TitledItem>()
                {
                    new Models.TitledItem(){Title = "Work",Value = "example@gmail.com"},
                    new Models.TitledItem(){Title = "Persoal",Value = "yasin@yahoo.net"},
                    new Models.TitledItem(){Title = "Home",Value = "matin@hotemail.com"},
                    new Models.TitledItem(){Title = "Office",Value = "ali@protonEmail.com"},
                }
            };

            var numbers = new TitledItemViewModel()
            {
                ItemsCollection = new System.Collections.ObjectModel.ObservableCollection<Models.TitledItem>()
                {
                    new Models.TitledItem(){Title = "Personal",Value = "+98 991 852 5922"},
                    new Models.TitledItem(){Title = "Home",Value = "+98 914 595 7929"},
                    new Models.TitledItem(){Title = "Other Home",Value = "+98 914 334 9374"},
                }
            };
            ContactViewModel = new ContactViewModel()
            {
                ItemsCollection = new System.Collections.ObjectModel.ObservableCollection<Models.Contact>
                {
                    new Models.Contact(){LastName = "Yasini" ,FirstName = "Yasin" ,ProfilePicture = new SolidColorBrush(Colors.Violet) ,EmailsViewModel = emails,NumbersViewModel = numbers},
                    new Models.Contact(){LastName = "Matini" ,FirstName = "Matin" ,ProfilePicture = new SolidColorBrush(Colors.Goldenrod) },
                    new Models.Contact(){LastName = "Ahmadi" ,FirstName = "Ahmad" ,ProfilePicture = new SolidColorBrush(Colors.IndianRed) ,EmailsViewModel = emails},
                    new Models.Contact(){LastName = "Mamadi" ,FirstName = "Mamad" ,ProfilePicture = new SolidColorBrush(Colors.HotPink) ,NumbersViewModel = numbers},
                }
            };
        }
    }
}
