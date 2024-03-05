using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using testeCSharpMVC.Models;

namespace testeCSharpMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<ItemModel> ListItens = new List<ItemModel>
    {
        new ItemModel { Id = 1, Name = "Item 1", Description = "Description 1", Date = DateTime.Parse("2024-03-05") },
        new ItemModel { Id = 2, Name = "Item 2", Description = "Description 2", Date = DateTime.Parse("2024-03-06") },
        new ItemModel { Id = 3, Name = "Item 3", Description = "Description 3", Date = DateTime.Parse("2024-03-07") },
    };
    
    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    
    

    public IActionResult Index(string filterOption)
    {
        ViewBag.SelectedFilter = filterOption;
        
        var filteredData = GetDataBasedOnFilter(filterOption);

        return View(filteredData);
    }
    
    
    private object GetDataBasedOnFilter(string filterOption)
    {
        if (!string.IsNullOrEmpty(filterOption))
        {
            return ListItens.FindAll(item => item.Name.Contains(filterOption));
        }

        return ListItens;
    }
}