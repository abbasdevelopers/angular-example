using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpworkAssignment.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        IsActive = true;
        AddedOnUtc = DateTime.UtcNow;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime? AddedOnUtc { get; set; } 

    public DateTime? UpdatedOnUtc { get; set; }
}
