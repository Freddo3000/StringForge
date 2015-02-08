﻿
using System.IO;

namespace RHSStringTableTools.Test
{
    using System.Collections.Generic;
    using RHSStringTableTools.Model;

    using NUnit.Framework;

    [TestFixture]
    public class XmlDeSerializerTestFixture
    {
        private const string pathToXml = @"testoutput\Stringtable.xml";

        [Test]
        public void VerifyThatSerializeDeSerializeWorks()
        {
            var obj = CsvParser.ParseProject("testdata");

            if (!Directory.Exists(Path.GetDirectoryName(pathToXml)))
                Directory.CreateDirectory(Path.GetDirectoryName(pathToXml));

            XmlDeSerializer.WriteXml(obj, pathToXml);

            Assert.IsTrue(File.Exists(pathToXml));

            var obj2 = XmlDeSerializer.LoadXml(pathToXml);

            Assert.IsNotNull(obj2);
            Assert.AreEqual(2, obj2.Packages.Count);

        }
    }
}
