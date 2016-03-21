using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using News.Data;
using News.Data.Repositories;
using News.Service.Controllers;
using News.Service.Models;

namespace TestingApiCotrollerWithMocking
{
    using News.Models;

    [TestClass]
    public class MockTests
    {
        private const int CorrectNewsId = 1;
        private const int IncorrectNewsId = 4;

        [TestMethod]
        public void GetAllNews_WithCorrectData_ShouldReturn201CreatedAndCreatedNews()
        {
            var news = MockDb.News();

            var mockRepository = new Mock<IRepository<News>>();

            mockRepository.Setup(r => r.All()).Returns(news.AsQueryable());

            var controller = new NewsController(mockRepository.Object);
            SetupController(controller, "news");

            var result = controller.GetAllNews().ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Novini", news.First().Title);
            Assert.IsTrue(news.Count == 3);

        }

        [TestMethod]
        public void PostNews_WithCorrectData_ShouldReturn201CreatedAndCreatedNews()
        {
            var news = MockDb.News();

            var mockRepository = new Mock<IRepository<News>>();

            mockRepository.Setup(r => r.Add(It.IsAny<News>())).Callback((News n) => news.Add(n));

            var controller = new NewsController(mockRepository.Object);
            SetupController(controller, "news");

            var bindigModel = new NewsBindingModel()
            {
                Title = "Novina",
                Content = "...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var result = controller.PostNews(bindigModel).ExecuteAsync(new CancellationToken()).Result;
            
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            Assert.AreEqual("Novini", news.First().Title);
            Assert.AreEqual(bindigModel.Title, news.Last().Title);
            Assert.IsTrue(news.Count == 4);

        }

        [TestMethod]
        public void PostNews_ThatIsIncorrect_ShouldThorw400BadRequeis()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Add(It.IsAny<News>())).Callback((News n) => news.Add(n));

            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");
            
            var bindigModel = new NewsBindingModel()
            {
                Content = "...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var result = controller.PostNews(bindigModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void EditNews_WithCorrectData_ShouldReturn200OkModifiesTheNewsInCorrectWay()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Update(It.IsAny<News>())).Callback((News n) => news[CorrectNewsId - 1] = n);

            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");

            var bindigModel = new NewsBindingModel()
            {
                Title = "Vremeto",
                Content = "...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var result = controller.EditMock(CorrectNewsId, bindigModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(bindigModel.Title, news.First().Title);
            Assert.AreEqual("Moda", news.Last().Title);
            Assert.IsTrue(news.Count == 3);
        }

        [TestMethod]
        public void EditNews_WithIncorrectData_ShouldReturn400BadRequest()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Update(It.IsAny<News>())).Callback((News n) => news[CorrectNewsId - 1] = n);

            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");

            //Incorect data - empty BindigModel
            var bindigModel = new NewsBindingModel();

            var result = controller.EditMock(CorrectNewsId, bindigModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }


        [TestMethod]
        public void EditNews_ThatDoesNotExists_ShouldReturn400BadRequest()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Update(It.IsAny<News>())).Callback((News n) => news[IncorrectNewsId - 1] = n);

            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");

            var bindigModel = new NewsBindingModel()
            {
                Title = "Vremeto",
                Content = "...",
                PublishedDate = DateTime.Now.ToString("D")
            };

            var result = controller.EditMock(IncorrectNewsId, bindigModel).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void DeleteNews_ThatExists_ShouldReturn200OkAndDeleteTheNews()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Delete(It.IsAny<News>())).Callback((News n) => news.RemoveAt(CorrectNewsId - 1));
           
            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");
            
            var result = controller.DeleteMock(CorrectNewsId).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Sport", news.First().Title);
            Assert.IsTrue(news.Count == 2);
        }

        [TestMethod]
        public void DeleteNews_ThatDoesNotExists_ShouldReturn400BadRequest()
        {
            var news = MockDb.News();

            var mockRepo = new Mock<IRepository<News>>();
            mockRepo.Setup(n => n.Delete(It.IsAny<News>())).Callback((News n) => news.RemoveAt(3));

            var controller = new NewsController(mockRepo.Object);
            SetupController(controller, "news");

            var result = controller.DeleteMock(IncorrectNewsId).ExecuteAsync(new CancellationToken()).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.IsTrue(news.Count == 3);
        }

        private static void SetupController(ApiController controller, string controllerName)
        {
            const string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
    }
}
