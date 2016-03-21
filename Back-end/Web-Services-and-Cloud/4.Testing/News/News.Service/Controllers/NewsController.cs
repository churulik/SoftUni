using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using News.Data;
using News.Data.Repositories;
using News.Service.Models;

namespace News.Service.Controllers
{
    using News.Models;
    public class NewsController : ApiController
    {
        public IRepository<News> NewsRepo { get; private set; }

        public NewsController()
            : this(new Repository<News>(new NewsContext()))
        {
        }

        public NewsController(IRepository<News> newsRepo)
        {
            this.NewsRepo = newsRepo;
        }

        //GET api/news
        public IHttpActionResult GetAllNews()
        {
            var news = this.NewsRepo.All()
                .OrderBy(n => n.PublishedDate)
                .Select(n => new
                {
                    n.Id,
                    n.Title,
                    n.Content,
                    n.PublishedDate
                });;

            return Ok(news);
        }

        // POST api/news
        public IHttpActionResult PostNews(NewsBindingModel model)
        {
            if (model.Title == null)
            {
                return this.BadRequest("The title cannot be empty.");
            }

            if (model.Content == null)
            {
                return this.BadRequest("The content cannot be empty.");
            }

            var news = new News
            {
                Title = model.Title,
                Content = model.Content,
                PublishedDate = DateTime.Now.ToString("D")
            };

            this.NewsRepo.Add(news);

            this.NewsRepo.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new object(), news);
        }

        //PUT api/news/{id}
        [HttpPut]
        public IHttpActionResult Edit(int id, NewsBindingModel model)
        {
            var news = this.NewsRepo.All().FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return this.BadRequest("Non-existing news.");
            }

            if (model == null)
            {
                return this.BadRequest("Enter valid data.");
            }

            if (model.Title != null)
            {
                news.Title = model.Title;
            }

            if (model.Content != null)
            {
                news.Content = model.Content;
            }

            if (model.PublishedDate != null)
            {
                news.PublishedDate = model.PublishedDate;
            }

            this.NewsRepo.SaveChanges();

            return this.Ok(news);
        }

        //DELETE api/news/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var news = this.NewsRepo.All().FirstOrDefault(n => n.Id == id);

            if (news == null)
            {
                return this.BadRequest("Non-existing news.");
            }

            this.NewsRepo.Delete(news);

            this.NewsRepo.SaveChanges();

            return this.Ok("The news is delete.");
        }

        //Mock Edit Endpoint
        [HttpPut]
        [Route("mock/edit/{id}")]
        public IHttpActionResult EditMock(int id, NewsBindingModel model)
        {
            var mockNews = MockDb.News().FirstOrDefault(n => n.Id == id);

            if (mockNews == null)
            {
                return this.BadRequest("Non-existing news.");
            }

            if (model.Title == null && model.Content == null && model.PublishedDate == null)
            {
                return this.BadRequest("Enter valid data.");
            }

            if (model.Title != null)
            {
                mockNews.Title = model.Title;
            }

            if (model.Content != null)
            {
                mockNews.Content = model.Content;
            }

            if (model.PublishedDate != null)
            {
                mockNews.PublishedDate = model.PublishedDate;
            }

            this.NewsRepo.Update(mockNews);

            return this.Ok(mockNews);
        }

        //Mock Delete Endpoint
        [HttpDelete]
        [Route("mock/delete/{id}")]
        public IHttpActionResult DeleteMock(int id)
        {
            var mockNews = MockDb.News().FirstOrDefault(n => n.Id == id);

            if (mockNews == null)
            {
                return this.BadRequest("Non-existing news.");
            }

            this.NewsRepo.Delete(mockNews);

            return this.Ok("The news is delete.");
        }
    }
}