using Dot7.API.CRUD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot7.API.CRUD.Data;

public class ThucTapTotNghiepDbContext : DbContext
{
    public ThucTapTotNghiepDbContext(DbContextOptions<ThucTapTotNghiepDbContext> options) : base(options)
    {

    }

    public DbSet<Beach> Beach { get; set; }
}