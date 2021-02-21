using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Damco.Domain.Common
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? modified_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
