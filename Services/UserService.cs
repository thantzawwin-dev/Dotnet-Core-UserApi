using UserApi.Models;
using UserApi.Interfaces;
// using Microsoft.Extensions.Caching.Memory;

namespace UserApi.Services;

public class UserService : IUserService
{
  static List<User>? _userList {get;}

  private const string V = "Id";
  static long _nextId = 3;

  static UserService()
  {
    _userList = new List<User>() {
      new User { Id = 1, FullName = "John", Email = "john001@gmail.com", Phone = "+959123456789", Age = 35 },
      new User { Id = 2, FullName = "Rose", Email = "rose002@gmail.com", Phone = null, Age = null }
    };
  }

  public List<User>? GetAll(string orderBy) 
  {
    orderBy = orderBy is not null ? orderBy.ToLower() : "";
    switch(orderBy)
    {
      case "fullname": return _userList.OrderBy(u => u.FullName).ToList();
      case "email": return _userList.OrderBy(u => u.Email).ToList();
      case "phone": return _userList.OrderBy(u => u.Phone).ToList();
      case "age": return _userList.OrderBy(u => u.Age).ToList();
      default: return _userList.OrderBy(u => u.Id).ToList();
    }
  }

  public User? Get(long id) => _userList.FirstOrDefault(u => u.Id == id);

  public long Create(User user) {
    user.Id = _nextId++;
    _userList.Add(user);
    return user.Id;
  }

  public bool Update(User user) {
    var index = _userList.FindIndex(u => u.Id == user.Id);
    if(index == -1)
      return false;
    _userList[index] = user;
    return true;
  }

  public bool Delete(long id) {
    var user = Get(id);
    if(user is null)
      return false;
    _userList.Remove(user);
    return true;
  }

}