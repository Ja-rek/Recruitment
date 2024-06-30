using Autofac;
using RestSharp;
using Task1;
using Task1.Application;
using Task1.Infrastructure;
using Task1.Infrastructure.BilingEntryAllegro;
using Task1.Infrastructure.OrmMapping;

const string clientId = "";
const string clientSecret = "";
const string connectionString = "";

var builder = new ContainerBuilder();

builder.RegisterAssemblyTypes(typeof(BillingEntry).Assembly)
    .Where(x => 
        x.Name.EndsWith("Service") 
        || x.Name.EndsWith("Provider")
        || x.Name.EndsWith("Mapper")
        || x.Name.EndsWith("Store")
    ).AsSelf().AsImplementedInterfaces();

builder.Register((ctx) => SessionFactoryBuilder
        .SessionFactory(m => m.FluentMappings.AddFromAssemblyOf<BillingEntryMap>(), connectionString))
    .AsSelf()
    .SingleInstance();

builder.Register(c => new RestClient("https://allegro.pl"))
    .As<IRestClient>()
    .SingleInstance();

builder.Register(c => new HttpRestClient(clientId, clientSecret, c.Resolve<IRestClient>()))
    .AsImplementedInterfaces();

builder.Register(ctx => new AllegroAuthService(ctx.Resolve<INotificationService>(), ctx.Resolve<IHttpRestClient>(), clientId))
    .AsSelf();

var container = builder.Build();

using (var scope = container.BeginLifetimeScope())
{
    var service = scope.Resolve<BillingEntryService>();
    await service.DownloadAsync();
}
