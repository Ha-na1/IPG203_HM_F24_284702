//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;



//    namespace TIC_IPG203_F24_HM
//    { 

//        // الفئة المجردة التي تطبّق الواجهة IPerson
//        public abstract class PersonBase : IPerson
//        {
//            //  المتغيرات الخاصة (Encapsulation)
//            private int _id;
//            private string _firstName;
//            private string _lastName;
//            private string _email;

//            //  الخصائص (Properties)
//            public int Id
//            {
//                get => _id;                 // يمكن قراءته من أي مكان
//                protected set               // يمكن تغييره فقط داخل هذا الكلاس أو كلاس يرث منه
//                {
//                    if (value <= 0)
//                        throw new ArgumentException("ID must be positive.");
//                    _id = value;
//                }
//            }

//            public string FirstName
//            {
//                get => _firstName;
//                protected set
//                {
//                    if (string.IsNullOrWhiteSpace(value))
//                        throw new ArgumentException("First name cannot be empty.");
//                    _firstName = value.Trim();
//                }
//            }

//            public string LastName
//            {
//                get => _lastName;
//                protected set
//                {
//                    if (string.IsNullOrWhiteSpace(value))
//                        throw new ArgumentException("Last name cannot be empty.");
//                    _lastName = value.Trim();
//                }
//            }

//            public string FullName => $"{FirstName} {LastName}";

//            public string Email
//            {
//                get => _email;
//                protected set
//                {
//                    if (!value.Contains("@") || !value.Contains("."))
//                        throw new ArgumentException("Invalid email address.");
//                    _email = value.Trim();
//                }
//            }

//            //  دالة مجردة يجب على الكلاسات الموروثة تنفيذها
//            public abstract void Person_ADD(int id, string firstName, string lastName);

//            //  دالة افتراضية يمكن للكلاسات الموروثة إعادة تعريفها
//            public virtual void PrintInfo()
//            {
//                Console.WriteLine($"ID: {Id} | Name: {FullName} | Email: {Email}");
//            }

//            //  دالة إضافية لعرض الاسم الكامل بطريقة موحدة
//            public virtual string GetDisplayName()
//            {
//                return $"{FullName} (ID: {Id})";
//            }
//        }
//    }

//}
