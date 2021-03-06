﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Cashier.Model;
using Cashier.Persistence.SQLserver;

namespace Cashier.Persistence.Fake.Tests
{
    [TestFixture]
    public class TestSqlDataAccess
    {
        [Test]
        public void TestInsertAndRead()
        {
        //arrange
            var sut = new SqlDataAccess();
            var p = new Product("foo", 1);
         //act
            sut.Put(p, "bar");
            var p2 = sut.Get("foo", "bar");
        //assert
            Assert.That(p2, Is.Not.Null);
            Assert.That(p2.Reference, Is.EqualTo("foo"));
            Assert.That(p2.Price, Is.EqualTo(1));
        }
    }
}
