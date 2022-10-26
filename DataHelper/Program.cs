// See https://aka.ms/new-console-template for more information
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Respository;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System;
using Entities.Auths;

Console.WriteLine("Start Data Creation");

DbContextOptionsBuilder dbContextOptions = new DbContextOptionsBuilder();
dbContextOptions.UseSqlServer("Server=SOPHIAW11\\SOPHIASQLEXPRESS; Database=Quinielas; Integrated Security=True; MultipleActiveResultSets=False;");
QuinielaContext _quinielaContext = new QuinielaContext(dbContextOptions.Options);

var randomGenerator = new Random();
List<string> apellidos = new List<string>() {
                    "Gonzalez",
                    "Rodriguez",
                    "Gomez",
                    "Fernandez",
                    "Lopez",
                    "Diaz",
                    "Martinez",
                    "Perez",
                    "Garcia",
                    "Sanchez",
                    "Romero",
                    "Sosa",
                    "Torres",
                    "Alvarez",
                    "Ruiz",
                    "Ramirez",
                    "Flores",
                    "Benitez",
                    "Acosta",
                    "Medina",
                    "Herrera",
                    "Suarez",
                    "Aguirre",
                    "Gimenez",
                    "Gutierrez" };
List<string> nombres = new List<string>() {
                    "María",
                    "Silvia",
                    "Natalia",
                    "Claudia",
                    "Patricia",
                    "Alicia",
                    "Lucía",
                    "Cintia",
                    "Cecilia",
                    "Valeria",
                    "Ana",
                    "Norma",
                    "Marta",
                    "Graciela",
                    "Mónica",
                    "Susana",
                    "Mirta",
                    "Nélida",
                    "Juana",
                    "Liliana",
                    "Sergio",
                    "Claudio",
                    "Oscar",
                    "Julio",
                    "José",
                    "Víctor",
                    "Horacio",
                    "Cesar",
                    "Mauricio",
                    "Nicolás",
                    "Martín",
                    "Juan",
                    "Carlos",
                    "Jorge",
                    "Luis",
                    "Miguel",
                    "Hector",
                    "Ramón",
                    "Roberto",
                    "Daniel",
                    "Mario",
                    "Pedro",
                    "Ricardo",
                    "Raúl"};

List<Match> matchs = _quinielaContext.Matchs.Where(g => g.CanDraw).ToList();
// Create Scores
Console.WriteLine("Start CreateScores");
foreach (Match match in matchs)
{
    //empate 20%
    if (randomGenerator.Next(1, 5) % 4 == 0)
    {
        int goals = randomGenerator.Next(0, 5);
        match.LocalGoals = goals;
        match.VisitorGoals = goals;
        match.Ended = true;
        _quinielaContext.SaveChanges();
    }
    else
    {
        match.LocalGoals = randomGenerator.Next(0, 6);
        match.VisitorGoals = randomGenerator.Next(0, 6);
        match.Ended = true;
        _quinielaContext.SaveChanges();
    }
}

Console.WriteLine("End CreateScores");

Console.WriteLine("Start CreatePlayers");
for (int i = 0; i < 50; i++)
{
    string name = nombres[randomGenerator.Next(0, nombres.Count - 1)];
    string surname = apellidos[randomGenerator.Next(0, apellidos.Count - 1)];
    string user = (name.Substring(0, 1) + surname).ToLowerInvariant();
    Rol rol = _quinielaContext.Rols.Find("Player");
    Player player = new Player()
    {
        Name = user,
        Rols = new List<Rol>() { rol }
    };
    _quinielaContext.Players.Add(player);

    _quinielaContext.SaveChanges();

    foreach (Match match in matchs)
    {
        _quinielaContext.PlayerGameResult.Add(new PlayerGameResult()
        {
            PlayerId = player.Id,
            MatchId = match.Id,
            Result = randomGenerator.Next(1, 3)
        });

        _quinielaContext.SaveChanges();
    }
}

Console.WriteLine("End CreatePlayers");
