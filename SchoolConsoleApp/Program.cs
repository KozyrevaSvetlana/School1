using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"В школе {Name} пока нет учеников!");
            }
            else
            {
                Console.WriteLine("{0, -20} {1, -20} {2, -10} {3, -10}", "Номер", "Имя", "Фамилия", "Возраст");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{0, -10} {1, -20} {2, -20} {3, -10}", i + 1, Students[i].FirstName, Students[i].LastName, Students[i].Age);
                }
            }
        }

        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.FirstName} успешно добавлен в школу {Name}.");
        }
        public void DeleteStudent(int k)
        {
            string first = "";
            string last = "";
            for (int i = 0; i < Students.Count; i++)
            {
                if (i == k - 1)
                {
                    first = Students[i].FirstName;
                    last = Students[i].LastName;
                    break;
                }
            }
            Students.RemoveAt(k - 1);
            Console.WriteLine($"Студент {first} {last} исключен из школы {Name}.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите название вашей школы");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешно создана");

            while (true)
            {
                Console.WriteLine($"Хотите посмотреть список учеников школы {school.Name}? Введите да или нет.");
                string userAnswer = Console.ReadLine().ToLower();
                while (userAnswer != "да")
                {
                    if (userAnswer == "нет")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Хотите посмотреть список учеников школы {school.Name}? Введите да или нет.");
                        userAnswer = Console.ReadLine().ToLower();
                    }
                }
                if (userAnswer == "да")
                {
                    school.PrintStudents();
                }
                Console.WriteLine($"Хотите добавить нового ученика в школу {school.Name}? Введите да или нет. ");
                userAnswer = Console.ReadLine().ToLower();
                if (userAnswer == "да")
                {
                    Console.WriteLine($"Введите имя ученика");
                    string firstName = Console.ReadLine();
                    Console.WriteLine($"Введите фамилию ученика");
                    string lastName = Console.ReadLine();
                    Console.WriteLine($"Введите возраст ученика");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(firstName, lastName, age);
                    school.AddNewStudent(student);
                }


                Console.WriteLine($"Хотите отчислить ученика из школы {school.Name}? Введите да или нет.");
                userAnswer = Console.ReadLine().ToLower();
                while (userAnswer != "да")
                {
                    if (userAnswer == "нет")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Хотите отчислить ученика из школы {school.Name}? Введите да или нет.");
                        userAnswer = Console.ReadLine().ToLower();
                    }
                }
                if (userAnswer == "да")
                {
                    school.PrintStudents();
                    Console.WriteLine($"Напишите порядковый номер ученика");
                    string userInput = Console.ReadLine();
                    int DeleteStudent;
                    bool IsValid = int.TryParse(userInput, out DeleteStudent);

                    while (DeleteStudent > school.Students.Count || DeleteStudent < 0)
                    {
                        Console.WriteLine($"Неверный ввод. Напишите порядковый номер ученика");
                        IsValid = int.TryParse(userInput, out DeleteStudent);
                    }
                    school.DeleteStudent(DeleteStudent);
                }
            }
        }
    }
}


