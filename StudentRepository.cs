using StudentWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentWebApi.Data
{
    public class StudentRepository
    {
        private static List<Student> students = new List<Student>();

        public IEnumerable<Student> GetAll() => students;

        public Student? GetByRn(int rn) => students.FirstOrDefault(s => s.Rn == rn);

        public void Add(Student student) => students.Add(student);

        public void Update(Student student)
        {
            var existing = GetByRn(student.Rn);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Batch = student.Batch;
                existing.Marks = student.Marks;
            }
        }

        public void Delete(int rn)
        {
            var student = GetByRn(rn);
            if (student != null)
                students.Remove(student);
        }
    }
}
