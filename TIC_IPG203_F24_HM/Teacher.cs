//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TIC_IPG203_F24_HM
//{
   
//        // يرث من PersonBase
//        public class Teacher : PersonBase
//        {
//            //  الخصائص الخاصة بالأستاذ
//            public string Department { get; private set; }
//            public double Salary { get; private set; }
//            public List<string> CoursesTaught { get; private set; }

//            //  تطبيق الدالة المجردة من PersonBase
//            public override void Person_ADD(int id, string firstName, string lastName)
//            {
//                Id = id;
//                FirstName = firstName;
//                LastName = lastName;

//                // توليد بريد إلكتروني جامعي خاص بالأساتذة
//                Email = $"{firstName.ToLower()}.{lastName.ToLower()}@uni.edu";
//            }

//            //  الباني (Constructor)
//            public Professor(int id, string firstName, string lastName, string department, double salary)
//            {
//                Person_ADD(id, firstName, lastName);
//                Department = department;
//                Salary = salary;
//                CoursesTaught = new List<string>();
//            }

//            // 🧩 دوال لإدارة المواد التي يدرّسها
//            public void AddCourse(string courseName)
//            {
//                if (!string.IsNullOrWhiteSpace(courseName) && !CoursesTaught.Contains(courseName))
//                {
//                    CoursesTaught.Add(courseName);
//                    Console.WriteLine($"📘 Professor {FullName} now teaches {courseName}");
//                }
//                else
//                {
//                    Console.WriteLine("⚠️ Invalid or duplicate course.");
//                }
//            }

//            public void RemoveCourse(string courseName)
//            {
//                if (CoursesTaught.Remove(courseName))
//                    Console.WriteLine($"❌ Course removed: {courseName}");
//                else
//                    Console.WriteLine("⚠️ Course not found.");
//            }

//            // دالة لحساب الدخل الشهري مع العلاوة
//            public double CalculateMonthlyIncome()
//            {
//                double bonus = CoursesTaught.Count * 100; // 100 لكل مادة
//                return Salary + bonus;
//            }

//            // إعادة تعريف لطباعة المعلومات (Polymorphism)
//            public override void PrintInfo()
//            {
//                Console.WriteLine($"👨‍🏫 Professor: {FullName} (ID: {Id})");
//                Console.WriteLine($"🏛️ Department: {Department}, Salary: {Salary:C}");
//                Console.WriteLine("Courses taught: " + (CoursesTaught.Count > 0 ? string.Join(", ", CoursesTaught) : "No courses yet."));
//            }

//        }
//}


