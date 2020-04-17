using GraphQL;
using GraphQL.Types;
using MyStatusGraphQL.Database;
using MyStatusGraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatusGraphQL.Graphql
{

    public class MentalStatusMutation : ObjectGraphType
    {
        public MentalStatusMutation(MentalStatusDbContext db)
        {
            Field<MentalStatusType>(
              "createStatus",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<MentalStatusInputType>> { Name = "mentalStatus" }
              ),
              resolve: context =>
              {
                  var mentalStatus = context.GetArgument<MentalStatus>("mentalStatus");
                  mentalStatus.Id = Guid.NewGuid();
                  db.MentalStatuses.Add(mentalStatus);
                  db.SaveChanges();
                  return mentalStatus;
              });
        }
    }
}

