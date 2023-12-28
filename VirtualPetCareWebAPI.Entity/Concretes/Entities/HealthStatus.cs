using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class HealthStatus : IEntity
    {
        public int Id { get; set; }
        public bool VaccinationStatus { get; set; }
        public string VetVisits { get; set; }
        public string DiseasesAllergies { get; set; }

        [ForeignKey("PetId")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
