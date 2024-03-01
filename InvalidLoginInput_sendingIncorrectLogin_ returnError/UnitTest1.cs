using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InvalidLoginInput_sendingIncorrectLogin__returnError
{
    public class Tests
    {
        private IWebDriver driver;
        //можно найти элемент подобным образом.
        private readonly By signInButton = By.XPath("//button[text()= 'Login']");
        private string erorText = "Invalid username or password!";
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/books";
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void ClinUp()
        {
        driver.Quit();
        }

        [Test]
        public void Test1()
        {
            var sigIn = driver.FindElement(signInButton);
            sigIn.Click();

            IWebElement login = driver.FindElement(By.Id("userName"));
            login.SendKeys("login");
            
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("PassworD");
           // password.SendKeys(Keys.Enter)-эмитация нажатия enter

            IWebElement loginButton = driver.FindElement(By.Id("login"));
            loginButton.Click();

            Thread.Sleep(5000);
            IWebElement eror = driver.FindElement(By.Id("name"));

            Assert.That(eror.Text == erorText);

        }
    }
}