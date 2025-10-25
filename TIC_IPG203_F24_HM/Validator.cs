public static class Validator
{
    public static bool IsValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public static bool IsValidId(string id)
    {
        return !string.IsNullOrEmpty(id) && id.Length >= 5;
    }
}

public class User
{
    public static int PersonCount { get; private set; }

    public User()
    {
        PersonCount++;
    }
}