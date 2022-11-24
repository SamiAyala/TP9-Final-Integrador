using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9_Final_Integrador.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP9_Final_Integrador.Controllers;

public class HomeController : Controller
{
    private IWebHostEnvironment Environment;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
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

    public void WriteFile(IFormFile File){
        string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\postFiles\" + File.FileName;
        using(var stream = System.IO.File.Create(wwwRootLocal)){
            File.CopyTo(stream);
        }
    }

    [HttpPost]
    public IActionResult AgregarPost(Post p, IFormFile FormFile){
        if(FormFile.Length>0){
            WriteFile(FormFile);
            p.Imagen = FormFile.FileName;
        }
        p.FechaCreacion = DateTime.Now;
        p.IdUsuario = BD.usuario.idUsuario;
        BD.InsertPost(p);

        return RedirectToAction("CargarBoard", "Home", new{id = p.IdBoard});
    }
    
    public IActionResult AgregarBoard(Board b){
        if(b.CantMaxPosts==-1) RedirectToAction("Index","Home");
        BD.InsertBoard(b);
        return RedirectToAction("Index","Home");
    }

    public string Registrar(String Nombre, String Contraseña, String Contraseña2, IFormFile ImgUsuario){
        string str = null;
        if (ImgUsuario.Length>0){
            WriteFile(ImgUsuario);
        }
        User u = new User(0, Nombre, ImgUsuario.FileName, Contraseña, false);
        str = BD.InsertUser(u, Contraseña2);
        if (str == "Ok") BD.usuario = BD.getUserByName(Nombre);
        return str;
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
