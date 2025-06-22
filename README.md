# AsyncMediator.Extensions.Autofac

This package provide helper classes to easily configure AsyncMediator using Autofac.

AsyncMediator is a library that implements the Mediator pattern, similar to the more better known MediatR.

The Github page of AsyncMediator:

- https://github.com/jpv001/AsyncMediator

## How to Use (ASPNET Core)

### Step 1) Install the Nuget package

```cmd
Install-Package AsyncMediator.Extensions.Autofac
```

### Step 2) Configure the Autofac's Dependency Container

```c#
// Get a reference to the assembly containing your Commands and Queries.
Assembly useCaseAssembly = typeof(GetCustomerCommand).Assembly;

// Add AsyncMediator to the dependency container.
containerBuilder.RegisterAsyncMediator(useCaseAssembly);
```

This code will register all the event handlers, command handlers, queries and lookup queries found in the specified assembly.

Multiple assemblies may be provided.