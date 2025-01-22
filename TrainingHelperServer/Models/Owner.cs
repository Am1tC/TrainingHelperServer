using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Table("Owner")]
public partial class Owner
{
    [Key]
    [StringLength(225)]
    public string OwnerId { get; set; } = null!;

    [StringLength(225)]
    public string Password { get; set; } = null!;

    [StringLength(225)]
    public string FirstName { get; set; } = null!;

    [StringLength(225)]
    public string LastName { get; set; } = null!;
}
