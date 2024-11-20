using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Controllers;

[Route("api")]
[Authorize]
public class OrderItemsController(ApplicationDbContext applicationDbContext): Controller
{
    [HttpGet]
    [Route("orderitems")]
    public IActionResult Get()
    {
        return Ok(applicationDbContext.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Book));
    }
    [HttpGet]
    [Route("orderitems/{id}")]
    public IActionResult GetById([FromQuery]string id)
    {
        var entity = applicationDbContext.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Book)
            .FirstOrDefault(a => a.ItemNumber.ToString().Equals(id.ToLower()));
        return Ok(entity);
    }
}