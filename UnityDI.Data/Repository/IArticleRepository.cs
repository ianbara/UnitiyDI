using System;
using System.Collections.Generic;

namespace UnityDI.Models
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article Add(Article item);
        void Update(Article item);
        void Delete(Article item);
        Article Get(Guid id);
    }
}