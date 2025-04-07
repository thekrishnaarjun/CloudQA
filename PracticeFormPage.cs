using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CloudQAFormTests
{
    public class PracticeFormPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public PracticeFormPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // First Name field with multiple locator strategies
        public IWebElement FirstNameInput => 
            FindElementWithFallback(
                By.XPath("//input[contains(@placeholder, 'First Name')]"),
                By.XPath("//input[@name='fname']"),
                By.CssSelector("input[placeholder*='First Name']"));

        // Gender radio buttons with resilient locators
        public IWebElement MaleGenderRadio => 
            FindElementWithFallback(
                By.XPath("//input[@type='radio' and following-sibling::label[contains(., 'Male')]]"),
                By.CssSelector("input[type='radio'][value='Male']"));

        public IWebElement FemaleGenderRadio => 
            FindElementWithFallback(
                By.XPath("//input[@type='radio' and following-sibling::label[contains(., 'Female')]]"),
                By.CssSelector("input[type='radio'][value='Female']"));

        // Submit button with resilient locators
        public IWebElement SubmitButton => 
            FindElementWithFallback(
                By.XPath("//button[contains(., 'Submit')]"),
                By.CssSelector("button[type='submit']"));

        private IWebElement FindElementWithFallback(params By[] locators)
        {
            foreach (var locator in locators)
            {
                try
                {
                    return _wait.Until(ExpectedConditions.ElementExists(locator));
                }
                catch (NoSuchElementException) { }
                catch (WebDriverTimeoutException) { }
            }
            throw new NoSuchElementException($"None of the locators found the element: {string.Join(", ", locators.Select(l => l.ToString()))}");
        }

        public void EnterFirstName(string name) => FirstNameInput.SendKeys(name);
        public void SelectMaleGender() => MaleGenderRadio.Click();
        public void SelectFemaleGender() => FemaleGenderRadio.Click();
        public void SubmitForm() => SubmitButton.Click();
    }
}