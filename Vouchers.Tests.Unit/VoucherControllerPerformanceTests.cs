using System;
using System.Collections.Generic;
using Dominos.OLO.Vouchers.Controllers;
using Dominos.OLO.Vouchers.Repository;
using NSubstitute;
using NUnit.Framework;
using VouchersDataLayer;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
    /// <summary>
    /// Test Class: Voucher Controller Performance 
    /// </summary>
    [TestFixture]
    public class VoucherControllerPerformanceTests
    {
        private readonly VoucherController _controller = new VoucherController(new VoucherService());

        [SetUp]
        public void Setup()
        {
            //var repository = _controller.Repository;
            //repository.DataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}\\..\\..\\..\\Vouchers\\data.json";
            // This is to pre-load the vouchers.
            //repository.GetVouchers();
            _controller.Get(0);//preload
        }

        [Test]
        public void Get_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 1000; i++)
            {
                _controller.Get();
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }

        [Test]
        public void Get_ShouldBePerformantWhenReturningASubset()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100000; i++)
            {
                _controller.Get(1000);
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 5000);
        }

        [Test]
        public void GetCheapestVoucherByProductCode_ShouldBePerformant()
        {
            var startTime = DateTime.Now;

            for (var i = 0; i < 100; i++)
            {
                _controller.GetCheapestVoucherByProductCode("P007D");
            }

            var elapsed = DateTime.Now.Subtract(startTime).TotalMilliseconds;
            Assert.LessOrEqual(elapsed, 15000);
        }
    }
}