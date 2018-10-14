namespace Soloria
{
    using NUnit.Framework;

    public static class ConfigEx
    {
        public static T C<T>(this string s) => Config.GetValue<T>(s);
    }

    public class Tests
    {
        [OneTimeSetUp]
        public static void Start() => SessionManager.Open(SessionManager.Path);

        [Test]
        [Order(order: 0)]
        public void LogIn()
        {
            new LoginPage(SessionManager.getDriver())
                .InputLogin("login:username".C<string>())
                .InputPassword("login:password".C<string>())
                .ClickSubmitButton();
      
            Assert.AreEqual(new MainPage(SessionManager.getDriver()).HeaderMessage.Text, "Договор Е-ОСАГО");
        }

        [Test]
        [Order(order: 1)]
        public void CheckForTechnicalInspection()
        {
            new MainPage(SessionManager.getDriver())
                .InputVIN("data:vin".C<string>());

            Assert.IsTrue(new MainPage(SessionManager.getDriver()).SuccessfulStep("ТО - проверено").Displayed);
        }

        [Test]
        [Order(order: 2)]
        public void SavingVehicleData()
        {
            new MainPage(SessionManager.getDriver())
                .ChooseCarMark("data:mark".C<string>())
                .ChooseCarModel("data:model".C<string>())
                .ChooseManufacturingDate("data:manufacturing_date".C<string>())
                .InputNumberPlate("data:number_plate".C<string>())
                .InputSeries("data:series".C<string>())
                .InputNumber("data:number".C<string>())
                .InputEnginePower("data:engine_power".C<string>())
                .InputReceivingDate("data:receiving_date".C<string>())
                .WaitSavingData();

           Assert.IsTrue(new MainPage(SessionManager.getDriver()).SuccessfulStep("Документы ТС")?.Displayed);
        }

        [OneTimeTearDown]
        public static void Clean() => SessionManager.Close();
    }
}
