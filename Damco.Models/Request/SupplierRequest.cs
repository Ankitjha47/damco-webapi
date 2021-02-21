using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Models.Request
{
    public class SupplierRequest
    {
        public string name { get; set; }
    }

    public class SupplierRateRequest
    {
        public double rate { get; set; }
        public Guid fk_supplier_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime? end_date { get; set; }
    }
}
