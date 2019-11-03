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
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                PhoneNumber = phoneTextBox.Text,
                Email = emailTextBox.Text
            };

            //Connect to SQLite --using can only use IDisposable interface descendants. Implements this interface.
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                //Create Contact table. If it is already exists it will be skipped!
                connection.CreateTable<Contact>();
                //Insert the newly created object
                connection.Insert(contact);
            }
            
            //Closing the form
            Close();
        }
    }
}
