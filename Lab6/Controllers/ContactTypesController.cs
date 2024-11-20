using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class ContactTypesController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("contacttypes")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.RefContactTypes);
    }
    [HttpGet]
    [Route("contacttypes/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.RefContactTypes
            .FirstOrDefault(a => a.ContactTypeCode.ToString().Equals(id.ToLower()));
        return Ok(entity);
    }
}