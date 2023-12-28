using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;

namespace VirtualPetCareWebAPI.Entity.Concretes.Requests
{
    public class AddTrainingRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<PetMapTraining> PetsMapTrainings { get; set; }
    }
}
