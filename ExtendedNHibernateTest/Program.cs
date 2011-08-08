using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using ExtendedCoreModel;
using CoreRepository;
using CoreModel;
using NHibernate;
using ExtendedRepository;

namespace ExtendedNHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
             var sessionFactory = CreateSessionFactory();

             using (var session = sessionFactory.OpenSession())
             {

                 ExtendedBlog blog = new ExtendedBlog { Name = "Blog", Title = "Sample post", Description = "Description" };
                 blog.Posts.Add(new ExtendedPost { Title = "Post title1", Content = "Post content1", Slug = "Slug1", Blog = blog });
                 blog.Posts.Add(new ExtendedPost { Title = "Post title2", Content = "Post content2", Slug = "Slug1", Blog = blog });
                 blog.Posts.Add(new ExtendedPost { Title = "Post title3", Content = "Post content3", Slug = "Slug1", Blog = blog });

                 BlogRepository repo = new BlogRepository(session);

                 repo.SaveOrUpdate(blog);

                 var blogs = repo.LoadAll().Cast<ExtendedBlog>();
                 foreach (var item in blogs)
                 {
                     Console.WriteLine("Id : {0}, Name : {1}, Title = {2}, Description : {3}", item.Id, item.Name, item.Title, item.Description);
                     if (item.Posts != null)
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("------ POST ------");
                         foreach (var post in item.Posts.Cast<ExtendedPost>())
                         {
                             Console.WriteLine("Id : {0}, Title : {1}, Content : {2}, Slug : {3}", post.Id, post.Title, post.Content, post.Slug);
                         }
                     }
                     Console.ResetColor();
                 }
             }
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
                m.FluentMappings.AddFromAssemblyOf<ExtendedBlogMap>();
            })
            .BuildSessionFactory();
        }
    }
}
