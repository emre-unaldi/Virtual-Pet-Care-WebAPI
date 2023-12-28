using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareWebAPI.Entity.Concretes.Responses
{
    public class GetSocialInteractionMapPetDetails
    {
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public int PetAge { get; set; }
        public string Gender { get; set; }

        public string DestinationPetName { get; set; }
        public string DestinationPetBreed { get; set; }
        public int DestinationPetAge { get; set; }
        public string DestinationGender { get; set; }
        public string SocialInteractionName { get; set; }
    }
}
