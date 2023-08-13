using ConteoRecaudo.Data.Models;
using ConteoRecaudo.Data.SpModels;
using Microsoft.EntityFrameworkCore;

namespace ConteoRecaudo.Data.Context
{
    public class ConteoRecaudoContext : DbContext
    {
        public ConteoRecaudoContext(DbContextOptions options) : base(options)
        {
        }

      
        //public ConteoRecaudoContext(DbContextOptions<ConteoRecaudoContext> options) : base(options)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        //    optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        //}

        //public async Task CommitAsync()
        //{
        //    await SaveChangesAsync().ConfigureAwait(false);
        //}

        //public virtual DbSet<Prestamo> Prestamo { get; set; }
        //public virtual DbSet<Recaudo> Recaudo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Recaudo> Recaudo { get; set; }
        public virtual DbSet<ObtenerRecaudosFiltrados> ObtenerRecaudosFiltrados { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        //    //optionsBuilder.UseLazyLoadingProxies(true);
        //    //            if (!optionsBuilder.IsConfigured)
        //    //            {
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //    //                optionsBuilder.UseSqlServer("Data Source=D-SERVER;Initial Catalog=PREEDev;Integrated Security=true;Column Encryption Setting=enabled;");
        //    //            }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));

            modelBuilder.Entity<Recaudo>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<ObtenerRecaudosFiltrados>().HasNoKey();
            //    .ToSqlQuery("EXEC");
        }
    }
}