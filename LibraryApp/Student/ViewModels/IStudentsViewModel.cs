using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public interface IStudentsViewModel : IDataLoad
    {
        List<StudentViewModel> Items { get; set; }
        StudentViewModel SelectedItem { get; set; }
    }
}
