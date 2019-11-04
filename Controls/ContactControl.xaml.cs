using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        private Contact _contact;

        public Contact Contact
        {
            get { return _contact; }
            set 
            { 
                _contact = value;
                nameTextBox.Text = Contact.Name;
                phoneTextBox.Text = Contact.PhoneNumber;
                emailTextBox.Text = Contact.Email;
            }
        }


        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
