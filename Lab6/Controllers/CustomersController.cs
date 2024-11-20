using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class CustomersController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("customers")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.Customers);
    }
    [HttpGet]
    [Route("customers/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.Customers
            .FirstOrDefault(a => a.CustomerId.ToString().Equals(id.ToLower()));
        return Ok(entity);
    }
}