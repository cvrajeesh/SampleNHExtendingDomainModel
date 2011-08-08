using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtendedCoreModel;
using FluentNHibernate.Mapping;

namespace ExtendedRepository
{
    public class ExtendedPostMap : SubclassMap<ExtendedPost>
    {
        public ExtendedPostMap()
        {
            Map(x => x.Slug);
            DiscriminatorValue(1);
        }
    }
}
