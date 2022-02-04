using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Service.Common;

namespace AuTOP.Service
{
   public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            //builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
