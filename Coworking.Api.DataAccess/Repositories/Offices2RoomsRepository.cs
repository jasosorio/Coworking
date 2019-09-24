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
    public class Offices2RoomsRepository : IOffices2RoomsRepository
    {
        private readonly ICoworkingDBContext _coworkingDBContext;

        public Offices2RoomsRepository(ICoworkingDBContext coworkingDBContext)
        {
            _coworkingDBContext = coworkingDBContext;
        }

        public async Task<Offices2RoomsEntity> Add(Offices2RoomsEntity entity)
        {
            await _coworkingDBContext.Offices2Rooms.AddAsync(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Offices2RoomsEntity> Update(Offices2RoomsEntity entity)
        {
            var updateEntity = _coworkingDBContext.Offices2Rooms.Update(entity);         

            await _coworkingDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Offices2RoomsEntity> Update(int idEntity, Offices2RoomsEntity updateEnt)
        {
            var entity = await Get(idEntity);

            entity.RoomId = updateEnt.RoomId;

            _coworkingDBContext.Offices2Rooms.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Offices2RoomsEntity> Get(int idEntity)
        {
            var result = await _coworkingDBContext.Offices2Rooms
                .Include(x => x.RoomId).FirstOrDefaultAsync(x => x.RoomId == idEntity);

            return result;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Offices2RoomsEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDBContext.Offices2Rooms.SingleAsync(x => x.RoomId == id);

            _coworkingDBContext.Offices2Rooms.Remove(entity);

            await _coworkingDBContext.SaveChangesAsync();
        }
    }
}
