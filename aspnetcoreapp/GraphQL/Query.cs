using System;
using GraphQL.Types;
using GraphQL;
using aspnetcoreapp.Database;
using System.Linq;
using System.Collections.Generic;

namespace aspnetcoreapp.GraphQL
{
    public class Query
    {
        
        [GraphQLMetadata("books")]
        public IEnumerable<Book> GetBooks()
        {
            List<Book> allbooks = new List<Book>();
            
            return Enumerable.Empty<Book>();
        }

        [GraphQLMetadata("authors")]
        public IEnumerable<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            Author objauthor = new Author();
            objauthor.Id = 2;
            objauthor.Name = "testAuthor";
            authors.Add(objauthor);
            return authors;
        }

        [GraphQLMetadata("author")]
        public Author GetAuthor(int id)
        {
            return null;
        }

        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "World";
        }

        [GraphQLMetadata("messages")]
        public IEnumerable<Message> GetMessages()
        {
            AuthorDetails details = (AuthorDetails)ServiceProviderServiceExtensions.GetRequiredService(new DefaultServiceProvider(), typeof(AuthorDetails));
            return details.AllAuthors.Take(10);
        }

    }
}
