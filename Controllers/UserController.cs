using Microsoft.AspNetCore.Mvc;

namespace art_school.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Goku", "Vegeta", "Trunks", "Gohan", "Videl"
    };

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    // [HttpGet(Name = "GetUser")]
    // public IEnumerable<User> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new User
    //     {
    //         Id = index,
    //         Name = Names[Random.Shared.Next(Names.Length)]
    //     })
    //     .ToArray();
    // }

    [HttpGet(Name = "GetUser/{parId}")]
    public User Get(int id)
    {
        try
        {   
            return new User(){
                Id = id,
                Name = Names[id - 1]
            };
        } catch(Exception)
        {
            return new User();
        }
    }
}
