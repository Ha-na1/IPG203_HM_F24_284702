

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Models;
namespace TIC_IPG203_F24_HM.Services
{
    // فئة مخصّصة لحمل بيانات الحدث عند تغيّر معدل الطالب (GPA)
    // تطبّق مبدأ الأحداث (Events) 

    public class StudentGradesChangedEventArgs : EventArgs
    {
        public string StudentId { get; }
        public double NewGpa { get; }
        public StudentGradesChangedEventArgs(string id, double gpa) { StudentId = id; NewGpa = gpa; }
    }
    // الفئة التي تمثل طالب يمتلك درجات
    //تطبّق مبدأ الوراثة (Inheritance)
    public class StudentWithGrades : PersonBase
    {
        // قائمة خاصة لحفظ درجات الطالب (تطبيق التغليف Encapsulation)
        private readonly List<double> _grades = new List<double>();
        private const double Threshold = 2.0;
        public event EventHandler<StudentGradesChangedEventArgs> OnGpaBelowThreshold;

        // باني (Constructor) يستدعي باني الفئة الأب
        public StudentWithGrades(string id, string name, string email) : base(id, name, email) { }
        // إضافة درجة جديدة وحساب المعدل الجديد مع إطلاق الحدث إذا كان المعدل أقل من الحد المحدد
        public void AddGrade(double g)
        {
            _grades.Add(g);
            double gpa = _grades.Average();
            if (gpa < Threshold) OnGpaBelowThreshold?.Invoke(this, new StudentGradesChangedEventArgs(ID, gpa));
        }
        // دالة لحساب المعدل الحالي للطالب
        public double GetGpa() => _grades.Count == 0 ? 0.0 : _grades.Average();

        // تجاوز (Override) دالة الطباعة من الفئة الأب لعرض المعدل
        // (تطبيق مبدأ تعدد الأشكال Polymorphism)
        public override void PrintInfo() => Console.WriteLine($"{GetDisplayName()} - GPA: {GetGpa():0.00}");
    }

}
