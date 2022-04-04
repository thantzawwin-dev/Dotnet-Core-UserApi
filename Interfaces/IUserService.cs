using UserApi.Models;

namespace UserApi.Interfaces;

public interface IUserService
{
  List<User>? GetAll();

  User? Get(long id);

  long Create(User user);

  bool Update(User user);

  bool Delete(long id);

}