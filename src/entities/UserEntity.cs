using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities;

public class UserEntity
{   
    [Key]
    [Column("id")]
    public string Id { get; init; } = Guid.NewGuid().ToString();

    [Required]
    [Column("email")]
        public string? Email { get; set; }

    [Required]
    [Column("password")]
    public string? Password { get; set; }

    [Column("data_create")]
    public DateTime DateCreated { get; set; }

    [Column("data_upgrade")]
        public DateTime DateUpgraded { get; set; }

    public ICollection<TaskEntity>? Tasks { get; set; } = new Collection<TaskEntity>(); 
    
}