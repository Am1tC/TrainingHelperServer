using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        public string Id { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly BirthDate { get; set; }


        public string Gender { get; set; } = null!;


        public string PhoneNum { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Picture { get; set; }

        public virtual ICollection<Training> Training { get; set; } = new List<Training>();
    }
}
