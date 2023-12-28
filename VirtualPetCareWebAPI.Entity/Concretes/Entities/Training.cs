using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class Training : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<PetMapTraining> PetsMapTrainings { get; set; }
    }
}
