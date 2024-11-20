using System.Security.Claims;
using System.Text.Json;
using Lab5.Data;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

public class BooksController: Controller
{
    private readonly HttpClient _client = new HttpClient();
    
    [HttpGet()]
    public async Task<IActionResult> Index([FromQuery]string date, [FromQuery]string name)
    {
        var books = await GetBooks(User);
        if (!string.IsNullOrEmpty(date))
        {
            books = books.Where(b => b.DateOfPublication.Equals(DateTime.Parse(date)))
                .ToList();
        }
        if (!string.IsNullOrEmpty(name))
        {
            books = books
                .Where(b => name.Split(",")
                    .Select(query => query.Trim())
                    .FirstOrDefault(n => b.BookTitle.ToLower().StartsWith(n.ToLower()) ||
                                            b.BookTitle.ToLower().EndsWith(n.ToLower())) != null)
                .ToList();
        }
        
        ViewData["SearchQueryDate"] = date;
        ViewData["SearchQueryName"] = name;
        return View(books);
    }
    [HttpGet("{controller}/{action}/{id}")]
    public async Task<IActionResult> Details([FromRoute] string id)
    {
        var books = await GetBooks(User);
        
        return View(books.FirstOrDefault(c => c.BookId.ToString().Equals(id)));
    }
    private async Task<List<Book>> GetBooks(ClaimsPrincipal user)
    {
        var token = user.Claims.FirstOrDefault(claim => claim.Type == "IdToken").Value;
        var request = new HttpRequestMessage(HttpMethod.Get, Config.BaseApiUrl + "/api/books");
        
        request.Headers.Add("Authorization", "Bearer " + token);
        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.StatusCode);
            return new List<Book>();
        }
        var result = JsonSerializer.Deserialize<List<Book>>(json);
        return result;
    }
}