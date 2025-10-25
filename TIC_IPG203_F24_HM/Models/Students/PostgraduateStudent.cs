using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Services;

namespace TIC_IPG203_F24_HM.Models.Students
{ // الفئة التي تمثل طالب دراسات عليا
  //تطبّق مبدأ الوراثة (Inheritance)
  //  لأنها ترث من الفئة StudentWithGrades
    public class PostgraduateStudent : StudentWithGrades
    {
        // خاصية لاسم المشرف الأكاديمي
        public string Supervisor { get; private set; }

        public PostgraduateStudent(string id, string name, string email, string supervisor)
            : base(id, name, email)
        {
            Supervisor = supervisor;
        }
        //تجاوز (Override) دالة طباعة المعلومات من الفئة الأب
        public override void PrintInfo()
        {
            Console.WriteLine($"Postgrad: {GetDisplayName()}, Supervisor: {Supervisor}, GPA: {GetGpa():0.00}");
        }
    }
}

