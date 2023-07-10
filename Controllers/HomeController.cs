using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using goblin_cheese.Models;

namespace goblin_cheese.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string patchPath = "\\patchnotes.txt";
        string basePath = Directory.GetCurrentDirectory();
        string[] patchnotes;
        try 
        {
            patchnotes = System.IO.File.ReadAllLines(basePath+patchPath);
            Console.WriteLine(String.Join(Environment.NewLine, patchnotes));
        }
        catch (FileNotFoundException e)
        {
            patchnotes = new string[] {"Patch notes file could not be found"};
            Console.WriteLine(e.Message);
        }
        ViewBag.PatchNotes = patchnotes;
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
