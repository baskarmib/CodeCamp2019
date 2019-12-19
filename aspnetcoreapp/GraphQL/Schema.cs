using GraphQL.Types;
using GraphQL;
using aspnetcoreapp.Database;

namespace aspnetcoreapp.GraphQL
{
    public class GraphSchema : Schema
    {

        private ISchema _schema { get; set; }
        public IAuthor _author { get; set; }

        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public GraphSchema(IAuthor authorContent)
        {
            //this._author = new AuthorDetails();
            this._author = authorContent;
            this._schema = Schema.For(@"
          type Book {
            id: ID
            name: String,
            genre: String,
            published: Date,
            Author: Author
          }

          type Author {
            id: ID,
            name: String,
            books: [Book]
          }
          
          type Query {
              books: [Book],
              author(id: ID): Author,
              authors: [Author],
              hello: String,
              messages: [MessageType]
          }
      ", _ =>
            {
                _.Types.Include<Query>();                
            });
            //This is needed.
            Query = this._schema.Query;
            Mutation = new AuthorMutation(authorContent);
            Subscription = new AuthorSubscription(authorContent);
        }       
    }

}
