﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class TrainingHelperDbContext : DbContext
{
    public Trainee? GetTrainee(string id)
    {
        return this.Trainees.Where(u => u.Id == id)
                            .FirstOrDefault();
                            
    }

    public Trainee? GetTraineeViaEmail(string email)
    {
        return this.Trainees.Where(u => u.Email == email)
                            .FirstOrDefault();
    }

    public Trainer? GetTrainer(string id)
    {
        return this.Trainers.Where(u => u.Id == id)
                            .FirstOrDefault();
    }

    public Training? GetTraining(int trainingnumber)
    {
        return this.Training.Where(t => t.TrainingNumber == trainingnumber)
            .FirstOrDefault();

    }

    public List<Training> GetTraining(DateTime date)
    {
      return  this.Training.Where(t => t.Date == date).ToList();

    }

    public List<Training> GetTrainings()
    {
        return this.Training.ToList();
    }


}
 