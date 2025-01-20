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

        public DateTime Date { get; set; }

        public string Duration { get; set; } = null!;


        public string Picture { get; set; } = null!;


        public virtual Trainer? Trainer { get; set; }

        public virtual ICollection<TrainingPicture> TrainingPictures { get; set; } = new List<TrainingPicture>();

        public Training () { }
        public Training (Models.Training Tg)
        {
            this.TrainingNumber = Tg.TrainingNumber;
            this.TrainerId = Tg.TrainerId;
            this.MaxParticipants = Tg.MaxParticipants;
            this.Place = Tg.Place;
            this.Date = Tg.Date;
            this.Duration = Tg.Duration;
            this.Picture = Tg.Picture;
            if (Tg.Trainer != null)
                this.Trainer = new Trainer(Tg.Trainer);

        }
        public Models.Training GetModel()
        {
            Models.Training tg = new Models.Training();
            tg.TrainingNumber = this.TrainingNumber;
            tg.TrainerId = this.TrainerId;
            tg.MaxParticipants = this.MaxParticipants;
            tg.Place = this.Place;
            tg.Date = this.Date;
            tg.Duration = this.Duration;
            tg.Picture = this.Picture;
            if (this.Trainer != null)
                tg.Trainer = this.Trainer.GetModel();
            return tg;
        }

    }
}
