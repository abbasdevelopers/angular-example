using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpworkAssignment.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer()
        :base()
    {
        Appointments = new List<Appointment>();
    }

    [Required]
    [StringLength(300)]
    public string? FullName { get; set; }

    [Required]
    [StringLength(300)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public List<Appointment> Appointments { get; set; }
}
