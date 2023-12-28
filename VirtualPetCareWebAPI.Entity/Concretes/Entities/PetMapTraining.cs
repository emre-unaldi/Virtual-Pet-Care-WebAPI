using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class PetMapTraining
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
