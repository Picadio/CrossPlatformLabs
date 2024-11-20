using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;
[Route("api")]
[Authorize]
public class BooksController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("books")]
    public IActionResult Books()
    {
        return Ok(applicationDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.BookCategory));
    }
    [HttpGet]
    [Route("books/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.Books
            .Include(b => b.Author)
            .Include(b => b.BookCategory)
            .FirstOrDefault(a => a.BookId.ToString().Equals(id.ToLower()));
        return Ok(entity);
    }
}