using Student_Control;
using static System.Console;

namespace MyNamespace;

internal class Program
{
    private static void Main(string[] args)
    {
        StudentList studentList = new StudentList();
        studentList.AddStudent();
        Write(studentList.ToString());
    }
}