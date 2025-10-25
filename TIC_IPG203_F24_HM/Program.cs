using System;

class Program
{
    static void Main()
    {
        var manager = new UniversityManager();

        // إشتراك في الحدث
        manager.OnPersonAdded += (msg) => Console.WriteLine($"Notification: {msg}");

        // إنشاء كائنات
        var student = new Student("Ahmed", "ahmed@uni.sy", "2023001");
        var professor = new Professor("Dr. Sami", "sami@uni.sy", "Computer Science");

        // إضافة الكائنات (تعدد الأشكال)
        manager.AddPerson(student);
        manager.AddPerson(professor);

        // استخدام الفئة الساكنة
        Console.WriteLine($"Total Persons: {Person.PersonCount}");

        // التحقق من البيانات
        Console.WriteLine($"Valid Email: {Validator.IsValidEmail("test@email.com")}");
    }
}