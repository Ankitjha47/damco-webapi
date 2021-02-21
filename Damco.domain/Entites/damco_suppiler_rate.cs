using Damco.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Damco.Domain.Entites
{
    public class damco_supplier_rate : BaseEntity
    {
        public double rate { get; set; }
        public Guid fk_supplier_id { get; set; }
        [ForeignKey("fk_supplier_id")]
        public damco_supplier damco_supplier { get; set; }
        public DateTime start_date { get; set; }
        public DateTime? end_date { get; set; }
    }
}
