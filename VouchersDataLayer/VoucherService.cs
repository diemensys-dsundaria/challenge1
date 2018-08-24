using Dominos.OLO.Vouchers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using VouchersModel.Interfaces;

namespace VouchersDataLayer
{
    /// <summary>
    /// Voucher Service
    /// </summary>
    public class VoucherService : IVoucherService
    {
        string _datafileName;
        public VoucherService()
        {
            _datafileName = $"{AppDomain.CurrentDomain.BaseDirectory}data.json";
        }


        /// <summary>
        /// Get All Vouchers
        /// </summary>
        /// <returns></returns>
        public virtual List<Voucher> GetAllVouchers()
        {

            ObjectCache cache = MemoryCache.Default;
            Voucher[] _vouchers = cache["filecontents"] as Voucher[];
            if (_vouchers == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                List<string> filePaths = new List<string>();
                filePaths.Add(_datafileName);

                // Monitoring File changes
                policy.ChangeMonitors.Add(new
                HostFileChangeMonitor(filePaths));

                // Fetch the file contents.  
                var _fileContent =
                    File.ReadAllText(_datafileName);
                _vouchers = JsonConvert.DeserializeObject<Voucher[]>(_fileContent);
                cache.Set("filecontents", _vouchers, policy);
            }
            
            return _vouchers.OfType<Voucher>().ToList(); 
        }
    }
}
