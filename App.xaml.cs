using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Set up database attributes
        public static string databaseName = "Contacts.db";
        //This will look for MyDocuments folder path
        public static string foldername = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //Create the final path
        public static string databasePath = System.IO.Path.Combine(foldername, databaseName);
    }
}
