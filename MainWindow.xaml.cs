using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDatabase();
        }

        private void newContactsWindowButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            //newContactWindow.Show();

            //ShowDialog disables the user to click out
            newContactWindow.ShowDialog();

            //After showdialog() - close the form or presssed save button - it will be called!
            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList();
            }

            if (contacts != null)
            {
                //foreach (var contact in contacts)
                //{
                //    contactsListview.Items.Add(new ListViewItem()
                //    {
                //        Content = contact
                //    });
                //}

                //The above code is happening behind the scenes! but this one calls the clear on it to avoid duplicating elements!
                contactsListview.ItemsSource = contacts;
            }
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(filterTextBox.Text.ToLower()));

            contactsListview.ItemsSource = filteredList;
        }
    }
}
