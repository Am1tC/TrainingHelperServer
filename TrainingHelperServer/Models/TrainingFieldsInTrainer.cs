using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Keyless]
[Table("TrainingFieldsInTrainer")]
public partial class TrainingFieldsInTrainer
{
    public int? TrainerId { get; set; }

    public int? TrainingFieldId { get; set; }

    [ForeignKey("TrainerId")]
    public virtual Trainer? Trainer { get; set; }

    [ForeignKey("TrainingFieldId")]
    public virtual TrainingField? TrainingField { get; set; }
}
