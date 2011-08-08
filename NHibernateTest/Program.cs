using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using CoreModel;
using CoreRepository;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {              
               
                Blog blog = new Blog {Name = "Blog", Title = "Sample post" };

                blog.Posts.Add(new Post { Title = "Post title1", Content = "Post content1", Blog = blog });
                blog.Posts.Add(new Post { Title = "Post title2", Content = "Post content2", Blog = blog });
                blog.Posts.Add(new Post { Title = "Post title3", Content = "Post content3", Blog = blog });

                BlogRepository repo = new BlogRepository(session);

                repo.SaveOrUpdate(blog);

                var blogs = repo.LoadAll();
                foreach (var item in blogs)
                {
                    Console.WriteLine("Id : {0}, Name : {1}, Title = {2}", item.Id, item.Name, item.Title);
                    if (item.Posts != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("------ POST ------");
                        foreach (var post in item.Posts)
                        {
                            Console.WriteLine("Id : {0}, Title : {1}, Content : {2}", post.Id, post.Title, post.Content);
                        }
                    }
                    Console.ResetColor();
                }
              
            }

            Console.ReadKey();
        }


        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey("DBConnection"))
              )
            .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<BlogMap>();
                })
            .BuildSessionFactory();
        }
    }
}
