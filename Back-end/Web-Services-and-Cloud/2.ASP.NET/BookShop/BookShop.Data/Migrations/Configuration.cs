using System.Globalization;
using System.IO;
using BookShop.Models;

namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.Data.BookShopEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookShop.Data.BookShopEntities context)
        {
            var random = new Random();

            using (var reader = new StreamReader("../../authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 2);
                    var firstName = data[0];
                    var lastName = data[1];


                    context.Authors.Add(new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }

            using (var reader = new StreamReader("../../books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                var authors = context.Authors.ToList();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 6);
                    var authorIndex = random.Next(1, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (Edition)int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        Edition = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }

            using (var reader = new StreamReader("../../categories.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var data = line.Split(new[] { ' ' }, 1);
                    var bookName = data[0];

                    context.Categories.Add(new Category()
                    {
                        Name = bookName
                    });

                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }

            var book = context.Books.Count();
            var category = context.Categories.Count();
            var listBooks = context.Books.ToList();
            var listCategory = context.Categories.ToList();

            for (int i = 0; i < book; i++)
            {

                var categoryId = random.Next(1, category);

                listBooks[i].Categories.Add(listCategory[categoryId]);
            }
            context.SaveChanges();
        }
    }
}
