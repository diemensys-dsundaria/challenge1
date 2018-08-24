using System;
using System.Collections.Generic;
using System.Linq;
using Dominos.OLO.Vouchers.Controllers;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using Dominos.OLO.Vouchers.Tests.Unit.Mocks;
using NSubstitute;
using NUnit.Framework;
using VouchersDataLayer;

namespace Dominos.OLO.Vouchers.Tests.Unit
{
    /// <summary>
    /// Test Class: Voucher Direct Business 
    /// For testing business methods directly.
    /// </summary>
    [TestFixture]
    public class Option2VoucherDirectBusinessTests
    {



        VoucherServiceMock _voucherServiceMock;
        VoucherRepository _repository;

        private List<Voucher> _vouchers = new List<Voucher>();

        [SetUp]
        public void Setup()
        {
            _vouchers = new List<Voucher>();
            _voucherServiceMock = new VoucherServiceMock();
            _repository = new VoucherRepository(_voucherServiceMock);

        }

        [Test]
        public void Get_ShouldReturnRequestedNumberOfVouchers()
        {
            
            var result = _repository.GetAllVouchers();

            Assert.AreEqual(2, result.Count);
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

            _voucherServiceMock._voucherList = _vouchers;
            var result = _repository.GetVouchersByName("A");
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

            _voucherServiceMock._voucherList = _vouchers;
            var result = _repository.GetVouchersByNameSearch("BC");
            Assert.AreEqual(new[] { a1Voucher, a2Voucher }, result);
        }

        [Test]
        public void GetCheapestVoucher_ShouldReturnVoucherWithLowestPrice()
        {

            var a1Voucher = new Voucher { Id = new Guid(), Price=23D, ProductCodes = "ABC" };
            var a2Voucher = new Voucher { Id = new Guid(), Price = 10D, ProductCodes = "ABCD" };
            var b1Voucher = new Voucher { Id = new Guid(), Price = 11_122D, ProductCodes = "BC" };
            var b2Voucher = new Voucher { Id = new Guid(), Price = 11_1D, ProductCodes = "BC" };
            var b3Voucher = new Voucher { Id = new Guid(), Price = 10_100D, ProductCodes = "BC" };

            _vouchers.Add(a1Voucher);
            _vouchers.Add(a2Voucher);
            _vouchers.Add(b1Voucher);
            _vouchers.Add(b2Voucher);
            _vouchers.Add(b3Voucher);

            _voucherServiceMock._voucherList = _vouchers;
            var result = _repository.GetCheapestVoucherByProductCode("BC");
            Assert.AreEqual(b2Voucher, result);
        }
    }
}