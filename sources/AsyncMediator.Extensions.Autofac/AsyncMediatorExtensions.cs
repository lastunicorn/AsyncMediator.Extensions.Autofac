// Copyright © 2025 Dust in the Wind 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0

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