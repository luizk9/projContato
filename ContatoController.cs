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
    
    public IActionResult Editar(int id)
    {  
        ContatoModel contatoED = _contatoRepositorio.ListarPorId(id);
        return View(contatoED);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult Apagar(int id)
    {
        _contatoRepositorio.Apagar(id);
        return RedirectToAction("Index");
    }
    



// esses metodos acima sem identificador acima sao metodos gets
// agora abaixo vamos fazer os metodos post

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        
        _contatoRepositorio.Adicionar(contato);
        return RedirectToAction("Index");
        // vai injetar o repositorio atraves do construtor acima
        //agora tem que no program.cs injetar a interface
        // tem que na view chamar esse metodo..
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
        _contatoRepositorio.Atualizar(contato);
        return RedirectToAction("Index");
    }



  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
