using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projContato.Models;
using projContato.Repositorio;

namespace projContato.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;
    //ctor já cria o construtor
    // esse construtor servirar para injetar os repositorios
    public ContatoController(IContatoRepositorio contatoRepositorio)
    { // acessar o contatoRepositorio atraves da variavel de fora acima
        _contatoRepositorio = contatoRepositorio;    
    }

    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
        return View(contatos);
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

// esses metodos acima sem identificador acima sao metodos gets
// agora abaixo vamos fazer os metodos post

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        // vai injetar o repositorio atraves do construtor acima
        _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");
        //agora tem que no program.cs injetar a interface
        // tem que na view chamar esse metodo..
    }



  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
