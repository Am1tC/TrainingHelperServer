using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class Training
    {
        public int TrainingNumber { get; set; }

        public int? TrainerId { get; set; }

        public int MaxParticipants { get; set; }

        public string Place { get; set; } = null!;

        public DateTime? Date { get; set; }

        public string Duration { get; set; } = null!;


        public string Picture { get; set; } = null!;


        public virtual Trainer? Trainer { get; set; }

        public virtual ICollection<TrainingPicture> TrainingPictures { get; set; } = new List<TrainingPicture>();
    }
}
