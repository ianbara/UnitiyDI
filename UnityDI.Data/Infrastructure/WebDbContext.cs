using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnityDI.Models
{
    public interface IWebDbContext : IDisposable
    {

    }

    public class WebDbContext : DbContext, IWebDbContext
    {
        public DbSet<Article> Articles { get; set; }

        public WebDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.Configurations.Add(new ArticleMapping());

            base.OnModelCreating(modelBuilder);

        }

        public new void Dispose()
        {

        }
    }
}