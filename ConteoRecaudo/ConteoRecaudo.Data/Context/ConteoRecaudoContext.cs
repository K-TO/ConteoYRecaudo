using ConteoRecaudo.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConteoRecaudo.Data.Context
{
    public class ConteoRecaudoContext : DbContext
    {
        //private readonly IConfiguration Config;

        public ConteoRecaudoContext(DbContextOptions<ConteoRecaudoContext> options/*, IConfiguration config*/) : base(options)
        {
            //Config = config;
        }

        //public async Task CommitAsync()
        //{
        //    await SaveChangesAsync().ConfigureAwait(false);
        //}

        //public virtual DbSet<Prestamo> Prestamo { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseLazyLoadingProxies(true);
        //    //            if (!optionsBuilder.IsConfigured)
        //    //            {
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //    //                optionsBuilder.UseSqlServer("Data Source=D-SERVER;Initial Catalog=PREEDev;Integrated Security=true;Column Encryption Setting=enabled;");
        //    //            }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema(Config.GetValue<string>("SchemaName"));

            //modelBuilder.Entity<Prestamo>(entity =>
            //{
            //    entity.HasKey(p => p.Id);
            //    entity.Property(p => p.FechaMaximaDevolucion).HasColumnType("datetime");
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}