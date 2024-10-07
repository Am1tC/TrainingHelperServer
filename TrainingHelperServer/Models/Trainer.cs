using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Table("Trainer")]
[Index("Email", Name = "UQ__Trainer__A9D105346932E540", IsUnique = true)]
public partial class Trainer
{
    [Key]
    public int TrainerId { get; set; }

    [StringLength(225)]
    public string Id { get; set; } = null!;

    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [StringLength(225)]
    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    [StringLength(225)]
    public string Gender { get; set; } = null!;

    [StringLength(225)]
    public string PhoneNum { get; set; } = null!;

    [StringLength(225)]
    public string Email { get; set; } = null!;

    [StringLength(225)]
    public string? Picture { get; set; }

    [InverseProperty("Trainer")]
    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
