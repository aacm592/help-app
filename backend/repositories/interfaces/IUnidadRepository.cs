using backend.data.models;

namespace backend.repositories.interfaces;

public interface IUnidadRepository
{
  Task<Unidad> Add(Unidad unidad);
  Task<bool> CodigoExists(string codigo);
  Task<Unidad?> GetByCodigoAsync(string codigo);
  Task UpdateAsync(Unidad unidad);
  Task<Unidad?> GetByIdWithMiembrosAsync(int unidadId);
  Task DeleteAsync(Unidad unidad);
}
