using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzAir.Components.PageObjects
{
    public static class SignInPageElements
    {
        public static By Title => By.CssSelector(".heading.heading--2");
        public static By Email => By.Name("email");
        public static By Password => By.Name("password");
        public static By SignInBtn => By.ClassName("rf-button--primary");
        public static By CancelBtn => By.ClassName("rf-button--secondary");


    }
}
