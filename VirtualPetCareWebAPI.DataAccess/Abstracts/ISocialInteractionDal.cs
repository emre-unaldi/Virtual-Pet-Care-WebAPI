using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;

namespace VirtualPetCareWebAPI.DataAccess.Abstracts
{
    public interface ISocialInteractionDal : IEntityRepository<PetMapSocialInteractions>
    {
        List<GetSocialInteractionMapPetDetails> GetDetail();
        List<GetSocialInteractionMapPetDetails> GetByPetId(int petId);
    }
}
