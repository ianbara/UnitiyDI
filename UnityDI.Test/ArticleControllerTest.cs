using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityDI.Controllers;
using UnityDI.Models;
using Moq;


namespace UnityDI.Test
{
    [TestClass]
    public class ArticleControllerTest
    {

        private Mock<IUnitOfWorkManager> _mockUnitOfWorkManager;
        private Mock<IArticleRepository> _mockArticleRepository;
        private ArticleController articleController;
        private IEnumerable<UnityDI.Models.Article> articleList;

        [TestInitialize]
        public void Initialize()
        {
            _mockUnitOfWorkManager = new Mock<IUnitOfWorkManager>();
            _mockArticleRepository = new Mock<IArticleRepository>();
            articleController = new ArticleController(_mockUnitOfWorkManager.Object, _mockArticleRepository.Object);
            articleList = new List<Article>()
            {
                new Article()
                {
                    Id = new Guid(),
                    ArticleContent = "Test Article 1",
                    Title = "Title 1",
                    CreatedDate = DateTime.Now,
                    Summary = "Summary Text 1",
                    CreatedByUsername = "ianbara",
                    Tags = "TDD, MVC, Unity",
                    ViewCount = 1
                },
                new Article()
                {
                    Id = new Guid(),
                    ArticleContent = "Test Article 2",
                    Title = "Title 2",
                    CreatedDate = DateTime.Now,
                    Summary = "Summary Text 2",
                    CreatedByUsername = "ianbara",
                    Tags = "TDD, MVC, Unity",
                    ViewCount = 1
                }
            };

        }

        [TestMethod]
        public void IndexGetsAllArticles()
        {
            //Arrange 
            _mockArticleRepository.Setup(x => x.GetAll()).Returns(articleList);

            //Act
            var result = ((articleController.Index() as ViewResult).Model as List<Article>);

            //Assert
            Assert.AreEqual(result.Count, 2);
        }

       
    }
}
