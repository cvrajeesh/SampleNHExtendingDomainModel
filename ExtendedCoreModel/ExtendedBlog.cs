using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreModel;

namespace ExtendedCoreModel
{
    public class ExtendedBlog : Blog
    {
        public  virtual string Description { get; set; }
    }
}
