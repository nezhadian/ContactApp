﻿using AdonisUI.Controls;
using ContactApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AdonisWindow
    {
        public object CurrentPage
        {
            get { return (object)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(object), typeof(MainWindow), new PropertyMetadata());

        private static MainWindow instance;
        public static MainWindow Instance
        {
            get { return instance ?? (MainWindow)Application.Current.MainWindow; }
            set { instance = value; }
        }




        HomePageViewModel HomePage;

        public MainWindow()
        {
            HomePage = new HomePageViewModel();
            NavigateToPage(HomePage);

            DataContext = this;

            InitializeComponent();
            Instance = this;
        }

        public void NavigateToPage(object content)
        {
            CurrentPage = content;
        }
        public void NavigateToHome()
        {
            NavigateToPage(HomePage);
        }


    }
}
