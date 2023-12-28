using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareWebAPI.Entity.Concretes.Requests
{
    public class AddSocialInteractionMapPetRequest
    {
        public int PetId { get; set; }
        public int DestinationPetId { get; set; }
        public int SocialInteractionId { get; set; }
    }
}
