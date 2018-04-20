using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_17
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NewsModelContainer context = new NewsModelContainer())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    Authors authors = new Authors();
                    authors.FullName = "Петров Иван Васильевич";
                    authors.Id = 0;
                    authors.Age = 36;
                    context.AuthorsSet.Add(authors);
                    News news = new News();
                    news.Id = 0;
                    news.Name = "Запустили ракету";
                    news.Text = "На марсе классно";
                    news.Authors = authors;
                    context.NewsSet.Add(news);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
