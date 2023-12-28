using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareWebAPI.Entity.Abstracts;

namespace VirtualPetCareWebAPI.Entity.Concretes.Entities
{
    public class PetMapSocialInteractions : IEntity
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int DestinationPetId { get; set; }
        public int SocialInteractionId { get; set; }
    }
}
