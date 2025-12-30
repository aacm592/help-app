using backend.data.models.especialidades;

namespace backend.repositories.interfaces;

public interface IEspecialidadRepository
{
  Task<IEnumerable<Especialidad>> GetEspecialidadesByRama(int rama);
}
