using Entities = Domain.Entities;

namespace Application.Ports.Infrastructure
{
    public interface IGuestRepository
    {
        Task<Entities.Guest> Get(int Id);
        Task<int> Create(Entities.Guest guest);
    }
}
