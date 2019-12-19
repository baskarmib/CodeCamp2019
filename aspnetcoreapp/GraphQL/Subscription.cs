using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using aspnetcoreapp.Database;
using GraphQL.Subscription;
using GraphQL.Resolvers;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Collections.Concurrent;

namespace aspnetcoreapp.GraphQL
{
    public class AuthorSubscription : ObjectGraphType
    {
        private readonly IAuthor _author;
        
        public AuthorSubscription(IAuthor authordetails)
        {
            _author = authordetails;

            AddField(new EventStreamFieldType
            {
                Name = "authorAdded",
                Type = typeof(MessageType),
                Resolver = new FuncFieldResolver<Message>(ResolveAuthor),
                Subscriber = new EventStreamResolver<Message>(Subscribe)
            });
        }

        private Message ResolveAuthor(ResolveFieldContext context)
        {
            return context.Source as Message;
        }

        private IObservable<Message> Subscribe(ResolveEventStreamContext context)
        {
            return _author.GetLatestAuthors();
        }
    }

    public interface IAuthor
    {
        IObservable<Message> GetLatestAuthors();
        Message AddAuthor(Message authorDetails);
        ConcurrentStack<Message> AllAuthors { get; }
    }

    public class AuthorDetails : IAuthor
    {
        private readonly ISubject<Message> _messageStream = new ReplaySubject<Message>(1);
        public ConcurrentStack<Message> AllAuthors { get; }

        public AuthorDetails()
        {
            AllAuthors = new ConcurrentStack<Message>();
        }

        public IObservable<Message> GetLatestAuthors()
        {
            return _messageStream.Select(author =>
            {   
                return author;
            })
                .AsObservable();
        }

        public Message AddAuthor(Message authorDetails)
        {
            AllAuthors.Push(authorDetails);
            _messageStream.OnNext(authorDetails);
            return authorDetails;
        }

        public void AddError(Exception exception)
        {
            _messageStream.OnError(exception);
        }
    }

    public class MessageType : ObjectGraphType<Message>
    {
        public MessageType()
        {
            Field(o => o.Id);

            Field(o => o.Name);
        }

    }

    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

