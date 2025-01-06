using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class Training
{
    [Key]
    public int TrainingNumber { get; set; }

    public int? TrainerId { get; set; }

    public int MaxParticipants { get; set; }

    [StringLength(225)]
    public string Place { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(225)]
    public string Duration { get; set; } = null!;

    [StringLength(225)]
    public string Picture { get; set; } = null!;

    [InverseProperty("TrainingNumberNavigation")]
    public virtual ICollection<TraineesInPractice> TraineesInPractices { get; set; } = new List<TraineesInPractice>();

    [ForeignKey("TrainerId")]
    [InverseProperty("Training")]
    public virtual Trainer? Trainer { get; set; }

    [InverseProperty("TrainingNumberNavigation")]
    public virtual ICollection<TrainingPicture> TrainingPictures { get; set; } = new List<TrainingPicture>();
}
