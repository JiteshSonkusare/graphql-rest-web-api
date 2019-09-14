using DataAccessLayer.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.API
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(a => a.Id);
            Field(a => a.AddressLineOne);
            Field(a => a.AddressLineTwo);
            Field(a => a.PostNr);
            Field(a => a.City);
            Field(a => a.State);
            Field(a => a.Country);
            Field(a => a.EmployeeId);
        }
    }
}
