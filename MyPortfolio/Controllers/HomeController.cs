using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DatabaseContext;
using MyPortfolio.Entities;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers;

[Route("")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDatabaseContext _myDatabaseContext;

    public HomeController(ILogger<HomeController> logger,
        MyDatabaseContext myDatabaseContext)
    {
        _logger = logger;
        _myDatabaseContext = myDatabaseContext;
    }

    [HttpGet("", Name="Home-index")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("About", Name = "Home-About")]
    public async Task<IActionResult> About()
    {
        AboutViewModel aboutViewModel = new AboutViewModel();
        AboutEntity aboutEntity = await _myDatabaseContext.Abouts.FirstOrDefaultAsync();
        if (aboutEntity != null)
        {
            aboutViewModel = new AboutViewModel
            {
                Description = aboutEntity.Description,
                FacebookLink = aboutEntity.FacebookLink,
                ImageUrl = aboutEntity.ImageUrl,
                InstagramLink = aboutEntity.InstagramLink,
                Name = aboutEntity.Name,
                Title = aboutEntity.Title,
                TwitterLink = aboutEntity.TwitterLink,
            };
        }
        else
        {
            aboutViewModel = new AboutViewModel
            {
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                FacebookLink = "https://facebook.com",
                ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pexels.com%2Fsearch%2Fbeautiful%2F&psig=AOvVaw333I0UJRRkjqXitn8llKwR&ust=1680859650080000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCLDwz6T4lP4CFQAAAAAdAAAAABAE",
                InstagramLink = "https://google.com",
                Name = "Your name",
                Title = "Your Title",
                TwitterLink = "https://google.com",
            };
        }
        return View(aboutViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

