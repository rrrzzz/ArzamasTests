﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestFramework;



namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CheckHomePage()
        {
            Pages.HomePage.GoTo();
            Assert.IsTrue(Pages.HomePage.IsAt());
        }
    }
}