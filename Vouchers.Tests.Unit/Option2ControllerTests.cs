using System;
using System.Collections.Generic;
using Dominos.OLO.Vouchers.Controllers;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Dominos.OLO.Vouchers.Tests.Unit.Mocks;
using NSubstitute;
using NUnit.Framework;
using VouchersDataLayer;
using VouchersModel.Interfaces;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
    /// <summary>
    /// Test Class: Controller 
    /// For testing Voucher service with Mock data
    /// </summary>
    [TestFixture]
    public class Option2ControllerTests
    {


        private VoucherServiceMock _service;
        private VoucherController _controller;

        private List<Voucher> _vouchers = new List<Voucher>();

        [SetUp]
        public void Setup()
        {
            _vouchers = new List<Voucher>();
            _service = new VoucherServiceMock();
            _controller = new VoucherController(_service);
        }

        [Test]
        public void Get_ShouldReturnRequestedNumberOfVouchers()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }
            _service._voucherList = _vouchers;
            var result = _controller.Get(100);

            Assert.AreEqual(100, result.Count);
        }

        [Test]
        public void Get_ShouldReturnAllVouchersByDefault()
        {
            for (var i = 0; i < 1000; i++)
            {
                _vouchers.Add(new Voucher
                {
                    Id = new Guid()
                });
            }
            _service._voucherList = _vouchers;
            var result = _controller.Get();

            Assert.AreEqual(_vouchers.Count, result.Count);
        }

        [Test]
        public void GetVouchersByName_ShouldReturnAllVouchersWithTheGivenName()
        {
            var a1Voucher = new Voucher { Id = new Guid(), Name = "A" };
            var a2Voucher = new Voucher { Id = new Guid(), Name = "A" };
            var b1Voucher = new Voucher { Id = new Guid(), Name = "B" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);
            _service._voucherList = _vouchers;
            var result = _controller.GetVouchersByName("A");
            Assert.AreEqual(new[] { a1Voucher, a2Voucher }, result);
        }

        [Test]
        public void GetVouchersByNameSearch_ShouldReturnAllVouchersWhichMatchTheSearch()
        {
            var a1Voucher = new Voucher { Id = new Guid(), Name = "ABC" };
            var a2Voucher = new Voucher { Id = new Guid(), Name = "ABCD" };
            var b1Voucher = new Voucher { Id = new Guid(), Name = "ACD" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);
            _service._voucherList = _vouchers;
            var result = _controller.GetVouchersByNameSearch("BC");
            Assert.AreEqual(new[] { a1Voucher, a2Voucher }, result);
        }
    }
}