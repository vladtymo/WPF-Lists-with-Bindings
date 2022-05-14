using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace _01_ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // INotifyCollectionChanged
        ObservableCollection<Person> people = null;

        public MainWindow()
        {
            InitializeComponent();

            people = new ObservableCollection<Person>()
            {
                new Person() { Name = "Bogdan", Surname = "Bogdan", Birth = new System.DateTime(1990, 1, 1)},
                new Person() { Name = "Vikrotia", Surname = "Leveg", Birth = new System.DateTime(1994, 5, 10)},
                new Person() { Name = "Sasha", Surname = "Kofae", Birth = new System.DateTime(1980, 12, 14)}
            };

            // clear collection
            comboBox.Items.Clear();

            //foreach (var p in people)
            //{
            //    comboBox.Items.Add(p);
            //}

            // binding collection to list items
            comboBox.ItemsSource = people;                      // show ToString() by default

            // nameof - get object name as string value 
            //comboBox.DisplayMemberPath = nameof(Person.Name);   // show specific property
            //comboBox.DisplayMemberPath = nameof(Person.FullName);
            comboBox.DisplayMemberPath = $"{nameof(Person.Birth)}.{nameof(Person.Birth.Year)}";
            comboBox.DisplayMemberPath = null;
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
            {
                MessageBox.Show(comboBox.SelectedItem.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newPerson = new Person() { Name = "New Name", Surname = "New Surname", Birth = new System.DateTime(1990, 1, 1) };
            people.Add(newPerson);
            //comboBox.Items.Add(newPerson); error
        }
    }
}
