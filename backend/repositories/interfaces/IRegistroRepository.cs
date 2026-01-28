using backend.data.models.registros;

namespace backend.repositories.interfaces;

public interface IRegistroRepository
{
  Task<Registro> Create(Registro registro);
  Task Update();
  Task<Registro?> GetRegistroByUserId(int userId, int gestionId);
  Task Delete(Registro registro);
}
