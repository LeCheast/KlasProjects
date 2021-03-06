﻿using System;
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
        public static List<string> _Success = new List<string>();
        public static List<string> _Failed = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {

                int input = 0;
                Console.WriteLine("What test would you like to run?");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Run All Test");
                Console.WriteLine("2 - Create new Provider");
                Console.WriteLine("3 - Create new Provider Contact");
                Console.WriteLine("4 - Decision Insight Processing");
                Console.WriteLine("5 - Forcast Report Sale");
                Console.WriteLine("6 - Submit For Executive Review");
                Console.Write("Input: ");
                input = Convert.ToInt16(Console.ReadLine());
                //Thread.Sleep(5000);
                //input = 3;

                if (input == 0)//exit
                    break;
                else if (input == 1)//run all tests
                {
                    Thread newProviderThread = new Thread(newProvider);
                    newProviderThread.Start();
                    Thread newContactThread = new Thread(newContact);
                    newContactThread.Start();
                    Thread decisionInsightProcessingThread = new Thread(decisionInsightProcessing);
                    decisionInsightProcessingThread.Start();
                    Thread forcastReportSaleThread = new Thread(forcastReportSale);
                    forcastReportSaleThread.Start();
                    Thread submitExecutiveReviewThread = new Thread(submitExecutiveReview);
                    submitExecutiveReviewThread.Start();
                    //Join all threads back together
                    newProviderThread.Join();
                    newContactThread.Join();
                    decisionInsightProcessingThread.Join();
                    forcastReportSaleThread.Join();
                    submitExecutiveReviewThread.Join();
                }
                else if (input == 2)//new provider
                    newProvider();
                else if (input == 3)//new contact
                    newContact();
                else if (input == 3)//forcast report sale
                    forcastReportSale();
                else if (input == 4)//Decision Insight
                    decisionInsightProcessing();
                else if (input == 4)//Decision Insight
                    decisionInsightProcessing();
                else if (input == 5)//forcast report sale
                    forcastReportSale();
                else if (input == 6)
                    submitExecutiveReview();

                if(_Success.Count > 0)
                {
                    Console.WriteLine(Environment.NewLine + "Successful Tests" + Environment.NewLine + "-----------------");
                    foreach (var test in _Success)
                    {
                        Console.WriteLine(test);
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                if(_Failed.Count > 0)
                {
                    Console.WriteLine("Failed Tests" + Environment.NewLine + "-----------------");
                    foreach (var test in _Failed)
                    {
                        Console.WriteLine(test);
                    }
                    Console.WriteLine(Environment.NewLine);
                }
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
            try
            {
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
                Thread.Sleep(5000);//type of org
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
                _Success.Add("New Provider");
                driver.Close();
            }
            catch
            {
                driver.Close();
                _Failed.Add("New Provider");
            }

        }
        static void newContact()
        {
            string test = "test";
            IWebDriver driver = new ChromeDriver();
            try
            {
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
                _Success.Add("New Contact");
                driver.Close();
            }
            catch
            {
                _Failed.Add("New Contact");
                driver.Close();
            }


        }
        static void forcastReportSale()
        {
            string amount = "07734";
            IWebDriver driver = new ChromeDriver();
            try
            {
                login(driver);
                driver.FindElement(By.LinkText("Sales Management")).Click();//select sales managment
                Thread.Sleep(2000);
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
                _Success.Add("Forcast Sales Report");
                driver.Close();
            }
            catch
            {
                _Failed.Add("Forcast Sales Report");
                driver.Close();
            }

        }
        static void decisionInsightProcessing()
        {
            IWebDriver driver = new ChromeDriver();
            login(driver);
            try
            {
                driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=2";
                Thread.Sleep(1000);
                string name = driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr[1]/td[1]/a")).Text;
                bool colBool = false;
                int submitIndex = 2;
                Thread.Sleep(3000);
                do
                {
                    try
                    {
                        driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr[1]/td[5]/div[" + submitIndex + "]/div/div/input[4]")).Click();
                        colBool = true;
                    }
                    catch
                    {
                        ++submitIndex;
                    }
                } while (colBool == false);
                Thread.Sleep(2000);
                driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=3";
                driver.FindElement(By.XPath("//*[@id='ReviewTable_filter']/label/input")).SendKeys(name);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr/td[5]/div[" + submitIndex + "]/div/div/input[5]")).Click();
                Thread.Sleep(1000);
                driver.Url = "http://dev-toolbox/dataentry/winLoss/Review?ReviewStep=4";
                driver.FindElement(By.XPath("//*[@id='ReviewTable_filter']/label/input")).SendKeys(name);
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//*[@id='ReviewTable']/tbody/tr/td[5]/div[" + submitIndex + "]/div/div/input[4]")).Click();
                Thread.Sleep(500);
                _Success.Add("Decision Insight Processing");
                driver.Close();
            }
            catch
            {
                _Failed.Add("Decision Insight Processing");
                driver.Close();
            }

        }
        static void submitExecutiveReview()
        {
            IWebDriver driver = new ChromeDriver();
            login(driver);
            try
            {
                driver.FindElement(By.XPath("//*[@id='top-search']")).SendKeys("John Doe-Test");
                driver.FindElement(By.XPath("//*[@id='top-search']")).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='ProviderContacts']/table/tbody/tr/td[1]/a/span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='openAddProductsSlideDown']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='assignmentsAddProduct']")).SendKeys("Epic");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='assignmentsAddProduct_listbox']/li[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@id='assignmentsPanel']/table/tbody/tr/td[1]")).Click();
                Thread.Sleep(1000);
                int trIndex = 1;
                bool trBool = false;
                do
                {
                    try
                    {
                        if (driver.FindElement(By.XPath("//*[@id='assignmentsPanel']/div[1]/div[1]/table/tbody/tr[" + trIndex + "]/td[2]/div/table/tbody/tr/td[6]/span")).Text == "Epic: Anesthesia Information Management System")
                        {
                            driver.FindElement(By.XPath("//*[@id='assignmentsPanel']/div[1]/div[1]/table/tbody/tr[" + trIndex + "]/td[2]/div/table/tbody/tr/td[6]/span")).Click();
                            trBool = true;
                        }
                        else
                            ++trIndex;
                    }
                    catch { ++trIndex; }
                } while (trBool == false);
                Thread.Sleep(5000);
                string newWindow = driver.WindowHandles.Last();
                driver.Close();
                driver.SwitchTo().Window(newWindow);
                driver.FindElement(By.Id("submitAllForExecutiveReview")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("numericsDataSubmitAsIs")).Click();
                Thread.Sleep(6000);
                _Success.Add("Submit For Executive Review");
                driver.Close();
            }
            catch
            {
                _Failed.Add("Submit For Executive Review");
                driver.Close();
            }

        }
    }
}