using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Domain.Model;

namespace SuperHeroApi.Domain;

public class HeroContext : DbContext {

    public DbSet<Hero> Heroes { get; set; }

    public HeroContext(DbContextOptions options) 
        : base(options) {
    }
}
