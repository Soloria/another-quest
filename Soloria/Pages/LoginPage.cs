namespace Soloria
{
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using JetBrains.Annotations;

    public class LoginPage : AbstractPage 
    {
        public LoginPage(IWebDriver driver): base(driver) { }

        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement LoginField { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PasswordField { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = ".ui.positive.right.button")]
        private IWebElement SubmitButton { get; [UsedImplicitly] set; }

        public LoginPage InputLogin(string login)
        {
            LoginField.Click();
            LoginField.SendKeys(login);
            return this;
        }

        public LoginPage InputPassword(string password)
        {
            PasswordField.Click();
            PasswordField.SendKeys(password);
            return this;
        }

        public MainPage ClickSubmitButton()
        {
            SubmitButton.Click();
            return new MainPage(SessionManager.getDriver());
            
        }
    }
}
