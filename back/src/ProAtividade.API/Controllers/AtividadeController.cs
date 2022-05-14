using back.src.ProAtividade.Data.Context;
using back.src.ProAtividade.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace back.src.ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : Controller
    {
        private readonly DataContext context;
        public AtividadeController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return context.Atividades; 
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return context.Atividades.FirstOrDefault(ativ => ativ.Id == id); 
        }        

        [HttpPost]
        public Atividade Post(Atividade atividade)
        {
            context.Atividades.Add(atividade); 
            if(context.SaveChanges() > 0)
            {
                return context.Atividades.FirstOrDefault(ativ => ativ.Id == atividade.Id); 
            } 
            else 
            {
                throw new Exception("Erro ao adicionar!"); 
            }
        }

        [HttpPut("{id}")]
        public Atividade Put(int id, Atividade atividade)
        {
            if(atividade.Id != id)
            {
                throw new Exception("ID incorreto"); 
            }
            else
            {
                context.Update(atividade); 
                if(context.SaveChanges() > 0)
                {
                    return context.Atividades.FirstOrDefault(ativ => ativ.Id == id); 
                } 
                else 
                {
                    return new Atividade(); 
                }
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var atividade = context.Atividades.FirstOrDefault(ativ => ativ.Id == id); 
            if(atividade == null)
            {
                throw new Exception("Atividade não encontrada"); 
            }
            else
            {
                context.Remove(atividade); 
                return context.SaveChanges() > 0; 
            }
        }
    }
}