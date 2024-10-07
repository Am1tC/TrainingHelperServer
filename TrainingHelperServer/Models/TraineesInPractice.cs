using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Keyless]
[Table("TraineesInPractice")]
public partial class TraineesInPractice
{
    public int? TraineeId { get; set; }

    public int? TrainingNumber { get; set; }

    public bool HasArrived { get; set; }

    [ForeignKey("TraineeId")]
    public virtual Trainee? Trainee { get; set; }

    [ForeignKey("TrainingNumber")]
    public virtual Training? TrainingNumberNavigation { get; set; }
}
