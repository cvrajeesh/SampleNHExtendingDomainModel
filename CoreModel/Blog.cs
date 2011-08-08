using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreModel
{
    public class Blog : DomainModel
    {
        public Blog()
        {
            this.Posts = new List<Post>();
        }

        public virtual string Name { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<Post> Posts { get; set; }

    }
}
