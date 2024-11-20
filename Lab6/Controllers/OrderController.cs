using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class OrderController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("orders")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.Orders
            .Include(o => o.Customer));
    }
    [HttpGet]
    [Route("orders/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.Orders
            .Include(o => o.Customer)
            .FirstOrDefault(a => a.OrderId.ToString().Equals(id.ToLower()));
        return Ok(entity);
    }
}