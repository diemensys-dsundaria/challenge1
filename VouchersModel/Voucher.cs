using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominos.OLO.Vouchers.Models
{
    public class Voucher
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductCodes { get; set; }
    }
}
