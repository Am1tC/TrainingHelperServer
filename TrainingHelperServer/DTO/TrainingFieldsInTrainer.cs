using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelperServer.DTO
{
    public class TrainingFieldsInTrainer
    {
        public int? TrainerId { get; set; }

        public int? TrainingFieldId { get; set; }


        public virtual Trainer? Trainer { get; set; }


        public virtual TrainingField? TrainingField { get; set; }

        public TrainingFieldsInTrainer() { }
        public TrainingFieldsInTrainer(Models.TrainingFieldsInTrainer tfi)
        {
            this.TrainerId = tfi.TrainerId;
            this.TrainingFieldId = tfi.TrainingFieldId;
            

        }
        public Models.TrainingFieldsInTrainer GetModel()
        {
            Models.TrainingFieldsInTrainer tfi = new Models.TrainingFieldsInTrainer();
            tfi.TrainerId = this.TrainerId;
            tfi.TrainingFieldId = this.TrainingFieldId;
            //tfi.Trainer = this.Trainer;
           // tfi.TrainingField = this.TrainingField;
            return tfi;
        }


    }

}
