// الواجهة
public interface IPerson
{
    string Name { get; }
    string Email { get; }
    string GetInfo();
}

// الفئة المجردة
public abstract class Person : IPerson
{

    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public abstract string GetInfo();
    public abstract string GetRole(); // دالة مجردة

    public static int PersonCount { get; private set; }

    public Person()
    {
        PersonCount++;
    }
}