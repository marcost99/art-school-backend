using Microsoft.AspNetCore.Mvc;

namespace art_school.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Dragon Ball Z", "YuYu Hakusho", "Street Fighter 2", "Gunbuster", "Crying Freeman"
    };

    private static readonly string?[] Files = new[]
    {
        "https://img.odcdn.com.br/wp-content/uploads/2022/07/Dragon-Ball-Z.webp", "https://kanto.legiaodosherois.com.br/w760-h398-cfill/wp-content/uploads/2020/07/legiao_g3b9Ok8yNfdo.jpg.webp", null, "https://m.media-amazon.com/images/M/MV5BNDIxOTI2YWEtMjljYy00NjkwLTlkNTYtOGY4NjdiNWM2NzRkXkEyXkFqcGdeQXVyMTUwNjU3NzU1._V1_.jpg", null
    };

    private readonly ILogger<ActivityController> _logger;

    public ActivityController(ILogger<ActivityController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetActivity/{parIdUser}")]
    public IEnumerable<Activity> Get(int idUser)
    {
        return Enumerable.Range(0, 5).Select(index => new Activity
        {
            Id = index + 1,
            Name = Names[index],
            Status = Files[index] == null ? "Em progresso" : "Enviado",
            File = Files[index]
        })
        .ToArray();
    }

}
