using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingHelperServer.DTO
{
    public class TrainingFieldsInTraining
    {
        public int? TrainingFieldId { get; set; }

        public int? TrainingNumber { get; set; }

        public virtual TrainingField? TrainingField { get; set; }

        public virtual Training? TrainingNumberNavigation { get; set; }
    }
}
