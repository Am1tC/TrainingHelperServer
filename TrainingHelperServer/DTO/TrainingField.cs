using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class TrainingField
    {
        public int TrainingFieldId { get; set; }
        public string Field { get; set; } = null!;

        public TrainingField() { }
        public TrainingField(Models.TrainingField f)
        {
            this.TrainingFieldId = f.TrainingFieldId;
            this.Field = f.Field;
        }
        public Models.TrainingField GetModel()
        {
            Models.TrainingField f = new Models.TrainingField();
            f.TrainingFieldId = this.TrainingFieldId;
            f.Field = this.Field;
            return f;
        }
    }
}
