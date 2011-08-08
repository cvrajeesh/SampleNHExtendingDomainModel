using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreModel;

namespace CoreRepository
{
    public class BlogMap : DomainModelMap<Blog>
    {
        public BlogMap()
        {
            Map(x => x.Name);
            Map(x => x.Title);
            HasMany(x => x.Posts)
                .Inverse()                
                .Cascade.All();
            DiscriminateSubClassesOnColumn("Type", 0);
        }
    }
}
