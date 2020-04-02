using Attila.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class UserLogin : BaseAuditedEntity
    {
        [Key]
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }

        public string Username { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }
        public bool IsTemporaryPassword { get; set; }
        public string TemporaryPassword { get; set; }

        public User User { get; set; } 
    }
}
