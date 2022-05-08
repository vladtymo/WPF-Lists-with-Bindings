using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ComboBox
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string FullName => Name + " " + Surname;

        public override string ToString()
        {
            return $"{Name} {Surname} - {Birth.ToLongDateString()}";
        }
    }
}
