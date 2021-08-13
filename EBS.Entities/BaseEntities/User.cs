using EBS.Shared;

namespace EBS.Entities.BaseEntities
{
    public class User : BaseEntity
    {
        [DataValidation(Exclude = true)]
        public int UserId { get; set; }

        [DataValidation(Required = true)]
        public string Email { get; set; }

        [DataValidation(Required = true, MinLength = 6, MaxLength = 50)]
        public string Password { get; set; }

        [DataValidation(Required = true)]
        public string FirstName { get; set; }

        [DataValidation(Required = true)]
        public string LastName { get; set; }

        [DataValidation(Required = true)]
        public int Type { get; set; }
    }
}