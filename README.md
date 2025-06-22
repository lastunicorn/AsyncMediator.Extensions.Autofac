# AsyncMediator.Extensions.Autofac

This package provide helper classes to easily configure AsyncMediator using Autofac.

AsyncMediator is a library that implements the Mediator pattern, similar to the more better known MediatR.

The Github page of AsyncMediator:

- https://github.com/jpv001/AsyncMediator

## How to Use

### Step 1) Install the Nuget package

```cmd
Install-Package AsyncMediator.Extensions.Autofac
```

### Step 2) Configure the Autofac's Dependency Container

**Console App**

Create an Autofac `ContainerBuilder` instance and register AsyncMediator with that builder.

```c#
ContainerBuilder containerBuilder = new();
containerBuilder.RegisterAsyncMediator(Assembly.GetExecutingAssembly());
```

**ASPNET Core App**

To use Autofac in a ASPNET Core App, the Autofac must be registered first, then the AsyncMediator may be registered in the ContainerBuilder.

```c#
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// ...

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterAsyncMediator(Assembly.GetExecutingAssembly());
    });

//...
```

This code will register all the event handlers, command handlers, queries and lookup queries found in the specified assembly.

Multiple assemblies may be provided.

### Note

For a full example see the project `AsyncMediator.Extensions.Autofac.Demo` from this repository.