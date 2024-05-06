using Microsoft.AspNetCore.Mvc;

namespace art_school.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private readonly ILogger<FileController> _logger;

    public FileController(ILogger<FileController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostFile")]
    public Response Post([FromForm] File file)
    {
        try
        {   
            string path = @"C:\Repos\art-school\Files\" + file.IdActivity.ToString();
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string pathFile = Path.Combine(path, file.FileName);

            using(Stream stream = new FileStream(pathFile, FileMode.Create))
            {
                file.FileData?.CopyTo(stream);
            }
            
            return new Response(){
                Resultado = true,
                Mensagem = "Imagem salva com sucesso :)",
                Payload = file
            };
        } catch(Exception ex)
        {
            return new Response(){
                Resultado = false,
                Mensagem = ex.Message,
                Payload = file
            };
        }
    }
}
