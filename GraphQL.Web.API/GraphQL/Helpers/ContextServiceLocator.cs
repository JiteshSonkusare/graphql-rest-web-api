using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Web.API
{
    public class ContextServiceLocator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEmployeeRepository EmployeeRepo
            => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IEmployeeRepository>();

        public IDepartmentRepository DepartmentRepo 
            => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IDepartmentRepository>();

        public IAddressRepository AddressRepo
            => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IAddressRepository>();
    }
}
