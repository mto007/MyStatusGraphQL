using GraphQL.Types;
using MyStatusGraphQL.Entities;

namespace MyStatusGraphQL.Graphql
{
    public class MentalStatusType : ObjectGraphType<MentalStatus>
    {
        public MentalStatusType()
        {
            Name = "MentalStatus";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Status ID.");
            Field(x => x.Status).Description("The status evaluation");
            Field(x => x.StatusDate).Description("The date of status");
            Field(x => x.Latitude, nullable: true).Description("The latitude of location of status");
            Field(x => x.Longitude, nullable: true).Description("The longitude of location of status");
            Field(x => x.PostCode, nullable: true).Description("The post code of status");
            Field(x => x.City, nullable: true).Description("The city of status");
            Field(x => x.Age, nullable: true).Description("The age of status author");
            Field(x => x.Sex, nullable: true).Description("The sex of status author");
            Field(x => x.AddInfo, nullable: true).Description("The additional information of status");
        }
    }
}

