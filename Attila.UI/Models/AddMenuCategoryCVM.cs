using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class AddMenuCategoryCVM
    {
       [Required]
       public string Category { get; set; }
    }
}
