using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace aspnetcoreapp.Database
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(o => o.Id);

            Field(o => o.Name);

            //Field(o => o.Books);
        }

    }
}
