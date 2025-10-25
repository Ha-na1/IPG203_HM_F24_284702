using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIC_IPG203_F24_HM.Models

{
    public interface IPerson 
    {
        // واجهة  تمثل الشخص داخل النظام الجامعي
        //تطبق مبدأ التجريد (interface)

        string ID { get; }      // معرّف فريد للشخص للقراءة فقط لا يمكن ان يتغير بعد الانشاء     
        string Name { get; set; }
        string Email { get; set; }

        string GetDisplayName();          // دالة تُرجع الاسم مع المعرّف لعرضه بطريقة موحدة
        void PrintInfo();           // (دالة لطباعة معلومات الشخص في الشاشة (سيتم تنفيذها لاحقًا في الفئات الموروثة
    }
}
