using System;
using EFCore.Data;
using EFCore.Models;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFCoreContext())
            {
                // Create
                Console.WriteLine("Inserting a new Author");

                var author = new Author();
                author.FirstName = "Tarik";
                author.LastName = "Alam";
                author.Username = "trk";
                author.Email = "trk@example.com";

                db.Add(author);
                db.SaveChanges();
            }
        }
    }
}
