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

Console.WriteLine("Hello, World!");

DbContextOptionsBuilder dbContextOptions = new DbContextOptionsBuilder();
dbContextOptions.UseSqlServer("Server=SOPHIAW11\\SOPHIASQLEXPRESS; Database=Quinielas; Integrated Security=True; MultipleActiveResultSets=False;");
QuinielaContext _quinielaContext = new QuinielaContext(dbContextOptions.Options);

var randomGenerator = new Random();
//foreach (MatchGame game in _quinielaContext.Games.Where(g => g.CanDraw).ToList())
//{
//    //empate 20%
//    if (randomGenerator.Next(1, 5) % 4 == 0)
//    {
//        int goals = randomGenerator.Next(0, 5);
//        game.LocalGoals = goals;
//        game.VisitorGoals = goals;
//        game.Ended = true;
//        _quinielaContext.SaveChanges();
//    }
//    else
//    {
//        game.LocalGoals = randomGenerator.Next(0, 6);
//        game.VisitorGoals = randomGenerator.Next(0, 6);
//        game.Ended = true;
//        _quinielaContext.SaveChanges();
//    }
//}

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

List<Player> Players = _quinielaContext.Players.ToList();

foreach (Player p in Players)
{
    string name = nombres[randomGenerator.Next(0, nombres.Count - 1)];
    string surname = apellidos[randomGenerator.Next(0, apellidos.Count - 1)];
    string user = (name.Substring(0, 1) + surname).ToLowerInvariant();
    p.Name = user;
    _quinielaContext.SaveChanges();
}
