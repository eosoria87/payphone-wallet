using Autofac;
using Wallet.Domain.Interfaces;
using Wallet.Infrastructure.Repositories;

namespace Wallet.API.Configurations.AutofacConfig;

public class RepositoryModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WalletRepository>()
            .As<IWalletRepository>()
            .InstancePerLifetimeScope();
            
        builder.RegisterType<TransactionRepository>()
            .As<ITransactionRepository>()
            .InstancePerLifetimeScope();
    }
}