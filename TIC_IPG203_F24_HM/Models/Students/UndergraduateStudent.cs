using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Services;

namespace TIC_IPG203_F24_HM.Models.Students
{
    // الفئة التي تمثل طالب جامعي
    //تطبّق مبدأ الوراثة (Inheritance)
    public class UndergraduateStudent : StudentWithGrades
    {
        public int Year { get; private set; }
        // منشئ الفئة مع التحقق من صحة السنة الدراسية
        public UndergraduateStudent(string id, string name, string email, int year)
                : base(id, name, email)
        {
            if (year < 1 || year > 6) throw new ArgumentException("Year must be between 1 and 6");
            Year = year;

        }
        //تجاوز (Override) دالة طباعة المعلومات من الفئة الأب
        public override void PrintInfo()
        {
            Console.WriteLine($"Undergrad: {GetDisplayName()}, Year: {Year}, GPA: {GetGpa():0.00}");
        }
    }


}
