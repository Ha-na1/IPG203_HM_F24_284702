using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Models;
using TIC_IPG203_F24_HM.Models.Students;

namespace TIC_IPG203_F24_HM
{

    // يستخدم لتمثيل الدوال التي يمكن استدعاؤها عند حدوث حدث معين
    // مبدأ التفويض (Delegates)

    public delegate void NotifyHandler(string message);
    // فئة لإدارة الطلاب وإضافة طلاب جدد مع إطلاق الأحداث عند الإضافة
    //  تطبق مبدأ التغليف من خلال إخفاء قائمة الطلاب داخل الفئة  (Encapsulation)
    public class StudentManager
    {
        // حدث يتم إطلاقه عند إضافة طالب جديد
        public event NotifyHandler OnPersonAdded;

        // قائمة خاصة لحفظ الطلاب
        private List<PersonBase> _students = new List<PersonBase>();
        // دالة لإضافة طالب جديد مع تحديث الإحصائيات وإطلاق الحدث المناسب تطبق مفهوم الوارثة
        public void AddStudent(PersonBase s)
        {
            _students.Add(s);
            Stats.TotalStudents++;
            // الاشتراك في حدث انخفاض المعدل إذا كان الطالب من نوع StudentWithGrades
            if (s is StudentWithGrades sg) sg.OnGpaBelowThreshold += (sender, e) =>
                Console.WriteLine($"ALERT: {e.StudentId} GPA dropped to {e.NewGpa:0.00}");
            OnPersonAdded?.Invoke($"New student added");
        }
        // دالة لطباعة معلومات جميع الطلاب في النظام
        public void PrintAll() { foreach (var s in _students) s.PrintInfo(); }
    }




}
