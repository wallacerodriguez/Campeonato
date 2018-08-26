using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Torneio.Domain.Entities;
using Torneio.Infra.Data.EntityConfig;

namespace Torneio.Infra.Data.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("EFConnectionString")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Time> Times { get; set; }

        public virtual DbSet<Campeonato> Campeonatos { get; set; }

        public virtual DbSet<TimeCampeonato> TimeCampeonatos { get; set; }

        public virtual DbSet<Partida> Partidas { get; set; }

        public virtual DbSet<TimePartida> TimePartidas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(c => c.Name == c.ReflectedType.Name + "Id")
                .Configure(c => c.IsKey());

            modelBuilder.Properties<string>()
                .Configure(c => c.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
               .Configure(c => c.HasMaxLength(200));

            modelBuilder.Configurations.Add(new TimeMapping());
            modelBuilder.Configurations.Add(new CampeonatoMapping());
            modelBuilder.Configurations.Add(new TimeCampeonatoMapping());
            modelBuilder.Configurations.Add(new PartidaMapping());
            modelBuilder.Configurations.Add(new TimePartidaMapping());


        }
    }


}
