using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projContato.Models;

namespace projContato.Controllers;

public class ContatoController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Criar()
    {
        return View();
    }
    
    public IActionResult Editar()
    {
        return View();
    }

    public IActionResult ApagarConfirmacao()
    {
        return View();
    }





  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
