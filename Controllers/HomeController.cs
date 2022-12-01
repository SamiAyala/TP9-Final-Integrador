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
        ViewBag.Mod = BD.usuario.Moderador;
        ViewBag.User = BD.usuario;
        ViewBag.ListBoard = BD.GetBoards();
        return View();
    }

    public IActionResult CargarBoard(int id)
    {
        ViewBag.User = BD.usuario;
        ViewBag.Board = BD.GetBoardById(id);
        ViewBag.ListPosts = BD.GetPostsByBoard(id);
        return View("Board");
    }
    public IActionResult CargarPost(int id)
    {
        ViewBag.User = BD.usuario;
        ViewBag.Post = BD.GetPostById(id);
        ViewBag.ListReplies = BD.getPostsByFkPost(id);
        return View("Post");
    }

    public void WriteFile(IFormFile File)
    {
        string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\postFiles\" + File.FileName;
        using (var stream = System.IO.File.Create(wwwRootLocal))
        {
            File.CopyTo(stream);
        }
    }

    [HttpPost]
    public IActionResult AgregarPost(Post p, IFormFile FormFile)
    {
        if (FormFile != null)
        {
            WriteFile(FormFile);
            p.Imagen = FormFile.FileName;
        }
        p.FechaCreacion = DateTime.Now;
        p.IdUsuario = BD.usuario.idUsuario;
        BD.InsertPost(p);

        if (p.FkPost != null) return RedirectToAction("CargarPost", "Home", new { id = p.FkPost });
        return RedirectToAction("CargarBoard", "Home", new { id = p.IdBoard });
    }

    public IActionResult AgregarBoard(Board b)
    {
        if (b.CantMaxPosts == -1) RedirectToAction("Index", "Home");
        BD.InsertBoard(b);
        return RedirectToAction("Index", "Home");
    }

    public string ChangeName(string name, int id) {
        User U = BD.getUserByName(name);
        if(U == null) {
            BD.ChangeUsername(name, id);
            return "Ok";
        }
        return "NameTaken";
    }

    public string Registrar(String Nombre, String Contraseña, String Contraseña2)
    {
        string str = null;
        User u = new User(0, Nombre, Contraseña, false);
        str = BD.InsertUser(u, Contraseña2);
        if (str == "Ok") BD.usuario = BD.getUserByName(Nombre);
        return str;
    }

    public string Login(String Nombre, String Contraseña)
    {
        string str = null;
        str = BD.CheckUser(Nombre, Contraseña);
        if (str == "Ok") BD.usuario = BD.getUserByName(Nombre);
        return str;
    }
    public User getUser()
    {
        return BD.usuario;
    }

    public string LogOut()
    {
        BD.usuario = BD.getUserById(1);
        return BD.usuario.Nombre;
    }

    public IActionResult Privacy()
    {
        ViewBag.User = BD.usuario;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult deletePost(int Id)
    {
        BD.DeletePostById(Id);
        return View("Index"); 
    }
}