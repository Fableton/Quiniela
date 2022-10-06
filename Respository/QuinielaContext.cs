using Entities;
using Entities.Auths;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Respository
{
    public class QuinielaContext : DbContext
    {
        public QuinielaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Countries { get; set; }
        public DbSet<MatchGame> Games { get; set; }
        public DbSet<Quiniela> Quinielas { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerMatchResult> PlayerMatchResult { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Activity> Activitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().ToTable("Tournaments")
               .HasMany(t => t.Quinielas)
               .WithOne(q => q.Tournament)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().ToTable("Teams");

            modelBuilder.Entity<MatchGame>().ToTable("MatchGames")
                .HasOne(mg => mg.Quiniela)
                .WithMany(q => q.Matches)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MatchGame>()
                .HasOne(mg => mg.Local)
                .WithMany(c => c.LocalGames)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MatchGame>()
                .HasOne(mg => mg.Visitor)
                .WithMany(c => c.VisitorsGames)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Quiniela>().ToTable("Quinielas")
                .HasMany(q => q.Matches)
                .WithOne(m => m.Quiniela)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Player>().ToTable("Players")
                .HasMany(p => p.MatchResults)
                .WithOne(mr => mr.Player)
                .OnDelete(DeleteBehavior.NoAction);

            var relationshipPlayerRols = modelBuilder.Entity<Player>()
                .HasMany(p => p.Rols)
                .WithMany(r => r.Players);

            modelBuilder.Entity<PlayerMatchResult>().ToTable("PlayerMatchResult")
                .HasKey(mr => new { mr.PlayerId, mr.MatchGameId });
            modelBuilder.Entity<PlayerMatchResult>()
                .HasOne(mr => mr.MatchGame)
                .WithMany(mg => mg.MatchResults)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>().ToTable("Activities", "Security")
                .HasKey(a => a.Id);

            modelBuilder.Entity<Rol>().ToTable("Rols", "Security")
                .HasKey(a => a.Id);
            var relationshipRolActivities = modelBuilder.Entity<Rol>()
                .HasMany<Activity>(r => r.Activities)
                .WithMany(a => a.Rols);
            //.UsingEntity(ar => ar.ToTable("RolActivities")
            //.HasData(
            //    new[] {
            //            new { ActivityId = "Index", RolId = "SinglePlayer"  },
            //            new { ActivityId = "UpdateQuiniela", RolId = "SinglePlayer"  },
            //        }
            //    )
            //);


            /* Data initializor*/

            modelBuilder.Entity<Tournament>().HasData(
                new Tournament() { Id = 1, Name = "Qatar 2022" }
                );

            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = "QAT", Name = "Catar" },
                new Team() { Id = "SEN", Name = "Senegal" },
                new Team() { Id = "ECU", Name = "Ecuador" },
                new Team() { Id = "NED", Name = "Paises Bajos" },
                new Team() { Id = "ENG", Name = "Inglaterra" },
                new Team() { Id = "USA", Name = "Estados Unidos" },
                new Team() { Id = "IRN", Name = "Iran" },
                new Team() { Id = "WAL", Name = "Gales" },
                new Team() { Id = "ARG", Name = "Argentina" },
                new Team() { Id = "MEX", Name = "Mexico" },
                new Team() { Id = "KSA", Name = "Arabia Saudita" },
                new Team() { Id = "POL", Name = "Polonia" },
                new Team() { Id = "DEN", Name = "Dinamarca" },
                new Team() { Id = "FRA", Name = "Francia" },
                new Team() { Id = "TUN", Name = "Tunez" },
                new Team() { Id = "AUS", Name = "Australia" },
                new Team() { Id = "ESP", Name = "España" },
                new Team() { Id = "GER", Name = "Alemania" },
                new Team() { Id = "CRC", Name = "CostaRica" },
                new Team() { Id = "JPN", Name = "Japon" },
                new Team() { Id = "BEL", Name = "Belgica" },
                new Team() { Id = "MAR", Name = "Marruecos" },
                new Team() { Id = "CAN", Name = "Canada" },
                new Team() { Id = "CRO", Name = "Croacia" },
                new Team() { Id = "SUI", Name = "Suiza" },
                new Team() { Id = "BRA", Name = "Brasil" },
                new Team() { Id = "CMR", Name = "Camerun" },
                new Team() { Id = "SRB", Name = "Serbia" },
                new Team() { Id = "POR", Name = "Portugal" },
                new Team() { Id = "URU", Name = "Uruguay" },
                new Team() { Id = "GHA", Name = "Ghana" },
                new Team() { Id = "KOR", Name = "Corea del Sur" }
                );

            modelBuilder.Entity<Quiniela>().HasData(
                new Quiniela() { Id = 1, StartDate = new DateTime(2022, 10, 05), EndDate = new DateTime(2022, 11, 19), TournamentId = 1, Name = "Jornada 1" },
                 new Quiniela() { Id = 2, StartDate = new DateTime(2022, 11, 25), EndDate = new DateTime(2022, 11, 25), TournamentId = 1, Name = "Jornada 2" },
                 new Quiniela() { Id = 3, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 11, 28), TournamentId = 1, Name = "Jornada 3" }
                );

            modelBuilder.Entity<MatchGame>().HasData(
                new MatchGame() { Id = 1, Group = "A", LocalId = "QAT", VisitorId = "ECU", CanDraw = true, Date = new DateTime(2022, 11, 20), QuinielaId = 1 },
                new MatchGame() { Id = 2, Group = "A", LocalId = "SEN", VisitorId = "NED", CanDraw = true, Date = new DateTime(2022, 11, 21), QuinielaId = 1 },
                new MatchGame() { Id = 3, Group = "B", LocalId = "ENG", VisitorId = "IRN", CanDraw = true, Date = new DateTime(2022, 11, 21), QuinielaId = 1 },
                new MatchGame() { Id = 4, Group = "B", LocalId = "USA", VisitorId = "WAL", CanDraw = true, Date = new DateTime(2022, 11, 21), QuinielaId = 1 },
                new MatchGame() { Id = 5, Group = "C", LocalId = "ARG", VisitorId = "KSA", CanDraw = true, Date = new DateTime(2022, 11, 22), QuinielaId = 1 },
                new MatchGame() { Id = 6, Group = "C", LocalId = "MEX", VisitorId = "POL", CanDraw = true, Date = new DateTime(2022, 11, 22), QuinielaId = 1 },
                new MatchGame() { Id = 7, Group = "D", LocalId = "DEN", VisitorId = "TUN", CanDraw = true, Date = new DateTime(2022, 11, 22), QuinielaId = 1 },
                new MatchGame() { Id = 8, Group = "D", LocalId = "FRA", VisitorId = "AUS", CanDraw = true, Date = new DateTime(2022, 11, 22), QuinielaId = 1 },
                new MatchGame() { Id = 9, Group = "E", LocalId = "ESP", VisitorId = "CRC", CanDraw = true, Date = new DateTime(2022, 11, 23), QuinielaId = 1 },
                new MatchGame() { Id = 10, Group = "E", LocalId = "GER", VisitorId = "JPN", CanDraw = true, Date = new DateTime(2022, 11, 23), QuinielaId = 1 },
                new MatchGame() { Id = 11, Group = "F", LocalId = "BEL", VisitorId = "CAN", CanDraw = true, Date = new DateTime(2022, 11, 23), QuinielaId = 1 },
                new MatchGame() { Id = 12, Group = "F", LocalId = "MAR", VisitorId = "CRO", CanDraw = true, Date = new DateTime(2022, 11, 23), QuinielaId = 1 },
                new MatchGame() { Id = 13, Group = "G", LocalId = "SUI", VisitorId = "CMR", CanDraw = true, Date = new DateTime(2022, 11, 24), QuinielaId = 1 },
                new MatchGame() { Id = 14, Group = "G", LocalId = "BRA", VisitorId = "SRB", CanDraw = true, Date = new DateTime(2022, 11, 24), QuinielaId = 1 },
                new MatchGame() { Id = 15, Group = "H", LocalId = "POR", VisitorId = "GHA", CanDraw = true, Date = new DateTime(2022, 11, 24), QuinielaId = 1 },
                new MatchGame() { Id = 16, Group = "H", LocalId = "URU", VisitorId = "KOR", CanDraw = true, Date = new DateTime(2022, 11, 24), QuinielaId = 1 }
                );

            modelBuilder.Entity<Activity>().HasData(
                   //SinglePlayer
                   new Activity() { Id = "UpdateQuiniela", Description = "Update Quiniela matches" },
                   //Admin
                   new Activity() { Id = "Index", Description = "Watch Index" },
                    new Activity() { Id = "UpdateMatches", Description = "Update matches" },
                    new Activity() { Id = "ViewAdminUsers", Description = "View List of Users" },
                    new Activity() { Id = "AddAdminUsers", Description = "Add new players" },
                    new Activity() { Id = "GenerateLinkAdminUsers", Description = "Generate acces token to user" }
                );

            modelBuilder.Entity<Rol>().HasData(
                new Rol() { Id = "Admin", Description = "Root admin", IsRoot = true },
                new Rol() { Id = "Player", Description = "Single PLayer" }
                );

            relationshipRolActivities.UsingEntity<Dictionary<string, object>>(
                    "RolsActivity",
                    r => r.HasOne<Activity>().WithMany().HasForeignKey("ActivityId"),
                    l => l.HasOne<Rol>().WithMany().HasForeignKey("RolId"),
                    je =>
                    {
                        je.HasKey("RolId", "ActivityId");
                        je.HasData(
                            new { RolId = "Admin", ActivityId = "UpdateQuiniela" },
                            new { RolId = "Admin", ActivityId = "Index" },
                            new { RolId = "Admin", ActivityId = "UpdateMatches" },
                            new { RolId = "Admin", ActivityId = "ViewAdminUsers" },
                            new { RolId = "Admin", ActivityId = "AddAdminUsers" },
                            new { RolId = "Admin", ActivityId = "GenerateLinkAdminUsers" },

                            new { RolId = "Player", ActivityId = "UpdateQuiniela" }
                            );
                    });

            modelBuilder.Entity<Player>().HasData(new Player()
            {
                Id = 1,
                Name = "ftrejo"
            });

            relationshipPlayerRols.UsingEntity<Dictionary<string, object>>(
                    "PlayersRols",
                    l => l.HasOne<Rol>().WithMany().HasForeignKey("RolId"),
                    r => r.HasOne<Player>().WithMany().HasForeignKey("PlayerId"),
                    je =>
                    {
                        je.ToTable("PlayersRols", "Security");
                        je.HasKey("RolId", "PlayerId");
                        je.HasData(
                            new { RolId = "Admin", PlayerId = 1 }
                            );
                    });
        }
    }
}