using Microsoft.EntityFrameworkCore;

namespace ProjetoCadastroAssociado
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Associado> Associados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<AssociadoEmpresa> AssociadoEmpresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssociadoEmpresa>()
                .HasKey(ae => new { ae.AssociadoId, ae.EmpresaId });

            modelBuilder.Entity<Associado>()
                .HasMany(a => a.AssociadoEmpresas)
                .WithOne(ae => ae.Associado)
                .HasForeignKey(ae => ae.AssociadoId);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.AssociadoEmpresas)
                .WithOne(ae => ae.Empresa)
                .HasForeignKey(ae => ae.EmpresaId);
        }
    }

}
