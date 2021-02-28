using System;
using System.Collections.Generic;
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
                // Register some Authors.
                Console.WriteLine("Register a new Author");
                List<Author> newAuthors = new List<Author>()
                {
                    new Author {
                        FirstName = "Tarik",
                        LastName = "Alam",
                        Username = "trk",
                        Email = "trk@example.com"
                    },
                    new Author {
                        FirstName = "Mehedi",
                        LastName = "Chowdhury",
                        Username = "mehdi",
                        Email = "mehedi@example.com"
                    }
                    ,
                    new Author {
                        FirstName = "Raihan",
                        LastName = "Dip",
                        Username = "thedi",
                        Email = "dip@example.com"
                    }
                };

                foreach (Author author in newAuthors)
                {
                    db.Add(author);
                }
                db.SaveChanges();
                Console.WriteLine($"{newAuthors.Count} author(s) have been registered");

                // List of all Authors.
                Console.WriteLine("List of all Authors");
                List<Author> allAuthors = db.Authors.ToList();
                
                foreach (Author author in allAuthors)
                {
                    Console.WriteLine($"* {author.Username}: {author.FirstName} {author.LastName}");
                }

                // Each author writes some posts.
                Author trk = db.Authors.Single(a => a.Username == "trk");
                Author mehdi = db.Authors.Single(a => a.Username == "mehdi");
                Author thedi = db.Authors.Single(a => a.Username == "thedi");
                List<Post> newPosts = new List<Post>()
                {
                    new Post {
                        Title = "Introduction to Entiry Framework Core",
                        Content = "In this tutorial, you create a .NET Core console app that performs data access against a SQLite database using Entity Framework Core.",
                        Author = trk
                    },
                    new Post {
                        Title = "Introduction to Django",
                        Content = "Django is a Python-based free and open-source web framework that follows the model-template-views architectural pattern.",
                        Author = trk
                    },
                    new Post {
                        Title = "This is my Shiro",
                        Content = "Shiro is my dog. I found her on the street.",
                        Author = mehdi
                    },
                    new Post {
                        Title = "Cali Craft",
                        Content = "I sell Typo graphy.",
                        Author = mehdi
                    },
                    new Post {
                        Title = "I Love Microsoft",
                        Content = "Microsoft pays me to say this. But inside i hate it!",
                        Author = thedi
                    },
                    new Post {
                        Title = "Party",
                        Content = "I am very good at party.",
                        Author = thedi
                    },
                };

                foreach (Post post in newPosts)
                {
                    db.Add(post);
                }
                db.SaveChanges();
                Console.WriteLine($"Total {newPosts.Count} posts have been posted");

                // List of all posts.
                List<Post> allPosts = db.Posts.ToList();
                foreach (Post post in allPosts)
                {
                    Console.WriteLine($"Title: {post.Title}");
                    Console.WriteLine($"Content: {post.Content}");
                    Console.WriteLine($"By: {post.Author.Username}");
                    Console.WriteLine("------------------------------");
                }

                foreach (Author author in allAuthors)
                {
                    Console.WriteLine($"Posts by {author.Username}");

                    foreach (Post post in author.Posts)
                    {
                        Console.WriteLine($"{post.Title}:\n{post.Content}");
                    }

                    Console.WriteLine("------------------------------");
                }
            }
        }
    }
}
