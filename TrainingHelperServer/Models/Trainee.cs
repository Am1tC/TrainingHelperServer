using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Table("Trainee")]
public partial class Trainee
{
    [Key]
    public int TraineeId { get; set; }

    [StringLength(225)]
    public string Id { get; set; } = null!;

    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [StringLength(225)]
    public string LastName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime SubscriptionStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SubscriptionEndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BirthDate { get; set; }

    [StringLength(225)]
    public string Gender { get; set; } = null!;

    [StringLength(225)]
    public string PhoneNum { get; set; } = null!;

    [StringLength(225)]
    public string Email { get; set; } = null!;

    [StringLength(225)]
    public string? Picture { get; set; }

    [StringLength(225)]
    public string? Password { get; set; }
}
