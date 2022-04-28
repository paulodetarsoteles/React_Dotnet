using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back.src.ProAtividade.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.src.ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : Controller
    {
        public IEnumerable<Atividade> Atividades = new List<Atividade>() 
        { 
            new Atividade(1), 
            new Atividade(2), 
            new Atividade(3) 
        }; 

        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return Atividades; 
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return Atividades.FirstOrDefault(ativ => ativ.Id == id) ; 
        }        

        [HttpPost]
        public Atividade Post(Atividade atividade)
        {
            return atividade; 
        }

        [HttpPut]
        public Atividade Put(int id, Atividade atividade)
        {
            atividade.Id = atividade.Id +1; 
            return atividade; 
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Primeiro Delete"; 
        }
    }
}