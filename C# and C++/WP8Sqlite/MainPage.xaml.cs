using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using FlashCardApp.Core.Managers;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using WP8Sqlite.Entities;
using WP8Sqlite.Resources;

namespace WP8Sqlite
{
    public partial class MainPage : PhoneApplicationPage
    {
        private DictionarySearchManager searchManager;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            searchManager = new DictionarySearchManager();
        }

        private void FilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
           resultsView.ItemsSource = searchManager.SearchByEnglish(FilterTextBox.Text);
            

        }


        private void SetSelected(object sender, SelectionChangedEventArgs e)
        {
            //not applicable in test project
        }

       
    }
}