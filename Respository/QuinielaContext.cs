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
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiniela> Quinielas { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerGameResult> PlayerGameResult { get; set; }
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

            modelBuilder.Entity<Match>().ToTable("Matchs")
                .HasOne(mg => mg.Quiniela)
                .WithMany(q => q.Matchs)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(mg => mg.Local)
                .WithMany(c => c.LocalMatchs)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(mg => mg.Visitor)
                .WithMany(c => c.VisitorMatchs)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Question>().ToTable("Questions")
                .HasOne(mg => mg.Quiniela)
                .WithMany(q => q.Questions)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Quiniela>().ToTable("Quinielas")
                .HasMany(q => q.Matchs)
                .WithOne(m => m.Quiniela)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Quiniela>()
                .HasMany(q => q.Questions)
                .WithOne(m => m.Quiniela)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Player>().ToTable("Players")
                .HasMany(p => p.MatchResults)
                .WithOne(mr => mr.Player)
                .OnDelete(DeleteBehavior.NoAction);

            var relationshipPlayerRols = modelBuilder.Entity<Player>()
                .HasMany(p => p.Rols)
                .WithMany(r => r.Players);

            modelBuilder.Entity<PlayerGameResult>().ToTable("PlayerMatchResult");

            modelBuilder.Entity<PlayerGameResult>()
                .HasOne(mr => mr.Match)
                .WithMany(mg => mg.MatchResults)
                .HasForeignKey(mr => mr.MatchId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayerGameResult>()
                .HasOne(mr => mr.Question)
                .WithMany(mg => mg.QuestionResults)
                .HasForeignKey(mr => mr.QuestionId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>().ToTable("Activities", "Security")
                .HasKey(a => a.Id);

            modelBuilder.Entity<Rol>().ToTable("Rols", "Security")
                .HasKey(a => a.Id);
            var relationshipRolActivities = modelBuilder.Entity<Rol>()
                .HasMany<Activity>(r => r.Activities)
                .WithMany(a => a.Rols);

            /* Data initializor*/

            modelBuilder.Entity<Tournament>().HasData(
                new Tournament() { Id = 1, Name = "Qatar 2022" }
                );

            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = "KSA", Name = "Arabia Saudita" },
                new Team() { Id = "ARG", Name = "Argentina" },
                new Team() { Id = "BRA", Name = "Brasil" },
                new Team() { Id = "QAT", Name = "Catar" },
                new Team() { Id = "CRC", Name = "CostaRica" },
                new Team() { Id = "CAN", Name = "Canada" },
                new Team() { Id = "CRO", Name = "Croacia" },
                new Team() { Id = "CMR", Name = "Camerun" },
                new Team() { Id = "KOR", Name = "Corea del Sur" },
                new Team() { Id = "SEN", Name = "Senegal" },
                new Team() { Id = "ECU", Name = "Ecuador" },
                new Team() { Id = "NED", Name = "Paises Bajos" },
                new Team() { Id = "ENG", Name = "Inglaterra" },
                new Team() { Id = "USA", Name = "Estados Unidos" },
                new Team() { Id = "IRN", Name = "Iran" },
                new Team() { Id = "WAL", Name = "Gales" },
                new Team() { Id = "MEX", Name = "Mexico" },
                new Team() { Id = "POL", Name = "Polonia" },
                new Team() { Id = "DEN", Name = "Dinamarca" },
                new Team() { Id = "FRA", Name = "Francia" },
                new Team() { Id = "TUN", Name = "Tunez" },
                new Team() { Id = "AUS", Name = "Australia" },
                new Team() { Id = "ESP", Name = "España" },
                new Team() { Id = "GER", Name = "Alemania" },
                new Team() { Id = "JPN", Name = "Japon" },
                new Team() { Id = "BEL", Name = "Belgica" },
                new Team() { Id = "MAR", Name = "Marruecos" },
                new Team() { Id = "SUI", Name = "Suiza" },
                new Team() { Id = "SRB", Name = "Serbia" },
                new Team() { Id = "POR", Name = "Portugal" },
                new Team() { Id = "URU", Name = "Uruguay" },
                new Team() { Id = "GHA", Name = "Ghana" },
                new Team() { Id = "N/A", Name = "Por definir" }
                );

            modelBuilder.Entity<Quiniela>().HasData(
                new Quiniela() { Id = 1, StartDate = new DateTime(2022, 10, 05), EndDate = new DateTime(2022, 11, 19), TournamentId = 1, Name = "Jornada 1" },
                new Quiniela() { Id = 2, StartDate = new DateTime(2022, 11, 25), EndDate = new DateTime(2022, 11, 25), TournamentId = 1, Name = "Jornada 2" },
                new Quiniela() { Id = 3, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 11, 29), TournamentId = 1, Name = "Jornada 3" },
                new Quiniela() { Id = 4, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 12, 3), TournamentId = 1, Name = "Octavos de final" },
                new Quiniela() { Id = 5, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 12, 9), TournamentId = 1, Name = "Cuartos de final" },
                new Quiniela() { Id = 6, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 12, 13), TournamentId = 1, Name = "Semifinal" },
                new Quiniela() { Id = 7, StartDate = new DateTime(2022, 11, 29), EndDate = new DateTime(2022, 12, 17), TournamentId = 1, Name = "Finales" }
             );

            modelBuilder.Entity<Match>().HasData(
                //Jornada 1
                new Match() { Id = 1, Group = "Grupo A", LocalId = "QAT", VisitorId = "ECU", CanDraw = true, Date = new DateTime(2022, 11, 20, 10, 0, 0), QuinielaId = 1 },
                new Match() { Id = 2, Group = "Grupo A", LocalId = "SEN", VisitorId = "NED", CanDraw = true, Date = new DateTime(2022, 11, 21, 10, 0, 0), QuinielaId = 1 },
                new Match() { Id = 3, Group = "Grupo B", LocalId = "ENG", VisitorId = "IRN", CanDraw = true, Date = new DateTime(2022, 11, 21, 7, 0, 0), QuinielaId = 1 },
                new Match() { Id = 4, Group = "Grupo B", LocalId = "USA", VisitorId = "WAL", CanDraw = true, Date = new DateTime(2022, 11, 21, 13, 0, 0), QuinielaId = 1 },
                new Match() { Id = 5, Group = "Grupo C", LocalId = "ARG", VisitorId = "KSA", CanDraw = true, Date = new DateTime(2022, 11, 22, 4, 0, 0), QuinielaId = 1 },
                new Match() { Id = 6, Group = "Grupo C", LocalId = "MEX", VisitorId = "POL", CanDraw = true, Date = new DateTime(2022, 11, 22, 10, 0, 0), QuinielaId = 1 },
                new Match() { Id = 7, Group = "Grupo D", LocalId = "DEN", VisitorId = "TUN", CanDraw = true, Date = new DateTime(2022, 11, 22, 7, 0, 0), QuinielaId = 1 },
                new Match() { Id = 8, Group = "Grupo D", LocalId = "FRA", VisitorId = "AUS", CanDraw = true, Date = new DateTime(2022, 11, 22, 13, 0, 0), QuinielaId = 1 },
                new Match() { Id = 9, Group = "Grupo E", LocalId = "ESP", VisitorId = "CRC", CanDraw = true, Date = new DateTime(2022, 11, 23, 10, 0, 0), QuinielaId = 1 },
                new Match() { Id = 10, Group = "Grupo E", LocalId = "GER", VisitorId = "JPN", CanDraw = true, Date = new DateTime(2022, 11, 23, 07, 0, 0), QuinielaId = 1 },
                new Match() { Id = 11, Group = "Grupo F", LocalId = "BEL", VisitorId = "CAN", CanDraw = true, Date = new DateTime(2022, 11, 23, 13, 0, 0), QuinielaId = 1 },
                new Match() { Id = 12, Group = "Grupo F", LocalId = "MAR", VisitorId = "CRO", CanDraw = true, Date = new DateTime(2022, 11, 23, 04, 0, 0), QuinielaId = 1 },
                new Match() { Id = 13, Group = "Grupo G", LocalId = "SUI", VisitorId = "CMR", CanDraw = true, Date = new DateTime(2022, 11, 24, 04, 0, 0), QuinielaId = 1 },
                new Match() { Id = 14, Group = "Grupo G", LocalId = "BRA", VisitorId = "SRB", CanDraw = true, Date = new DateTime(2022, 11, 24, 13, 0, 0), QuinielaId = 1 },
                new Match() { Id = 15, Group = "Grupo H", LocalId = "POR", VisitorId = "GHA", CanDraw = true, Date = new DateTime(2022, 11, 24, 10, 0, 0), QuinielaId = 1 },
                new Match() { Id = 16, Group = "Grupo H", LocalId = "URU", VisitorId = "KOR", CanDraw = true, Date = new DateTime(2022, 11, 24, 07, 0, 0), QuinielaId = 1 },

                //Jornada 2
                new Match() { Id = 17, Group = "Grupo B", LocalId = "WAL", VisitorId = "IRN", CanDraw = true, Date = new DateTime(2022, 11, 25, 04, 0, 0), QuinielaId = 2 },
                new Match() { Id = 18, Group = "Grupo A", LocalId = "QAT", VisitorId = "SEN", CanDraw = true, Date = new DateTime(2022, 11, 25, 07, 0, 0), QuinielaId = 2 },
                new Match() { Id = 19, Group = "Grupo A", LocalId = "NED", VisitorId = "ECU", CanDraw = true, Date = new DateTime(2022, 11, 25, 10, 0, 0), QuinielaId = 2 },
                new Match() { Id = 20, Group = "Grupo B", LocalId = "ENG", VisitorId = "USA", CanDraw = true, Date = new DateTime(2022, 11, 25, 13, 0, 0), QuinielaId = 2 },
                new Match() { Id = 21, Group = "Grupo D", LocalId = "TUN", VisitorId = "AUS", CanDraw = true, Date = new DateTime(2022, 11, 26, 04, 0, 0), QuinielaId = 2 },
                new Match() { Id = 22, Group = "Grupo C", LocalId = "POL", VisitorId = "KSA", CanDraw = true, Date = new DateTime(2022, 11, 26, 07, 0, 0), QuinielaId = 2 },
                new Match() { Id = 23, Group = "Grupo D", LocalId = "FRA", VisitorId = "DEN", CanDraw = true, Date = new DateTime(2022, 11, 26, 10, 0, 0), QuinielaId = 2 },
                new Match() { Id = 24, Group = "Grupo C", LocalId = "ARG", VisitorId = "MEX", CanDraw = true, Date = new DateTime(2022, 11, 26, 13, 0, 0), QuinielaId = 2 },
                new Match() { Id = 25, Group = "Grupo E", LocalId = "JPN", VisitorId = "CRC", CanDraw = true, Date = new DateTime(2022, 11, 27, 04, 0, 0), QuinielaId = 2 },
                new Match() { Id = 26, Group = "Grupo F", LocalId = "BEL", VisitorId = "MAR", CanDraw = true, Date = new DateTime(2022, 11, 27, 07, 0, 0), QuinielaId = 2 },
                new Match() { Id = 27, Group = "Grupo F", LocalId = "CRO", VisitorId = "CAN", CanDraw = true, Date = new DateTime(2022, 11, 27, 10, 0, 0), QuinielaId = 2 },
                new Match() { Id = 28, Group = "Grupo E", LocalId = "ESP", VisitorId = "GER", CanDraw = true, Date = new DateTime(2022, 11, 27, 13, 0, 0), QuinielaId = 2 },
                new Match() { Id = 29, Group = "Grupo G", LocalId = "CMR", VisitorId = "SRB", CanDraw = true, Date = new DateTime(2022, 11, 28, 04, 0, 0), QuinielaId = 2 },
                new Match() { Id = 30, Group = "Grupo H", LocalId = "KOR", VisitorId = "GHA", CanDraw = true, Date = new DateTime(2022, 11, 28, 07, 0, 0), QuinielaId = 2 },
                new Match() { Id = 31, Group = "Grupo G", LocalId = "BRA", VisitorId = "SUI", CanDraw = true, Date = new DateTime(2022, 11, 28, 10, 0, 0), QuinielaId = 2 },
                new Match() { Id = 32, Group = "Grupo H", LocalId = "POR", VisitorId = "URU", CanDraw = true, Date = new DateTime(2022, 11, 28, 13, 0, 0), QuinielaId = 2 },

                //Jornada 3
                new Match() { Id = 33, Group = "Grupo A", LocalId = "ECU", VisitorId = "SEN", CanDraw = true, Date = new DateTime(2022, 11, 29, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 34, Group = "Grupo A", LocalId = "NED", VisitorId = "QAT", CanDraw = true, Date = new DateTime(2022, 11, 29, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 35, Group = "Grupo B", LocalId = "IRN", VisitorId = "USA", CanDraw = true, Date = new DateTime(2022, 11, 29, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 36, Group = "Grupo B", LocalId = "WAL", VisitorId = "ENG", CanDraw = true, Date = new DateTime(2022, 11, 29, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 37, Group = "Grupo D", LocalId = "TUN", VisitorId = "FRA", CanDraw = true, Date = new DateTime(2022, 11, 30, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 38, Group = "Grupo D", LocalId = "AUS", VisitorId = "DEN", CanDraw = true, Date = new DateTime(2022, 11, 30, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 39, Group = "Grupo C", LocalId = "POL", VisitorId = "ARG", CanDraw = true, Date = new DateTime(2022, 11, 30, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 40, Group = "Grupo C", LocalId = "KSA", VisitorId = "MEX", CanDraw = true, Date = new DateTime(2022, 11, 30, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 41, Group = "Grupo F", LocalId = "CRO", VisitorId = "BEL", CanDraw = true, Date = new DateTime(2022, 12, 1, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 42, Group = "Grupo F", LocalId = "CAN", VisitorId = "MAR", CanDraw = true, Date = new DateTime(2022, 12, 1, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 43, Group = "Grupo E", LocalId = "JPN", VisitorId = "ESP", CanDraw = true, Date = new DateTime(2022, 12, 1, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 44, Group = "Grupo E", LocalId = "CRC", VisitorId = "GER", CanDraw = true, Date = new DateTime(2022, 12, 1, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 45, Group = "Grupo H", LocalId = "KOR", VisitorId = "POR", CanDraw = true, Date = new DateTime(2022, 12, 2, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 46, Group = "Grupo H", LocalId = "GHA", VisitorId = "URU", CanDraw = true, Date = new DateTime(2022, 12, 2, 09, 0, 0), QuinielaId = 3 },
                new Match() { Id = 47, Group = "Grupo G", LocalId = "SRB", VisitorId = "SUI", CanDraw = true, Date = new DateTime(2022, 12, 2, 13, 0, 0), QuinielaId = 3 },
                new Match() { Id = 48, Group = "Grupo G", LocalId = "CMR", VisitorId = "BRA", CanDraw = true, Date = new DateTime(2022, 12, 2, 13, 0, 0), QuinielaId = 3 },

                //Octavos de final
                new Match() { Id = 49, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 3, 09, 0, 0), QuinielaId = 4 },
                new Match() { Id = 50, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 3, 13, 0, 0), QuinielaId = 4 },
                new Match() { Id = 51, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 4, 09, 0, 0), QuinielaId = 4 },
                new Match() { Id = 52, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 4, 13, 0, 0), QuinielaId = 4 },
                new Match() { Id = 53, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 5, 09, 0, 0), QuinielaId = 4 },
                new Match() { Id = 54, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 5, 13, 0, 0), QuinielaId = 4 },
                new Match() { Id = 55, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 6, 09, 0, 0), QuinielaId = 4 },
                new Match() { Id = 56, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 6, 13, 0, 0), QuinielaId = 4 },

                //Cuartos de final
                new Match() { Id = 57, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 9, 09, 0, 0), QuinielaId = 5 },
                new Match() { Id = 58, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 9, 13, 0, 0), QuinielaId = 5 },
                new Match() { Id = 59, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 10, 09, 0, 0), QuinielaId = 5 },
                new Match() { Id = 60, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 10, 13, 0, 0), QuinielaId = 5 },

                //Semifinal
                new Match() { Id = 61, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 13, 13, 0, 0), QuinielaId = 6 },
                new Match() { Id = 62, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 14, 13, 0, 0), QuinielaId = 6 },

                //Final
                new Match() { Id = 63, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 17, 9, 0, 0), QuinielaId = 7 },
                new Match() { Id = 64, Group = "", LocalId = "N/A", VisitorId = "N/A", CanDraw = false, Date = new DateTime(2022, 12, 18, 9, 0, 0), QuinielaId = 7 }
                );

            modelBuilder.Entity<Activity>().HasData(
                   //SinglePlayer
                   new Activity() { Id = "UpdateQuiniela", Description = "Update Quiniela matches" },
                   //Admin
                   new Activity() { Id = "Index", Description = "Watch Index" },
                    new Activity() { Id = "UpdateMatches", Description = "Update matches" },
                    new Activity() { Id = "ViewAdminUsers", Description = "View List of Users" },
                    new Activity() { Id = "AddAdminUsers", Description = "Add new players" },
                    new Activity() { Id = "GenerateLinkAdminUsers", Description = "Generate acces token to user" },
                    new Activity() { Id = "ViewAdminMatch", Description = "View List of Matchs" },
                    new Activity() { Id = "UpdateAdminMatchResult", Description = "Update Match Result" }
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
                            new { RolId = "Admin", ActivityId = "ViewAdminMatch" },
                            new { RolId = "Admin", ActivityId = "UpdateAdminMatchResult" },

                            new { RolId = "Player", ActivityId = "UpdateQuiniela" },
                            new { RolId = "Player", ActivityId = "Index" }
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