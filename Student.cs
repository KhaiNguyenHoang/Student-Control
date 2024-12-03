namespace Student_Control;

public class Student<T1, T2>
{
    private string _fullname;
    private double[] _marks = new double[3];
    private string _parent;
    private T1 _studentId;
    private T2 _grade;

    public Student(string fullname, T2 grade, string parent, T1 studentId, double[] marks)
    {
        this._fullname = fullname;
        this._grade = grade;
        this.Grade = grade;
        this._parent = parent;
        this.Marks=marks;
        _studentId = studentId;
        AvgMarks = 0;
        foreach (var s in _marks)
        {
            AvgMarks = AvgMarks + s;
        }
        AvgMarks = AvgMarks / 3;
    }

    public double AvgMarks { get; set; }

    public string Fullname
    {
        get => _fullname;
        set => _fullname = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double[] Marks
    {
        get => _marks;
        set => _marks = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Parent
    {
        get => _parent;
        set => _parent = value ?? throw new ArgumentNullException(nameof(value));
    }

    public T1 StudentId
    {
        get => _studentId;
        set => _studentId = value;
    }

    public T2 Grade
    {
        get => _grade;
        set => _grade = value;
    }

    public override string ToString()
    {
        return
            $"{nameof(_studentId)}: {_studentId}, {nameof(_fullname)}: {_fullname}, {nameof(_parent)}: {_parent}, {nameof(_grade)}: {_grade}, {nameof(_marks)}: {_marks}";
    }
}