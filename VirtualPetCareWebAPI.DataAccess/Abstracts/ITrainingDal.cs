using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareWebAPI.Entity.Concretes.Entities;

namespace VirtualPetCareWebAPI.DataAccess.Abstracts
{
    public interface ITrainingDal : IEntityRepository<Training>
    {
    }
}
