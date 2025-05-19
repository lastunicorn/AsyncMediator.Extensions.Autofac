using Autofac;
using System.Reflection;

namespace AsyncMediator.Extensions.Autofac;

public static class AsyncMediatorExtensions
{
    public static ContainerBuilder RegisterAsyncMediator(this ContainerBuilder containerBuilder, params Assembly[] assembly)
    {
        containerBuilder.Register<MultiInstanceFactory>(context =>
        {
            IComponentContext localContext = context.Resolve<IComponentContext>();
            return type => (IEnumerable<object>)localContext.Resolve(typeof(IEnumerable<>).MakeGenericType(type));
        });

        containerBuilder.Register<SingleInstanceFactory>(context =>
        {
            IComponentContext localContext = context.Resolve<IComponentContext>();
            return type => localContext.Resolve(type);
        });

        containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

        containerBuilder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>));
        containerBuilder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>));
        containerBuilder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQuery<,>));
        containerBuilder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ILookupQuery<>));

        return containerBuilder;
    }
}