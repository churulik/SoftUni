using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Data;
using News.Data.Repositories;

namespace TestingRepositories
{
    using News.Models;

    [TestClass]
    public class TestingRepositories
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            // Start a new temporary transaction
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            // Rollback the temporary transaction
            tran.Dispose();
        }
        
        [TestMethod]
        public void ListAllNews_RepoAllAddSaveChanges_ShouldReturnAllNewsCount()
        {
            var news = new TempNews()
            {
                Title = "Novinite dnes",
                Content = "Niama takiva",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var context = new Repository<TempNews>(new NewsContext());

            var count = context.All().Count();

            context.Add(news);

            context.SaveChanges();

            var newCount = context.All().Count();

            Assert.AreEqual(count + 1, newCount);
        }

        [TestMethod]
        public void AddANews_RepoAddFindSaveChanges_ShouldCreateAndReturnTheNewsFromDb()
        {
            var news = new TempNews()
            {
                Title = "Sport",
                Content = "Dnes...",
                PublishedDate = DateTime.Now.ToString("D")
            };
            
            var context = new Repository<TempNews>(new NewsContext());
            
            context.Add(news);
            context.SaveChanges();

            var findNews = context.Find(news.Id);

            Assert.AreEqual(news.Id, findNews.Id);
            Assert.AreEqual(news.Title, findNews.Title);
            Assert.AreEqual(news.Content, findNews.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddANewsWithoutTitle_RepoAddSaveChanges_ShouldThrоwDbEntityValidationException()
        {
            var news = new TempNews()
            {
                Content = "Niama takiva",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var context = new Repository<TempNews>(new NewsContext());

            context.Add(news);
            context.SaveChanges();
        }

        [TestMethod]
        public void EditExistingNews_RepoAddUpdateSaveChanges_ShouldBeModified()
        {
            var news = new TempNews()
            {
                Title = "Sport",
                Content = "Dnes...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var context = new Repository<TempNews>(new NewsContext());
            
            context.Add(news);
            context.SaveChanges();

            var findNews = context.Find(news.Id);

            findNews.Title = "Vremeto";

            context.Update(findNews);

            context.SaveChanges();

            Assert.AreEqual("Vremeto", findNews.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void EditExistingNews_RepoAddSaveChangesFindUpdate_ShouldThrоwDbEntityValidationException()
        {
            var news = new TempNews()
            {
                Title = "Sport",
                Content = "Dnes...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var context = new Repository<TempNews>(new NewsContext());

            context.Add(news);
            context.SaveChanges();

            var findNews = context.Find(news.Id);

            findNews.Content = "D";

            context.Update(findNews);

            context.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EditNonExistingNews_RepoFindUpateSaveChanges_ShouldThrоwNullReferenceException()
        {
            var context = new Repository<TempNews>(new NewsContext());

            var findNews = context.Find(1000);

            findNews.Content = "Novinata ne e namerena";

            context.Update(findNews);
            context.SaveChanges();
        }

        [TestMethod]
        public void DeleteExistingNews_RepoDelete_ShouldDeleteTheNews()
        {
            var news = new TempNews()
            {
                Title = "Sport",
                Content = "Dnes...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var context = new Repository<TempNews>(new NewsContext());

            context.Add(news);
            context.SaveChanges();

            var findNews = context.Find(news.Id);

            context.Delete(findNews);
            context.SaveChanges();
            var findNewsAfterDelete = context.Find(news.Id);

            Assert.IsNull(findNewsAfterDelete);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNonExistingNews_RepoDelete_ShouldThrоwArgumentNullException()
        {
            var context = new Repository<TempNews>(new NewsContext());

            var findNews = context.Find(1000);

            context.Delete(findNews);
            context.SaveChanges();
        }
     
    }
}
