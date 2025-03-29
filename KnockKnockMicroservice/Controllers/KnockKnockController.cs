using Microsoft.AspNetCore.Mvc;

namespace KnockKnockMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnockKnockController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string? _helloServiceUrl;
        private readonly ILogger<KnockKnockController> _logger;

        public KnockKnockController(HttpClient httpClient,
            IConfiguration configuration,
            ILogger<KnockKnockController> logger)
        {
            _httpClient = httpClient;
            _helloServiceUrl = configuration.GetValue<string>("HelloServiceUrl");
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Calling HelloService at URL: {HelloServiceUrl}", _helloServiceUrl);

            var response = await _httpClient.GetStringAsync($"{_helloServiceUrl}api/hello");

            return Ok($"Response from HelloService: {response}");
        }
    }
}
