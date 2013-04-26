using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using Cashier.Model;
using Cashier.UseCases;
using Cashier.Persistence.Fake;


namespace Cashier.Business.CafeAlma.Tests
{
    [TestFixture]
    public class BusinessTest
    {
        [Test]
        public void TestTotalVeryBasic()
        {
            //arrange
            var listProd = new List<Product>();
            listProd.Add(new Product("foo", 1));
            listProd.Add(new Product("bar", 1.8));            
            var sut = new Calculateur(listProd);
            //act
            sut.ProcessEntry(new CashierTyping{ Number=2, Reference="foo"});
            sut.ProcessEntry(new CashierTyping{ Number=1, Reference="bar"});
            //assert
            Assert.That(sut.CalculateTotal(), Is.EqualTo(3.8));

        }






        [Test]
        public void TestTotalWithPersistenceMocked()
        {
            //arrange            
            var sut = new Calculateur();
            var mockStorage = new Mock<ICanPersistProducts>();
            var listProd = new List<Product>();
            listProd.Add(new Product("foo", 1));
            listProd.Add(new Product("bar", 1.8));            
            mockStorage.Setup(s => s.GetAllFromCatalogNamed("foo")).Returns(listProd);
            





            //act
            sut.GiveMeAWayToPersistData(mockStorage.Object, "foo");
            sut.ProcessEntry(new CashierTyping { Number = 2, Reference = "foo" });
            sut.ProcessEntry(new CashierTyping { Number = 1, Reference = "bar" });
            
            //assert
            Assert.That(sut.CalculateTotal(), Is.EqualTo(3.8));
            Assert.AreEqual(sut.CalculateTotal(), 3.8);
        }






        [Test]
        public void TestTotalWithPersistenceSpied()
        {
            //arrange            
            var sut = new Calculateur();
            var spyStorage = new SpyStorage();
            //act
            sut.GiveMeAWayToPersistData(spyStorage, "foo");
            //assert
            Assert.That(spyStorage.Tracker.Count(), Is.EqualTo(1));
            Assert.That(spyStorage.Tracker.First(), Is.EqualTo("GetAllFromCatalogNamed foo"));

        }




        [Test]
        public void TestTotalWithPersistenceFaked()
        {
            //arrange            
            var sut = new Calculateur();
            var fakeStorage = new FakeDataAccess();
            fakeStorage.Put(new Product("foo", 1), "cat");
            fakeStorage.Put(new Product("bar", 1.8), "cat");   
            //act
            sut.GiveMeAWayToPersistData(fakeStorage, "foo");
            
            sut.ProcessEntry(new CashierTyping { Number = 2, Reference = "foo" });
            sut.ProcessEntry(new CashierTyping { Number = 1, Reference = "bar" });

            //assert
            Assert.That(sut.CalculateTotal(), Is.EqualTo(3.8));

        }

    }
}
