using Dominos.OLO.Vouchers.Models;
using System.Collections.Generic;

namespace VouchersModel.Interfaces
{
    /// <summary>
    /// Voucher Service Interface
    /// </summary>
    public interface IVoucherService
    {
        List<Voucher> GetAllVouchers();
    }
}
