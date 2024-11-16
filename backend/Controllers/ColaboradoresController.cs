using Microsoft.AspNetCore.Mvc;
using WorkshopApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private static List<Colaborador> colaboradores = new List<Colaborador>
        {
            new Colaborador { Id = 1, Nome = "João", Email = "joao@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 2, Nome = "Maria", Email = "maria@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 3, Nome = "Pedro", Email = "pedro@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 4, Nome = "Ana", Email = "ana@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 5, Nome = "Carlos", Email = "carlos@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 6, Nome = "Fernanda", Email = "fernanda@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 7, Nome = "Lucas", Email = "lucas@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 8, Nome = "Beatriz", Email = "beatriz@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 9, Nome = "Ricardo", Email = "ricardo@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 10, Nome = "Juliana", Email = "juliana@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 11, Nome = "Gabriel", Email = "gabriel@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 12, Nome = "Camila", Email = "camila@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 13, Nome = "Vitor", Email = "vitor@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 14, Nome = "Sofia", Email = "sofia@email.com", WorkshopsParticipados = new List<string>() },
            new Colaborador { Id = 15, Nome = "Roberta", Email = "roberta@email.com", WorkshopsParticipados = new List<string>() }
        };

        private static List<string> workshops = new List<string>
        {
            "Workshop de Desenvolvimento Web",
            "Workshop de React para Iniciantes",
            "Workshop de JavaScript Moderno",
            "Workshop de APIs RESTful",
            "Workshop de Node.js Avançado"
        };

        [HttpGet]
        public IActionResult GetColaboradores()
        {
            return Ok(colaboradores);
        }

        [HttpGet("grafico")]
        public IActionResult GetGraficoColaboradores()
        {
            // Distribuição balanceada dos colaboradores entre os workshops
            var random = new Random();
            var workshopParticipants = workshops.ToDictionary(workshop => workshop, workshop => new List<Colaborador>());

            // Distribuir colaboradores para os workshops de forma balanceada
            foreach (var colaborador in colaboradores)
            {
                // Escolhe aleatoriamente o workshop em que o colaborador irá participar (apenas uma escolha por colaborador)
                var selectedWorkshop = workshops[random.Next(workshops.Count)];
                workshopParticipants[selectedWorkshop].Add(colaborador);
            }

            // Gerar dados para o gráfico
            var graficoData = workshops
                .Select(workshop => new
                {
                    NomeWorkshop = workshop,
                    QuantidadeColaboradores = workshopParticipants[workshop].Count
                })
                .OrderByDescending(c => c.QuantidadeColaboradores)
                .ToList();

            return Ok(graficoData);
        }
    }
}
