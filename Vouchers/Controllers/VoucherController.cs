using System;
using System.Collections.Generic;
using System.Web.Http;
using Dominos.OLO.Vouchers.Models;
using Dominos.OLO.Vouchers.Repository;
using VouchersDataLayer;
using VouchersModel.Interfaces;

namespace Dominos.OLO.Vouchers.Controllers
{
    /// <summary>
    /// Voucher controller
    /// To handle service requests
    /// </summary>
    public class VoucherController : ApiController
    {
        
        public VoucherController(IVoucherService voucherService)
        {
            // DI Service activation 
            VoucherRepository = new VoucherRepository(voucherService);
        }

        private VoucherRepository VoucherRepository { get; set; }

        /// <summary>
        /// Get Vouchers By Count
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [Route("")]
        public List<Voucher> Get(int count = 0)
        {
            return VoucherRepository.GetVouchersByCount(count);
        }

        /// <summary>
        /// Get Voucher by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("")]
        public Voucher GetVoucherById(Guid id)
        {
            return VoucherRepository.GetVoucherById(id);
           
        }

        /// <summary>
        /// Get Voucher by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("")]
        public List<Voucher> GetVouchersByName(string name)
        {
            return VoucherRepository.GetVouchersByName(name);
        }

        /// <summary>
        /// Search Voucher By Name
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [Route("")]
        public List<Voucher> GetVouchersByNameSearch(string search)
        {
            return VoucherRepository.GetVouchersByNameSearch(search);
        }

        /// <summary>
        /// Get Cheapest Voucher by Product Code
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        [Route("")]
        public Voucher GetCheapestVoucherByProductCode(string productCode)
        {
            return VoucherRepository.GetCheapestVoucherByProductCode(productCode);
        }
    }
}