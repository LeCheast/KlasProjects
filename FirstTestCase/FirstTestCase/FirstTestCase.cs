using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace FirstTestCase
{
    class FirstTestCase
    {
        static void Main(string[] args)
        {
            while(true)
            {
                int input = 0;
                Console.WriteLine("What test would you like to run?");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Create new Provider");
                Console.WriteLine("2 - Create new Provider Contact");
                Console.WriteLine("3 - Forcast Report Sale");
                Console.WriteLine("4 - Decision Insight Processing");
                Console.Write("Input: ");
                input = Convert.ToInt16(Console.ReadLine());
                //Thread.Sleep(5000);
                //input = 3;
                if (input == 0)//exit
                    break;
                else if (input == 1)//new provider
                    newProvider();
                else if (input == 2)//new contact
                    newContact();
                else if (input == 3)//forcast report sale
                    forcastReportSale();
                else if (input == 4)//Decision Insight
                    decisionInsightProcessing();
            }
        }
        static void login(IWebDriver driver)
        {
            string loginUserID = "travis.kingery";
            string loginPassword = "t321kingery";
            string locationLogin = "superdave";
            driver.Url = "http://dev-toolbox/";
            driver.Manage().Window.Maximize();
            //if web page asks for logins 
            if (driver.Url == "http://dev-toolbox/Login.aspx?ReturnUrl=%2f")
            {
                Thread.Sleep(1000);
                try
                {
                    driver.FindElement(By.Id("TextBoxIpChallenge")).SendKeys(locationLogin);
                    Thread.Sleep(1000);
                    driver.FindElement(By.Id("ButtonLogin")).Click();
                }
                catch { }
                Thread.Sleep(1000);
                driver.FindElement(By.Id("username")).SendKeys(loginUserID);
                driver.FindElement(By.Id("password")).SendKeys(loginPassword);
                driver.FindElement(By.Name("ButtonLogin")).Click();
            }
        }
        static void newProvider()
        {
            string test = "test";
            IWebDriver driver = new ChromeDriver();
            login(driver);
            driver.FindElement(By.Id("void_4")).Click();//click Project Managment drop down.
            Thread.Sleep(300);//click Database Management
            driver.FindElement(By.LinkText("Database Managment")).Click();
            Thread.Sleep(300);//Click All Organizations
            driver.FindElement(By.LinkText("Provider Manager")).Click();
            Thread.Sleep(300);//Click second add provider
            driver.FindElement(By.LinkText("Add Provider")).Click();
            driver.FindElement(By.Id("OrgName")).SendKeys(test);//add org name
            driver.FindElement(By.XPath("//*[@id='OrgTypeSelect']/option[4]")).Click();//Org type
            Thread.Sleep(2000);//type of org
            driver.FindElement(By.XPath("//*[@id='OrgSubTypeSelect']/option[5]")).Click();
            Thread.Sleep(1000);//add specialties
            driver.FindElement(By.XPath("//*[@id='AttributeListContainer']/span/div/button")).Click();
            driver.FindElement(By.XPath("//*[@id='AttributeListContainer']/span/div/ul/li[1]/a")).Click();
            driver.FindElement(By.Id("addressID1_Address_City")).SendKeys(test);//add city
            driver.FindElement(By.XPath("//*[@id='addressID1_addressCountry']/option[2]")).Click();//select country
            Thread.Sleep(3000);//select state
            driver.FindElement(By.XPath("//*[@id='addressID1_addressStateProvince']/option[6]")).Click();
            driver.FindElement(By.Id("addUpdateButton")).Click();//save new provider
            Thread.Sleep(1000);
            Console.WriteLine(Environment.NewLine + "New Provider Test Successful" + Environment.NewLine);
            driver.Close();
        }
        static void newContact()
        {
            string test = "test";
            IWebDriver driver = new ChromeDriver();
            login(driver);
            driver.FindElement(By.Id("void_4")).Click();//click Project Managment drop down.
            Thread.Sleep(300);//click Database Management
            driver.FindElement(By.LinkText("Database Managment")).Click();
            Thread.Sleep(300);//click provider manager
            driver.FindElement(By.LinkText("Contact Manager")).Click();
            Thread.Sleep(300);//click add provider contact
            driver.FindElement(By.LinkText("Add Provider Contact")).Click();
            driver.FindElement(By.Id("ChooseOrg")).Click();//click Choose Organization
            Thread.Sleep(5000);//select an org
            driver.FindElement(By.XPath("//*[@id='vendors']/tbody/tr[1]/td[1]/a")).Click();
            driver.FindElement(By.Id("FirstName")).SendKeys(test);//Add First Name
            driver.FindElement(By.Id("LastName")).SendKeys(test);//add last name
            driver.FindElement(By.Id("Title")).SendKeys(test);//Add Title
            driver.FindElement(By.XPath("//*[@id='JobLevel']/option[3]")).Click();//select job level
            driver.FindElement(By.XPath("//*[@id='JobArea']/option[2]")).Click();//select job area
            driver.FindElement(By.Id("CreateContact")).Click();//create contact
            Thread.Sleep(1000);
            Console.WriteLine(Environment.NewLine + "New Contact Test Successful" + Environment.NewLine);
            driver.Close();
        }
        static void forcastReportSale()
        {
            string amount = "07734";
            IWebDriver driver = new ChromeDriver();
            login(driver);
            driver.FindElement(By.LinkText("Sales Management")).Click();//select sales managment
            driver.FindElement(By.LinkText("Sales Mgmt Tool")).Click();//select sales mgmt tool
            Thread.Sleep(5000);//Impersonate someone
            driver.FindElement(By.XPath("//*[@id='notImpersonating']/span/span/span/span")).Click();
            driver.FindElement(By.XPath("//*[@id='impersonate_listbox']/li[2]")).Click();
            Thread.Sleep(5000);//select report
            driver.FindElement(By.XPath("//*[@id='orderItemTypeId']/option[3]")).Click();
            driver.FindElement(By.XPath("//*[@id='orderItemId3']/option[3]")).Click();
            driver.FindElement(By.Id("forecastAmount")).SendKeys(amount);//enter dollar amount
            driver.FindElement(By.Id("NewSave")).Click();//select add
            Thread.Sleep(5000);  //delete new forcast 
            driver.FindElement(By.XPath("//*[@class='fa fa-trash fa-2x']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[10]/div[2]/p[2]/button[2]")).Click();
            Thread.Sleep(5000);
            Console.WriteLine(Environment.NewLine + "Forcast Report Sale Test Successful" + Environment.NewLine);
            driver.Close();
        }
        static void decisionInsightProcessing()
        {
            IWebDriver driver = new ChromeDriver();
            login(driver);
            driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=2";
            string name = driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr[1]/td[1]/a")).Text;
            driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr[1]/td[5]/div[2]/div/div/input[3]")).Click();
            driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=3";
            driver.FindElement(By.XPath("//*[@id='ReviewTable_filter']/label/input")).SendKeys(name);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr/td[5]/div[2]/div/div/input[4]")).Click();
            driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=4";
            driver.FindElement(By.XPath("//*[@id='ReviewTable_filter']/label/input")).SendKeys(name);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr/td[5]/div[2]/div/div/input[3]")).Click();
            Thread.Sleep(500);
            Console.WriteLine(Environment.NewLine + "Decision Insight Processing Test Successful" + Environment.NewLine);
        }
    }
}
