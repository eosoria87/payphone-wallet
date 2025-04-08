using System.Reflection;
using Autofac;
using MediatR;
using Wallet.Application.Wallet.Commands;
using Wallet.Application.Wallet.Queries;
using Wallet.Application.Wallet.Validations;
using Wallet.Infrastructure.Behaviors;
using Module = Autofac.Module;

namespace Wallet.API.Configurations.AutofacConfig;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();
        
        // Register all the Command classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(CreateWalletCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        // Register all the DomainService classes (they implement IRequestHandler) in assembly holding the Commands
        builder.RegisterAssemblyTypes(typeof(ReadWalletQuery).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.RegisterAssemblyTypes(typeof(CreateWalletCommandValidator).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.RegisterGeneric(typeof(ValidatorTransactionBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        builder.RegisterGeneric(typeof(ResponseTransactionBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}