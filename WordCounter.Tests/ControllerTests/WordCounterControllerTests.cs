using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WordCounter.Controllers;
using WordCounter.Models;

namespace WordCounter.Tests
{
    [TestClass]
    public class CountersControllerTest
    {

        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            WordCountersController controller = new WordCountersController();
            ActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_RedirectsToCorrectAction_Index()
        {
            WordCountersController controller = new WordCountersController();
            RedirectToActionResult actionResult = controller.Create("dog", "walk the dog") as RedirectToActionResult;
            string result = actionResult.ActionName;
            Assert.AreEqual(result, "Index");
        }
    }
}