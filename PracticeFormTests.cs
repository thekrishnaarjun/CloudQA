using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CloudQAFormTests
{
    [TestFixture]
    public class PracticeFormTests
    {
        private IWebDriver _driver;
        private PracticeFormPage _formPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            _formPage = new PracticeFormPage(_driver);
        }

        [Test]
        public void TestFirstNameField()
        {
            string testName = "Test User";
            _formPage.EnterFirstName(testName);
            Assert.That(_formPage.FirstNameInput.GetAttribute("value"), Is.EqualTo(testName),
                "First name field should contain the entered value");
        }

        [Test]
        public void TestGenderSelection()
        {
            _formPage.SelectMaleGender();
            Assert.That(_formPage.MaleGenderRadio.Selected, Is.True,
                "Male gender radio should be selected");
            
            _formPage.SelectFemaleGender();
            Assert.That(_formPage.FemaleGenderRadio.Selected, Is.True,
                "Female gender radio should be selected");
        }

        [Test]
        public void TestFormSubmission()
        {
            _formPage.EnterFirstName("Test User");
            _formPage.SelectMaleGender();
            _formPage.SubmitForm();
            
            // Verify successful submission by checking URL change
            Assert.That(_driver.Url, Does.Not.Contain("AutomationPracticeForm"),
                "Form submission should navigate away from the form page");
        }

        [TearDown]
        public void Teardown()
        {
            try
            {
                if (_driver != null)
                {
                    _driver.Quit();
                }
            }
            catch (WebDriverException)
            {
                // Ignore errors during teardown
            }
        }
    }
}