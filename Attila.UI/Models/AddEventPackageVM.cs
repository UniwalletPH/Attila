using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddEventPackageVM
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int NumberOfGuest { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
    }
}
