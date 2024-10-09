using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelperServer.DTO
{
    public class TrainingFieldsInTrainer
    {
        public int? TrainerId { get; set; }

        public int? TrainingFieldId { get; set; }


        public virtual Trainer? Trainer { get; set; }


        public virtual TrainingField? TrainingField { get; set; }
    }
}
