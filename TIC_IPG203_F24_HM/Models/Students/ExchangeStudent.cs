using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Services;

namespace TIC_IPG203_F24_HM.Models.Students
{
    // الفئة التي تمثل طالب تبادل طلابي
    //تطبّق مبدأ الوراثة (Inheritance)
    public class ExchangeStudent : StudentWithGrades
    {
        public string HomeUniversity { get; private set; }
        // منشئ الفئة مع تعيين اسم الجامعة الأصلية
        public ExchangeStudent(string id, string name, string email, string homeUniversity)
                : base(id, name, email)
        {
            HomeUniversity = homeUniversity;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Exchange: {GetDisplayName()}, Home Uni: {HomeUniversity}, GPA: {GetGpa():0.00}");
        }
    }
}

