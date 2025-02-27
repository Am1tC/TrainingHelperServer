using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class TrainingHelperDbContext : DbContext
{
    public Trainee? GetTrainee(string id)
    {
        return this.Trainees.Where(u => u.Id == id && u.IsActive == true)
                            .FirstOrDefault();
                            
    }

    public Trainee? GetTraineeViaEmail(string email)
    {
        return this.Trainees.Where(u => u.Email == email)
                            .FirstOrDefault();
    }

    public Trainer? GetTrainer(string id)
    {
        return this.Trainers.Where(u => u.Id.ToString() == id && u.IsActive == true)
                            .FirstOrDefault();
    }

    public Trainer GetTrainerViaSerialNumber(int id)
    {
        return this.Trainers.Where(u => u.TrainerId == id && u.IsActive == true)
                           .FirstOrDefault();
    }

    public Training? GetTraining(int trainingnumber)
    {
        return this.Training.Where(t => t.TrainingNumber == trainingnumber)
            .FirstOrDefault();

    }

    //public List<Training> GetTraining(DateTime date)
    //{
    //  return  this.Training.Where(t => t.Date == date).ToList();

    //}
    public Owner? GetOwner(string id)
    {
        return this.Owners // Replace with the actual collection name
                   .Where(u => u.OwnerId == id)
                   .FirstOrDefault();
    }



    public List<Training> GetTrainings()
    {
        return this.Training.Include(t => t.Trainer).ToList();
    }

    public List<TraineesInPractice> GetOrderdTrainings(string id)
    {
        return this.TraineesInPractices.Where(t => t.TraineeId.ToString() == id).ToList();
    }
    public List<Training> GetTrainerTrainings(string id)
    {
        return this.Training.Where(t => t.TrainerId.ToString() == id).ToList();
    }


    public List<Trainee> GetAllTrainees()
    {
        return this.Trainees.Where(t=> t.IsActive == true).ToList();
    }

    public List<Trainer> GetAllTrainers()
    {
        return this.Trainers.Where(t => t.IsActive == true).ToList();
    }




}
