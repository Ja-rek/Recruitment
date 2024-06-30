using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Task2.Application;
using Task2.Infrastructure;
using Task2.Infrastructure.Provider1;
using Task2.Infrastructure.Provider2;
using Task2.Infrastructure.Provider3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Test"));

var containerBuilder = new ContainerBuilder();
containerBuilder.Populate(builder.Services);

var container = containerBuilder.Build();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(cb => {
                cb.RegisterType<XmlProductReader>().AsImplementedInterfaces();
                cb.RegisterType<ProductStore>().AsImplementedInterfaces();
                cb.RegisterType<ProductDownloader>().AsSelf();
                cb.Register<IProductProvider>(x => new ProductProvider1(new XmlProductReader("./Provider1/dostawca1plik2.xml")));
                cb.Register<IProductProvider>(x => new ProductProvider2(new XmlProductReader("./Provider2/dostawca2plik2.xml")));
                cb.Register<IProductProvider>(x => new ProductProvider3(new XmlProductReader("./Provider3/dostawca3plik1.xml")));
            });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}");

app.Run();
