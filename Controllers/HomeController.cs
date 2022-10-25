using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9_Final_Integrador.Models;

namespace TP9_Final_Integrador.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListBoard=BD.GetBoards();
        return View();
    }

    public IActionResult CargarBoard(int id)
    {
        ViewBag.Board=BD.GetBoardById(id);
        ViewBag.ListPosts=BD.GetPostsByBoard(id);
        return View("Board");
    }
    public IActionResult CargarPost(int id)
    {
        ViewBag.Post=BD.GetPostById(id);
        ViewBag.ListReplies=BD.getPostsByFkPost(id);
        return View("Post");
    }

    public IActionResult AgregarPost(Post p){
        p.FechaCreacion = DateTime.Now;
        BD.InsertPost(p);
        return RedirectToAction("CargarBoard", "Home", new{id = p.IdBoard});
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
