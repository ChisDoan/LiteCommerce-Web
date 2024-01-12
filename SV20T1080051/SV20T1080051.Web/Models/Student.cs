using System.Reflection.Metadata.Ecma335;

namespace SV20T1080051.Web.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set;}

    }
    public class StudentDAL
    {
        public List<Student> List()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student()
            {
                StudentId = 1,
                StudentName = "Chis",
            });
            return students;
        }
            
    }
}
