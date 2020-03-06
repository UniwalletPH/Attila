using System;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class AddEventPackageVM
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
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
