using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominos.OLO.Vouchers.Models;
using VouchersModel.Interfaces;

namespace Dominos.OLO.Vouchers.Tests.Unit.Mocks
{
    public class VoucherServiceMock : IVoucherService
    {
        public List<Voucher> _voucherList;
       
        public VoucherServiceMock()
        {
            _voucherList = new List<Voucher>();
            var _voucherArray1 = new Voucher()
            {
                Id = Guid.NewGuid(),
                Name = "TestName2",
                Price = 123,
                ProductCodes = "2323"
            };
            var _voucherArray2 = new Voucher()
            {
                Id = Guid.NewGuid(),
                Name = "TestName",
                Price = 123,
                ProductCodes = "2323"
            };
            _voucherList.Add(_voucherArray1);
            _voucherList.Add(_voucherArray2);
        }

        public List<Voucher> GetAllVouchers()
        {
            
            return _voucherList;
        }
    }
}
