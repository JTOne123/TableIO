﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TableIO.Tests
{
    [TestClass()]
    public class CsvRowWriterTests
    {
        [TestMethod()]
        public void Write()
        {
            var sw = new StringWriter();
            var writer = new CsvRowWriter(sw);

            writer.Write(new[] { "aaa", "aaa", "aaa" });
            writer.Write(new[] { "bbb", "bbb", "bbb" });

            Assert.AreEqual("aaa,aaa,aaa\r\nbbb,bbb,bbb\r\n", sw.ToString());
        }

        [TestMethod]
        public void WriteEmpty()
        {
            var sw = new StringWriter();
            var writer = new CsvRowWriter(sw);

            writer.Write(new[] { "", "", "" });
            writer.Write(new string [] { null, null, null });

            Assert.AreEqual(",,\r\n,,\r\n", sw.ToString());
        }

        [TestMethod]
        public void WriteEscape()
        {
            var sw = new StringWriter();
            var writer = new CsvRowWriter(sw);

            writer.Write(new[] { ",", "a,", "\r", "\n", "\"" });
            // ",","a,","\r","\n",""""
            Assert.AreEqual("\",\",\"a,\",\"\r\",\"\n\",\"\"\"\"\r\n", sw.ToString());
        }

        [TestMethod]
        public void WriteNothing()
        {
            var sw = new StringWriter();
            var writer = new CsvRowWriter(sw);

            Assert.AreEqual("", sw.ToString());
        }

        [TestMethod]
        public void WriteNoFields()
        {
            var sw = new StringWriter();
            var writer = new CsvRowWriter(sw);

            writer.Write(new string[] { });
            writer.Write(new string[] { });

            Assert.AreEqual("\r\n\r\n", sw.ToString());
        }
    }
}