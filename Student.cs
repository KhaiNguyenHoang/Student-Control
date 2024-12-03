using System.Text.Unicode;

namespace Student_Control;

public class Student<T1, T2> : ISpanFormattable, IUtf8SpanFormattable
{
    private string _fullname;
    private T2 _grade;
    private double[] _marks = new double[3];
    private string _parent;
    private T1 _studentId;
    private HocLuc _hocLuc;

    public HocLuc HocLuc
    {
        get => _hocLuc;
        set => _hocLuc = value;
    }

    public Student(string fullname, T2 grade, string parent, T1 studentId, double[] marks)
    {
        _fullname = fullname;
        _grade = grade;
        Grade = grade;
        _parent = parent;
        Marks = marks;
        _studentId = studentId;
        AvgMarks = 0;
        foreach (var s in _marks) AvgMarks = AvgMarks + s;
        AvgMarks = AvgMarks / 3;
        _hocLuc = new HocLuc();
        if (AvgMarks <= 3)
        {
            _hocLuc = HocLuc.Kem;
        }
        else
        {
            if (AvgMarks <= 5)
            {
                _hocLuc = HocLuc.Trungbinh;
            }
            else
            {
                if (AvgMarks <= 8)
                {
                    _hocLuc = HocLuc.Kha;
                }
                else
                {
                    if (AvgMarks <= 10)
                    {
                        _hocLuc = HocLuc.Gioi;
                    }
                }
            }
        }
        
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

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable =
            $"{nameof(_fullname)}: {_fullname}, {nameof(_grade)}: {_grade}, {nameof(_marks)}: {_marks}, {nameof(_parent)}: {_parent}, {nameof(_studentId)}: {_studentId}, {nameof(_hocLuc)}: {_hocLuc}";
        return formattable.ToString(formatProvider);
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format,
        IFormatProvider? provider)
    {
        return destination.TryWrite(provider,
            $"{nameof(_fullname)}: {_fullname}, {nameof(_grade)}: {_grade}, {nameof(_marks)}: {_marks}, {nameof(_parent)}: {_parent}, {nameof(_studentId)}: {_studentId}, {nameof(_hocLuc)}: {_hocLuc}",
            out charsWritten);
    }

    public bool TryFormat(Span<byte> destination, out int bytesWritten, ReadOnlySpan<char> format,
        IFormatProvider? provider)
    {
        return Utf8.TryWrite(destination, provider,
            $"{nameof(_fullname)}: {_fullname}, {nameof(_grade)}: {_grade}, {nameof(_marks)}: {_marks}, {nameof(_parent)}: {_parent}, {nameof(_studentId)}: {_studentId}, {nameof(_hocLuc)}: {_hocLuc}",
            out bytesWritten);
    }

    public override string ToString()
    {
        return
            $"{nameof(_fullname)}: {_fullname}, {nameof(_grade)}: {_grade}, {nameof(_marks)}: {_marks}, {nameof(_parent)}: {_parent}, {nameof(_studentId)}: {_studentId}, {nameof(_hocLuc)}: {_hocLuc}";
    }
}