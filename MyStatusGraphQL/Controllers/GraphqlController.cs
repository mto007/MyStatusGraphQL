using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using MyStatusGraphQL.Graphql;
using System;
using GraphQL.Types;
using MyStatusGraphQL.Database;
using Newtonsoft.Json;

[Route("graphql")]
[ApiController]
public class GraphqlController : ControllerBase
{

    private readonly MentalStatusDbContext _db;


    public GraphqlController(MentalStatusDbContext db)
    {
        
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] System.Text.Json.JsonElement rawQuery)
    {
        string rawJson = rawQuery.ToString();
        var query = JsonConvert.DeserializeObject<GraphQLQuery>(rawJson);
        if (query == null) { throw new ArgumentNullException(nameof(query)); }
        var inputs = query.Variables.ToInputs();
        var schema = new Schema { Query = new MentalStatusQuery(_db), Mutation = new MentalStatusMutation(_db) };

        var result = await new DocumentExecuter().ExecuteAsync(_ =>
        {
            _.Schema = schema;
            _.Query = query.Query;
            _.OperationName = query.OperationName;
            _.Inputs = inputs;
        });

        if (result.Errors?.Count > 0)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}