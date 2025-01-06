using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[PrimaryKey("TraineeId", "TrainingNumber")]
[Table("TraineesInPractice")]
public partial class TraineesInPractice
{
    [Key]
    public int TraineeId { get; set; }

    [Key]
    public int TrainingNumber { get; set; }

    public bool HasArrived { get; set; }

    [ForeignKey("TraineeId")]
    [InverseProperty("TraineesInPractices")]
    public virtual Trainee Trainee { get; set; } = null!;

    [ForeignKey("TrainingNumber")]
    [InverseProperty("TraineesInPractices")]
    public virtual Training TrainingNumberNavigation { get; set; } = null!;
}
