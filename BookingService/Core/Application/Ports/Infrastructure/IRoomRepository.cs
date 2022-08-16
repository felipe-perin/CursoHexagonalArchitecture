﻿using Entities = Domain.Entities;

namespace Application.Ports.Infrastructure
{
    public interface IRoomRepository
    {
        Task<Entities.Room> Get(int Id);
        Task<int> Create(Entities.Room room);
        Task<Entities.Room> GetAggregate(int Id);
    }
}
