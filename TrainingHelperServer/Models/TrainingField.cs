using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Table("TrainingField")]
public partial class TrainingField
{
    [Key]
    public int TrainingFieldId { get; set; }

    [StringLength(225)]
    public string Field { get; set; } = null!;
}
