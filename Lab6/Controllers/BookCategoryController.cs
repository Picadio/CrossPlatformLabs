using Lab6.Data;
using Lab6.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class BookCategoryController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("bookcategories")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.BookCategories);
    }
    [HttpGet]
    [Route("bookcategories/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var bc = applicationDbContext.BookCategories
            .FirstOrDefault(a => a.BookCategoryCode.ToString().Equals(id.ToLower()));
        return Ok(bc);
    }
}