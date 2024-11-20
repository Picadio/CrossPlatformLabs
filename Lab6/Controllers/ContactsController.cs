using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class ContactsController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("contacts")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.Contacts
            .Include(c => c.ContactType));
    }
    [HttpGet]
    [Route("contacts/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.Contacts
            .Include(c => c.ContactType)
            .FirstOrDefault(a => a.ContactId.ToString().Equals(id.ToLower()));
        
        return Ok(entity);
    }
}