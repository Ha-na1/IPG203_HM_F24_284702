using System;
using System.Collections.Generic;
using TIC_IPG203_F24_HM;
//using TIC_IPG203_F24_HM.Models.Students;
using TIC_IPG203_F24_HM.Models;
using TIC_IPG203_F24_HM.Validators;
using TIC_IPG203_F24_HM.Models.Students;
//using TIC_IPG203_HM_F24_UN_HM.Models.Students;

namespace TIC_IPG203_F24_HM
{
    // البرنامج الرئيسي لتشغيل نظام إدارة الطلاب في الجامعة
    // يحتوي على القائمة الرئيسية التي تمكّن المستخدم من التفاعل مع النظام
    class Program
    {
        // قائمة تخزن المواد الدراسية المتاحة في الجامعة
        private static List<Course> availableCourses = new List<Course>();
        // كائن من StudentManager لإدارة إضافة وطباعة الطلاب مبدأ التجريد
        private static StudentManager manager = new StudentManager();
        // قائمة عامة مساعدة لجميع الطلاب المسجلين في النظام
        private static List<PersonBase> allStudents = new List<PersonBase>();

        // نقطة الدخول الرئيسية للبرنامج
        static void Main()
        {
            // تهيئة النظام بإضافة بعض المواد الافتراضية
            InitializeSystem();

            Console.WriteLine("UniversityApp - demo (OOP concepts)\n");
            manager.OnPersonAdded += (msg) => Console.WriteLine($"Notification: {msg}");

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddCourseToStudent();
                        break;
                    case "3":
                        AddGradeToStudent();
                        break;
                    case "4":
                        manager.PrintAll();
                        break;
                    case "5":
                        ShowAvailableCourses();
                        break;
                    case "6":
                        AddNewCourse();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            Console.WriteLine($"\nStats.TotalStudents = {Stats.TotalStudents}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // دالة لإضافة مواد افتراضية للنظام عند البداية
        static void InitializeSystem()
        {
            availableCourses.Add(new Course("IPG101", "Introduction to Programming", 3));
            availableCourses.Add(new Course("GMA101", "Basic Mathematics", 3));
            availableCourses.Add(new Course("GBS102", "Career Preparation ", 3));
            availableCourses.Add(new Course("IPG203", "Object Oriented Programming", 3));
            availableCourses.Add(new Course("ENG101", "English Language", 2));
        }

        // دالة لعرض القائمة الرئيسية للمستخدم
        static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Main Menu ===");
            Console.ResetColor();
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Add Course to Student");
            Console.WriteLine("3. Add Grade to Student");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Show Available Courses");
            Console.WriteLine("6. Add New Course");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");
        }

        // دالة لإضافة طالب جديد إلى النظام حسب نوعه
        static void AddStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Add New Student ===");
            Console.ResetColor();
            Console.WriteLine("Choose student type:");
            Console.WriteLine("1. Undergraduate Student");
            Console.WriteLine("2. Postgraduate Student");
            Console.WriteLine("3. Exchange Student");
            Console.Write("Choose type: ");

            string typeChoice = Console.ReadLine();
            Console.Write("Enter student ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            // إنشاء كائن الطالب المناسب بناءً على الاختيار
            PersonBase student = null;

            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter academic year: ");
                    int year = int.Parse(Console.ReadLine());
                    student = new UndergraduateStudent(id, name, email, year);
                    break;
                case "2":
                    Console.Write("Enter supervisor name: ");
                    string supervisor = Console.ReadLine();
                    student = new PostgraduateStudent(id, name, email, supervisor);
                    break;
                case "3":
                    Console.Write("Enter home university: ");
                    string homeUniversity = Console.ReadLine();
                    student = new ExchangeStudent(id, name, email, homeUniversity);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid student type!");
                    Console.ResetColor();
                    return;
            }

            manager.AddStudent(student);
            allStudents.Add(student); // إضافة الطالب إلى القائمة العامة للمساعدة في العمليات الأخرى
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student added successfully!");
            Console.ResetColor();

        }
        // دالة لربط مادة دراسية إلى طالب معين
        static void AddCourseToStudent()
        {
            if (allStudents.Count == 0)
            {
                Console.WriteLine("No students registered!");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Add Course to Student ===");
            Console.ResetColor();
            manager.PrintAll();
            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();

            var student = allStudents.Find(s => s.ID == studentId);
            if (student != null)
            {
                ShowAvailableCourses();
                Console.Write("Enter course code: ");
                string courseCode = Console.ReadLine();

                var course = availableCourses.Find(c => c.Code == courseCode);
                if (course != null)
                {
                    student.AddCourse(courseCode);
                    Console.WriteLine($"Course {courseCode} added to student {student.Name}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid course code!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student not found!");
                Console.ResetColor();

            }
        }

        // (إضافة درجة لطالب محدد (تطبيق مبدأ الأحداث
        static void AddGradeToStudent()
        {
            if (allStudents.Count == 0)
            {
                Console.WriteLine("No students registered!");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Add Grade to Student ===");
            Console.ResetColor();
            manager.PrintAll();
            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();

            var student = allStudents.Find(s => s.ID == studentId);
            if (student != null)
            {
                // التحقق من أن الطالب من نوع StudentWithGrades
                if (student is StudentWithGrades studentWithGrades)
                {
                    Console.Write("Enter grade: ");
                    if (double.TryParse(Console.ReadLine(), out double grade))
                    {
                        studentWithGrades.AddGrade(grade);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Grade added successfully!");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine("Invalid grade!");
                    }
                }
                else
                {
                    Console.WriteLine("This student type does not support adding grades!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        // عرض جميع المواد الدراسية المتاحة
        static void ShowAvailableCourses()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Available Courses ===");
            Console.ResetColor();
            foreach (var course in availableCourses)
            {
                Console.WriteLine($"{course.Code} - {course.Name} ({course.Credits} credits)");
            }
        }


        // إضافة مادة جديدة إلى قائمة المواد
        static void AddNewCourse()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n=== Add New Course ===");
            Console.ResetColor();
            Console.Write("Enter course code: ");
            string code = Console.ReadLine();
            Console.Write("Enter course name: ");
            string name = Console.ReadLine();
            Console.Write("Enter credit hours: ");
            int credits = int.Parse(Console.ReadLine());

            availableCourses.Add(new Course(code, name, credits));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Course added successfully!");
            Console.ResetColor();
        }
    }


    // فئة تمثل مادة دراسية في الجامعة
    // تطبّق مبدأ التغليف (Encapsulation)
    public class Course
    {
        // خصائص المادة الدراسية: الكود، الاسم، وعدد الساعات المعتمدة
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Course(string code, string name, int credits)
        {
            Code = code;
            Name = name;
            Credits = credits;
        }
    }
}
