public class Student : Person
{
    public string StudentId { get; private set; }

    public Student(string name, string email, string id)
    {
        Name = name;
        Email = email;
        StudentId = id;
    }

    public override string GetInfo() => $"Student: {Name} | ID: {StudentId}";
    public override string GetRole() => "Student";
}

public class Professor : Person
{
    public string Department { get; private set; }

    public Professor(string name, string email, string dept)
    {
        Name = name;
        Email = email;
        Department = dept;
    }

    public override string GetInfo() => $"Prof. {Name} | Department: {Department}";
    public override string GetRole() => "Professor";
}