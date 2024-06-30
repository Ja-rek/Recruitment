using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Task1.Infrastructure;

public static class SessionFactoryBuilder
{
    public static ISessionFactory SessionFactory(Action<MappingConfiguration> mapping, string connectionString, bool createDb = false)
    {
        Action<NHibernate.Cfg.Configuration> shemaConfig = (cfg) => 
        { 
            if (createDb) new SchemaExport(cfg).Create(true, createDb); 
            new SchemaUpdate(cfg).Execute(true, true); 
        };

        return Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
            .Mappings(mapping)
            .ExposeConfiguration(shemaConfig)
            .BuildSessionFactory();
    }
}
