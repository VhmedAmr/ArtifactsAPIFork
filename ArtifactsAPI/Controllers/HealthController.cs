using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ArtifactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            // This logs a highly visible message in your Back4App terminal
            _logger.LogInformation("✅ SERVER IS AWAKE: Cron job ping received at {Time}", DateTime.UtcNow);
            
            // Returns a simple 200 OK without touching the Supabase database
            return Ok(new { 
                status = "Awake", 
                message = "Heritage Digital Twin API is running.",
                time = DateTime.UtcNow 
            });
        }
    }
}
