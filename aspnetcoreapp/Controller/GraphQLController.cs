using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using aspnetcoreapp.GraphQL;
namespace aspnetcoreapp.Controller
{

    

    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly GraphSchema _schema;
        private readonly AuthorSubscription _authorsubscription;
        private readonly IAuthor _authorDetails;

        public GraphQLController(GraphSchema schema, AuthorSubscription author, IAuthor authorDetails)
        {
            _schema = schema;
            _authorsubscription = author;
            _authorDetails = authorDetails;
            //_schema.AddSubscription(author);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new GraphSchema(_authorDetails);
           
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema.GraphQLSchema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
                _.EnableMetrics = false;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            //
            return Ok(result.Data);
        }

    }
}
