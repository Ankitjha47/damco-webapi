using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Models.Response
{
    public class SupplierResponce
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }

    public class SupplierRateResponce
    {
        public Guid id { get; set; }
        public Guid fk_supplier_id { get; set; }
        public double rate { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }
}
