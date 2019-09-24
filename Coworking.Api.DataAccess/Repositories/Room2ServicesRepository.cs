using Coworking.Api.DataAccess.Contracts;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Repositories
{
    public class Room2ServicesRepository : IRoom2ServicesRepository
    {
        private readonly ICoworkingDBContext _coworkingDBContext;

        public Room2ServicesRepository(ICoworkingDBContext coworkingDBContext)
        {
            _coworkingDBContext = coworkingDBContext;
        }

        public async Task<Room2ServicesEntity> Add(Room2ServicesEntity entity)
        {
            await _coworkingDBContext.Room2Services.AddAsync(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Room2ServicesEntity> Update(Room2ServicesEntity entity)
        {
            var updateEntity = _coworkingDBContext.Room2Services.Update(entity);         

            await _coworkingDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Room2ServicesEntity> Update(int idEntity, Room2ServicesEntity updateEnt)
        {
            var entity = await Get(idEntity);

            entity.IdService = updateEnt.IdService;

            _coworkingDBContext.Room2Services.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Room2ServicesEntity> Get(int idEntity)
        {
            var result = await _coworkingDBContext.Room2Services
                .Include(x => x.IdService).FirstOrDefaultAsync(x => x.IdService == idEntity);

            return result;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room2ServicesEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDBContext.Room2Services.SingleAsync(x => x.IdService == id);

            _coworkingDBContext.Room2Services.Remove(entity);

            await _coworkingDBContext.SaveChangesAsync();
        }
    }
}
