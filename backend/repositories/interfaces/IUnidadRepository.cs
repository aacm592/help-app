using backend.data.models;

namespace backend.repositories.interfaces;

public interface IUnidadRepository
{
  Task<Unidad> Add(Unidad unidad);
  Task<Unidad?> GetByCodigo(string codigo);
  Task<bool> CodigoExists(string codigo);  
}
