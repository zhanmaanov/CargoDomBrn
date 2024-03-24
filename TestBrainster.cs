using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using System.IO;

namespace Brain
{
    public class ZadacaRandom
    {
        [TestFixture]
        public class Domasna
        {
            public IWebDriver Driver = new ChromeDriver();
            public WebDriverWait wait;
            public static Random random = new Random();

            [OneTimeSetUp]
            public void OneTimeSetUp()
            {

            }

            [SetUp]
            public void SetUp()
            {
                Driver = new ChromeDriver();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                Driver.Manage().Window.Maximize();
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

                Driver.Navigate().GoToUrl("http://18.156.17.83:9095/");
            }

            [Test]
            public void homeworkRandom()
            {
                //Log in as a user and create a request of your choosing. 

                IWebElement logIn = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.login']"));
                logIn.Click();

                IWebElement enterEmail = Driver.FindElement(By.Id("username"));
                enterEmail.Click();
                enterEmail.Clear();
                enterEmail.SendKeys("zhan.manov0@gmail.com");

                IWebElement enterPass = Driver.FindElement(By.Id("password"));
                enterPass.Click();
                enterPass.Clear();
                enterPass.SendKeys("12345678");

                IWebElement clickSignInButton = Driver.FindElement(By.CssSelector("button[type='submit']"));
                clickSignInButton.Click();

                // Creating Request
                IWebElement createRequest = Driver.FindElement(By.CssSelector("span[translate='provider.createRequest']"));
                createRequest.Click();

                IWebElement titleClick = Driver.FindElement(By.CssSelector("input[ng-model='vm.request.title']"));
                titleClick.Click();

                IWebElement titleText = Driver.FindElement(By.CssSelector("input[ng-model='vm.request.title']"));
                titleText.SendKeys(RandomGenerateLetters(8));

                IWebElement dropDownTransportCategory = Driver.FindElement(By.Id("field_y"));
                SelectElement selectElementTransportC = new SelectElement(dropDownTransportCategory);
                selectElementTransportC.SelectByValue("MOTORBIKE");

                List<IWebElement> adressfields = Driver.FindElements(By.CssSelector("input[ng-value='vm.address.formattedAddress']")).ToList();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[ng-value='vm.address.formattedAddress']")));

                adressfields.First().SendKeys("Skopje City Mall, Ljubljanska, Skopje, North Macedonia");
                List<IWebElement> autoPickUpAdress = Driver.FindElements(By.CssSelector("span[class='pac-matched']")).ToList();
                autoPickUpAdress[0].Click();

                adressfields.Last().SendKeys("Milano, Metropolitan City of Milan, Italy");
                List<IWebElement> autoPickUpAdressLast = Driver.FindElements(By.CssSelector("span[class='pac-matched']")).ToList();
                autoPickUpAdressLast[0].Click();

                IWebElement blueRButton = Driver.FindElement(By.CssSelector("a[title='Remove Item']"));
                blueRButton.Click();

                IWebElement cashOnPickUP = Driver.FindElement(By.Id("cachePickup"));
                cashOnPickUP.Click();

                IWebElement cashOnDelivery = Driver.FindElement(By.Id("cacheDelivery"));
                cashOnDelivery.Click();

                IWebElement cashInAdvance = Driver.FindElement(By.Id("advance"));
                cashInAdvance.Click();

                IWebElement submitRequest = Driver.FindElement(By.CssSelector("input[type='submit']"));
                submitRequest.Click();


                //After creating the request, you must confirm that the request is present in ‘My Requests.’ 
                string expectedUrl = "http://18.156.17.83:9095/client/my-requests/active";
                string result = Driver.FindElement(By.CssSelector("a[href='/client/my-requests/active']")).GetAttribute("href");

                Assert.That(expectedUrl, Is.EqualTo(result));

                // 2. Log out 

                IWebElement logOut = Driver.FindElement(By.Id("logout2"));
                logOut.Click();

                //Log in as a transporter, and find the request you created. 
                IWebElement logInAsTransporter = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.login']"));
                logInAsTransporter.Click();

                IWebElement enterEmailTransporter = Driver.FindElement(By.Id("username"));
                enterEmailTransporter.Click();
                enterEmailTransporter.Clear();
                enterEmailTransporter.SendKeys("zhan.manov1@gmail.com");

                IWebElement enterPassTransporter = Driver.FindElement(By.Id("password"));
                enterPassTransporter.Click();
                enterPassTransporter.Clear();
                enterPassTransporter.SendKeys("12345678");

                IWebElement clickSignInButtonTransporter = Driver.FindElement(By.CssSelector("button[type='submit']"));
                clickSignInButtonTransporter.Click();

                // LISTATA MI E NOVA  (LJ)
                List<IWebElement> offerList = Driver.FindElements(By.CssSelector("a[ui-sref='provider-request-details({id: request.id})']")).ToList();
                var firstOffer = offerList[0];
                firstOffer.Click();

                // Make an offer for it.
                IWebElement creatingOffer = Driver.FindElement(By.CssSelector("button[class='details-panel__make-offer-btn']"));
                creatingOffer.Click();

                IWebElement offerPayInAdvance = Driver.FindElement(By.CssSelector("input[ng-model='paymentType.price']"));
                offerPayInAdvance.Click();
                offerPayInAdvance.SendKeys("1");

                IWebElement PickingDatum = Driver.FindElement(By.CssSelector("input[ng-model='vm.pickUpTime']"));
                PickingDatum.Click();
                IList<IWebElement> PickupdatumChoosing = Driver.FindElements(By.CssSelector("table[class='uib-daypicker']"));
                foreach (IWebElement day in PickupdatumChoosing)
                {
                    if (day.GetAttribute("id").Equals("datepicker-2036-7109-17")) ;
                    {
                        day.Click();
                    }

                }
                IWebElement hourChoosing = Driver.FindElement(By.CssSelector("span[class='glyphicon glyphicon-chevron-down']"));
                hourChoosing.Click();

                IWebElement minutsChoosing = Driver.FindElement(By.CssSelector("a[ng-click='incrementMinutes()']"));
                minutsChoosing.Click();

                IWebElement sideClick = Driver.FindElement(By.CssSelector("textarea[maxlength='400']"));
                sideClick.Click();

                IWebElement deliveryTime = Driver.FindElement(By.CssSelector("input[ng-click='vm.openDeliveryTimePicker()'"));
                deliveryTime.Click();
                deliveryTime.SendKeys("28.11.2022 00:00");

                IWebElement sideClick1 = Driver.FindElement(By.CssSelector("textarea[maxlength='400']"));
                sideClick1.Click();

                IWebElement validUntil = Driver.FindElement(By.CssSelector("input[name='expirationDateInput']"));
                validUntil.Click();
                validUntil.SendKeys("28.11.2022 14:00");

                IWebElement sideClick2 = Driver.FindElement(By.CssSelector("textarea[maxlength='400']"));
                sideClick2.Click();

                IWebElement insurance = Driver.FindElement(By.CssSelector("select[name='insuranceAmount']"));
                SelectElement insurancePrice = new SelectElement(insurance);
                insurancePrice.SelectByIndex(1);

                IWebElement messageToTheClient = Driver.FindElement(By.CssSelector("textarea[maxlength='400']"));
                messageToTheClient.Click();
                messageToTheClient.SendKeys(RandomGenerateLetters(20));

                IWebElement SUBMIT = Driver.FindElement(By.CssSelector("button[type='submit']"));
                SUBMIT.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[type='submit']")));

                IWebElement createButton2 = Driver.FindElement(By.ClassName("modal-footer__btn-save"));
                createButton2.Click();

                //Driver.Navigate().GoToUrl("http://18.156.17.83:9095/provider/home");




                //IWebElement cargodomButton = Driver.FindElement(By.CssSelector("a[class='navbar-brand logo']"));

                IWebElement transakcii = Driver.FindElement(By.CssSelector("a[ui-sref='provider-transactions']"));


                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript("arguments[0].scrollInToView(true);", transakcii);

                ////transakcii.Click();





                IWebElement myOffers = Driver.FindElement(By.CssSelector("a[ui-sref='provider-my-active-offers']"));
                myOffers.Click();





                // After making the offer, you must confirm that the offer was sent, which you can check via the ‘My offers’ page. 
                string checkOffer = Driver.FindElement(By.CssSelector("span[translate='provider.myOffers']")).Text;
                Assert.That(checkOffer, Is.EqualTo("МОИТЕ ПОНУДИ"));

                //Log out
                IWebElement logOut1 = Driver.FindElement(By.Id("logout2"));
                logOut1.Click();

                //Log in as a user and accept the offer. 
                IWebElement logIn1 = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.login']"));
                logIn1.Click();
                IWebElement enterEmailUser = Driver.FindElement(By.Id("username"));
                enterEmailUser.Click();
                enterEmailUser.Clear();
                enterEmailUser.SendKeys("zhan.manov0@gmail.com");

                IWebElement enterPassUser = Driver.FindElement(By.Id("password"));
                enterPassUser.Click();
                enterPassUser.Clear();
                enterPassUser.SendKeys("12345678");

                IWebElement clickSignInButtonUser = Driver.FindElement(By.CssSelector("button[type='submit']"));
                clickSignInButtonUser.Click();

                IWebElement myRequestAccOffer = Driver.FindElement(By.CssSelector("span[translate='provider.myRequests']"));
                myRequestAccOffer.Click();

                List<IWebElement> myReequests = Driver.FindElements(By.CssSelector("a[ui-sref='client-request-details({id: request.id})']")).ToList();
                var firstRequest1 = myReequests[0];
                firstRequest1.Click();

                IWebElement moreButtonAccOffer = Driver.FindElement(By.CssSelector("a[class='flex-table__expander-btn']"));
                moreButtonAccOffer.Click();
                IWebElement offerAccCickButton = Driver.FindElement(By.Id("offer0"));
                offerAccCickButton.Click();

                IWebElement acceptButton = Driver.FindElement(By.CssSelector("input[ng-disabled='!offersSet.acceptedOffer']"));
                acceptButton.Click();


                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a[href='/client/accepted-offers']")));
                //IWebElement myAcceptedOffers = Driver.FindElement(By.CssSelector("a[href='/client/accepted-offers']"));
                //myAcceptedOffers.Click();


                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("a[ui-sref='client-accepted-offers-list']")));
                IWebElement myAcceptedOffers1 = Driver.FindElement(By.CssSelector("a[ui-sref='client-accepted-offers-list']"));
                myAcceptedOffers1.Click();

