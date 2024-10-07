using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

[Keyless]
[Table("TrainingFieldsInTraining")]
public partial class TrainingFieldsInTraining
{
    public int? TrainingFieldId { get; set; }

    public int? TrainingNumber { get; set; }

    [ForeignKey("TrainingFieldId")]
    public virtual TrainingField? TrainingField { get; set; }

    [ForeignKey("TrainingNumber")]
    public virtual Training? TrainingNumberNavigation { get; set; }
}
