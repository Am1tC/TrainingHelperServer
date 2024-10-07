using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class TrainingPicture
{
    [Key]
    [StringLength(225)]
    public string PictureId { get; set; } = null!;

    public int? TrainingNumber { get; set; }

    [StringLength(225)]
    public string PictureEnding { get; set; } = null!;

    [ForeignKey("TrainingNumber")]
    [InverseProperty("TrainingPictures")]
    public virtual Training? TrainingNumberNavigation { get; set; }
}
