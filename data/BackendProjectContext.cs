using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public interface IBackendProjectContext
{
    DbSet<Cafe> Cafes { get; set; }
    DbSet<Stad> Steden { get; set; }
    DbSet<Studentenclub> Studentenclubs { get; set; }
    DbSet<Student> Studente { get; set; }
    DbSet<Evenementen> Evenementen { get; set; }
    DbSet<EvenementenStudentenclub> EvenementenStudentenclub {get;set;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class BackendProjectContext : DbContext, IBackendProjectContext
{
    public DbSet<Cafe> Cafes { get; set; }
    public DbSet<Stad> Steden { get; set; }
    public DbSet<Studentenclub> Studentenclubs { get; set; }
    public DbSet<Student> Studente { get; set; }
    public DbSet<Evenementen> Evenementen { get; set; }
    public DbSet<EvenementenStudentenclub> EvenementenStudentenclub {get;set;}

    private ConnectionStrings _connectionStrings;

    public BackendProjectContext(DbContextOptions<BackendProjectContext> options, IOptions<ConnectionStrings> connectionStrings)
        : base(options)
    {
        _connectionStrings = connectionStrings.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        options.UseSqlServer(_connectionStrings.SQL);
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            
        modelBuilder.Entity<EvenementenStudentenclub>()
            .HasKey(cs => new {cs.EvenementenId, cs.StudentenclubId});

        modelBuilder.Entity<Stad>().HasData(new Stad()
        {
            StadId = 1,
            Naam = "Kortrijk",
            Provincie = "West-Vlaanderen"
        });
        modelBuilder.Entity<Stad>().HasData(new Stad()
        {
            StadId = 2,
            Naam = "Brugge",
            Provincie = "West-Vlaanderen"
        });
/*
        modelBuilder.Entity<Cafe>().HasData(new Cafe()
        {
            CafeId = Guid.NewGuid(),
            Naam = "Tbunkertje",
            Adres = "GraafKarelDeGoedelaan 5, 8500 Kortrijk",
            StadId = 1
        });

        modelBuilder.Entity<Cafe>().HasData(new Cafe()
        {
            CafeId = Guid.NewGuid(),
            Naam = "Tkanon",
            Adres = "Doorniksesteenweg 2, 8500 Kortrijk",
            StadId = 1
        });

        modelBuilder.Entity<Cafe>().HasData(new Cafe()
        {
            CafeId = Guid.NewGuid(),
            Naam = "De Pick",
            Adres = "Eiermarkt 2, 8000 Brugge",
            StadId = 2
        });
        
        modelBuilder.Entity<Evenementen>().HasData(new Evenementen()
        {
            EvenementenId = Guid.NewGuid(),
            Naam = "Zomercantus",
            Beschrijving = "Commilitones! Zet jullie bierpotten klaar voor deze cantus! 20u30 Io Vivat"
        });
        */
    }

}