using System.Collections.Generic;

public delegate void NotifyHandler(string message);

public class UniversityManager
{
    public event NotifyHandler OnPersonAdded;

    private List<Person> _people = new List<Person>();

    public void AddPerson(Person person)
    {
        _people.Add(person);
        OnPersonAdded?.Invoke($"New {person.GetRole()} added: {person.Name}");
    }
}