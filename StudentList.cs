namespace Student_Control;
using static System.Console;

public class StudentList
{
    private List<Student<string, string>> students;

    public StudentList()
    {
        students = new List<Student<string, string>>();
    }

    public List<Student<string, string>> Students
    {
        get => students;
        set => students = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddStudent()
    {
        Write("Enter student ID: ");
        var name = ReadLine();
        Write("Enter student name: ");
        var studentID = ReadLine();
        Write("Enter name of parent: ");
        var parent  = ReadLine();
        Write("Enter grade: ");
        var grade = ReadLine();
        double[] listMark= new double[3]; 
        for (int i = 0; i < 3; i++)
        {
            Write($"Enter mark for subject {i + 1}: ");
            while (true)
            {
                string input = ReadLine();
                if (double.TryParse(input, out double mark))
                {
                    listMark[i] = mark;
                    break; 
                }
                else
                {
                    WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        var newstudent = new Student<string, string>(name, grade, parent, studentID, listMark);
        students.Add(newstudent);
        WriteLine("Added student!");
    }

    public override string ToString()
    {
        string output = "";
        foreach (var student in students)
        {
            output += $"Name: {student.Fullname}, Student ID: {student.StudentId}, Grade: {student.Grade}, Parent: {student.Parent}, Student Avg Marks: {student.AvgMarks}\n";
        }
        return output;
    }

    public void removeStudent()
    {
        bool flag = false;
        Write("Enter student ID: ");
        var id = ReadLine();
        foreach (var student in students)
        {
            if (student.StudentId == id)
            {
                students.Remove(student);
                flag = true;
                break;
            }
        }

        if (flag)
        {
            WriteLine("Removed student!");
        }
        else
        {
            WriteLine("Student not found!");
        }
    }
}