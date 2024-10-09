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

        public TrainingPicture () { }
        public TrainingPicture (Models.TrainingPicture tp) 
        {
            this.PictureId = tp.PictureId;
            this.PictureEnding = tp.PictureEnding;
            this.TrainingNumber = tp.TrainingNumber;


        }

        public Models.TrainingPicture GetModel()
        {
            Models.TrainingPicture tp = new Models.TrainingPicture();
            tp.PictureId = this.PictureId;
            tp.PictureEnding = this.PictureEnding;
            tp.TrainingNumber = this.TrainingNumber;
            return tp;
        }

    }
}
