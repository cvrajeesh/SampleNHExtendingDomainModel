using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreModel;

namespace ExtendedCoreModel
{
    public class ExtendedPost : Post
    {
        public virtual string Slug { get; set; }
    }
}
