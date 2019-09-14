using DataAccessLayer.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.API
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<ListGraphType<EmployeeType>>(
                "employees",
                resolve: context =>
                {
                    return contextServiceLocator.EmployeeRepo.GetEmployees();
                });


            Field<EmployeeType>(
                "employee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return contextServiceLocator.EmployeeRepo.GetEmployeeById(id);
                });
        }

        //public EmployeeQuery(IEmployeeRepository employeeRepository)
        //{
        //    Field<ListGraphType<EmployeeType>>(
        //        "employees",
        //        resolve: context => employeeRepository.GetEmployees()
        //        );
        //}
    }
}
