using System.Collections.Generic;
using GraphQL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GraphQL.Types;
using MyStatusGraphQL.Database;

namespace MyStatusGraphQL.Graphql
{
    public class MentalStatusQuery : ObjectGraphType
    {
        public MentalStatusQuery(MentalStatusDbContext db)
        {
            Field<MentalStatusType>(
              "mentalStatus",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Status." }),
              resolve: context =>
              {
                  var id = context.GetArgument<System.Guid>("id");
                  var status = db
              .MentalStatuses
              .FirstOrDefault(i => i.Id == id);
                  return status;
              });

            Field<ListGraphType<MentalStatusType>>(
              "mentalStatuses",
              resolve: context =>
              {
                  var authors = db.MentalStatuses;
                  return authors;
              });
        }
    }
}
