using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class StudentDataProvider : IStudentsDataProvider
    {
        public List<StudentViewModel> GetStudents()
        {
            return new List<StudentViewModel>()
            {
                new StudentViewModel() { Name = "Bidyut", Dept = "Industry" },
                new StudentViewModel() { Name = "James", Dept = "Digital" },
                new StudentViewModel() { Name = "Naveen", Dept = "Digital" }
            };
        }
    }
}
