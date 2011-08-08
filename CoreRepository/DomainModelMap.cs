using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using CoreModel;

namespace CoreRepository
{
    public abstract class DomainModelMap<T> : ClassMap<T> where T : DomainModel
    {
        public DomainModelMap()
        {
            Id(x => x.Id).Column("Id");    
        }
    }
}
