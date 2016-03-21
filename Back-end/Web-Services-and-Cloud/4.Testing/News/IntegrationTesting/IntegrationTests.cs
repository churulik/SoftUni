using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFramework.Extensions;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using News.Data;
using News.Service;

namespace IntegrationTesting
{
    using Owin;
    using News.Models;

    [TestClass]
    public class IntegrationTests : Db
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;

        [TestInitialize]
        public void TestInit()
        {
            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });
            this.httpClient = httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void GetAllNews_FromDb_ShouldReturn200OkAndAllNews()
        {
            CleanDatabase();

            AddNews();
            AddNews();
            AddNews();
            AddNews();

            var httpResponse = httpClient.GetAsync("/api/news").Result;
            var newsFromServer = httpResponse.Content.ReadAsAsync<List<News>>().Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");

            var newsFromDb = DbContext.News.ToList();
            Assert.AreEqual(newsFromServer.Count, newsFromDb.Count);

            for (int i = 0; i < newsFromServer.Count; i++)
            {
                Assert.AreEqual(newsFromServer[i].Title, newsFromDb[i].Title);
            }
        }

        [TestMethod]
        public void PostNews_FromDb_ShouldReturn201CreatedAndAllNews()
        {
            CleanDatabase();
            var post = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "Novini"),
                new KeyValuePair<string, string>("content", "Sadarjanie"),
                new KeyValuePair<string, string>("publishedDate", DateTime.Now.ToString("D")),
            });

            var httpResponse = httpClient.PostAsync("api/news", post).Result;
            var newsFromServer = httpResponse.Content.ReadAsAsync<News>().Result;

            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.AreEqual(newsFromServer.Title, "Novini");
            Assert.IsNotNull(newsFromServer.PublishedDate);
        }

        [TestMethod]
        public void PostNews_InDb_ShouldReturn400BadRequest()
        {
            CleanDatabase();

            var post = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>(),
            });

            var httpResponse = httpClient.PostAsync("api/news", post).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void ModifyNews_WithCorrectData_ShouldReturn200Ok()
        {
            CleanDatabase();

            AddNews();

            var news = DbContext.News.First();

            var update = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("title", "Sport"),
            });

            var httpResponse = httpClient.PutAsync("api/news/" + news.Id, update).Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }
        [TestMethod]
        public void ModifyNews_WithIncorrectData_ShouldReturn400BadRequest()
        {
            CleanDatabase();

            AddNews();

            var news = DbContext.News.First();
            
            var httpResponse = httpClient.PutAsync("api/news/" + news.Id, null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeleteNews_WithCorrectData_ShouldReturn200Ok()
        {
            CleanDatabase();

            AddNews();

            var news = DbContext.News.First();

            var httpResponse = httpClient.DeleteAsync("api/news/" + news.Id).Result;

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [TestMethod]
        public void DeleteNews_WithIncorrectData_ShouldReturn400BadRequest()
        {
            CleanDatabase();

            AddNews();

            var news = DbContext.News.First();

            var httpResponse = httpClient.DeleteAsync("api/news/" + (news.Id + 1)).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        private static void CleanDatabase()
        {
            // Clean all data in all database tables
            var dbContext = new NewsContext();
            dbContext.News.Delete();
            // ...
            // dbContext.AnotherEntity.Delete();
            // ...
            dbContext.SaveChanges();
        }

        private static void AddNews()
        {
             DbContext.News.Add(
                new News()
                {
                    Title = "Novini",
                    Content = "Sadarjanie",
                    PublishedDate = DateTime.Now.ToString("D")
                });
            DbContext.SaveChanges();
        }
    }
}
