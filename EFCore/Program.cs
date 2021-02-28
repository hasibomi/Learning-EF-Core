using System;
using System.Linq;
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

                var newAuthor = new Author();
                newAuthor.FirstName = "Tarik";
                newAuthor.LastName = "Alam";
                newAuthor.Username = "trk";
                newAuthor.Email = "trk@example.com";

                db.Add(newAuthor);
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying all Authors:");

                var authors = db.Authors.ToList();
                
                foreach (var item in authors)
                {
                    Console.WriteLine(item.FirstName);
                }

                // Read a single Author
                var author = db.Authors.OrderBy(a => a.FirstName).First();
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }
    }
}
