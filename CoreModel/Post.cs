using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreModel
{
    public class Post : DomainModel
    {
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
