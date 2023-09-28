
using Assets.Code.Application.Commons.Interfaces.Mediator;
using System;
using System.Linq;
using System.Reflection;
using Zenject;

namespace Assets.Code.Infrastructure.Services
{
    public class Mediator : IMediator
    {
        private readonly DiContainer _container;

        public Mediator(DiContainer container)
        {
            _container = container;
            RegisterHandlers();
        }

        private void RegisterHandlers()
        {
            var handlerTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(h => h.Name.EndsWith("Handler") && h.GetInterfaces().Any(IsHandlerInterface));

            foreach (var handlerType in handlerTypes)
            {
                var interfaces = handlerType.GetInterfaces().Where(IsHandlerInterface);
                foreach (var @interface in interfaces)
                {
                    _container.Bind(@interface).To(handlerType).AsSingle();
                }
            }

        }

        private bool IsHandlerInterface(Type type)
        {
            return type.IsGenericType &&
                (type.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
                || type.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)
                || type.GetGenericTypeDefinition() == typeof(ICommandHandler<,>));
        }

        public TResult Send<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _container.TryResolve(handlerType);

            if (handler != null)
            {
                return handler.Handle((dynamic)query);
            }

            throw new ArgumentException($"AQ: There is no handler registered for this query {query.GetType()}");
        }

        public void Send(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _container.TryResolve(handlerType);

            if (handler != null)
            {
                handler.Handle((dynamic)command);
            }
            else
            {
                throw new ArgumentException($"AQ: There is no handler registered for this command {command.GetType()}");
            }
        }

        public TReturn Send<TReturn>(ICommand<TReturn> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TReturn));
            dynamic handler = _container.TryResolve(handlerType);

            if (handler != null)
            {
                return handler.Handle((dynamic)command);
            }

            throw new ArgumentException($"AQ: There is no handler registered for this return command {command.GetType()}");

        }
    }
}