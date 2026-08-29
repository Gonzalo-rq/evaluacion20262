using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Models;

namespace TecnoGasHogar.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SolicitudServicio> SolicitudesServicio { get; set; }
}
