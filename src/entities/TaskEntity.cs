using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities;

public class TaskEntity
{
    
    [Column("id")]
        public string? Id { get; init; } = Guid.NewGuid().ToString();

    [Required]
    [Column("title")]
    public string? Title { get; set; }

    [Required]
    [Column("descricao")]
    public string? Description { get; set; }

    [Column("data_criacao")]
    public DateTime DateCreated { get; set; }
    
    [Column("data_update")]
    public DateTime DateUpgraded { get; set; }

    [ForeignKey("userId")]
    [Column("user_id")]
    public string? UserId { get; init; }

    public UserEntity? User { get; set; }
    
}