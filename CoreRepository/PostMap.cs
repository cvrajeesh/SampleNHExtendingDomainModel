using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreModel;

namespace CoreRepository
{
    public class PostMap : DomainModelMap<Post>
    {
        public PostMap()
        {
            Map(x => x.Title);
            Map(x => x.Content);
            References(x => x.Blog);
            DiscriminateSubClassesOnColumn("Type", 0);
        }
    }
}
