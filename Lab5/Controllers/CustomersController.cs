using System.Security.Claims;
using System.Text.Json;
using Lab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Lab5.Controllers;
[Authorize]
public class CustomersController: Controller
{
    private readonly HttpClient _client = new HttpClient();
    
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery]string name)
    {
        var customers = await GetCustomers(User);
        Console.WriteLine(name);
        if (!string.IsNullOrEmpty(name))
        {
            customers = customers
                .Where(b => name.Split(",")
                    .Select(query => query.Trim())
                    .FirstOrDefault(n => b.CustomerName.ToLower().StartsWith(n.ToLower()) ||
                                         b.CustomerName.ToLower().EndsWith(n.ToLower())) != null)
                .ToList();
        }
        
        ViewData["SearchQueryName"] = name;
        return View(customers);
    }
    [HttpGet("{controller}/{action}/{id}")]
    public async Task<IActionResult> Details([FromRoute] string id)
    {
        var customers = await GetCustomers(User);
        
        return View(customers.FirstOrDefault(c => c.CustomerId.ToString().Equals(id)));
    }

    private async Task<List<Customer>> GetCustomers(ClaimsPrincipal user)
    {
        var token = user.Claims.FirstOrDefault(claim => claim.Type == "IdToken").Value;
        var request = new HttpRequestMessage(HttpMethod.Get, Config.BaseApiUrl + "/api/customers");
        
        request.Headers.Add("Authorization", "Bearer " + token);
        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.StatusCode);
            return new List<Customer>();
        }
        var result = JsonSerializer.Deserialize<List<Customer>>(json);
        return result;
    }
}