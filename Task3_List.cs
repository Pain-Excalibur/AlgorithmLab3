using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab3
{
    internal class Task3_List
    {
        public static void Start()
        {
            //создаем экземпляр класса StudentList и добавляем несколько студентов

            StudentList studentList = new StudentList();

            Student student1 = new Student { Name = "Иванов", Age = 20, Major = "Математика" };
            Student student2 = new Student { Name = "Петров", Age = 21, Major = "Физика" };
            Student student3 = new Student { Name = "Сидоров", Age = 19, Major = "Информатика" };

            studentList.AddStudent(student1);
            studentList.AddStudent(student2);
            studentList.AddStudent(student3);

            //операции поиска и удаления студентов  #вечнаяпамятьпетровичу

            Student foundStudent = studentList.FindStudent("Петров");
            Console.WriteLine($"Найден студент: {foundStudent.Name}, возраст: {foundStudent.Age}, специальность: {foundStudent.Major}");

            studentList.RemoveStudent(student2);
            Console.WriteLine("Студент удален");

            foundStudent = studentList.FindStudent("Петров");
            if (foundStudent == null)
            {
                Console.WriteLine("Студента с таким именем больше нет в списке");
            }
        }
    }


    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public Student Previous { get; set; }
        public Student Next { get; set; }
    }



    public class StudentList
    {
        private Student _head;
        private Student _tail;

        public void AddStudent(Student student)
        {
            if (_head == null)
            {
                _head = student;
                _tail = student;
            }
            else
            {
                _tail.Next = student;
                student.Previous = _tail;
                _tail = student;
            }
        }

        public void RemoveStudent(Student student)
        {
            if (student.Previous != null)
            {
                student.Previous.Next = student.Next;
            }
            else
            {
                _head = student.Next;
            }

            if (student.Next != null)
            {
                student.Next.Previous = student.Previous;
            }
            else
            {
                _tail = student.Previous;
            }
        }

        public Student FindStudent(string name)
        {
            Student current = _head;

            while (current != null)
            {
                if (current.Name == name)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }
    }


}
