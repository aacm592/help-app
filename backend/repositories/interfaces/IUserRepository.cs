using backend.data.models;

namespace backend.repositories.interfaces;
public interface IUserRepository 
{ 
  Task<User?> GetByUsernameAsync(string username); 
  Task<User> AddAsync(User user);
  Task<User?> GetByIdAsync(int id);
}
