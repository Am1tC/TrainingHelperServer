using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelperServer.DTO
{
    public class TraineesInPractice
    {
        public int TraineeId { get; set; }

        public int TrainingNumber { get; set; }

        public bool HasArrived { get; set; }

        public virtual Trainee? Trainee { get; set; }

        public TraineesInPractice() { }
        public TraineesInPractice(Models.TraineesInPractice traineesInPractice)
        {
            this.TraineeId = traineesInPractice.TraineeId;
            this.TrainingNumber = traineesInPractice.TrainingNumber;
            this.HasArrived = traineesInPractice.HasArrived;
            //this.Trainee = traineesInPractice.Trainee;


        }
        public Models.TraineesInPractice GetModel()
        {
            Models.TraineesInPractice tip =new Models.TraineesInPractice();
            tip.TraineeId = this.TraineeId;
            tip.TrainingNumber = this.TrainingNumber;
            tip.HasArrived = this.HasArrived;
            //tip.Trainee = this.Trainee;
            return tip;

        }


    }
}

