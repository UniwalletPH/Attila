using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_PackageAdditionalDurationRequest")]
    public class PackageAdditionalDurationRequest
    {
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }

    }
}
