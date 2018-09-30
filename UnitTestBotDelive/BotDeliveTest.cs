using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Botdelive;
namespace UnitTestBotDelive
{
    [TestClass]
    class BotDeliveTest
    {
        public Botdelive.Botdelive bd { get; set; }

        public BotDeliveTest()
        {
            string AppId = "B1QMo76F7";
            string SecretKey = "oPsNmyIvO6QgDYlgSyOjrCLO3OU-Wa4YNgfZ4UFf";
            bd = new Botdelive.Botdelive(AppId, SecretKey);
        }

        [TestMethod]
        public void TestVerifyUser()
        {
            string accessCode = "SJI8oXaFm";

            try
            {
                bd.Verify(accessCode);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestAuthUser()
        {
            string userId = "xPdDzngBRwm8CGkSj4I9Abi-2gYNXz6uO0jOYq43";

            try
            {
                bd.Auth(userId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestPushNotification()
        {
            string userId = "xPdDzngBRwm8CGkSj4I9Abi-2gYNXz6uO0jOYq43";

            try
            {
                bd.Push(userId,"Test message from unit test");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
