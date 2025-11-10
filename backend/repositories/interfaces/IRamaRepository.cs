using backend.data.models;

namespace backend.repositories.interfaces;

public interface IRamaRepository
{
  Task<IEnumerable<Rama>> GetAll();
}
