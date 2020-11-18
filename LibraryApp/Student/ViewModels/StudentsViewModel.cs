using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class StudentsViewModel : ViewModelBase, IStudentsViewModel
    {
        public List<StudentViewModel> Items { get; set; }
        public StudentViewModel SelectedItem { get; set; }

        private IStudentsDataProvider _studentsDataProvider;

        public StudentsViewModel(IStudentsDataProvider studentsDataProvider)
        {
            this._studentsDataProvider = studentsDataProvider;
            this.LoadData();
        }

        public void LoadData()
        {
            this.Items = this._studentsDataProvider.GetStudents();
            if (this.Items.Count > 0)
            {
                this.SelectedItem = this.Items[0];
            }
        }
    }
}
