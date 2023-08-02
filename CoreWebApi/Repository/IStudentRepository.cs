using System.Collections.Generic;
using CoreWebApi.Models;

namespace CoreWebApi.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel GetStudentById(int studentId);
        void AddStudent(StudentModel student);
        void UpdateStudent(StudentModel student);
        void DeleteStudent(int studentId);
    }
}
