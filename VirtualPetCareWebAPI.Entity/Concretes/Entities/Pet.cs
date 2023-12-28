using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class Pet : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }


        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual HealthStatus HealthStatus { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public virtual List<Food> Foods { get; set; }

        public virtual List<PetMapTraining> PetsMapTrainings { get; set; }
    }
}