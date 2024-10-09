using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class TrainingPicture
    {
        public string PictureId { get; set; } = null!;

        public int? TrainingNumber { get; set; }

        public string PictureEnding { get; set; } = null!;


        public virtual Training? TrainingNumberNavigation { get; set; }
    }
}
