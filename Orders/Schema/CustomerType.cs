using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
//
using Orders.Models;

namespace Orders.Schema
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
        }
    }
}
