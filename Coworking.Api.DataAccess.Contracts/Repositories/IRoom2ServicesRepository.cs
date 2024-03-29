﻿using Coworking.Api.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Api.DataAccess.Contracts.Repositories
{
    public interface IRoom2ServicesRepository : IRepository<Room2ServicesEntity>
    {
        Task<Room2ServicesEntity> Update(Room2ServicesEntity entity);
    }
}
