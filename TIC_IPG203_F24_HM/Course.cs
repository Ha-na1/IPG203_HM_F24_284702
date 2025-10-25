public class Course
{
    private string _courseId;
    private string _courseName;

    public string CourseId
    {
        get => _courseId;
        private set => _courseId = value;
    }

    public string CourseName
    {
        get => _courseName;
        set => _courseName = value;
    }

    public Course(string id, string name)
    {
        CourseId = id;
        CourseName = name;
    }
}