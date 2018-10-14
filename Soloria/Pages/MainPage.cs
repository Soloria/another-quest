namespace Soloria
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using JetBrains.Annotations;
    

    public class MainPage : AbstractPage
    {
        public MainPage(IWebDriver driver) : base(driver) { }
        
        [FindsBy(How = How.Id, Using = "car_mark")]
        private IWebElement CarMarksInput { get; [UsedImplicitly] set; }
       
        [FindsBy(How = How.CssSelector, Using = "ng-select[labelforid='car_mark']>div.ng-select-container")]
        private IWebElement CarMarksDropdown { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = "div.ng-option-marked")]
        private IWebElement Select { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "car_model")]
        private IWebElement CarModelsInput { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = "ng-select[labelforid='car_model']>div.ng-select-container")]
        private IWebElement CarModelsDropdown { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "manufacturing_date")]
        private IWebElement ManufacturingDatesInput { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = "ng-select[labelforid='manufacturing_date']>div.ng-select-container")]
        private IWebElement ManufacturingDatesDropdown { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname='ident_type_value']")]
        private IWebElement IdentType { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "number_plate")]
        private IWebElement NumberPlate { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "engine_power")]
        private IWebElement EnginePower { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "ts_series")]
        private IWebElement Series { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "ts_number")]
        private IWebElement Number { get; [UsedImplicitly] set; }

        [FindsBy(How = How.Id, Using = "issue_date")]
        private IWebElement ReceivingDate { get; [UsedImplicitly] set; }

        [FindsBy(How = How.CssSelector, Using = "li.active")]
        private IList<IWebElement> SuccessfulSteps { get; [UsedImplicitly] set; }

        public IWebElement SuccessfulStep(string text) => SuccessfulSteps?.FirstOrDefault(x => x.Text.Contains(text));
        
        [FindsBy(How = How.CssSelector, Using = "div>div>h1")]
        public IWebElement HeaderMessage { get; [UsedImplicitly] set; }

        public MainPage ChooseCarMark(string mark)
        {
            CarMarksDropdown.Click();
            CarMarksInput.SendKeys(mark);
            Select.Click();
            return this;
        }

        public MainPage ChooseCarModel(string model)
        {
            CarModelsDropdown.Click();
            CarModelsInput.SendKeys(model);
            Select.Click();
            return this;
        }

        public MainPage ChooseManufacturingDate(string date)
        {
            ManufacturingDatesDropdown.Click();
            ManufacturingDatesInput.SendKeys(date);
            Select.Click();
            return this;
        }

        public MainPage InputVIN(string VIN)
        {
            IdentType.Click();
            IdentType.SendKeys(VIN);
            return this;
        }

        public MainPage InputSeries(string series)
        {
            Series.Click();
            Series.SendKeys(series);
            return this;
        }

        public MainPage InputNumber(string number)
        {
            Number.Click();
            Number.SendKeys(number);
            return this;
        }

        public MainPage InputNumberPlate(string numberplate)
        {
            NumberPlate.Click();
            NumberPlate.SendKeys(numberplate);
            return this;
        }

        public MainPage InputEnginePower(string power)
        {
            EnginePower.Click();
            EnginePower.SendKeys(power);
            return this;
        }

        public MainPage InputReceivingDate(string date)
        {
            ReceivingDate.Click();
            ReceivingDate.SendKeys(date);
            return this;
        }

        public MainPage WaitSavingData()
        {
            while (SuccessfulStep("Документы ТС")?.Displayed == null)
            {
                Thread.Sleep(300);
            }
            return this;
        }
    }
}
