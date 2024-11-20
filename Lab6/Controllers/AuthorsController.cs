using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class AuthorsController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("authors")]
    public IActionResult Books()
    {
        return Ok(applicationDbContext.Authors);
    }
    
    [HttpGet]
    [Route("authors/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var author = applicationDbContext.Authors
            .FirstOrDefault(a => a.AuthorId.ToString().Equals(id.ToLower()));
        return Ok(author);
    }
}