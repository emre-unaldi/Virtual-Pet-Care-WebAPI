using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Pet> Pets { get; set; }
    }
}