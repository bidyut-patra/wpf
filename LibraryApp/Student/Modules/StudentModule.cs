using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Student
{
    public class StudentModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentDataProvider>().As<IStudentsDataProvider>();
            builder.RegisterType<StudentsViewModel>().As<IStudentsViewModel>();
            builder.RegisterType<StudentInformation>().As<StudentInformation>();
        }
    }
}
