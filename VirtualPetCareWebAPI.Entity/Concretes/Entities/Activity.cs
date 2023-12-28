using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class Activity : IEntity
    {
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public string Notes { get; set; }

        [ForeignKey("PetId")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
