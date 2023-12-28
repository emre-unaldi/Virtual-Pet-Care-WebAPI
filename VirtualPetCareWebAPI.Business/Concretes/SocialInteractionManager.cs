using AutoMapper;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Core.Utilities.Results.Abstracts;
using VirtualPetCareWebAPI.Core.Utilities.Results.Concretes;
using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;

namespace VirtualPetCareWebAPI.Business.Concretes
{
    public class SocialInteractionManager : ISocialInteractionService
    {
        private readonly ISocialInteractionDal _socialInteractionDal;
        private readonly IMapper _mapper;

        public SocialInteractionManager(ISocialInteractionDal socialInteractionDal, IMapper mapper)
        {
            _socialInteractionDal = socialInteractionDal;
            _mapper = mapper;
        }

        public IResult Add(AddSocialInteractionMapPetRequest addSocialInteractionMapPetRequest)
        {
            PetMapSocialInteractions socialInteractionMapPet = _mapper.Map<PetMapSocialInteractions>(addSocialInteractionMapPetRequest);
            _socialInteractionDal.Add(socialInteractionMapPet);
            return new SuccessResult("Success");
        }

        public IDataResult<List<GetSocialInteractionMapPetDetails>> GetByPetId(int petId)
        {
            try
            {
                return new SuccessDataResult<List<GetSocialInteractionMapPetDetails>>(_socialInteractionDal.GetByPetId(petId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetSocialInteractionMapPetDetails>>(ex.Message);
            }
        }

        public IDataResult<List<GetSocialInteractionMapPetDetails>> GetDetails()
        {
            try
            {
                return new SuccessDataResult<List<GetSocialInteractionMapPetDetails>>(
                    _socialInteractionDal.GetDetail(), "Social Interaction Map Pet listed succesfly");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetSocialInteractionMapPetDetails>>(ex.Message);
            }
        }
    }
}
