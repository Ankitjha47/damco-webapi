using Damco.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Damco.Domain.Entites
{
    public class damco_supplier : BaseEntity
    {
        public string name { get; set; }

        public ICollection<damco_supplier_rate> damco_supplier_rates { get; set; }
    }
}
