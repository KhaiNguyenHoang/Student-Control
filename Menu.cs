using static System.Console;

namespace Student_Control
{
    public class Menu
    {
        public Menu()
        {
            var studentList = new StudentList(); // Tạo đối tượng studentList trước

            while (true)
            {
                WriteLine("Welcome to Student Control");
                WriteLine("1. Add Student");
                WriteLine("2. Show Students");
                WriteLine("3. Remove Student");
                WriteLine("4. Exit");

                Write("Your choice: ");
                string input = ReadLine();
                byte option;

                // Kiểm tra đầu vào hợp lệ
                if (!byte.TryParse(input, out option))
                {
                    WriteLine("Not a valid option");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        studentList.AddStudent();
                        break;
                    case 2:
                        WriteLine(studentList.ToString());
                        break;
                    case 3:
                        studentList.RemoveStudent();
                        break;
                    case 4:
                        WriteLine("Exiting program...");
                        return; // Thoát chương trình
                    default:
                        WriteLine("Not a valid option");
                        break;
                }
            }
        }
    }
}