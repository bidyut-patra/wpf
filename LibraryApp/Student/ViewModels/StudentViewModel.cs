using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class StudentViewModel : ViewModelBase
    {
        public Student Model { get; set; }

        public string Name { get; set; }
        public string Dept { get; set; }
        public string Book { get; set; }
    }
}
