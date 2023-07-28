using Microsoft.AspNetCore.Mvc;
using MoviemntacaoContaApi.Repositorio;
using RestSharp;

namespace MoviemntacaoContaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoContaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MovimentacaoContaController> _logger;


        public MovimentacaoContaController(ILogger<MovimentacaoContaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("SalvarMoviementacao")]
        public IActionResult Get(string requisicao, string idcontacorrente, double valor, char tipomovimento)
        {

            string UrlApi = $"https://localhost:7140/Movimentacao?requisicao={requisicao}&idcontacorrente={idcontacorrente}&valor={valor}&tipomovimento={tipomovimento}";
            var client = new RestClient(UrlApi);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest(response.Content);
            }
        }
        [HttpGet("ObterSaldo")]
        public IActionResult Get(string idcontacorrente)
        {
            string UrlApi = $"https://localhost:7140/Movimentacao/ObterSaldo?idcontacorrente={idcontacorrente}";
            var client = new RestClient(UrlApi);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest(response.Content);
            }

        }
    }
}