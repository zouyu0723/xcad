﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xarial.XCad.Documents;
using Xarial.XCad.SolidWorks.Documents;

namespace SolidWorks.Tests.Integration
{
    public class ConfigurationsTest : IntegrationTests
    {
        [Test]
        public void ActiveConfTest() 
        {
            string name;

            using (var doc = OpenDataDocument("Configs1.SLDPRT"))
            {
                name = (m_App.Documents.Active as SwDocument3D).Configurations.Active.Name;
            }

            Assert.AreEqual("Conf3", name);
        }

        [Test]
        public void IterateConfsTest()
        {
            string[] confNames;

            using (var doc = OpenDataDocument("Configs1.SLDPRT"))
            {
                confNames = (m_App.Documents.Active as SwDocument3D).Configurations.Select(x => x.Name).ToArray();
            }

            Assert.That(confNames.SequenceEqual(new string[] 
            {
                "Conf1", "Conf2", "SubConf1", "SubSubConf1", "SubConf2", "Conf3"
            }));
        }

        [Test]
        public void GetConfigByNameTest()
        {
            IXConfiguration conf1;
            IXConfiguration conf2;
            IXConfiguration conf3;
            bool r1;
            bool r2;
            Exception e1 = null;

            using (var doc = OpenDataDocument("Configs1.SLDPRT"))
            {
                var confs = (m_App.Documents.Active as SwDocument3D).Configurations;

                conf1 = confs["Conf1"];
                r1 = confs.TryGet("Conf2", out conf2);
                r2 = confs.TryGet("Conf4", out conf3);

                try
                {
                    var conf4 = confs["Conf5"];
                }
                catch (Exception ex)
                {
                    e1 = ex;
                }
            }

            Assert.IsNotNull(conf1);
            Assert.IsNotNull(conf2);
            Assert.IsNull(conf3);
            Assert.IsTrue(r1);
            Assert.IsFalse(r2);
            Assert.IsNotNull(e1);
        }
    }
}
