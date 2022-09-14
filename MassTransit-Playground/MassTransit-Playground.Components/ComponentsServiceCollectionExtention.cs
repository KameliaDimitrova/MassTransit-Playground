using MassTransit;
using MassTransit_Playground.Components.Consumers;
using MassTransit_Playground.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit_Playground.Components;

public static class ComponentsServiceCollectionExtention
{
    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
        return services.AddMassTransit(cfg =>
        {
            //we can add filters. For example it could be based on the keyword contained in the namespace of the class
            //...AddConsumers(f => f?.FullName.Contains("some text", StringComparison.OrdinalIgnoreCase) ?? false, typeOf(IComponentsAssemblymarker).Assembly)
            cfg.UsingInMemory();
            cfg.AddMediator(options =>
            {
                options.AddConsumers(typeof(IComponentsAssemblyMarker).Assembly);
                options.AddRequestClient<ISubmitOrder>();
            });
        });
    }
}
