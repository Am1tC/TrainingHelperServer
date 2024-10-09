using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class TrainingField
    {
        public int TrainingFieldId { get; set; }

        public string Field { get; set; } = null!;
    }
}
