using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpworkAssignment.Domain.Entities;

public class Appointment : BaseEntity
{

    [Required]
    [StringLength(255)]
    public string? Title { get; set; }

    [StringLength(300)]
    public string? Note { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Required]
    public int CustomerId { get; set; }

    public AppointmentAddress? AppointmentAddress { get; set; }

    public Customer? Customer { get; set; }
}
