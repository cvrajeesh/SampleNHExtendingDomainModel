using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepository;
using ExtendedCoreModel;
using FluentNHibernate.Mapping;

namespace ExtendedRepository
{
    public class ExtendedBlogMap : SubclassMap<ExtendedBlog>
    {
        public ExtendedBlogMap()
        {
            Map(x => x.Description);
            DiscriminatorValue(1);
        }
    }
}
