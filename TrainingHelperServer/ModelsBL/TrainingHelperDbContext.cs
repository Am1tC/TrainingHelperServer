using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class TrainingHelperDbContext : DbContext
{
    public Trainee? GetTrainee(string id)
    {
        return this.Trainees.Where(u => u.Id == id)
                            //.Include(u=> u.FirstName)
                            .FirstOrDefault();
                            
    }

    public Trainer? GetTrainer(string id)
    {
        return this.Trainers.Where(u => u.Id == id)
                            .FirstOrDefault();
    }
}
 