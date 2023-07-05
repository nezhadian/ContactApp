﻿using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactApp.Pages
{
    /// <summary>
    /// Interaction logic for EditContactItemPage.xaml
    /// </summary>
    public partial class EditContactItemPage : Page
    {
        private Contact _targetContact;
        public Contact TargetContact
        {
            get => _targetContact;
            set {

                DataContext = value;
                _targetContact = value;
            }
        }

        public EditContactItemPage()
        {
            InitializeComponent();
        }
        public EditContactItemPage(Contact contact):this()
        {
            TargetContact = contact;
        }
    }
}
