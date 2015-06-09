using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

//http://www.codeproject.com/Articles/786332/ASP-NET-MVC-with-Unity-Dependency-Injection

namespace UnityDI.Models
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            this.HasKey(x => x.Id);
            this.ToTable("Articles"); // map to Articles table in database
        }
    }
}