using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projContato.Data;
using projContato.Models;

namespace projContato.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        
        //construtor que vai ser injetado o contexto
        public ContatoRepositorio(BancoContext bancoContext )
        { // que vai ser acessado atraves da variavel acima, pois ela só
        // dentro do metodo
            _bancoContext = bancoContext;
        }


         public List<ContatoModel> BuscarTodos()
         {
            return _bancoContext.Contatos.ToList();
                // agora vai na index
         }   

        public ContatoModel Adicionar(ContatoModel contato)
        {          
            // gravar no banco de dados que vem do contexto
            // vindo do contexto injetado no construtor 

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;

        }
    }
}