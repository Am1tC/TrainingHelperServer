using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelperServer.DTO
{
    public class TrainingFieldsInTraining
    {
        public int? TrainingFieldId { get; set; }

        public int? TrainingNumber { get; set; }

        public virtual TrainingField? TrainingField { get; set; }

        public virtual Training? TrainingNumberNavigation { get; set; }

        public TrainingFieldsInTraining() { }
        public TrainingFieldsInTraining(Models.TrainingFieldsInTraining tfit)
        {
            this.TrainingFieldId = tfit.TrainingFieldId;
            this.TrainingNumber = tfit.TrainingNumber;

        }
        public Models.TrainingFieldsInTraining GetModel()
        {
            Models.TrainingFieldsInTraining tfit = new Models.TrainingFieldsInTraining();
            tfit.TrainingFieldId = this.TrainingFieldId;
            tfit.TrainingNumber = this.TrainingNumber;
            return tfit;
        }
    }
}
