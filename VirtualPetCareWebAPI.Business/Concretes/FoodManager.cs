using AutoMapper;
using VirtualPetCareWebAPI.Core.Aspects.Autofac.Validation;
using VirtualPetCareWebAPI.Core.Utilities.Results.Abstracts;
using VirtualPetCareWebAPI.Core.Utilities.Results.Concretes;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;
using VirtualPetCareWebAPI.Entity.Concretes.Responses;
using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Business.ValidationRules.FluentValidation;

namespace VirtualPetCareWebAPI.Business.Concretes
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;
        private readonly IMapper _mapper;

        public FoodManager(IFoodDal foodDal, IMapper mapper)
        {
            _foodDal = foodDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(UpdateFoodRequestValidator))]
        public IResult Add(AddFoodRequest addFoodRequest)
        {
            try
            {
                Food food = _mapper.Map<Food>(addFoodRequest);
                _foodDal.Add(food);

                return new SuccessResult("Food added successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [FluentValidationAspect(typeof(UpdateFoodRequestValidator))]
        public IResult Update(UpdateFoodRequest updateFoodRequest)
        {
            try
            {
                Food food = _mapper.Map<Food>(updateFoodRequest);
                _foodDal.Update(food);

                return new SuccessResult("Food updated successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int foodId)
        {
            try
            {
                Food food = _foodDal.Get(food => food.Id == foodId);
                _foodDal.Delete(food);

                return new SuccessResult("Food deleted successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<GetFoodResponse>> GetAll()
        {
            try
            {
                List<GetFoodResponse> foods = _mapper.Map<List<GetFoodResponse>>(_foodDal.GetAll());

                return new SuccessDataResult<List<GetFoodResponse>>(foods, "Foods listed successfully");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetFoodResponse>>(ex.Message);
            }
        }

        public IDataResult<GetFoodResponse> GetFoodById(int foodId)
        {
            try
            {
                GetFoodResponse food = _mapper.Map<GetFoodResponse>(_foodDal.Get(food => food.Id == foodId));
                
                return new SuccessDataResult<GetFoodResponse>(food, "Food listed successfully");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetFoodResponse>(ex.Message);
            }
        }
    }
}
