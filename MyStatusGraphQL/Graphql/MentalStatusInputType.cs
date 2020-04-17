using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatusGraphQL.Graphql
{
    public class MentalStatusInputType : InputObjectGraphType
    {
        public MentalStatusInputType()
        {
            Name = "mentalStatusInput";
            
            Field<NonNullGraphType<IntGraphType>>("status");
            Field<DateGraphType>("statusDate");
            Field<DecimalGraphType>("latitude");
            Field<DecimalGraphType>("longitude");
            Field<StringGraphType>("postCode");
            Field<StringGraphType>("city");
            Field<IntGraphType>("age");
            Field<IntGraphType>("sex");
            Field<StringGraphType>("addInfo");
        }
    }
}
