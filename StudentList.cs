namespace Student_Control;

#region

using static Console;

#endregion

public class StudentList
{
    private List<Student<string, string>> _students;

    public StudentList()
    {
        _students = new List<Student<string, string>>();
    }

    public List<Student<string, string>> Students
    {
        get => _students;
        set => _students = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddStudent()
    {
        Write("Enter student ID: ");
        var studentId = ReadLine();
        Write("Enter student name: ");
        var name = ReadLine();
        Write("Enter name of parent: ");
        var parent = ReadLine();
        Write("Enter grade: ");
        var grade = ReadLine();
        var listMark = new double[3];
        for (var i = 0; i < 3; i++)
        {
            Write($"Enter mark for subject {i + 1}: ");
            while (true)
            {
                var input = ReadLine();
                if (double.TryParse(input, out var mark))
                {
                    listMark[i] = mark;
                    break;
                }

                WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        if (name != null)
        {
            var newstudent = new Student<string, string>(name, grade, parent, studentId, listMark);
            _students.Add(newstudent);
        }

        WriteLine("Added student!");
    }

    public override string ToString()
    {
        var output = "";
        foreach (var student in _students) // Lặp qua từng phần tử của _students
        {
            output += $"{student.ToString()}\n";
        }
        return output;
    }

    public void RemoveStudent()
    {
        var flag = false;
        Write("Enter student ID: ");
        var id = ReadLine();
        foreach (var student in _students)
            if (student.StudentId == id)
            {
                _students.Remove(student);
                flag = true;
                break;
            }

        if (flag)
            WriteLine("Removed student!");
        else
            WriteLine("Student not found!");
    }
}