using GraphQL;
using GraphQL.Types;


namespace MyStatusGraphQL.Graphql
{
    public class MentalStatusSchema : Schema
    {
        public MentalStatusSchema(MentalStatusQuery query, MentalStatusMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
