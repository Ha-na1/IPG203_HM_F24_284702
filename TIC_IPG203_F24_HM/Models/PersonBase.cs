using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIC_IPG203_F24_HM.Models;
using TIC_IPG203_F24_HM.Validators;

namespace TIC_IPG203_F24_HM.Models
{
    // الفئة المجردة الأساسية لجميع الأشخاص في النظام (Abstract Class)

    public abstract class PersonBase : IPerson
    {
        // حقول خاصة لا يمكن الوصول اليها خارج الكلاس تطبيق لمفهوم التغليف
        private readonly string _id; // معرف ثابت لا يمكن تغييره بعد الإنشاء
        private string _name;
        private string _email;

        // يُستخدم لإنشاء كائن جديد مع التحقق من صحة البيانات
        protected PersonBase(string id, string name, string email)
        {
            //  ( Validation التحقق من صحة القيم قبل تخزينها (استدعاء دوال من كلاس 
            if (!Validation.IsValidId(id)) throw new ArgumentException("Invalid id");
            if (!Validation.IsValidName(name)) throw new ArgumentException("Invalid name");
            if (!Validation.IsValidEmail(email)) throw new ArgumentException("Invalid email");

            _id = id;
            _name = name;
            _email = email;
        }

        public string ID => _id;
        public string Name { get => _name; set { if (!Validation.IsValidName(value)) throw new ArgumentException(); _name = value; } }
        public string Email { get => _email; set { if (!Validation.IsValidEmail(value)) throw new ArgumentException(); _email = value; } }

        protected List<string> Courses { get; } = new List<string>(); // قائمة المواد الخاصة بالشخص
        // إضافة مادة جديدة إلى القائمة مع التحقق من التكرار
        public void AddCourse(string course) { if (!string.IsNullOrWhiteSpace(course) && !Courses.Contains(course)) Courses.Add(course); }

        // إرجاع نسخة للقراءة فقط من قائمة المواد
        public IReadOnlyList<string> GetCourses() => Courses.AsReadOnly();

        // دالة تُرجع الاسم مع المعرّف لعرضه بطريقة موحدة
        public virtual string GetDisplayName() => $"{Name} ({ID})";

        // تُجبر الفئات الموروثة على تنفيذها بأسلوبها الخاص <دالة مجردة
        public abstract void PrintInfo();
    }

}
