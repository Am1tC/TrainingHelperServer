using System.ComponentModel.DataAnnotations;

namespace TrainingHelperServer.DTO
{
    public class Owner
    {
     
        public string OwnerId { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public Owner() { }
        public Owner(Models.Owner owner)
        {
            this.OwnerId = owner.OwnerId;
            this.Email = owner.Email;
            this.FirstName = owner.FirstName;
            this.LastName = owner.LastName;

        }

    }
}
