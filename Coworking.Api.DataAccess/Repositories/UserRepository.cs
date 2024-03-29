﻿using Coworking.Api.DataAccess.Contracts;
using Coworking.Api.DataAccess.Contracts.Entities;
using Coworking.Api.DataAccess.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ICoworkingDBContext _coworkingDBContext;

        public UserRepository(ICoworkingDBContext coworkingDBContext)
        {
            _coworkingDBContext = coworkingDBContext;
        }

        public async Task<UserEntity> Add(UserEntity entity)
        {
            await _coworkingDBContext.Users.AddAsync(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UserEntity> Update(UserEntity entity)
        {
            var updateEntity = _coworkingDBContext.Users.Update(entity);         

            await _coworkingDBContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<UserEntity> Update(int idEntity, UserEntity updateEnt)
        {
            var entity = await Get(idEntity);

            entity.Name = updateEnt.Name;

            _coworkingDBContext.Users.Update(entity);

            await _coworkingDBContext.SaveChangesAsync();

            return entity;
        }

        public async Task<UserEntity> Get(int idEntity)
        {
            var result = await _coworkingDBContext.Users
                .Include(x => x.Name).FirstOrDefaultAsync(x => x.Id == idEntity);

            return result;
        }

        public Task<bool> Exist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _coworkingDBContext.Users.SingleAsync(x => x.Id == id);

            _coworkingDBContext.Users.Remove(entity);

            await _coworkingDBContext.SaveChangesAsync();
        }
    }
}
