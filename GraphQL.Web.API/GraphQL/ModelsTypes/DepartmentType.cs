using DataAccessLayer.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.API
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType()
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Type);
        }
    }
}
