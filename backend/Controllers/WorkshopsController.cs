using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private static List<string> colaboradores = new List<string>
        {
            "João", "Maria", "Pedro", "Ana", "Carlos", 
            "Fernanda", "Lucas", "Beatriz", "Ricardo", 
            "Juliana", "Gabriel", "Camila", "Vitor", 
            "Sofia", "Roberta"
        };

        private static List<Workshop> workshops = new List<Workshop>
        {
            new Workshop { Id = 1, Nome = "Workshop de Desenvolvimento Web", DataRealizacao = "2024-10-10", Descricao = "Fundamentos do desenvolvimento web", Participantes = new List<string>() },
            new Workshop { Id = 2, Nome = "Workshop de React para Iniciantes", DataRealizacao = "2024-11-05", Descricao = "Aprenda os conceitos fundamentais do React", Participantes = new List<string>() },
            new Workshop { Id = 3, Nome = "Workshop de JavaScript Moderno", DataRealizacao = "2024-10-12", Descricao = "Explorando os recursos modernos do JavaScript", Participantes = new List<string>() },
            new Workshop { Id = 4, Nome = "Workshop de APIs RESTful", DataRealizacao = "2024-11-10", Descricao = "Como criar e consumir APIs RESTful", Participantes = new List<string>() },
            new Workshop { Id = 5, Nome = "Workshop de Node.js Avançado", DataRealizacao = "2024-10-15", Descricao = "Técnicas avançadas para construção de APIs com Node.js", Participantes = new List<string>() }
        };

        
        private static bool distribuido = false;

        public WorkshopsController()
        {
            
            if (!distribuido)
            {
                DistribuirColaboradores();
                distribuido = true;
            }
        }

        private void DistribuirColaboradores()
        {
            var random = new Random();
            var colaboradoresNaoDistribuidos = new List<string>(colaboradores);

            
            while (colaboradoresNaoDistribuidos.Any())
            {
                foreach (var workshop in workshops)
                {
                    if (!colaboradoresNaoDistribuidos.Any())
                        break;

                    
                    var colaborador = colaboradoresNaoDistribuidos[random.Next(colaboradoresNaoDistribuidos.Count)];
                    workshop.Participantes.Add(colaborador);
                    colaboradoresNaoDistribuidos.Remove(colaborador);
                }
            }

           
            foreach (var colaborador in colaboradores)
            {
                var workshop = workshops[random.Next(workshops.Count)];
                if (!workshop.Participantes.Contains(colaborador))
                {
                    workshop.Participantes.Add(colaborador);
                }
            }
        }

        [HttpGet]
        public IActionResult GetWorkshops()
        {
            return Ok(workshops);
        }

       
        [HttpGet("colaboradores-por-workshop")]
        public IActionResult GetColaboradoresPorWorkshop()
        {
            var colaboradoresPorWorkshop = workshops.Select(w => new
            {
                Workshop = w.Nome,
                QuantidadeParticipantes = w.Participantes.Count
            });

            return Ok(colaboradoresPorWorkshop);
        }
    }
}
