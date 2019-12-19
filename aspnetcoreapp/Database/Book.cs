using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace aspnetcoreapp.Database
{
    public class Book
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool Published { get; set; }

        public string Genre { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }

    public class BookType :ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(o => o.Id);

            Field(o => o.Name);

            Field(o => o.Published);

            Field(o => o.Genre);
            Field(o => o.AuthorId);
            Field(o => o.Author);


        }
       
    }
}
