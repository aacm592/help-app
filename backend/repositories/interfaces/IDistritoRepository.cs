using backend.data.models;

namespace backend.repositories.interfaces;

public interface IDistritoRepository
{
  Task<IEnumerable<Distrito>> GetAll();
}
