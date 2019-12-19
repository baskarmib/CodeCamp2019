using GraphQL;
using aspnetcoreapp.Database;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Types;

namespace aspnetcoreapp.GraphQL
{
    public class AuthorMutation : ObjectGraphType
    {
        private readonly IAuthor _author;
        public AuthorMutation(IAuthor author)
        {
            _author = author;
            
            Field<AuthorType>("addAuthor",
                  arguments: new QueryArguments(
                      new QueryArgument<StringGraphType> { Name = "name" }
                  ),
                  resolve: context =>
                  {
                      var receivedMessage = context.GetArgument<String>("name");
                      return Add(receivedMessage.ToString());                      
                  });
        }      
        
        public Author Add(string name)
        {
            JObject jsonContent = JObject.Parse(System.IO.File.ReadAllText(@"SampleData.json"));
            //List<Author> authors = new List<Author>();
            JArray a = (JArray)jsonContent["Authors"];
            IList<Author> authors = a.ToObject<IList<Author>>();
            int authorid = GenerateRandomNo();
            authors.Add(new Author() { Id = authorid, Name = name });

            Message message = new Message();
            message.Id = authorid;
            message.Name = authors.Where(x => x.Id == authorid).First().Name;
            _author.AddAuthor(message);

            return authors.Where(x => x.Id == authorid).First();
        }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }

    public static class ServiceProviderServiceExtensions
    {
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            var requiredServiceSupportingProvider = provider as ISupportRequiredService;
            if (requiredServiceSupportingProvider != null)
            {
                return requiredServiceSupportingProvider.GetRequiredService(serviceType);
            }

            var service = provider.GetService(serviceType);
            if (service == null)
            {
                throw new InvalidOperationException();
            }

            return service;
        }
    }
}
