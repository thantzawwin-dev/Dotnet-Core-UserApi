using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Services;
using UserApi.Interfaces;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    // GET: api/User/
    [HttpGet]
    public ActionResult<List<User>> GetUser()
    {
        return _userService.GetAll();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(long id)
    {
        var user = _userService.Get(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    public IActionResult PutUser(long id, User request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        bool isSuccess = _userService.Update(request);

        if(!isSuccess)
            return NotFound();

        return CreatedAtAction("GetUser", new { id = request.Id }, request);
    }

    // POST: api/User
    [HttpPost]
    public ActionResult<User> PostUser(User request)
    {
        request.Id = _userService.Create(request);

        return CreatedAtAction("GetUser", new { id = request.Id }, request);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(long id)
    {
        bool isSuccess = _userService.Delete(id);

        if(!isSuccess)
            return NotFound();

        return Ok();
    }

    private bool UserExists(long id)
    {
        return _userService.Get(id) != null ? true : false;
    }
    
}
