﻿using System;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace HelpSistem
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        private JavaScriptControlHelper ch;
        public HelpViewer(string key, Window originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("../../html/{0}.html", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("file:///{0}/../../html/{1}.html", curDir, key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
         
           

        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }


    }
}
