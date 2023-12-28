using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;

namespace VirtualPetCareWebAPI.DataAccess.Concretes.EntityFramework
{
    public class EfTrainingDal : EfEntityRepositoryBase<Training, PetCareDbContext>, ITrainingDal
    {
    }
}