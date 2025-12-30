using backend.data.models.especialidades;

namespace backend.repositories.interfaces;

public interface IRequisitoEspRepository
{
  Task<IEnumerable<RequisitoEspUser>> GetRequisitosByUser(int userId);
  Task<IEnumerable<RequisitoEsp>> GetRequisitosByEspecialidad(int especialidadId);
  Task<RequisitoEspUser> Add(RequisitoEspUser requisitoEspUser);
  Task<RequisitoEsp?> GetRequisito(int id);
}
