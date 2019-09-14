using Autofac;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace GraphQL.Web.API.Code
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
        }
    }
}
