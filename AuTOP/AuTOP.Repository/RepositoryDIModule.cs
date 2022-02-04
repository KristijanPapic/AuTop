using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
   public class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            //builder.RegisterType<CourseRepository>().As<ICourseRepository>();
        }
    }
}
