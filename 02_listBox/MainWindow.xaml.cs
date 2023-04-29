using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace _02_listBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // INotifyCollectionChanged -> CollectionChanged
        ObservableCollection<Student> group = null;
        public MainWindow()
        {
            InitializeComponent();

            group = new ObservableCollection<Student>()
            {
                new Student() {Name = "Bob", Age = 30},
                new Student() {Name = "Will", Age = 35},
                new Student() {Name = "Tom", Age = 10},
                new Student() {Name = "Jack", Age = 17},
            };

            list.Items.Clear();

            //group.CollectionChanged += (s, e) => MessageBox.Show("Changed");

            // прив'язка колекціх до ListBox
            list.ItemsSource = group;
            // встановлення властивості елемента для відображення    
            list.DisplayMemberPath = nameof(Student.FullInfo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            group.Add(new Student() { Name = "Bill", Age = 30 });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                group.Remove(list.SelectedItem as Student);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                Student p = list.SelectedItem as Student;

                // Notify about Property Changed
                p.Name += "!";
                p.Age++;
            }
        }
    }

    class Student : INotifyPropertyChanged
    {
        private string name;
        private int age;

        public string Name
        {
            get => name;
            set
            {
                this.name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullInfo"));
            }
        }
        public int Age
        {
            get => age;
            set
            {
                this.age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullInfo"));
            }
        }

        public string FullInfo => Name + " : " + Age; // getter

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} : {Age}";
        }
    }
}
