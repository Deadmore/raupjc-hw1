using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student student1 = (Student) obj;
                return Name.Equals(student1.Name) && Jmbag.Equals(student1.Jmbag) && (Gender == student1.Gender);
            }

            return false;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (object.ReferenceEquals(student1, null))
            {
                return object.ReferenceEquals(student2, null);
            }

            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            if (object.ReferenceEquals(student1, null))
            {
                return !object.ReferenceEquals(student2, null);
            }

            return student1.Equals(student2);
        }

        public override int GetHashCode()
        {
            int i = Gender == Gender.Male ? 1 : 0;
            return Name.GetHashCode() + Jmbag.GetHashCode() + i + 7;
        }
    }
    public enum Gender
    {
        Male, Female
    }


}
