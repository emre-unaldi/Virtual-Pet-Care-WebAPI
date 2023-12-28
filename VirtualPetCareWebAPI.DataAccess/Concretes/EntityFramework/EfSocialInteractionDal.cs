using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;

namespace VirtualPetCareWebAPI.DataAccess.Concretes.EntityFramework
{
    public class EfSocialInteractionDal : EfEntityRepositoryBase<PetMapSocialInteractions, PetCareDbContext>, ISocialInteractionDal
    {
        public List<GetSocialInteractionMapPetDetails> GetDetail()
        {
            using (PetCareDbContext context = new PetCareDbContext())
            {
                var GetSocialInteractionMapPetDetails = from socialInteractionMapPet in context.PetMapSocialInteractions
                                                     join pet in context.Pets
                                                     on socialInteractionMapPet.Id equals pet.Id
                                                     join destinationPet in context.Pets
                                                     on socialInteractionMapPet.DestinationPetId equals destinationPet.Id
                                                     join socialInteraction in context.SocialInteractions
                                                     on socialInteractionMapPet.SocialInteractionId equals socialInteraction.Id
                                                     select new GetSocialInteractionMapPetDetails
                                                     {
                                                         PetName = pet.Name,
                                                         PetBreed = pet.Species,
                                                         PetAge = pet.Age,
                                                         Gender = pet.Gender,
                                                         DestinationPetName = destinationPet.Name,
                                                         DestinationPetBreed = destinationPet.Species,
                                                         DestinationPetAge = destinationPet.Age,
                                                         DestinationGender = destinationPet.Gender,
                                                         SocialInteractionName = socialInteraction.Name
                                                     };

                return GetSocialInteractionMapPetDetails.ToList();
            }
        }

        public List<GetSocialInteractionMapPetDetails> GetByPetId(int petId)
        {
            using (PetCareDbContext context = new PetCareDbContext())
            {
                var GetSocialInteractionMapPetDetail = from socialInteractionMapPet in context.PetMapSocialInteractions
                                                     join pet in context.Pets
                                                     on socialInteractionMapPet.Id equals pet.Id
                                                     join destinationPet in context.Pets
                                                     on socialInteractionMapPet.DestinationPetId equals destinationPet.Id
                                                     join socialInteraction in context.SocialInteractions
                                                     on socialInteractionMapPet.SocialInteractionId equals socialInteraction.Id
                                                     where pet.Id == petId
                                                     select new GetSocialInteractionMapPetDetails
                                                     {
                                                         PetName = pet.Name,
                                                         PetBreed = pet.Species,
                                                         PetAge = pet.Age,
                                                         Gender = pet.Gender,
                                                         DestinationPetName = destinationPet.Name,
                                                         DestinationPetBreed = destinationPet.Species,
                                                         DestinationPetAge = destinationPet.Age,
                                                         DestinationGender = destinationPet.Gender,
                                                         SocialInteractionName = socialInteraction.Name
                                                     };

                return GetSocialInteractionMapPetDetail.ToList();
            }
        }
    }
}
