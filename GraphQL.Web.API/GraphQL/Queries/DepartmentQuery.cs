using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.API
{
    public class DepartmentQuery : ObjectGraphType
    {
        public DepartmentQuery(ContextServiceLocator contextServiceLocator)
        {
            //Field<ListGraphType<DepartmentType>>(
            //    "departments",
            //    resolve: context => contextServiceLocator.DepartmentRepo.GetDepartments(context.Source.Id));
        }
    }
}
