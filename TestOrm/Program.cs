// See https://aka.ms/new-console-template for more information
using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite;
using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
using (var context = new DatabaseContext())
{
    // Ajouter une personne
    var newPers = new Person("0", "test", "test", new Address(1, "streetName", 3, "city"));
    var PersonneToSave = newPers.ToSQL();
    context.Personnes.Add(PersonneToSave);
    context.SaveChanges();

    // Lire toutes les personnes
    var toutesLesPersonnes = context.Personnes.ToList();
    foreach (var personne in toutesLesPersonnes)
    {
        Console.WriteLine($"ID: {personne.Id}, Lastname: {personne.LastName}, Firstname: {personne.FirstName}");
    }
}