

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F24_HM.Validators
{
    // فئة تحتوي على دوال للتحقق من صحة البيانات
    public static class Validation
    {
        // دالة للتحقق من صحة المعرف
        public static bool IsValidId(string id) => !string.IsNullOrWhiteSpace(id);
        public static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name);
        public static bool IsValidEmail(string email) => !string.IsNullOrWhiteSpace(email) && email.Contains("@");
    }

}
