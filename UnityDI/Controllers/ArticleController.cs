using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityDI.Models;

namespace UnityDI.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(IUnitOfWorkManager unitOfWorkManager, IArticleRepository articleRepository)
            : base(unitOfWorkManager)
        {
            this._articleRepository = articleRepository;
        }

        public ActionResult Create()
        {
            var newArticle = new Article()
                {
                    Id = Guid.NewGuid(),
                    ViewCount = 0,
                    CreatedDate = DateTime.Now,
                    CreatedByUsername = "admin",
                    Tags = "mvc, unity, asp.net"
                };

            return View(newArticle);
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            // Create a article
            using (var unitOfWork = this.UnitOfWorkManager.NewUnitOfWork())
            {
                this._articleRepository.Add(article);

                unitOfWork.Commit();
            }

            return View();
        }

        public ActionResult Details(Guid id)
        {
            Article returnedArticle = new Article();
            
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                returnedArticle = _articleRepository.Get(id);
            }

            return View(returnedArticle);
        }

        public ActionResult Index()
        {

            IEnumerable<Article> articles = new List<Article>();

            // Create a article
            using (var unitOfWork = this.UnitOfWorkManager.NewUnitOfWork())
            {
                articles = this._articleRepository.GetAll();

            }
            return View(articles);

        }
    }
}