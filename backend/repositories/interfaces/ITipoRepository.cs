using backend.data.models;

namespace backend.repositories.interfaces;

public interface ITipoRepository
{
  Task<Tipo?> GetByNameAsync(string nombre);
}
