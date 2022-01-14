using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpworkAssignment.Domain.Entities;

public class AppointmentAddress : BaseEntity
{

    [Required]
    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(255)]
    public string? Country { get; set; }

    [StringLength(50)]
    public string? State { get; set; }

    [StringLength(50)]
    public string? City { get; set; }

    [StringLength(50)]
    public string? Zip { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    public Appointment? Appointment { get; set; }
}
