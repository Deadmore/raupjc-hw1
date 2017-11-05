using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1;
using Zadatak_4;

namespace Tester_1
{ // classa za testanje linq metoda
    class Program
    {
        static void Main(string[] args)
        {
            University FER = new University();
            FER.Name = "FER";

            Student Ante = new Student("Ante", "0036");
            Ante.Gender = Gender.Male;
            Student Bernard = new Student("Bernard", "0035");
            Bernard.Gender = Gender.Male;
            Student Ante1 = new Student("Ante", "0036");
            Ante1.Gender = Gender.Male;
            Student Stjepan = new Student("Stjepan", "0031");
            Stjepan.Gender = Gender.Male;

            Student[] students = new Student[4];

            students[0] = Ante;
            students[1] = Ante1;
            students[2] = Bernard;
            students[3] = Stjepan;

            FER.Students = students;

            University FIL = new University();
            FIL.Name = "FIL";

            Student Ana = new Student("Ana", "3036");
            Ana.Gender = Gender.Female;
            Student Bernarda = new Student("Bernarda", "3035");
            Bernarda.Gender = Gender.Female;
            Student Stjepana = new Student("Stjepan", "3031");
            Stjepana.Gender = Gender.Male;
            Student Ante2 = new Student("Ante", "0036");
            Ante.Gender = Gender.Male;

            Student[] studentsf = new Student[4];

            studentsf[0] = Ana;
            studentsf[3] = Ante2;
            studentsf[2] = Bernarda;
            studentsf[1] = Stjepan;

            FIL.Students = studentsf;

            University[] Faksovi = {FER, FIL};
            Faksovi[0] = FER;
            Faksovi[1] = FIL;

            Student[] s = HomeworkLinqQueries.Linq2_5(Faksovi);

            foreach (Student stu in s)
            {
                Console.WriteLine(stu.Name + stu.Jmbag);
            }



        }
    }
}