                //Confirm that the offer was accepted and the request is closed.
                string actualResult1 = Driver.FindElement(By.CssSelector("h2[translate='provider.finishedRequests']")).Text;
                Assert.That(actualResult1, Is.EqualTo("Прифатени понуди за транспорт"));

                IWebElement requestClosedCHECK = Driver.FindElement(By.CssSelector("span[translate='provider.myRequests']"));
                myRequestAccOffer.Click();

                string acttualClosedCheck = Driver.FindElement(By.CssSelector("div[translate='request.noRequests']")).Text;
                Assert.That(acttualClosedCheck, Is.EqualTo("Извинете! Во оваа листа нема барања."));

                // Log out/Confirm that you are logged out. 
                IWebElement lastLogOut = Driver.FindElement(By.Id("logout2"));
                lastLogOut.Click();

                string lastLogoutCheck = Driver.FindElement(By.CssSelector("h1[translate='home.title']")).Text;
                Assert.That(lastLogoutCheck, Is.EqualTo("Паметен начин да пронајдеш транспортер"));


            }

            [TearDown]
            public void TearDown()
            {
                //Driver.Close();
                //Driver.Dispose();
            }

            public static string RandomGenerateLetters(int lenght)
            {
                const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsqtuvwxyz";
                return new string(Enumerable.Repeat(letters, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }

    }
}
