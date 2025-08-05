//using System;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using Xunit;

//namespace TheToDoListApp.UnitTest
//{
//    public class BrowserSmokeTests : IAsyncLifetime, IDisposable
//    {
//        private IWebDriver _driver;

//        public async Task InitializeAsync()
//        {
//            await Task.Run(() =>
//            {
//                var options = new ChromeOptions();
//                options.AddArgument("--headless=new");
//                _driver = new ChromeDriver(options);
//            });
//        }

//        [Fact]
//        public async Task Can_Create_TodoItem_From_UnCompletedToDoList()
//        {
//            await Task.Run(() =>
//            {
//                // Go to the UnCompletedToDoList page
//                _driver.Navigate().GoToUrl("https://localhost:7297/ToDoList/UnCompletedToDoList");

//                // Click the "Create" button to open the offcanvas form
//                _driver.FindElement(By.CssSelector("a.btn.btn-success[data-bs-toggle='offcanvas']")).Click();

//                // Wait for the offcanvas to be visible
//                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
//                wait.Until(d => d.FindElement(By.Name("description")).Displayed);

//                // Fill in the form fields
//                _driver.FindElement(By.Name("description")).SendKeys("SmokeTest Uncompleted");
//                var prioritySelect = _driver.FindElement(By.Name("priorityForm"));
//                var selectElement = new SelectElement(prioritySelect);
//                selectElement.SelectByText("Normal");

//                // Submit the form
//                _driver.FindElement(By.CssSelector("button.btn.btn-success[type='submit']")).Click();

//                // Optionally, verify the new item appears in the list
//                var pageSource = _driver.PageSource;
//                Assert.Contains("SmokeTest Uncompleted", pageSource);
//            });
//        }

//        public Task DisposeAsync()
//        {
//            Dispose();
//            return Task.CompletedTask;
//        }

//        public void Dispose()
//        {
//            _driver?.Quit();
//            _driver?.Dispose();
//        }
//    }
//}