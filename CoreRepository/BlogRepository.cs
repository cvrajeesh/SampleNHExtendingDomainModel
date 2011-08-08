using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreModel;
using NHibernate;
using NHibernate.Transform;

namespace CoreRepository
{
    public class BlogRepository
    {
        private ISession session;

        public BlogRepository(ISession session)
        {
            this.session = session;
        }

        public void SaveOrUpdate(Blog blog)
        {
            using (var transaction = session.BeginTransaction())
            {             
                session.SaveOrUpdate(blog);
                transaction.Commit();
            }
        }

        public IList<Blog> LoadAll()
        {
            using (session.BeginTransaction())
            {
                var blogs = session.CreateCriteria<Blog>()
                    .SetFetchMode("Posts", FetchMode.Eager)
                    .SetResultTransformer(Transformers.DistinctRootEntity)
                    .List<Blog>();
                return blogs;
            }
        }

    }
}
