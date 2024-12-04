using Microsoft.EntityFrameworkCore;

public class ConsultorioDbContext : DbContext
{
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=consultorio;Username=postgres;Password=1234");
    }
}
