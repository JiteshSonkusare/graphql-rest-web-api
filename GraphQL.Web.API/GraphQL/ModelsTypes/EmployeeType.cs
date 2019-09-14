using DataAccessLayer;
using DataAccessLayer.Models;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Web.API
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(ContextServiceLocator contextServiceLocator, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Email);
            Field(a => a.Mobile);
            Field(a => a.Company).Description("Company Name");
            Field(a => a.Address);
            Field(a => a.ShortDescription);
            Field(a => a.LongDescription);

            /// <summary>
            /// If you want to fetch address for each employee, then the "GetAddressByEmployeeId" method expects EmployeeId. 
            /// That means for each employee, we must call the "GetAddressByEmployeeId" method
            /// Use of "GetAddressesByEmpIds" method is good practice, when you want to fetch address for multiple employee 
            /// </summary>

            //Field<ListGraphType<AddressType>>(
            //    "addresses",
            //    resolve: context => contextServiceLocator.AddressRepo.GetAddressByEmployeeId(context.Source.Id));

            Field<ListGraphType<AddressType>>(
                "addresses",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, Address>(
                        "GetAddressesByEmpIds", contextServiceLocator.AddressRepo.GetAddressesByEmpIds);

                    return loader.LoadAsync(context.Source.Id);
                });

            Field<ListGraphType<DepartmentType>>(
                "departments",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, Department>(
                        "GetDepartmentByEmpIds", contextServiceLocator.DepartmentRepo.GetDepartmentByEmpIds);

                    return loader.LoadAsync(context.Source.DepartmentId);
                });
        }
    }
}
