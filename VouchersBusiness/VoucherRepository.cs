using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dominos.OLO.Vouchers.Models;
using VouchersDataLayer;
using VouchersModel.Interfaces;

namespace Dominos.OLO.Vouchers.Repository
{
    // Voucher Repository 
    public class VoucherRepository
    {
        IVoucherService _voucherService;
        public VoucherRepository(IVoucherService voucherService )
        {
            _voucherService = voucherService;
        }
        internal string DataFilename = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";

        private List<Voucher> _vouchers;

        public virtual List<Voucher> GetVouchersByCount(int count = 0)
        {
            var vouchers = GetAllVouchers();
            if (count == 0)
            {
                count = vouchers.Count;
            }
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < count; i++)
            {
                returnVouchers.Add(vouchers[i]);
            }
            return returnVouchers;
        }

        public virtual Voucher GetVoucherById(Guid id)
        {
            var vouchers = GetAllVouchers();
            Voucher voucher = null;
            for (var i = 0; i < vouchers.Count; i++)
            {
                if (vouchers[i].Id == id)
                {
                    voucher = vouchers[i];
                }
            }

            return voucher;
        }

        public virtual List<Voucher> GetVouchersByName(string name)
        {
            var vouchers = GetAllVouchers();
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < vouchers.Count; i++)
            {
                if (vouchers[i].Name == name)
                {
                    returnVouchers.Add(vouchers[i]);
                }
            }

            return returnVouchers;
        }


        public virtual Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            var vouchers = GetAllVouchers();
            var returnVouchers = new List<Voucher>();
            for (var i = 0; i < vouchers.Count; i++)
            {
                if (vouchers[i].ProductCodes == productCode)
                {
                    returnVouchers.Add(vouchers[i]);
                }
            }
            Voucher cheapestVoucher = new Voucher();
            if (returnVouchers.Any())
            {
                cheapestVoucher = returnVouchers.OrderBy(p => p.Price).First();
            }

            return cheapestVoucher;
        }
        public virtual List<Voucher> GetVouchersByNameSearch(string search)
        {
            var vouchers = GetAllVouchers();
            var voucherList= vouchers.OfType<Voucher>().ToList();
            var returnList = voucherList.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            return returnList;
        }

            
        public virtual List<Voucher> GetAllVouchers()
        {
            if (_vouchers == null)
            {
                _vouchers = _voucherService.GetAllVouchers();
            }
            return _vouchers;
        }

    }
}