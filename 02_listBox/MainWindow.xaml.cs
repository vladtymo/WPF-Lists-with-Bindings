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
        ObservableCollection<Student> group = new ObservableCollection<Student>();
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
            list.DisplayMemberPath = nameof(Student.FullName);
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
                p.Name = "New Name";
                p.Age++;
            }
        }
    }

   
    class Student : INotifyPropertyChanged
    {
        private string name;
        public string Name 
        { 
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            } 
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string FullName => Name + " : " + Age;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} : {Age}";
        }

    }
}
