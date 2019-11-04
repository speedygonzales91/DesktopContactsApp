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
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contact contact;
        public ContactDetailWindow(Contact selectedContact)
        {
            InitializeComponent();
            contact = selectedContact;

            InitializeControls();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            Close();
        }

        void InitializeControls()
        {
            nameTextBox.Text = contact.Name;
            phoneTextBox.Text = contact.PhoneNumber;
            emailTextBox.Text = contact.Email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.PhoneNumber = phoneTextBox.Text;
            contact.Email = emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            Close();
        }
    }
}
