using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IOffices2RoomsRepository : IRepository<Offices2RoomsEntity>
    {
        Task<Offices2RoomsEntity> Update(Offices2RoomsEntity entity);
    }
}
