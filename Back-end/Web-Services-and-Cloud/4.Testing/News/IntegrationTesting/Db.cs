using News.Data;

namespace IntegrationTesting
{
    public class Db
    {
        public Db() : this (new NewsContext())
        {
           
        }

        public Db(NewsContext dbContext)
        {
            DbContext = dbContext;
        }

        public static NewsContext DbContext { get; private set; } 
    }
}