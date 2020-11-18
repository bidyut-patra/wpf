using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public interface IStudentsDataProvider
    {
        List<StudentViewModel> GetStudents();
    }
}
