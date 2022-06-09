using ConsoleApp1;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Engine;
using NHibernate.Extensions.Sqlite;
using NHibernate.Tool.hbm2ddl;

var config = Fluently.Configure()
    .Database(MsSqliteConfiguration
        .Standard
        .Driver<SqliteDriver>()
        .Dialect<SqliteDialect>()
        .InMemory())
    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(People).Assembly))
    .BuildConfiguration();

var factory = config.BuildSessionFactory();

var dbConnection = (factory as ISessionFactoryImplementor)?.ConnectionProvider.GetConnection();
new SchemaExport(config).Execute(false, true, false, dbConnection, null);

var session = factory
    .WithOptions()
    .Connection(dbConnection)
    .OpenSession();

session.Save(new People("Little", "Coder"));
var p = session.Query<People>().ToList();

Console.WriteLine(p[0].FirstName);