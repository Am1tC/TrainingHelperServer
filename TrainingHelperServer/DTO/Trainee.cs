using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TrainingHelperServer.DTO
{
    public class Trainee
    {
        public int TraineeId { get; set; }
        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? SubscriptionStartDate { get; set; }

        public DateTime? SubscriptionEndDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Gender { get; set; } 
        public string PhoneNum { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Picture { get; set; }
        public string? Password { get; set; }

        public Trainee() { }
        public Trainee(Models.Trainee trainee) 
        {
            this.TraineeId = trainee.TraineeId;
            this.Id = trainee.Id;
            this.FirstName = trainee.FirstName;
            this.LastName = trainee.LastName;
            this.SubscriptionStartDate = trainee.SubscriptionStartDate;
            this.SubscriptionEndDate = trainee.SubscriptionEndDate;
            this.BirthDate = trainee.BirthDate;
            this.Gender = trainee.Gender;
            this.PhoneNum = trainee.PhoneNum;
            this.Email = trainee.Email;
            this.Picture = trainee.Picture;
            this.Password = trainee.Password;

        }

        public Models.Trainee GetModel()
        {
            Models.Trainee t = new Models.Trainee();
            t.Id = this.Id;
            t.FirstName = this.FirstName;
            t.LastName = this.LastName;
            t.SubscriptionStartDate = this.SubscriptionStartDate;
            t.SubscriptionEndDate = this.SubscriptionEndDate;
            t.BirthDate = this.BirthDate;
            t.Gender = this.Gender;
            t.PhoneNum = this.PhoneNum;
            t.Email = this.Email;
            t.Password = this.Password;
            t.Picture = this.Picture;
            return t;
        }



    }
}
