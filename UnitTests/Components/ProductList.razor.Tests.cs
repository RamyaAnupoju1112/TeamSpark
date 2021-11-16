using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using Bunit;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("The Quantified Cactus: An Easy Plant Soil Moisture Sensor"));
        }

        #region SelectProduct
        [Test]
        public void SelectProduct_Valid_ID_jenlooper_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-cactus";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("This project is a good learning project to get comfortable with soldering and programming an Arduino."));
        }
        #endregion SelectProduct

        #region SubmitRating



        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            /*
            This test tests that the SubmitRating will change the vote as well as the Star checked
            Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed



            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status



            */



            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-light";



            var page = RenderComponent<ProductList>();



          
            var buttonList = page.FindAll("Button");



         
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();



         
            var buttonMarkup = page.Markup;



          
            var starButtonList = page.FindAll("span");



            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;



           
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));



            
            var preStarChange = starButton.OuterHtml;



            // Act



         
            starButton.Click();



            
            buttonMarkup = page.Markup;



         
            starButtonList = page.FindAll("span");



           
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;



           
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));



            
            var postStarChange = starButton.OuterHtml;



            // Assert



            
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }


        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            /*
            This test tests that the SubmitRating will change the vote as well as the Star checked
            Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed



            The test needs to open the page
            Then open the popup on the card
            Then record the state of the count and star check status
            Then check a star
            Then check again the state of the cound and star check status



            */



            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_jenlooper-cactus";



            var page = RenderComponent<ProductList>();

           
            var buttonList = page.FindAll("Button");



           
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();



           
            var buttonMarkup = page.Markup;



            
            var starButtonList = page.FindAll("span");



          
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;



            
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));



            
            var preStarChange = starButton.OuterHtml;

            // Act



           
            starButton.Click();



           
            buttonMarkup = page.Markup;



           
            starButtonList = page.FindAll("span");



          
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;



            
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));



            
            var postStarChange = starButton.OuterHtml;

            // Assert



            
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        #endregion SubmitRating








    }
}
