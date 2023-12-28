using VirtualPetCareWebAPI.Core.Utilities.Results.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;

namespace VirtualPetCareWebAPI.Business.Abstracts
{
    public interface ISocialInteractionService
    {
        IResult Add(AddSocialInteractionMapPetRequest addSocialInteractionMapPetRequest);
        IDataResult<List<GetSocialInteractionMapPetDetails>> GetDetails();
        IDataResult<List<GetSocialInteractionMapPetDetails>> GetByPetId(int petId);
    }
}
