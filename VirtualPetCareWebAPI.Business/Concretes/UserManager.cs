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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        [FluentValidationAspect(typeof(AddUserRequestValidator))]
        public IResult Add(AddUserRequest addUserRequest)
        {
            try
            {
                User user = _mapper.Map<User>(addUserRequest);
                _userDal.Add(user);

                return new SuccessResult("User added successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        [FluentValidationAspect(typeof(UpdateUserRequestValidator))]
        public IResult Update(UpdateUserRequest updateUserRequest)
        {
            try
            {
                User user = _mapper.Map<User>(updateUserRequest);
                _userDal.Update(user);

                return new SuccessResult("User updated successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int userId)
        {
            try
            {
                User user = _userDal.Get(u => u.Id == userId);
                _userDal.Delete(user);
                                    
                return new SuccessResult("User deleted successfully");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<GetUserResponse>> GetAll()
        {
            try
            {
                List<GetUserResponse> users = _mapper.Map<List<GetUserResponse>>(_userDal.GetAll());

                return new SuccessDataResult<List<GetUserResponse>>(users, "Users listed successfully");

            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetUserResponse>>(ex.Message);
            }
        }

        public IDataResult<GetUserResponse> GetUserById(int userId)
        {
            try
            {
                GetUserResponse user = _mapper.Map<GetUserResponse>(_userDal.Get(user => user.Id == userId));
                return new SuccessDataResult<GetUserResponse>(user, "User listed successfully");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<GetUserResponse>(ex.Message);
            }
        }
    }
}
